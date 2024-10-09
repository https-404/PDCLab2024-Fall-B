using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 38, 27, 43, 3, 9, 82, 10 };
        Console.WriteLine("Original array:");
        PrintArray(array);

        MergeSort(array, 0, array.Length - 1);

        Console.WriteLine("Sorted array:");
        PrintArray(array);
    }

    static void MergeSort(int[] array, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            // Sort in parallel
            Task leftTask = Task.Run(() => MergeSort(array, left, mid));
            Task rightTask = Task.Run(() => MergeSort(array, mid + 1, right));

            Task.WaitAll(leftTask, rightTask);

            // Merge the sorted halves
            Merge(array, left, mid, right);
        }
    }

    static void Merge(int[] array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] L = new int[n1];
        int[] R = new int[n2];

        Array.Copy(array, left, L, 0, n1);
        Array.Copy(array, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                array[k] = L[i];
                i++;
            }
            else
            {
                array[k] = R[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            array[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            array[k] = R[j];
            j++;
            k++;
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