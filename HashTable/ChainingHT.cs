using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class ChainingHT<K,V>
    {
        private int Capacity , Size;
        private float Threshold;
        private xLinkedList<K, V>[] arr;
    
        public ChainingHT()
        {
            this.Capacity = 10;
            this.Size = 0;
            this.Threshold = 0.75f;
            this.arr = new xLinkedList<K, V>[Capacity];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = new xLinkedList<K, V>();
            }
        }

        public  int getHash(K key)
        {
            return (Math.Abs(key.GetHashCode()) % Capacity);
        }

        public void put(K key , V value)
        {
            if ((Size / Capacity) > Threshold)
            {
                reHash(Capacity*2);
            }
            int idx = getHash(key);
            if (arr[idx].isExist(key)) { return; }
            arr[idx].addNode(new KeyValuePair<K, V>(key,value));
            Size++;
        }

        public void remove(K key)
        {
            int idx = getHash(key);
            if (arr[idx].remove(key)) { Size--; }
        }

        public bool get(K key , out V xValue)
        {
            xValue = arr[getHash(key)].find(key);
            return (xValue == null) ? false : true;
        }

        public void Display()
        {
            foreach (xLinkedList<K,V> LL in arr)
            {
                LL.Display();
            }
        }
    
        private void reHash(int newCapacity)
        {
            this.Capacity = newCapacity;
            xLinkedList<K, V>[] tmp = new xLinkedList<K, V>[newCapacity];
            for(int i = 0; i< newCapacity; i++)
            {
                tmp[i] = new xLinkedList<K, V>();
            }
            
            for(int k = 0; k<arr.Length; k++)
            {
                KeyValuePair<K, V> ptr = arr[k].Head;
                while(ptr != null)
                {
                    tmp[getHash(ptr.key)].addNode(ptr);
                    ptr = ptr.next;
                }
            }
            this.arr = tmp;
        }

    }
}
