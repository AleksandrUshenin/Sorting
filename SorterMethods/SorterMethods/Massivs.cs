using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterMethods
{
    class Massivs
    {
        /// <summary>
        /// вывод масива 
        /// </summary>
        /// <param name="arr">массив</param>
        public static void Print(int[] arr)
        {
            foreach (int iter in arr)
            {
                Console.Write(iter + " ");
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// вывод масива и уоличества итерайий
        /// </summary>
        /// <param name="arr">массив</param>
        /// <param name="count_iteration">количество итераций</param>
        public static void Print(int[] arr, int count_iteration)
        {
            foreach (int iter in arr)
            {
                Console.Write(iter + " ");
            }
            Console.WriteLine("\nколичество итераций " + count_iteration);
        }
        /// <summary>
        /// создание массива
        /// </summary>
        /// <param name="len">длинна</param>
        /// <param name="min">минимальное значение</param>
        /// <param name="max">максимальное значение</param>
        /// <returns>массив</returns>
        public static int[] Create(int len, int min, int max)
        {
            int[] arr = new int[len];
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                arr[i] = random.Next(min, max);
            }
            return arr;
        }
        /// <summary>
        /// создание массива
        /// </summary>
        /// <param name="len">длинна</param>
        /// <returns>массив</returns>
        public static int[] Create(int len)
        {
            return Create(len, 0, len);
        }
    }
}
