using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDemo.SortAlgorithms
{
    public class InsertionSort : Algorithm
    {
        private static string ExecuteBody = @"for (int i = 0; i < integers.Count; i++)
{
    int p = 0;
    for (; p < i && integers[p] < integers[i]; p++) ;
    integers.Insert(p, integers[p]);
    integers.RemoveAt(p + 1);
}";
        public InsertionSort()
            : base()
        {
            Name = "Insertion Sort";
            this.MethodBody = ExecuteBody;
        }
        public InsertionSort(ObservableCollection<int> integers) : base(integers) { }

        public async override Task Execute()
        {
            for (int i = 0; i < integers.Count; i++)
            {
                int p = 0;
                for (; p < i && integers[p] < integers[i]; p++) ;
                integers.Insert(p, integers[i]);
                integers.RemoveAt(i + 1);
                if (StepExecuted != null)
                    await StepExecuted();
            }
        }
    }
}
