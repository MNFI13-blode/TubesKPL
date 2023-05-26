using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Class1
    {
        private Dictionary<string, int> items = new Dictionary<string, int>();

        public void MasukanItem(string namaItem, int jumlah)
        {

            if (items.ContainsKey(namaItem))
            {
                items[namaItem] += jumlah;
            }
            else
            {

                items[namaItem] = jumlah;
            }


        }
        


        public void TampilkanItem()
        {
            Console.WriteLine("\nBarang yang terdapat di keranjang");

            foreach (KeyValuePair<string, int> item in items)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }
        }
     
    }


}