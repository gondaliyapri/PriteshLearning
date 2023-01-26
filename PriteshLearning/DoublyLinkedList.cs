using System;
using System.ComponentModel.Design;

namespace PriteshLearning
{
    class ListNode
    {
        public int Element;
        public ListNode Next;
        public ListNode Prev;

        public ListNode(int e, ListNode n, ListNode p)
        {
            Element = e;
            Next = n;
            Prev = p;
        }
    }

    class DoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;
        private int size;

        public DoublyLinkedList()
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

        public void AddLast(int e) // O(1)
        {
            var node = new ListNode(e, null, null);
            if (IsEmpty())
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                node.Prev = tail;
                tail = node;
            }

            size++;
        }

        public void AddFirst(int e)
        {
            var node = new ListNode(e, null, null);
            if (IsEmpty())
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Prev = node;
                head = node;
            }

            size++;
        }

        public void Add(int e, int position) // O(n)
        {
            if (position > size || position <= 0)
            {
                Console.WriteLine("Invalid position given.");
            }
            else if (position == 1)
            {
                AddFirst(e);
            }
            else if (position == size)
            {
                AddLast(e);
            }
            else
            {
                var node = new ListNode(e, null, null);
                if (IsEmpty())
                {
                    head = node;
                    tail = node;
                }
                else
                {
                    var ptr = head;
                    int i = 1;
                    while (i < position - 1)
                    {
                        ptr = ptr.Next;
                        i++;
                    }

                    node.Next = ptr.Next;
                    ptr.Next.Prev = node;
                    ptr.Next = node;
                    node.Prev = ptr;
                }
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty()) return;

            tail = tail.Prev;
            tail.Next = null;

            size--;

            if (IsEmpty())
                head = null;
        }

        public void RemoveFirst()
        {
            if (IsEmpty()) return;

            head = head.Next;
            head.Prev = null;

            size--;

            if (IsEmpty())
                tail = null;
        }

        public void Remove(int position)
        {
            if (position > size || position <= 0)
            {
                Console.WriteLine("Invalid position given.");
            }
            else if (position == 1)
            {
                RemoveFirst();
            }
            else if (position == size)
            {
                RemoveLast();
            }
            else
            {
                var ptr = head;
                int i = 1;

                while(i < position - 1)
                {
                    ptr = ptr.Next;
                    i++;
                }

                ptr.Next = ptr.Next.Next;
                ptr.Next.Prev = ptr;
                size--;
            }
        }

        public void Search()
        {
        }

        public void SortedInsert(int element)
        {
        }

        public void Display() // O(n)
        {
            var ptr = head;

            while (ptr != null)
            {
                Console.Write(ptr.Element + " -> ");
                ptr = ptr.Next;
            }
        }

        //static void Main()
        //{
        //    DoublyLinkedList list = new DoublyLinkedList();
        //    list.AddLast(2);
        //    list.AddLast(3);
        //    list.AddLast(5);
        //    list.AddFirst(1);
        //    list.AddLast(6);
        //    list.AddFirst(0);
        //    list.Add(4, 5);
        //    list.Add(-1, 1);
        //    list.Remove(1);
        //    Console.WriteLine("Size: " + list.Length());
        //    list.Display();
        //    Console.ReadLine();
        //}
    }
}
