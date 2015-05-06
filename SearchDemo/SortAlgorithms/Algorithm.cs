using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDemo.SortAlgorithms
{
    public delegate void ExecutedStepHandler(object sender, EventArgs e);

    public abstract class Algorithm
    {
        protected ObservableCollection<int> integers;

        public ObservableCollection<int> Integers
        {
            get
            {
                return integers;
            }
        }

        public Func<Task> StepExecuted { get; set; }


        public Algorithm() { }
        public Algorithm(ObservableCollection<int> integers)
        {
            this.integers = integers;
        }

        public Task Execute(ObservableCollection<int> integers)
        {
            this.integers = integers;
            return Execute();
        }

        public abstract Task Execute();

        public string Name { get; protected set; }

        public string MethodBody { get; protected set; }
    }
}
