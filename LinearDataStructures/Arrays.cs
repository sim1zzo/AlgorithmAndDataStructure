using System;

namespace LinearDataStructures
{
    public class Arrays
    {
        private int[] items;
        private int count = 0;

        public Arrays(int length)
        {
            if (length < 0)
                throw new System.Exception("Lenght cannot be smaller than 0");
            items = new int[length];
        }

        public void Print()
        {
            if (count == 0)
                return;

            System.Console.Write("[");
            for(var i = 0; i < count; i++)
            {
                if(i == count - 1)
                {
                    Console.Write("{0}]\n", items[i]);
                    break;
                }
                Console.Write(items[i]+", ");
            }

        }
        public void Insert(int item)
        {
            ResizeIfRequired();
            items[count++] = item;
            
        }
        public void Reverse()
        {
            var reversedArr = new int[items.Length];
            for (int i = 0; i < count; i++)
                reversedArr[i] = items[count - i - 1];

            items = reversedArr;
        }
        public int Max()
        {
            if (IsEmpty())
                throw new Exception("Array has to have at least a value.");
            var max = Int32.MinValue;
            foreach(var i in items)
            {
                if (i > max)
                    max = i;
            }
            return max;
        }
        public int IndexOf(int item)
        {
            var index = -1;
            for(int i = 0; i < count; i++)
            {
                if (items[i] == item)
                    index = i;
            }
            return index;

        }
        public void InsertAtIndex(int index, int item)
        {
            if (index < 0 || index > count)
                throw new ArgumentException();

            ResizeIfRequired();

            for(int i = count-1; i >= index; i--)
                items[i + 1] = items[i];

            items[index] = item;
            count++;
            

        }

        // --- HELPER METHODS!!! ---
        private void ResizeIfRequired()
        {
            if(IsFull(items))
            {
                var newItems = new int[items.Length * 2];
                for(var i = 0; i < items.Length; i++)
                    newItems[i] = items[i];
                items = newItems; 
            }
        }
        private bool IsFull(int[] items) => count >= items.Length;
        private bool IsEmpty()
        {
            return count == 0;
        }



    }
}
