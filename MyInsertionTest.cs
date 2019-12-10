using System.IO;
using System;

public class MyInsertionTest {
    public static void InsertionSort(int[] a, int lo, int hi) {
        for (int i = lo; i <= hi; i++) {
            for (int j = i; j > lo && a[j] < a[j-1]; j--) {
                int x = a[j]; a[j] = a[j-1]; a[j-1] = x;
            }
        }
    }

    // Checks if the first n element of a are in sorted order.
    public static bool IsSorted(int[] a, int lo, int hi) {
        int flaws = 0;
        for (int i = lo+1; i <= hi; i++) {
            if (a[i] < a[i-1]) {
                if (flaws++ >= 10) {
                    System.Console.WriteLine("...");
                    break;
                }
                System.Console.WriteLine("a["+(i-1)+"] = "+a[i-1]+", a["+i+"] = "+a[i]);
            }
        }
        return flaws == 0;
    }

    // Shuffles the first n elements of a.
    public static void Shuffle(int[] a, int lo, int hi) {
        Random rand = new Random();
        for (int i = lo; i <= hi; i++) {
            int r = i + rand.Next(hi+1-i);     // between i and hi
            int t = a[i]; a[i] = a[r]; a[r] = t;
        }
    }

    public static int[] ReadIntfile(String filename) {
        // Read file into a byte array, and then combine every group of four bytes to an int. (Not
        // the standard way, but it works!)
        byte[] bytes = File.ReadAllBytes("../../../" + filename);
        int[] ints = new int[bytes.Length/4];
        for (int i = 0; i < ints.Length; i++) {
            for (int j = 0; j < 4; j++) { ints[i] += (bytes[i*4+j] & 255) << (3-j)*8; }
        }
        return ints;
    }

    /*public static void Main() {
        int[] data = ReadIntfile("largeints"); // Also try "largeints"!
        int N = data.Length;    // Change to some smaller number to test on part of array.

        // Look at numbers before sorting, unless there are too many of them.
        if (N <= 1000) {
            for (int i = 0; i < N; i++) { System.Console.Write(data[i]+" "); }
            System.Console.Write("\n\n");
        }

        long before = Environment.TickCount;
        InsertionSort(data, 0, N-1);
        long after = Environment.TickCount;

        // Look at numbers after sorting, unless there are too many of them.
        if (N <= 1000) {
            for (int i = 0; i < N; i++) { System.Console.Write(data[i]+" "); }
            System.Console.Write("\n");
        }

        if (IsSorted(data, 0, N-1)) {
            System.Console.WriteLine((after-before) / 1000.0 + " seconds");
        }
    }*/
}
