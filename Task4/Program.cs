using System;
using System.Threading;

class ThreadWorker
{
    private int _threadNumber;

    public ThreadWorker(int threadNumber)
    {
        _threadNumber = threadNumber;
    }

    // Method executed by the thread
    public void PrintThreadName()
    {
        // Name the thread with its number
        Thread.CurrentThread.Name = "Thread " + _threadNumber;
        Console.WriteLine($"Executing: {Thread.CurrentThread.Name}");
    }
}

class MainThreadProgram
{
    public static void Main(string[] args)
    {
        // Print the name of the thread running the Main() method
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        Console.WriteLine($"Executing: {mainThread.Name}");

        // Create and start 10 threads
        for (int i = 1; i <= 10; i++)
        {
            ThreadWorker worker = new ThreadWorker(i);
            Thread thread = new Thread(new ThreadStart(worker.PrintThreadName));
            thread.Start();
            thread.Join(); // Ensures each thread finishes execution before starting the next
        }
    }
}
