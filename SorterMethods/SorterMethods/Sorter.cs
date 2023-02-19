using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SorterMethods
{
    class Sorter
    {
        /// <summary>
        /// пузырковая сортировка
        /// </summary>
        /// <param name="arr">массив для сортировки</param>
        /// <param name="iteration">количество итераций</param>
        /// <returns>отсортированный массмив</returns>
        public static int[] BubbleSort(int[] arr, ref int iteration)
        {
            bool needSort;
            do
            {
                needSort = false;
                for(int i = 0; i < arr.Length - 1; i++)
                {
                    iteration++;
                    if(arr[i] > arr[i + 1])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        needSort = true;
                    }
                }
            }
            while(needSort);
            return arr;
        }
        /// <summary>
        /// сортировка выбором 
        /// </summary>
        /// <param name="arr">массив для сортировки</param>
        /// <param name="iteration">количество итераций</param>
        /// <returns>отсортированный массмив</returns>
        public static int[] SelectionSort(int[] arr, ref int iteration)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minPosition = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    iteration++;
                    if (arr[j] < arr[minPosition]) 
                    {
                        minPosition = j;
                    }
                }
                if (minPosition != i) 
                {
                    int temp = arr[i];
                    arr[i] = arr[minPosition];
                    arr[minPosition] = temp;
                }

            }
            return arr;
        }
        /// <summary>
        /// сортировка вставками 
        /// </summary>
        /// <param name="arr">массив для сортировки</param>
        /// <param name="iteration">количество итераций</param>
        /// <returns>отсортированный массмив</returns>
        public static int[] Inserts(int[] arr, ref int iteration)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        iteration++;
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
        /// <summary>
        /// быстрая сортировка
        /// </summary>
        /// <param name="arr">массив для сортировки</param>
        /// <param name="iteration">количество итераций</param>
        /// <returns>отсортированный массмив</returns>
        public static int[] QuickSort(int[] arr, ref int iteration)
        {
            QuickSort(arr,0, arr.Length - 1, ref iteration);
            return arr;
        }
        /// <summary>
        /// быстрая сортировка
        /// </summary>
        /// <param name="arr">массив для сортировки</param>
        /// <param name="startposition">начало</param>
        /// <param name="endPosition">конец</param>
        /// <param name="iteration">количество итераций</param>
        /// <returns>отсортированный массмив</returns>
        private static void QuickSort(int[] arr, int startposition, int endPosition, ref int iteration)
        {
            //int[]
            int leftposition = startposition;
            int rightPosition = endPosition;
            int pivot = arr[(startposition + endPosition) / 2];
            do
            {
                while (arr[leftposition] < pivot)
                {
                    leftposition++;
                    iteration++;
                }
                while (arr[rightPosition] > pivot)
                {
                    rightPosition--;
                    iteration++;
                }
                if (leftposition <= rightPosition)
                {
                    if (leftposition < rightPosition)
                    {
                        int temp = arr[leftposition];
                        arr[leftposition] = arr[rightPosition];
                        arr[rightPosition] = temp;
                    }
                    leftposition++;
                    rightPosition--;
                    iteration++;
                }
            }
            while(leftposition <= rightPosition);
            if (leftposition < endPosition)
                QuickSort(arr, leftposition, endPosition, ref iteration);
            if(startposition < rightPosition)
                QuickSort(arr, startposition, rightPosition, ref iteration);
            //iteration++;
            //sreturn arr;
        }
        /// <summary>
        /// сортировка кучей
        /// </summary>
        /// <param name="arr">массив для сортировки</param>
        /// <param name="iteration">количество итераций</param>
        /// <returns>тсортированный массмив</returns>
        public static int[] HeapSort(int[] arr, ref int iteration)
        {
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
                heapify(arr, arr.Length - 1, i, ref iteration);
            for (int i = arr.Length - 1; i >= 0; i--) 
            {
                iteration++;
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                heapify(arr, i, 0, ref iteration);
            }
            return arr;
        }
        private static void heapify(int[] arr, int heapSize, int rootIndex, ref int iteration)
        {
            iteration++;
            int largest = rootIndex;
            int leftChild = 2 * rootIndex + 1;
            int rightChild = 2 * rootIndex + 2;
            if (leftChild < heapSize && arr[leftChild] > arr[largest])
                largest = leftChild;
            if (rightChild < heapSize && arr[rightChild] > arr[largest])
                largest = rightChild;
            if (largest != rootIndex) 
            {
                int temp = arr[rootIndex];
                arr[rootIndex] = arr[largest];
                arr[largest] = temp;

                heapify(arr, heapSize, largest, ref iteration);
            }
        }
    }
}
