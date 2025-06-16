using System;
using System.Collections.Generic;
using System.Globalization;

namespace BAITAP1_
{
    internal class Program
    {
        public static void RandomNum(int num)
        {
            if (num < 0)
            {
                Console.WriteLine("So luong phan tu lon hon 0.");
                return;
            }

            List<int> numbers = new List<int>();
            Random random = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < num; i++)
            {
                int value = random.Next(100);
                numbers.Add(value);
            }
            numbers.Sort();
            Console.WriteLine("Day so sau khi sap xep tang dan:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number + " ");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap so luong phan tu: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int n))
            {
                RandomNum(n);
            }
            else
            {
                Console.WriteLine("Nhap sai! Vui long nhap mot so nguyen.");
            }
        }
    }
}
