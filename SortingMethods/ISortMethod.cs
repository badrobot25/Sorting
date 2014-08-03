using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods
{
    public interface ISortMethod
    {
        List<int> Sorter(List<int> array);
    }

    public class BubbleSort : ISortMethod
    {
        public List<int> Sorter(List<int> array)
        {
            var sortOn = true;
            for (var i=1; i<array.Count; i++)
            {
                // !sortOn - early breaker in case no more sorting is performed
                if (!sortOn) break;
                sortOn = false;
                for (var j=0; j<array.Count; j++)
                {
                    if (array[i] < array[j])
                    {
                        sortOn = true;
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
    }

    public class QuickSort : ISortMethod
    {
        public List<int> WorkArray;
        public List<int> Sorter(List<int> array)
        {
            WorkArray = array;
            RecursiveQSort(WorkArray, 0, array.Count - 1);
            return WorkArray;
        }

        private void RecursiveQSort(List <int> array, int inferior, int superior)
        {
            var i = inferior;
            var j = superior;
            // divide-et-impera - choose pivot in the middle of the array/list
            var x = WorkArray[(i + j) / 2];
            do
            {
                // find bounds
                while ((WorkArray[i] < x)) i++;
                while ((WorkArray[j] > x)) j--;

                // swap
                if (i <= j)
                {
                    var temp = WorkArray[i];
                    WorkArray[i] = WorkArray[j];
                    WorkArray[j] = temp;
                    i++;
                    j--;
                }
            }
            while (i <= j);
            // handle lower half
            if (inferior < j) RecursiveQSort(array, inferior, j);
            // handle upper half
            if (superior > i) RecursiveQSort(array, i, superior);
        }
    }

    public class InsertionSort : ISortMethod
    {
        public List<int> Sorter(List<int> array)
        {
            for (var i=0; i < array.Count; i++)
            {
                var temp = array[i];
                var j = i;
                while (j > 0 && array[j-1] > temp)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = temp;
            }
            return array;
        }
    }

}
