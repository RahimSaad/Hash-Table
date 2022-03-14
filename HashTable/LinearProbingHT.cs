using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class LinearProbingHT<K,V>
    {
        private int Capacity, Size;
        private float Threshold;
        private KeyValuePair<K, V>[] arr;
        public LinearProbingHT()
        {
            this.Capacity = 10;
            this.Size = 0;
            this.Threshold = 0.75f;
            this.arr = new KeyValuePair<K, V>[this.Capacity];
        }

        public int getHash(K key)
        {
            return (Math.Abs(key.GetHashCode()) % Capacity);
        }

        public void put(K key, V value)
        {
            if ((Size / Capacity) > Threshold)
            {
                reHash(Capacity * 2);
            }
            int idx = getHash(key);
            int stopPos = idx;
            if (isOccupied(idx))
            {
                if (arr[idx].isDeleted)
                {
                    arr[idx] = new KeyValuePair<K, V>(key, value);
                    Size++;
                    return;
                }
                if (arr[idx].key.Equals(key))
                {
                    return ;
                }
                idx = (idx + 1) % Capacity;
            }
            else
            {
                arr[idx] = new KeyValuePair<K, V>(key, value);
                Size++;
                return;
            }
            while (isOccupied(idx) && !arr[idx].isDeleted && idx != stopPos)
            {

                if (arr[idx].key.Equals(key))
                {
                    return ;
                }
                idx = (idx + 1) % Capacity;
            }
            if (isOccupied(idx) && !arr[idx].isDeleted) // idx == stopPos
            {
                throw new Exception("full");
            }
            else  // !isOccupied(idx) || arr[idx].isDeleted
            {
                arr[idx] = new KeyValuePair<K, V>(key, value);
                Size++;
            }
        }

        public bool remove(K key)
        {
            int idx = getHash(key);
            int stopPos = idx;
            if (arr[idx].key.Equals(key))
            {
                arr[idx].isDeleted = true;
                return true;
            }
            else
            {
                idx = (idx + 1) % Capacity;
            }
            while (isOccupied(idx) && idx != stopPos)
            {
                if (arr[idx].key.Equals(key))
                {
                    arr[idx].isDeleted = false;
                    return true;
                }
                idx = (idx + 1) % Capacity;
            }
            return false;
        }

        public bool isExist(K key)
        {
            int idx = getHash(key);
            int stopPos = idx;
            if (arr[idx].key.Equals(key))
            {
                return true;
            }
            else
            {
                idx = (idx + 1) % Capacity;
            }
            while(isOccupied(idx) && idx != stopPos)
            {
                if (arr[idx].key.Equals(key))
                {
                    return true;
                }
                idx = (idx + 1) % Capacity;
            }
            return false;
        }

        private bool isOccupied(int idx) => arr[idx] != null;

        private void reHash(int newCapacity)
        {
            this.Capacity = newCapacity;
            int tmpSize = 0;
            KeyValuePair<K, V>[] tmp = new KeyValuePair<K, V>[newCapacity];
            foreach(KeyValuePair<K,V> kvp in this.arr)
            {
                if(kvp != null && !kvp.isDeleted)
                {
                    tmpSize++;
                    tmp[getHash(kvp.key)] = kvp;
                }
            }
            this.Size = tmpSize;
            this.arr = tmp;
        }


    }
}
