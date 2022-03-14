using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class KeyValuePair<K, V>
    {
        public K key;
        public V value;
        public bool isDeleted;
        public KeyValuePair<K, V> next;
        public KeyValuePair(K key, V value)
        {
            this.key = key;
            this.value = value;
            this.isDeleted = false;
            this.next = null;
        }
    }
}
