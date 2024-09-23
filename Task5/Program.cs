// Write a C# program that prints out the name of a fruit at timed intervals. For this create
//     and start 3 threads. The run() method for the Fruit class has a loop that repeats 10 times.
//     The sleep() method causes the thread to sleep for the number of seconds specified when
// the thread is created. Once the thread is done sleeping, it should output a time value, the
// name of the fruit specified when the thread was created, and the current loop number.
//     After 10 iterations the thread terminates.

using System;
using System.Threading;

class Fruit
{
    private string _fruitName;
    private int _sleepSeconds;

    public Fruit(string fruitName, int sleepSeconds)
    {
        _fruitName = fruitName;
        _sleepSeconds = sleepSeconds;
    }

    // The method to be executed by the thread
    public void Run()
    {
        for (int i = 1; i <= 10; i++)
        {
            try
            {
                Thread.Sleep(_sleepSeconds * 1000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine($"Thread interrupted: {e.Message}");
            }

            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {_fruitName} - Loop {i}");
        }
    }
}

class FruitTimerProgram
{
    public static void Main(string[] args)
    {
        Fruit apple = new Fruit("Apple", 1);    // Sleep for 1 second
        Fruit banana = new Fruit("Banana", 2);  // Sleep for 2 seconds
        Fruit cherry = new Fruit("Cherry", 3);  // Sleep for 3 seconds

        Thread appleThread = new Thread(new ThreadStart(apple.Run));
        Thread bananaThread = new Thread(new ThreadStart(banana.Run));
        Thread cherryThread = new Thread(new ThreadStart(cherry.Run));

        appleThread.Start();
        bananaThread.Start();
        cherryThread.Start();

        appleThread.Join();
        bananaThread.Join();
        cherryThread.Join();
    }
}
