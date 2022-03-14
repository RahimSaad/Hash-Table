using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            ChainingHT<string, string> ht = new ChainingHT<string, string>();
            ht.put("x1", "abdelrahim");
            ht.put("x2", "shimaa");
            ht.put("x3", "basma");
            ht.put("x4", "nisma");

            string ss ;
            if(ht.get("x3", out ss))
            {
                Console.WriteLine(ss);
            }
            ht.Display();
            

        }
    }
}
