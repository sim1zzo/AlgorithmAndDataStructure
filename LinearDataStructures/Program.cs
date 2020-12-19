using System;

namespace LinearDataStructures
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            LinkedList_Examples();
        }

        public static void Arrays_Examples()
        {
            var array = new Arrays(3);
            array.Insert(10);
            array.Insert(20);
            array.Insert(30);
            array.Insert(40);
            array.Insert(50);
            array.Print();
            //array.Reverse();
            //array.Print();
            //array.Reverse();
            //var max = array.Max();
            //Console.WriteLine($"The max value is {max}");
            //var index = array.IndexOf(50);
            //Console.WriteLine($"Index of 50 is {index}");
            array.InsertAtIndex(2, 25);
            array.Print();

        }

        public static void LinkedList_Examples()
        {
            var ll = new LinkedList();
            ll.AddLast(10);
            ll.AddLast(20);
            ll.AddLast(30);
            ll.AddLast(40);
            ll.AddLast(50);
            ll.AddFirst(70);

            ll.Reverse();
            var llarray = ll.ToArray();
            Action<int> action = new Action<int>(ShowAction);
            Array.ForEach(llarray, action);
            


        }

        private static void ShowAction(int val)
        {
            Console.WriteLine(val);
        }
    }
}
