using System.Reflection.PortableExecutable;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System;
namespace LinearDataStructures
{

    public class LinkedList
    {
        internal class Node
        {
            internal int Value;
            internal Node Next;

            public Node(int value)
            {
                Value = value;
            }

            public override string ToString()
            {
                return $"value: {Value}";
            }
        }
        private int count;
        private Node first;
        private Node last;

        public void AddLast(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
                first = last = node;
            else
            {
                last.Next = node;
                last = node;
            }
            count++;
        }
        public void AddFirst(int value)
        {
            var node = new Node(value);
            if (IsEmpty())
                first = last = node;
            else
            {
                node.Next = first;
                first = node;

            }
            count++;


        }
        public int[] ToArray()
        {
            var array = new int[count];
            var current = first;
            int index = 0;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }
            return array;
        }
        public int IndexOf(int value)
        {
            if (IsEmpty())
                return -1;
            var current = first;
            int index = 0;
            while (current != null)
            {
                if (current.Value == value)
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }
        public bool Contains(int item)
        {
            return IndexOf(item) >= 0;
        }
        public void RemoveFirst()
        {
            var second = first.Next;
            if (IsEmpty())
                throw new System.Exception();
            if (count == 1)
                first = last = null;
            else
            {
                first.Next = null;
                first = second;
            }
            count--;
        }
        public void RemoveLast()
        {
            if (IsEmpty())
                throw new System.Exception();

            if (HasSingleNode())
                first = last = null;
            else
            {
                var previous = GetPreviousNode(last);
                last = previous;
                last.Next = null;
            }

        }
        public void Reverse()
        {
            if (IsEmpty())
                return;

            var previous = first;
            var current = first.Next;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            last = first;
            last.Next = null;
            first = previous;
        }

        public int GetKthFromTheEnd(int k)
        {
            if(IsEmpty())
                throw new SystemException();
            var head = first;
            var tail = first;
            for (var i = 0; i < k-1; i++)
            {
                tail = tail.Next;
                if(tail == null)
                    throw new SystemException();
            }
            while(tail != last)
            {
                head = head.Next;
                tail = tail.Next;
            }
            return head.Value;
        }




        // --- Helper Methods!!! ---
        private bool IsEmpty()
        {
            return first == null;
        }
        private bool HasSingleNode()
        {
            return first == last;
        }
        private Node GetPreviousNode(Node node)
        {
            var current = first;
            while (current != null)
            {
                if (current.Next == node) return current;

            }
            return null;
        }

    }
}
