using System;

class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}

class cat : Animal
{
    public override void Sound()
    {
        Console.WriteLine("cat meows.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        cat cat = new cat();
        cat.Sound(); // Calls overridden method in cat class
    }
}