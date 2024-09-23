using System;

class Overload
{
    public int Addition(int a, int b)
    {
        return a + b;
    }

    public int Addition(int a, int b, int c)
    {
        return a + b + c;
    }

    public double Addition(double a, double b)
    {
        return a + b;
    }
}

class OverloadTesting
{
    static void Main(string[] args)
    {
        Overload overload = new Overload();
        
        Console.WriteLine("Addition of two integers: " + overload.Addition(3, 4));
        Console.WriteLine("Addition of three integers: " + overload.Addition(3, 4, 5));
        Console.WriteLine("Addition of two doubles: " + overload.Addition(3.5, 4.5));
    }
}