using System;
using System.Security.Cryptography;
using Matematika;

namespace Keranjan
{
    public class Program
    {
        enum State { START, ADD, REMOVE, CHECKOUT }
        static void Main(string[] args)
        {
            Console.WriteLine("Command yang bisa dipakai: ");
            Console.WriteLine("1. add      = tambah barang");
            Console.WriteLine("2. remove   = kurangi barang");
            Console.WriteLine("3. checkout = akhiri belanjaan (selesai)");
            Console.WriteLine("Barang yang tersedia pensil, pulpen, water colour, dan writing book");
            Console.WriteLine("Masukkan START untuk memulai");
            int pulpen = 0;
            int pensil = 0;
            int water_colour = 0;
            int writing_book = 0;
            int total = 0;

            State keadaan = State.START;
            while (keadaan != State.CHECKOUT)
            {
                Console.WriteLine("Masukkan permintaan : ");
                string perintah = Console.ReadLine();
                switch (keadaan)
                {
                    case State.START:
                        if (perintah == "add")
                        {
                            keadaan = State.ADD;
                        }
                        else if (perintah == "remove")
                        {
                            keadaan = State.REMOVE;
                        }
                        else if (perintah == "checkout")
                        {
                            keadaan = State.CHECKOUT;
                        }
                        else
                        {
                            keadaan = State.START;
                        }
                        break;
                    case State.ADD:
                        Console.WriteLine("Masukkan barang yang ingin dibeli: ");
                        string barang = Console.ReadLine();
                        Console.WriteLine("Masukkan total barang yang kamu tambahkan");
                        string All = Console.ReadLine();
                        if (int.TryParse(All, out int nomor))
                        {
                            if (nomor >= 0)
                            {
                                if (barang == "pulpen")
                                {
                                    pulpen += nomor;
                                }
                                else if (barang == "pensil")
                                {
                                    pensil += nomor;
                                }
                                else if (barang == "water colour")
                                {   
                                    water_colour += nomor;
                                }
                                else if (barang == "writing book")
                                {
                                    writing_book += nomor;
                                }
                        }
                            else
                            {
                                Console.WriteLine("Maaf, angka yang dimasukkan tidak boleh negatif");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Inputan harus berupa angka, jadi tolong masukkan angka lagi");
                            All = Console.ReadLine();
                        }
                        keadaan = State.START;
                        break;
                    case State.REMOVE:
                        Console.WriteLine("Masukkan barang yang ingin dibeli: ");
                        barang = Console.ReadLine();
                        Console.WriteLine("Masukkan total barang yang kamu ingin kurangi");
                        All = Console.ReadLine();
                        if (int.TryParse(All, out nomor))
                        {
                            if (nomor >= 0)
                            {
                                if (barang == "pulpen")
                                {
                                    pulpen -= nomor;
                                }
                                else if (barang == "pensil")
                                {
                                    pensil -= nomor;
                                }
                                else if (barang == "water colour")
                                {
                                    water_colour -= nomor;
                                }
                                else if (barang == "writing book")
                                {
                                    writing_book -= nomor;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Maaf, angka yang dimasukkan tidak boleh negatif");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Inputan harus berupa angka, jadi tolong masukkan angka lagi");
                            All = Console.ReadLine();
                        }
                        keadaan = State.START;
                        break;
                }
            }
            Console.WriteLine("Barang yang dibeli adalah");
            Console.WriteLine("Pulpen       = " + pulpen);
            Console.WriteLine("Pensil       = " + pensil);
            Console.WriteLine("Water Colour = " + water_colour);
            Console.WriteLine("Writing Book = " + writing_book);
            Console.WriteLine("Menghitung total belanjaan...");
            int pulpen1 = Total.Keseluruhan(10000, pulpen);
            int pensil1 = Total.Keseluruhan(10000, pensil);
            int water_colour1 = Total.Keseluruhan(10000, water_colour);
            int writing_book1 = Total.Keseluruhan(10000, writing_book);
            total = Total.Total_Belanja(pulpen1, water_colour1, writing_book1, pensil1);
            Console.WriteLine(total);
        }
    }
}

