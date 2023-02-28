using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterMethods
{
    class MyCompare : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            if (x > y)
                return 1;
            if (x < y)
                return -1;
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Compare2 c2 = new Compare2();
            BinatyThree<int> bin = new BinatyThree<int>(c2);

            bin.Add(5);
            bin.Add(7);
            bin.Add(10);
            bin.Add(3);
            bin.Add(6);

            Console.ReadKey();
        }
    }
    class Compare2 : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            if (x > y)
                return 1;
            else if (x < y)
                return -1;
            return 0;
        }
    }
}
//Console.WriteLine("\nПузырковая сортировка");
//            iteration = 0;
//            arr = Massivs.Create(100000);
//            DateTime startTimer = DateTime.Now;
//            Sorter.BubbleSort(arr, ref iteration);
//            DateTime endTimer = DateTime.Now;
//            Console.WriteLine("количество итераций " + iteration);
//            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);

//            Console.WriteLine("\nСортировка выбором");
//            arr = Massivs.Create(100000);
//            iteration = 0;
//            startTimer = DateTime.Now;
//            Sorter.SelectionSort(arr, ref iteration);
//            endTimer = DateTime.Now;
//            Console.WriteLine("Количество итераций " + iteration);
//            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);

//            Console.WriteLine("\nСортировка вставками");
//            arr = Massivs.Create(100000);
//            iteration = 0;
//            startTimer = DateTime.Now;
//            Sorter.Inserts(arr, ref iteration);
//            endTimer = DateTime.Now;
//            Console.WriteLine("количество итераций " + iteration);
//            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);

//            Console.WriteLine("\nБыстрая сортировка");
//            arr = Massivs.Create(100000);
//            iteration = 0;
//            startTimer = DateTime.Now;
//            Sorter.QuickSort(arr, ref iteration);
//            endTimer = DateTime.Now;
//            Console.WriteLine("Количество итераций " + iteration);
//            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);

//            Console.WriteLine("\nСортировка кучей");
//            arr = Massivs.Create(100000);
//            iteration = 0;
//            startTimer = DateTime.Now;
//            Sorter.HeapSort(arr, ref iteration);
//            endTimer = DateTime.Now;
//            Console.WriteLine("количество итераций " + iteration);
//            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);
