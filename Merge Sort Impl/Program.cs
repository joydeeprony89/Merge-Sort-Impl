using System;

namespace Merge_Sort_Impl
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 12, 11, 13, 5, 6, 7 };
            Sort(arr, 0, arr.Length - 1);
            foreach (int i in arr) Console.WriteLine(i);
        }

        // 1. Divide the array input into two halves
        // 2. Sort both the halves.
        // 3. merge both the sorted halves.

        static void Sort(int[] arr, int l , int r)
        {
            if(l < r)
            {
                int mid = (r - l) / 2 + l;
                Sort(arr, l, mid);
                Sort(arr, mid + 1, r);
                Merge(arr, l, mid, r);
            }
        }

        static void Merge(int[] arr, int l , int m , int r)
        {
            int k = 0, i = 0, j = 0; ;
            // size of the left subarray
            int n1 = m - l + 1;
            // size of the right subarray
            int n2 = r - m;
            int[] left = new int[n1];
            int[] right = new int[n2];

            // copy items to left
            for (i = 0; i < n1; i++)
            {
                left[i] = arr[l + i];
            }

            // copy items to right
            for (j = 0; j < n2; j++)
            {
                right[j] = arr[m + 1 + j];
            }

            i = 0; j = 0; k = l;
            // do the original merge here
            while(i < n1 && j < n2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                    k++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                    k++;
                }
            }

            // if any items left in the left subarray
            while(i < n1)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            // if any items left in the right subarray
            while (j < n2)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
