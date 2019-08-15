using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmTest
{
    public class HeapSort
    {
       public static void Sort(int[] array)
        {
            var length = array.Length;
            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(array, length, i);

                Console.WriteLine("First Loop");
                Console.WriteLine(string.Join(",", array));
            }

            for (int i = length - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Heapify(array, i, 0);

                Console.WriteLine("Second Loop");
                Console.WriteLine(string.Join(",", array));
            }
        }

        //Rebuilds the heap
        public static void Heapify(int[] array, int length, int i)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && array[left] > array[smallest])
            {
                smallest = left;
            }
            if (right < length && array[right] > array[smallest])
            {
                smallest = right;
            }
            if (smallest != i)
            {
                int swap = array[i];
                array[i] = array[smallest];
                array[smallest] = swap;
                Heapify(array, length, smallest);
            }
        }

        //public static void Main()
        //{
        //    int[] arr = { 74, 19, 24, 5, 8, 79, 42, 15, 20, 53, 11 };
        //    Console.WriteLine("Heap Sort");

        //    //CommonFunctions.PrintInitial(arr);

        //    Console.WriteLine(arr.ToString());

        //    Sort(arr);

        //    //CommonFunctions.PrintFinal(arr);

        //    Console.WriteLine(arr.ToString());

        //    Console.ReadKey();
        //}
    }
}
