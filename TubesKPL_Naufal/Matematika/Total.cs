using System;
using System.Transactions;

namespace Matematika
{
    public class Total 
    { 
        public static int Keseluruhan(int a, int b)
        {
            return a * b;
        }
        public static int Total_Belanja(int a, int b, int c, int d)
        {
            return a + b + c + d;
        }
    }
}