using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SearchDemo.SortAlgorithms
{
    public static class HelperMethods
    {
        public static T SubCollection<T, U>(this T collection, int lower, int upper) where T : Collection<U>, new()
        {
            var newCollection = new T();
            for (int i = lower; i < upper; i++)
                newCollection.Add(collection[i]);
            return newCollection;
        }
    }

    public class MergeSort : Algorithm
    {
        private static string ExecuteBody = @"if (integers.Count <= 1)
    return integers;
// Sort the lower and upper halves asynchronously
var lower = Sort<T>(integers.SubCollection<T, int>(0, integers.Count / 2);
var upper = Sort<T>(integers.SubCollection<T, int>(integers.Count / 2, integers.Count);
integers.Clear();
while (lower.Count > 0 && upper.Count > 0)
{
    if (lower[0] > upper[0])
    {
        integers.Add(upper[0]);
        upper.RemoveAt(0);
    }
    else
    {
        integers.Add(lower[0]);
        lower.RemoveAt(0);
    }
}
            
// Add any extras
if(lower.Count > 0)
{
    foreach (var i in lower)
        integers.Add(i);
}
else if(upper.Count > 0)
{
    foreach (var i in upper)
        integers.Add(i);
}

return integers;";
        public MergeSort()
            : base()
        {
            Name = "Merge Sort";
            this.MethodBody = ExecuteBody;
        }
        public MergeSort(ObservableCollection<int> integers) : base(integers) { }

        public async override Task Execute()
        {
            await Sort<ObservableCollection<int>>(integers);
        }

        public async Task<T> Sort<T>(T integers) where T : Collection<int>, new()
        {
            if (integers.Count <= 1)
                return integers;
            // sorry
            // Sort the lower and upper halves asynchronously
            var lower = await await Task.Factory.StartNew(async () => await Sort<T>(integers.SubCollection<T, int>(0, integers.Count / 2)));
            var upper = await await Task.Factory.StartNew(async () => await Sort<T>(integers.SubCollection<T, int>(integers.Count / 2, integers.Count)));
            integers.Clear();
            while (lower.Count > 0 && upper.Count > 0)
            {
                if (lower[0] > upper[0])
                {
                    integers.Add(upper[0]);
                    upper.RemoveAt(0);
                }
                else
                {
                    integers.Add(lower[0]);
                    lower.RemoveAt(0);
                }
            }
            
            // Add any extras
            if(lower.Count > 0)
            {
                foreach (var i in lower)
                    integers.Add(i);
            }
            else if(upper.Count > 0)
            {
                foreach (var i in upper)
                    integers.Add(i);
            }

            return integers;
        }


    }

}
