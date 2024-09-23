// Write a C# program in which you are required to create a stack data structure from Generics library and then sort it.

using System;
using System.Collections.Generic;

class StackLab
{
    Stack<int> stack = new Stack<int>();
    
    public void Add(int value)
    {
        stack.Push(value);
    }
    
    public void Remove()
    {
        stack.Pop();
    }
    public void Display()
    {
        foreach (int value in stack)
        {
            Console.WriteLine(value);
        }
    }
    
    public void Sort()
    {
        List<int> list = new List<int>(stack);
        list.Sort();
        stack = new Stack<int>(list);
    }
}

class Program
{
    static void Main(string[] args)
    {
        StackLab stackLab = new StackLab();
        
        stackLab.Add(5);
        stackLab.Add(3);
        stackLab.Add(7);
        stackLab.Add(1);
        Console.WriteLine("--------------------");
        Console.WriteLine("Stack:");
        stackLab.Display();
        Console.WriteLine("--------------------");
        Console.WriteLine("Sorted Stack:");
        stackLab.Sort();
        
        stackLab.Display();
    }
}