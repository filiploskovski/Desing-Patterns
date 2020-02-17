using System;
using System.Collections.Generic;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
           SortedList studentRecords = new SortedList();

           studentRecords.Add("Samual");
           studentRecords.Add("Jimmy");
           studentRecords.Add("Sandra");
           studentRecords.Add("Vivek");
           studentRecords.Add("Anna");

           studentRecords.SetSortStrategy(new MergeSort());
           studentRecords.Sort();

           studentRecords.SetSortStrategy(new QuickSort());
           studentRecords.Sort();

           Console.ReadLine();
        }
    }

    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }
    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            Console.WriteLine("QuickSort");
        }
    }
    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            Console.WriteLine("MergeSort");
        }
    }
    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            _sortstrategy.Sort(_list);
        }
    }

}
