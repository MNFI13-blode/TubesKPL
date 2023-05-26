using System;
using ClassLibrary1;

class Program
{
    static void Main(string[] args)
    {
        Class1 Belanja = new Class1();

        while (true)
        {
            Console.WriteLine("Masukan nama barang :");
            string barang = Console.ReadLine();
            
            if (barang == "")
            {
                break;

            }

            Console.WriteLine("Masukan jumlah barang :");
            
            int jumlah = int.Parse(Console.ReadLine());

            Belanja.MasukanItem(barang, jumlah);
        }
        Belanja.TampilkanItem();
        Console.ReadLine();
    }
}
