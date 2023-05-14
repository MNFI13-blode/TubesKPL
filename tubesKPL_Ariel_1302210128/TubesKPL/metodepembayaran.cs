﻿using System;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace TubesKPL
{
    public class metodepembayaran
    {
        //table driven
        public enum caraBayar
        {
            COD,
            TFBank,
            qris
        }

        public string getPenjelasan(caraBayar a)
        {
            string[] metode = { "silahkan menunggu barang sampai ke tangan anda lalu bayar", "pilih bank lalu masukkan 9 digit angka dari nomor rekening", "silahkan melanjutkan aktifitas" };

            int indeks = (int)a;
            return metode[indeks];
        }

        //eksekusia
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            metodepembayaran newqr = new metodepembayaran();
            Console.WriteLine("Masukkan 3 angka terserah tanpa spasi untuk verifikasi manusia");
            string q = Console.ReadLine();
            Console.WriteLine(newqr.pembayaranOTP(q));
            Console.WriteLine(" ");

            Console.WriteLine("Pilih Cara Pembayaran:");
            Console.WriteLine("1. Cash on delivery");
            Console.WriteLine("2. Transfer Bank");
            Console.WriteLine("3. QRIS");
            Console.WriteLine(" ");
            Console.Write("Masukkan angka menu: ");
            string inputs = Console.ReadLine();
            Console.WriteLine(" ");
           

            if (inputs == "1")
            {
                string CaraBayar = newqr.getPenjelasan(caraBayar.COD);
                Console.WriteLine(CaraBayar);
            }
            else if (inputs == "2")
            {
                string CaraBayar = newqr.getPenjelasan(caraBayar.TFBank);
                Console.WriteLine(CaraBayar);
                pilihBank();
                kejelasan();
            }
            else if (inputs == "3")
            {
                string CaraBayar = newqr.getPenjelasan(caraBayar.qris);
                Console.WriteLine("masukkan 3 digit OTP tanpa spasi");
                string i = Console.ReadLine();
                Console.WriteLine(newqr.qrOTP(i));
                Console.WriteLine(CaraBayar);
            }
            else
            {
                Console.WriteLine("Pilih pembayaran yang tersedia di menu");
            }
        }

        static void kejelasan()
        {
            Console.WriteLine("Masukkan nomor rekening");
            string input = Console.ReadLine();

            //desain by contract
            Debug.Assert(input.Length == 9, "Nomor kartu tidak memenuhi standar");

            //error handling
            try
            {
                int inputcek = Convert.ToInt32(input);
                Console.WriteLine("Terimakasih Pembayaran akan segera kami proses dilanjutkan dengan pengiriman barang anda");
            }
            catch (FormatException e)
            {
                Console.WriteLine("input harus berupa angka");
            }
        }

        public string qrOTP(string input)
        {
            int inputcek = Convert.ToInt32(input);

            if(inputcek > 99 && inputcek < 1000 )
            {
                return "ctrl + klik pada Link untuk mendapatkan kode QR: https://drive.google.com/file/d/1H4Yfvc_75mjGq_-z0Rf4kHVeCTZP4XnB/view";
            }
            return "kode tidak valid";
            
        }

        public string pembayaranOTP(string input)
        {
            int inputcek = Convert.ToInt32(input);

            if(inputcek > 99 && inputcek < 1000)
            {
                return "lanjutkan pembayaran";
            }
            else
            {
                Console.WriteLine("Kode tidak valid");
                Environment.Exit(0);
                return " ";
               
            }
        }


        //---------------------------------------------TEKNIK RUNTIME CONFIGURATION------------------------------------

        static void pilihBank()
        {
            
            List<biayaAdmin> listBiaya = new List<biayaAdmin>();
            listBiaya.Add(new biayaAdmin(" ", 0));
            listBiaya.Add(new biayaAdmin("BCA", 2500));
            listBiaya.Add(new biayaAdmin("BNI", 2000));
            listBiaya.Add(new biayaAdmin("BRI", 1500));
            listBiaya.Add(new biayaAdmin("MANDIRI", 1000));

            mengserialisasi(listBiaya);

            List<biayaAdmin> listbiaya = mengdeserialisasi<List<biayaAdmin>>("bank.json");
            
            Console.WriteLine(" ");
            Console.WriteLine("1. BCA");
            Console.WriteLine("2. BNI");
            Console.WriteLine("3. BRI");
            Console.WriteLine("4. MANDIRI");
            Console.WriteLine(" ");
            Console.Write("Pilih bank untuk melihat biaya admin: ");

            string i = Console.ReadLine();

            //DESAIN BY CONTRACT
            Debug.Assert(i.Length == 1, "input berlebihan");
            
            //ERROR HANDLING
            try
            {
                int inputcek = Convert.ToInt32(i);
                

                while (inputcek > 0 && inputcek <= 4)
                {
                    Console.WriteLine("nama bank : " + listbiaya[inputcek].NamaBank + " | " + "biaya admin: " + listbiaya[inputcek].Biaya);
                    Console.WriteLine(" ");
                    break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("input harus berupa angka");
                Environment.Exit(1);
            }
        }

        private static void mengserialisasi(Object obj)
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string hasil = JsonSerializer.Serialize(obj, options);
            File.WriteAllText(@"D:\vscode\C#\TubesKPL\TubesKPL\bank.json", hasil);
        }

        private static Tipe mengdeserialisasi<Tipe>(string input)
        {
            string jsonString = File.ReadAllText(@"D:\vscode\C#\TubesKPL\TubesKPL\bank.json");
            return JsonSerializer.Deserialize<Tipe>(jsonString);
        }
    }

    public class biayaAdmin
    {
        //PARSING
        public string NamaBank { get; set; }
        public int Biaya { get; set; }

        public biayaAdmin() { }

        public biayaAdmin(string nama, int biaya)
        {
            this.NamaBank = nama;
            this.Biaya = biaya;

        }
    }


    //-------------------------------------------------------------------------------------------------------------------
}

//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//tester


// 
/*string nomoratm = Console.ReadLine();
                    int a = nomoratm.Length;*/

//precondition
/*                Debug.Assert(a > 16, "Nomor ATM tidak Valid, tolong pastikan kembali nomor ATM yang anda gunakan");
                Debug.Assert(a < 16, "Nomor ATM tidak Valid, tolong pastikan kembali nomor ATM yang anda gunakan");*/
/*                                 
                    "Terimakasih Pembayaran dan Pengiriman akan segera kami proses"
 */
//error handling
//try
//{
/* 
 public class pilihbank
    {
        public pilihbank() { }

        public string dipilh(int inputcek)
        {
            Console.WriteLine(" ");
            Console.WriteLine("1. BCA");
            Console.WriteLine("2. BNI");
            Console.WriteLine("3. BRI");
            Console.WriteLine("4. MANDIRI");
            Console.WriteLine(" ");
            Console.Write("Masukkan angka dari list bank: ");

            

            if (inputcek <= 4 && inputcek >= 0)
            {
                return "pembayaran sedang berlangsung";
            }
            return "bank tidak terdaftar";
        }
    }
 */

/*bool c = checked(a == 16);
Console.WriteLine("Terimakasih Pembayaran dan Pengiriman akan segera kami proses");*/
//}
//catch
//{
//Console.WriteLine("Nomor ATM harus 16 digit");
//}