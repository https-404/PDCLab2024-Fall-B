// Write a C# program in which you are required to create a queue data structure
// from Generics library and then sort it.

using System;
using System.Collections.Generic;



class QueueLab
{
    Queue<int> queue = new Queue<int>();
    
    public void Add(int value)
    {
        queue.Enqueue(value);
    }
    
    public void Remove()
    {
        queue.Dequeue();
    }
    public void Display()
    {
        foreach (int value in queue)
        {
            Console.WriteLine(value);
        }
    }
    
    public void Sort()
    {
        List<int> list = new List<int>(queue);
        list.Sort();
        queue = new Queue<int>(list);
    }
}

class Program
{
    static void Main(string[] args)
    {
        QueueLab queueLab = new QueueLab();
        
        queueLab.Add(5);
        queueLab.Add(3);
        queueLab.Add(7);
        queueLab.Add(1);
        Console.WriteLine("--------------------");
        Console.WriteLine("Queue:");
        queueLab.Display();
        Console.WriteLine("--------------------");
        Console.WriteLine("Sorted Queue:");
        queueLab.Sort();
        
        queueLab.Display();
    }
}