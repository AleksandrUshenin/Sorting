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
            MyCompare myC = new MyCompare();
            PiramidalSort<int> ps = new PiramidalSort<int>(myC);
            ps.Add(5);
            ps.Add(2);
            ps.Add(1);
            ps.Add(3);
            ps.Add(8);
            ps.Add(6);
            ps.Add(9);
            ps.Add(7);
            ps.Add(0);
            ps.Sorter();

            ps = new PiramidalSort<int>(myC);
            Console.WriteLine("\nмоя сортировка");
            //int iteration = 0;
            int[] arrE = Massivs.Create(100000);

            DateTime startTimerE = DateTime.Now;
            ps.Add(arrE);
            ps.Sorter();
            DateTime endTimerE = DateTime.Now;

            //Console.WriteLine(startTimerE.TimeOfDay);
            //Console.WriteLine(endTimerE.TimeOfDay);
            Console.WriteLine(endTimerE.TimeOfDay - startTimerE.TimeOfDay);


            Console.ReadKey();
            int[] arr = { 4, 5, 0, 1, 7, 8};
            int iteration = 0;
            //Massivs.Print(Sorter.HeapSort(arr, ref iteration), iteration);
            //Massivs.Print(Sorter.QuickSort(arr, ref iteration), iteration);
            //Massivs.Print(Sorter.BableSort(arr, ref iteration), iteration);
            //Massivs.Print(Sorter.BableSort(Massivs.Create(10000), ref iteration), iteration);
            Console.WriteLine("Сортировка массива длинной 100000");

            Console.WriteLine("\nПузырковая сортировка");
            iteration = 0;
            arr = Massivs.Create(100000);
            DateTime startTimer = DateTime.Now;
            Sorter.BubbleSort(arr, ref iteration);
            DateTime endTimer = DateTime.Now;
            Console.WriteLine("количество итераций " + iteration);
            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);

            Console.WriteLine("\nСортировка выбором");
            arr = Massivs.Create(100000);
            iteration = 0;
            startTimer = DateTime.Now;
            Sorter.SelectionSort(arr, ref iteration);
            endTimer = DateTime.Now;
            Console.WriteLine("Количество итераций " + iteration);
            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);

            Console.WriteLine("\nСортировка вставками");
            arr = Massivs.Create(100000);
            iteration = 0;
            startTimer = DateTime.Now;
            Sorter.Inserts(arr, ref iteration);
            endTimer = DateTime.Now;
            Console.WriteLine("количество итераций " + iteration);
            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);

            Console.WriteLine("\nБыстрая сортировка");
            arr = Massivs.Create(100000);
            iteration = 0;
            startTimer = DateTime.Now;
            Sorter.QuickSort(arr, ref iteration);
            endTimer = DateTime.Now;
            Console.WriteLine("Количество итераций " + iteration);
            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);

            Console.WriteLine("\nСортировка кучей");
            arr = Massivs.Create(100000);
            iteration = 0;
            startTimer = DateTime.Now;
            Sorter.HeapSort(arr, ref iteration);
            endTimer = DateTime.Now;
            Console.WriteLine("количество итераций " + iteration);
            Console.WriteLine(endTimer.TimeOfDay - startTimer.TimeOfDay);


            Console.ReadKey();
        }
    }
}
