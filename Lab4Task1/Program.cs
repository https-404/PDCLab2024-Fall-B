// Create a banking class in C# Defire private members such as account number, balance and type of account, 
// Write public functions of deposit and withdraw along with printing balance of account. Use lockest to synchronize the code.

public class Bank
{
    private double _balance;
    private string _accountNUmber;
    private string _accountType;
    private object _lockObject = new object();
    
    public Bank(double balance, string accountNUmber, string accountType)
    {
        _balance = balance;
        _accountNUmber = accountNUmber;
        _accountType = accountType;
    }
    
    public void Deposit(double amount)
    {
        lock (_lockObject)
        {
            Console.WriteLine("Depositing " + amount);
            _balance += amount;
            GetBalance();
        }
    }
    
    public void Withdraw(double amount)
    {
        lock (_lockObject)
        {
            Console.WriteLine("Withdrawing " + amount);
            if(_balance < amount)
            {
                Console.WriteLine("Insufficient balance");
                throw new Exception("Insufficient balance");
                return;
            }
            _balance -= amount;
            GetBalance();
        }
    }
    
    public void GetBalance()
    {
        
        Console.WriteLine($"Account Number: {_accountNUmber}");
        Console.WriteLine($"Account Type: {_accountType}");
        Console.WriteLine($"Balance: {_balance}");
    }
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank(12345, "1000", "Savings");

        Thread t1 = new Thread(() => bank.Deposit(500));
        Thread t2 = new Thread(() => bank.Withdraw(12775));

        t1.Start();
        t2.Start();


        t2.Join();
        t1.Join();

    }
}