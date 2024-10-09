using System;
using System.Threading;

class TaskQueueManager
{
    public void EnqueueTasks(int numberOfTasks, Action<int> taskAction)
    {
        for (int i = 1; i <= numberOfTasks; i++)
        {
            int taskId = i;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Task-{taskId} starts on Thread ID: {threadId}");
                taskAction(taskId);
                Console.WriteLine($"Task-{taskId} ends on Thread ID: {threadId}");
            });
        }
    }

    public void RetrieveThreadPoolInfo()
    {
        ThreadPool.GetMaxThreads(out int maxThreads, out int maxIOTasks);
        ThreadPool.GetAvailableThreads(out int availableThreads, out int availableIOTasks);

        Console.WriteLine($"Max Worker Threads: {maxThreads}, Available Worker Threads: {availableThreads}");
        Console.WriteLine($"Max IO Threads: {maxIOTasks}, Available IO Threads: {availableIOTasks}");
    }
}

class TaskObserver
{
    static void Main()
    {
        var queueManager = new TaskQueueManager();

        // Function to pass as task to be performed
        Action<int> customTask = (taskId) =>
        {
            Console.WriteLine($"Performing custom task logic for Task-{taskId}");
            Thread.Sleep(800 + (taskId * 100)); // Simulated task work
        };

        queueManager.RetrieveThreadPoolInfo();

        Console.WriteLine("\nSubmitting tasks to thread pool...");
        queueManager.EnqueueTasks(7, customTask);  // Queue 7 tasks and pass the custom task function

        Thread.Sleep(5000); // Allow time for task completion

        Console.WriteLine("\nRechecking thread pool status...");
        queueManager.RetrieveThreadPoolInfo();

        Console.WriteLine("\nExecution completed.");
    }
}