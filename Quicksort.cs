using System;
using System.Collections.Generic;
using System.Text;

namespace Programmeringuppgift
{
    class Quicksort
    {
        public static int Partition(int[] arr, int left, int right)
        {
            int pivot;
            pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return right;
                }
            }

        }

        public static void Sort(int[] arr, int left, int right)
        {
            int pivot;
            if (left < right)
            {
                pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Sort(arr, pivot + 1, right);
                }
            }
        }


    }
}
