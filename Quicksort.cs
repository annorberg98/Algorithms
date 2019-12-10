using System;
using System.Collections.Generic;
using System.Text;

namespace Programmeringuppgift
{
    class Quicksort
    {
        public int[] array;
        private int N;

        public Quicksort(int[] array)
        {
            this.array = array;
            this.N = this.array.Length;
        }

        public int[] Sort()
        {
            return sort(0, N - 1);
        }

        private int[] sort(int left, int right)
        {
            int pivot, leftend, rightend;

            leftend = left;
            rightend = right;
            pivot = array[left];

            while (left < right)
            {
                while ((array[right] >= pivot) && (left < right))
                {
                    right--;
                }

                if (left != right)
                {
                    array[left] = array[right];
                    left++;
                }

                while ((array[left] <= pivot) && (left < right))
                {
                    left++;
                }

                if (left != right)
                {
                    array[right] = array[left];
                    right--;
                }
            }

            array[left] = pivot;
            pivot = left;
            left = leftend;
            right = rightend;

            if (left < pivot)
            {
                sort(left, pivot - 1);
            }

            if (right > pivot)
            {
                sort(pivot + 1, right);
            }

            return this.array;
        }
    }
}
