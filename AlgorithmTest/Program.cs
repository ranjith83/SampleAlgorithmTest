using System;
using System.Collections;
using System.Data.SqlTypes;

namespace AlgorithmTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            //HeapSortCall();

            //DecodeNumbers();
            ExcelUtility excelUtility = new ExcelUtility();

            excelUtility.CreateExcel($@"C:\Users\ranjithkumar.radhakr\source\repos\AlgorithmTest\AlgorithmTest\output_{DateTime.Now.ToFileTimeUtc()}.xlsx",
                @"C:\Users\ranjithkumar.radhakr\source\repos\AlgorithmTest\AlgorithmTest\SampleText.txt");
        }

        public static void HeapSortCall()
        {
            Console.WriteLine("Hello World!");

            int[] arr = { 74, 19, 24, 5, 8, 79, 42, 15, 20, 53, 11 };
            Console.WriteLine("Heap Sort");

            //CommonFunctions.PrintInitial(arr);

            Console.WriteLine(string.Join(",", arr));

            HeapSort.Sort(arr);

            //CommonFunctions.PrintFinal(arr);

            Console.WriteLine(string.Join(",", arr));



            Console.ReadKey();

        }

        public static void DecodeNumbers()
        {
            string data = "568";

            Console.WriteLine(data);

            DecodeArray decArr = new DecodeArray();

            int ways = decArr.Numarray_Ways(data.ToCharArray(), data.Length);

            Console.WriteLine(ways);

            Console.ReadKey();
        }
    }
}
