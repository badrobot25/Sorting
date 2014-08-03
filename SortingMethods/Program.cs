using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            var totalNo = 10000;
            var aList = new int[totalNo];

            for (var i = 0; i < totalNo; i++)
            {
                aList[i] = rand.Next();
            }

            ISortMethod bubblesort = new BubbleSort();
            ISortMethod quicksort = new QuickSort();
            ISortMethod insertionsort = new InsertionSort();

            SortAndDisplayTime(bubblesort, aList.ToList());
            SortAndDisplayTime(quicksort, aList.ToList());
            SortAndDisplayTime(insertionsort, aList.ToList());

            Console.ReadKey();
        }

        public static void SortAndDisplayTime(ISortMethod sorter,  List<int> array)
        {
            var watch = Stopwatch.StartNew();
            var sortedList = sorter.Sorter(array);
            watch.Stop();
            Console.WriteLine(sorter.GetType());
            if (array.Count < 101)
                foreach (var element in sortedList)
                {
                    Console.Write(element + "  ");
                }
            Console.WriteLine("Time: " + watch.ElapsedMilliseconds + "\n");
            
        }

    }
}
