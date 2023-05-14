using System.Reflection.Metadata;
using System.Collections.Generic;
using System;
using System.Diagnostics.Contracts;

namespace MyApp.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inisialisasi objek user dan repository
            MyApp.Model.User user = new MyApp.Model.User();
            MyApp.Repository.UserRepository repository = new MyApp.Repository.UserRepository();

            // Meminta input username dan password dari pengguna
            Console.WriteLine("Masukkan username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Masukkan password: ");
            string password = Console.ReadLine();

            // Memasukkan input username dan password ke dalam objek user
            user.Username = username;
            user.Password = password;

            // Pre-condition: user tidak boleh kosong atau null
            Contract.Requires(user != null, "User tidak boleh kosong");

            // Memvalidasi user dan password
            bool isAuthenticated = repository.ValidateUser(user);

            // Post-condition: isAuthenticated harus benar jika user valid
            Contract.Ensures(isAuthenticated == true, "User tidak valid");

            // Menampilkan hasil autentikasi
            if (isAuthenticated)
            {
                Console.WriteLine("Login sukses!");

                while (true)
                {
                    Console.WriteLine("Ketik 'logout' untuk keluar");
                    string input = Console.ReadLine();

                    // Invariant: input tidak boleh kosong
                    Contract.Invariant(!string.IsNullOrEmpty(input), "Input tidak boleh kosong");

                    if (input == "logout")
                    {
                        Console.WriteLine("Logout berhasil!");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Username atau password anda salah silakan coba lagi.");
            }

            Console.ReadKey();
        }
    }
}
