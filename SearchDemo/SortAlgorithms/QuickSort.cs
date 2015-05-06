using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDemo.SortAlgorithms
{
    public class QuickSort : Algorithm
    {
        private static string ExecuteBody = @"";
        public QuickSort()
            : base()
        {
            Name = "Insertion Sort";
            this.MethodBody = ExecuteBody;
        }
        public QuickSort(ObservableCollection<int> integers) : base(integers) { }

        public async override Task Execute()
        {
            
        }

        public async Task<T> Sort<T>(T integers) where T : Collection<int>, new()
        {
            if (integers.Count <= 1)
                return integers;

            int pivot = integers[integers.Count / 2];
            
            for(int i = 0; i < integers.Count;)
            {
                if(integers[i] > pivot)
                {
                    integers.Add(integers[i]);
                    integers.RemoveAt(i);
                }
                else
                {
                    integers.Insert(0, integers[i]);
                    integers.RemoveAt(i++);
                }
            }

            return integers;
        }
    }
}
