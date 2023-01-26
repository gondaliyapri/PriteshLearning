using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriteshLearning
{
    public class LRUNode
    {
        public int Key;
        public int Value;
        public LRUNode next;
        public LRUNode prev;

        public LRUNode(int key, int val, LRUNode next = null, LRUNode prev = null)
        {
            this.Key = key;
            this.Value = val;
            this.next = next;
            this.prev = prev;
        }
    }

    public class LRUCache
    {
        private Dictionary<int, LRUNode> map;
        private int size;
        private LRUNode head;
        private LRUNode tail;
        private int capacity;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.head = new LRUNode(0, 0);
            this.tail = new LRUNode(0, 0);
            head.next = tail;
            tail.prev = head;
            head.prev = null;
            tail.next = null;
            size = 0;
            this.map = new Dictionary<int, LRUNode>();
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {
                LRUNode LRUNode = map[key];
                int result = LRUNode.Value;
                RemoveLRUNode(LRUNode);
                AddLRUNodeHead(LRUNode);
                return result;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                var LRUNode = map[key];
                LRUNode.Value = value;
                RemoveLRUNode(LRUNode);
                AddLRUNodeHead(LRUNode);
            }
            else
            {
                var LRUNode = new LRUNode(key, value);
                map.Add(key, LRUNode);

                if (size >= capacity)
                {
                    map.Remove(tail.prev.Key);
                    RemoveLRUNode(tail.prev);
                    AddLRUNodeHead(LRUNode);
                }
                else
                {
                    size++;
                    AddLRUNodeHead(LRUNode);
                }
            }
        }

        private void RemoveLRUNode(LRUNode LRUNode)
        {
            LRUNode.prev.next = LRUNode.next;
            LRUNode.next.prev = LRUNode.prev;
        }

        private void AddLRUNodeHead(LRUNode LRUNode)
        {
            LRUNode.next = head.next;
            LRUNode.next.prev = LRUNode;
            LRUNode.prev = head;
            head.next = LRUNode;
        }

        static void Main()
        {
            LRUCache obj = new LRUCache(2);
            obj.Put(1, 1);
            obj.Put(2, 2);
            Console.WriteLine(obj.Get(1));
            obj.Put(3, 3);
            Console.WriteLine(obj.Get(2));
            obj.Put(4, 4);
            Console.WriteLine(obj.Get(1));
            Console.WriteLine(obj.Get(3));
            Console.WriteLine(obj.Get(4));
        }
    }
}
