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
        public int val;
        public int key;
        public LRUNode next;
        public LRUNode pre;

        public LRUNode(int val, int key, LRUNode next = null, LRUNode pre = null)
        {
            this.val = val;
            this.key = key;
            this.next = next;
            this.pre = pre;
        }
    }

    public class LRUCache
    { 
        private int count;
        private int capacity;
        private LRUNode head;
        private LRUNode tail;
        private Dictionary<int, LRUNode> map;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            count = 0;
            head = new LRUNode(0, 0);
            tail = new LRUNode(0, 0);

            head.next = tail;
            tail.pre = head;
            
            head.pre = null;
            tail.next = null;

            map = new Dictionary<int, LRUNode>();
        }

        public void AddHead(LRUNode node)
        {
            node.next = head.next;
            head.next = node;
            node.pre = head;
            node.next.pre = node;
        }

        public void RemoveNode(LRUNode node)
        {
            node.pre.next = node.next;
            node.next.pre = node.pre;
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {
                var node = map[key];
                var result = node.val;

                RemoveNode(node);
                AddHead(node);

                return result;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (map.ContainsKey(key))
            {
                var node = map[key];
                node.val = value;
                RemoveNode(node);
                AddHead(node);
            }
            else
            {
                LRUNode node = new LRUNode(value, key);
                map.Add(key, node);

                if (count < capacity)
                {
                    count++;
                    AddHead(node);
                }
                else
                {
                    map.Remove(tail.pre.key);
                    RemoveNode(tail.pre);
                    AddHead(node);
                }
            }            
        }

        //static void Main()
        //{
        //    LRUCache obj = new LRUCache(1);
        //    obj.Put(2, 1);
        //    Console.WriteLine(obj.Get(2));
        //}
    }
}