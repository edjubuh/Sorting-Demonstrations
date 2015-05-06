using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDemo.SortAlgorithms
{
    public class SelectionSort : Algorithm
    {
        private static string ExecuteBody = @"for (int i = 0; i < Integers.Count; i++)
{
    int smallestValueIndex = i;
    for (int v = i; v < integers.Count; v++)
    if (Integers[v] < Integers[smallestValueIndex]) smallestValueIndex = v;

    int temp = Integers[i];
    Integers[i] = Integers[smallestValueIndex];
    Integers[smallestValueIndex] = temp;
}";

        public SelectionSort()
            : base()
        {
            Name = "Selection Sort";
            this.MethodBody = ExecuteBody;
        }
        public SelectionSort(ObservableCollection<int> integers) : base(integers) { }

        public async override Task Execute()
        {
            for (int i = 0; i < Integers.Count; i++)
            {
                int smallestValueIndex = i;
                for (int v = i; v < integers.Count; v++)
                    if (Integers[v] < Integers[smallestValueIndex]) smallestValueIndex = v;

                int temp = Integers[i];
                Integers[i] = Integers[smallestValueIndex];
                Integers[smallestValueIndex] = temp;

                if (StepExecuted != null)
                    await StepExecuted();
            }
        }
    }
}
