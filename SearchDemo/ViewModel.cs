using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using SearchDemo.SortAlgorithms;

namespace SearchDemo
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            Algorithms = new ObservableCollection<Algorithm>();
            Algorithms.Add(new SelectionSort());
            SelectedAlgorithm = Algorithms[0];
            Randomize(null);
        }


        public ObservableCollection<Algorithm> Algorithms { get; private set; }

        public ObservableCollection<int> Integers { get; private set; }

        private string methodBody;
        public string MethodBody
        {
            get { return methodBody; }
            set
            {
                if(methodBody != value)
                {
                    methodBody = value;
                    RaisePropertyChanged("MethodBody");
                }
            }
        }

        private int count = 10;
        public int Count
        {
            get { return count; }
            set
            {
                if(count != value)
                {
                    count = value;
                    RaisePropertyChanged("Count");
                    Randomize(null);
                }
            }
        }

        private Algorithm selectedAlgorithm;
        public Algorithm SelectedAlgorithm
        {
            get { return selectedAlgorithm; }
            set
            {
                if (selectedAlgorithm != value)
                {
                    selectedAlgorithm = value;
                    MethodBody = selectedAlgorithm.MethodBody;
                    RaisePropertyChanged("SelectedAlgorithm");
                }
            }
        }

        #region RandomizeCommand Members
        public ICommand RandomizeCommand
        {
            get { return new Command(Randomize); }
        }
        private static Random rand = new Random();
        private void Randomize(object obj)
        {
            if (Integers == null) Integers = new ObservableCollection<int>();
            else Integers.Clear();

            for (int i = 0; i < Count; i++) Integers.Add(rand.Next(Count) + 1);
        }
        #endregion

        #region ExecuteCommand Members
        public ICommand ExecuteCommand
        {
            get { return new Command(Execute, (object o) => { return selectedAlgorithm != null; }); }
        }

        private async void Execute(object obj)
        {
            selectedAlgorithm.StepExecuted = selectedAlgorithm_StepExecuted;
            ObservableCollection<int> quick = new ObservableCollection<int>(Integers);
            await selectedAlgorithm.Execute(Integers);
            selectedAlgorithm.StepExecuted = null;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var task = selectedAlgorithm.Execute(quick);
            stopwatch.Stop();
        }

        private async Task selectedAlgorithm_StepExecuted()
        {
            await Task.Delay(3000/Count);
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string value)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(value));
        }

        #endregion
    }
}
