// Write C# Program that implements a multithread application that has three
// threads. First thread generates random integer for every second and if the value is
//     even, second thread computes the square of number and prints. If the value is odd,
// the third threadwill print the value of cube of number.

using System;
using System.Threading;

class MultiThreadStructure
{
    static int number;
    static bool flag = false;
    static bool flag2 = false;
    static bool flag3 = false;


    public static void GenerateRandom()
    {
        Random rand = new Random();
        while (true)
        {
            number = rand.Next(1, 100);
            Console.WriteLine("Random number: " + number);
            if (number % 2 == 0)
            {
                flag = true;
            }
            else
            {
                flag2 = true;
            }
            Thread.Sleep(1000);
        }
    }

    public static void Square()
    {
        while (true)
        {
            if (flag)
            {
                Console.WriteLine("Square: " + number * number);
                flag = false;
            }
            Thread.Sleep(1000);
        }
    }

    public static void Cube()
    {
        while (true)
        {
            if (flag2)
            {
                Console.WriteLine("Cube: " + number * number * number);
                flag2 = false;
            }
            Thread.Sleep(1000);
        }
    }

  
}

class Program
{
    static void Main()
    {
        
        
        Thread t1 = new Thread(MultiThreadStructure.GenerateRandom);
        Thread t2 = new Thread(MultiThreadStructure.Square);
        Thread t3 = new Thread(MultiThreadStructure.Cube);

        t1.Start();
        t2.Start();
        t3.Start();
    }
}