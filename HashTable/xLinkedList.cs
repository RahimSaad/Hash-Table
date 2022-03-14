using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class xLinkedList<K,V>
    {
        private KeyValuePair<K, V> head;
        private KeyValuePair<K, V> tail;
        private int size;
        public KeyValuePair<K,V> Head { get => head; }
        public KeyValuePair<K,V> Tail { get => tail; }
        public int Size { get => size; }

        public xLinkedList()
        {
            this.size = 0;
        }

        public void addNode(KeyValuePair<K, V> node)
        {
            if (head == null) { head = node; tail = node; }
            else
            {
                tail.next = node;
                tail = node;
            }
            this.size++;
        }

        public V find(K key)
        {
            KeyValuePair<K, V> ptr = head;
            while (ptr != null)
            {
                if(ptr.key.Equals(key))
                {
                    return ptr.value;
                }
                ptr = ptr.next;
            }
            return ptr.value;
        }

        public bool isExist(K key)
        {
            KeyValuePair<K, V> ptr = head;
            while (ptr != null)
            {
                if (ptr.key.Equals(key))
                {
                    return true;
                }
                ptr = ptr.next;
            }
            return false;
        }

        internal void Display()
        {
            if (this.isEmpty()) { return; }
            KeyValuePair<K, V> ptr = head;
            while (ptr != null)
            {
                Console.Write("key = {0} , value = {1} \t", ptr.key, ptr.value);
                ptr = ptr.next;
            }
            Console.WriteLine("");
        }

        public bool remove(K key)
        {
            if (head.key.Equals(key))
            {
                head = head.next;
            }
            KeyValuePair<K, V> ptr = head;
            while (ptr.next != null)
            {
                if (ptr.next.key.Equals(key))
                {
                    ptr = ptr.next.next;
                    return true;
                }
                ptr = ptr.next;
            }
            return false;
        }

        public bool isEmpty() => head == null;

    }
}
