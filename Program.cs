using System;

namespace Programmeringuppgift
{
    class Program
    {

        private void RunQuickSort(string filename)
        {
            int[] arr = MyInsertionTest.ReadIntfile(filename);
            int N = arr.Length;

            if (N <= 1000)
            {
                for (int i = 0; i < N; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine("\n\n");
            }

            long before = Environment.TickCount;
            Quicksort.Sort(arr, 0, arr.Length-1);
            long after = Environment.TickCount;

            // Look at numbers after sorting, unless there are too many of them.
            if (N <= 1000)
            {
                for (int i = 0; i < N; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.Write("\n");
            }

            if (MyInsertionTest.IsSorted(arr, 0, N - 1))
            {
                Console.WriteLine((after - before) / 1000.0 + " seconds");
            }

            Console.ReadLine();
        }

        private void RunMergesort(string filename)
        {
            int[] data = MyInsertionTest.ReadIntfile(filename);
            int N = data.Length;

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

            Console.ReadLine();
        }

        public void Run(string type,string filename)
        {
            if(type == "quick")
            {
                this.RunQuickSort(filename);
            } else if(type == "merge")
            {
                this.RunMergesort(filename);
            }
        }
        
        static void Main(string[] args)
        {
            
        }
    }
}
