using System;

class Animal
{
    public string name;
    public void Eat()
    {
        Console.WriteLine(name + " is eating.");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine(name + " is barking.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Dog dog = new Dog();
        dog.name = "Buddy"; 
        dog.Eat(); 
        dog.Bark(); 
    }
}