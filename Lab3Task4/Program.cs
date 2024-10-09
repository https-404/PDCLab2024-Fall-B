using System;
using System.Threading;
class Program
{
    static int[] array = { 38, 27, 43, 3, 9, 82, 10 };
    static int target = 43;
    static int result = -1;
    static object lockObj = new object();

    static void Main(string[] args)
    {
        Array.Sort(array);
        Console.WriteLine("Sorted array:");
        PrintArray(array);

        Thread t1 = new Thread(() => BinarySearch(0, array.Length / 2 - 1));
        Thread t2 = new Thread(() => BinarySearch(array.Length / 2, array.Length - 1));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        if (result != -1)
        {
            Console.WriteLine($"Element found at index: {result}");
        }
        else
        {
            Console.WriteLine("Element not found");
        }
    }

    static void BinarySearch(int left, int right)
    {
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
            {
                lock (lockObj)
                {
                    result = mid;
                }
                return;
            }
            if (array[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
    }

    static void PrintArray(int[] array)
    {
        foreach (int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}