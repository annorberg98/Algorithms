using System;

namespace Programmeringuppgift
{
    class Program
    {
        static int Partition(int[] array, int low, int high)
        {
            //1. Select a pivot point.
            int pivot = array[high];

            int lowIndex = (low - 1);

            //2. Reorder the collection.
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    lowIndex++;

                    int temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            int temp1 = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = temp1;

            return lowIndex + 1;
        }

        static void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                //3. Recursively continue sorting the array
                Sort(array, low, partitionIndex - 1);
                Sort(array, partitionIndex + 1, high);
            }
        }
       

        static void Main(string[] args)
        {
            string type = "merge";

            int[] data = MyInsertionTest.ReadIntfile("largeints");
            int N = data.Length;

            if (type == "merge")
            {
                Console.WriteLine("Mergesort");

                if (N <= 1000)
                {
                    for (int i = 0; i < N; i++)
                    {
                        Console.Write(data[i] + " ");
                    }
                    Console.WriteLine("\n\n");
                }

                long before = Environment.TickCount;
                int[] sorted = Mergesort.Sort(data);
                long after = Environment.TickCount;

                // Look at numbers after sorting, unless there are too many of them.
                if (N <= 1000)
                {
                    for (int i = 0; i < N; i++)
                    {
                        Console.Write(sorted[i] + " ");
                    }
                    Console.Write("\n");
                }

                if (MyInsertionTest.IsSorted(sorted, 0, N - 1))
                {
                    Console.WriteLine((after - before) / 1000.0 + " seconds");
                }

                
            } else if(type == "quick")
            {
                Console.WriteLine("QuickSort");

                long before = Environment.TickCount;
                Sort(data, 0, N - 1);
                long after = Environment.TickCount;

                if (MyInsertionTest.IsSorted(data, 0, N - 1))
                {
                    Console.WriteLine((after - before) / 1000.0 + " seconds");
                }
            }

            Console.ReadLine();
        }
    }
}
