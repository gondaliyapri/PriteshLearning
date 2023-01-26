using System;

namespace PriteshLearning
{
    class CircularLinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public CircularLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public int Length()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public void AddLast(int element) // O(1)
        {
            Node node = new Node(element, null);
            if (IsEmpty())
            {
                node.Next = node;
                head = node;
            }
            else
            {
                node.Next = tail.Next;
                tail.Next = node;
            }

            tail = node;
            size++;
        }

        public void AddFirst()
        {
        }

        public void Add(int e, int position)
        {
        }

        public void RemoveLast()
        {
        }

        public void RemoveFirst()
        {
        }

        public void Remove(int e, int position)
        {
        }

        public void Search()
        {
        }

        public void SortedInsert(int element)
        {
        }

        public void Display() // O(n)
        {
            if (size >= 0)
            {
                var n = head;
                int i = 0;
                while (i < Length())
                {
                    Console.Write(n.Element + " -> ");
                    n = n.Next;
                    i++;
                }
            }
        }

        //static void Main()
        //{
        //    CircularLinkedList list = new CircularLinkedList();
        //    list.AddLast(7);
        //    list.AddLast(4);
        //    list.AddLast(12);
        //    list.AddLast(8);
        //    list.AddLast(3);
        //    Console.WriteLine("Size: " + list.Length());
        //    list.Display();
        //    Console.ReadLine();
        //}
    }
}
