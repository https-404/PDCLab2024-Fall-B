using System;

class Employee
{
    private string firstName;
    private string lastName;
    private int monthlySalary;

    public Employee(string firstName, string lastName, int monthlySalary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.MonthlySalary = monthlySalary;
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public int MonthlySalary
    {
        get { return monthlySalary; }
        set { monthlySalary = (value > 0) ? value : 0; }
    }

    public int YearlySalary()
    {
        return MonthlySalary * 12;
    }

    public void GiveRaise(double percent)
    {
        MonthlySalary += (int)(MonthlySalary * (percent / 100));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee emp1 = new Employee("John", "Doe", 2000);
        Employee emp2 = new Employee("Jane", "Doe", 3000);

        Console.WriteLine($"{emp1.FirstName} {emp1.LastName} yearly salary: {emp1.YearlySalary()}");
        Console.WriteLine($"{emp2.FirstName} {emp2.LastName} yearly salary: {emp2.YearlySalary()}");

        emp1.GiveRaise(10);
        emp2.GiveRaise(10);

        Console.WriteLine($"{emp1.FirstName} {emp1.LastName} new yearly salary: {emp1.YearlySalary()}");
        Console.WriteLine($"{emp2.FirstName} {emp2.LastName} new yearly salary: {emp2.YearlySalary()}");
    }
}