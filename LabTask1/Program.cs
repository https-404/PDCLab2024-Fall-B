// See https://aka.ms/new-console-template for more information

using System;

class P
{
    public int a = 30; 
}

class Q : P
{
    public new int a = 50; 
}

class Program
{
    static void Main(string[] args)
    {
        Q q = new Q(); 
        Console.WriteLine("Q class variable a: " + q.a); 

        P p = q; 
        Console.WriteLine("P class variable a: " + p.a); 
    }
}
