using System;

namespace PriteshLearning
{
    class LinkedList
    {
        private Node head;
        private Node tail;
        private int size;

        public LinkedList()
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
            Node newNode = new Node(e, null);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                tail.Next = newNode;
            }

            tail = newNode;
            size++;
        }

        public void AddFirst(int e) // O(1)
        {
            Node newNode = new Node(e, null);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }

            size++;
        }

        public void Add(int e, int position) // O(n)
        {
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("Invalid Position");
                return;
            }

            Node newNode = new Node(e, null);
            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else if (position == 1)
            {
                newNode.Next = head;
                head = newNode;
            }
            else if (position == size)
            {
                tail.Next = newNode;
            }
            else
            {
                Node p = head;
                int i = 1;

                while (i < position - 1)
                {
                    p = p.Next;
                    i++;
                }

                newNode.Next = p.Next;
                p.Next = newNode;
            }

            size++;
        }

        public void Display() // O(n)
        {
            Node p = head;

            while (p != null)
            {
                Console.Write(p.Element + "\n");
                p = p.Next;
            }
        }

        public void RemoveFirst() // O(n)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty.");
                return;
            }

            head = head.Next;
            size--;

            if (IsEmpty())
            {
                tail = null;
            }
        }

        public void RemoveLast() // O(n)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty.");
                return;
            }

            if (size == 1)
            {
                head = null;
                tail = null;
                size = 0;
                return;
            }

            int i = 1;
            var e = head;
            while (i < size - 1)
            {
                e = e.Next;
                i++;
            }

            tail = e;
            tail.Next = null;
            size--;
        }

        public void Remove(int position) // O(n)
        {
            if (position <= 0 || position > size)
            {
                Console.WriteLine("Invalid Position");
                return;
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
                var element = head;
                int i = 1;
                while (i < position - 1)
                {
                    element = element.Next;
                    i++;
                }

                element.Next = element.Next.Next;
            }
        }

        public int Search(int key) // O(n)
        {
            if (size <= 0)
            {
                return -1;
            }

            var e = head;
            int index = 1;
            while (e != null)
            {
                if (e.Element == key)
                    return index;

                e = e.Next;
                index++;
            }

            return -1;
        }

        public void AddSorted(int e) // O(n)
        {
            Node newNode = new Node(e, null);
            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                Node p = head;
                Node q = head;

                while (p != null && p.Element < e)
                {
                    q = p;
                    p = p.Next;
                }

                if (p == head)
                {
                    newNode.Next = head;
                    head = newNode;
                }
                else
                {
                    newNode.Next = q.Next;
                    q.Next = newNode;
                }
            }

            size++;
        }

        #region Main method
        //static void Main()
        //{
        //    LinkedList list = new LinkedList();
        //    list.AddSorted(1);
        //    list.AddSorted(2);
        //    list.AddSorted(3);
        //    list.AddSorted(4);
        //    list.AddSorted(5);
        //    list.AddSorted(0);
        //    //list.Add(-1, 1);
        //    //list.Add(20, 3);
        //    //list.Add(21, 3);
        //    list.Display();
        //    Console.WriteLine("Size: " + list.Length());
        //    Console.WriteLine("Index of element 4 is: " + list.Search(4));

        //    Console.WriteLine("---");
        //    list.Remove(4);
        //    list.Display();

        //    Console.WriteLine("Size: " + list.Length());
        //    Console.ReadKey();
        //}
        #endregion
    }
}
