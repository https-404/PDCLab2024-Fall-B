using System;
using System.Diagnostics;
using System.Threading;

class BinarySearcher
{
    public int FindInArray(int[] arr, int start, int end, int target)
    {
        while (start <= end)
        {
            int middle = (start + end) / 2;
            if (arr[middle] == target)
                return middle;
            if (arr[middle] < target)
                start = middle + 1;
            else
                end = middle - 1;
        }
        return -1;
    }
}

class ManualThreading
{
    public Thread GenerateThread(Action act)
    {
        return new Thread(new ThreadStart(act));
    }
}

class PooledThreads
{
    public void PoolAction(Action act)
    {
        ThreadPool.QueueUserWorkItem(x => act());
    }
}

class Executor
{
    private readonly BinarySearcher searcher = new BinarySearcher();
    private readonly ManualThreading threadFactory = new ManualThreading();
    private readonly PooledThreads pooler = new PooledThreads();

    public void DirectSearch(int[] arr, int target)
    {
        var sw = Stopwatch.StartNew();
        Console.WriteLine($"Result: {searcher.FindInArray(arr, 0, arr.Length - 1, target)}");
        sw.Stop();
        Console.WriteLine($"Direct Search Time: {sw.ElapsedMilliseconds} ms");
    }

    public void UsingUserDefinedThreads(int[] arr, int target)
    {
        var sw = Stopwatch.StartNew();
        var thread = threadFactory.GenerateThread(() =>
        {
            int res = searcher.FindInArray(arr, 0, arr.Length - 1, target);
            Console.WriteLine($"User Thread Result: {res}");
            sw.Stop();
            Console.WriteLine($"User-Defined Thread Time: {sw.ElapsedMilliseconds} ms");
        });
        thread.Start();
        thread.Join();
    }

    public void UsingPooledThreads(int[] arr, int target)
    {
        var sw = Stopwatch.StartNew();
        pooler.PoolAction(() =>
        {
            int res = searcher.FindInArray(arr, 0, arr.Length - 1, target);
            Console.WriteLine($"Pooled Thread Result: {res}");
            sw.Stop();
            Console.WriteLine($"Pooled Thread Time: {sw.ElapsedMilliseconds} ms");
        });
    }
}

class Program
{
    static void Main()
    {
        int[] arrayData = { 2, 5, 8, 12, 16, 23, 38, 45, 56, 72 };
        int targetValue = 23;
        var exe = new Executor();

        Console.WriteLine("Direct Search:");
        exe.DirectSearch(arrayData, targetValue);

        Console.WriteLine("\nUser Defined Thread Search:");
        exe.UsingUserDefinedThreads(arrayData, targetValue);

        Console.WriteLine("\nPooled Thread Search:");
        exe.UsingPooledThreads(arrayData, targetValue);

        Thread.Sleep(500); // Wait to let pooled thread complete before main ends
    }
}
