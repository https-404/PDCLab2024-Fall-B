// Write a C# program in which you are required to create a single thread then callit
//     multiple times by its objects.

using System;
using System.Threading;

class Program
{
    public void Display()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Thread is running :" + i.ToString() );
        }
    }
    
    static void Main(string[] args)
    {
        Program program = new Program();
        
        Thread thread1 = new Thread(new ThreadStart(program.Display));
        Thread thread2 = new Thread(new ThreadStart(program.Display));
        
        thread1.Start();
        thread2.Start();
    }
}