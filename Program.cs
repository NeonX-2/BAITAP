using System;
using System.IO;
using System.Text; 

namespace Baitap1
{
   
    public class DevideByZeroException : Exception
    {
        public DevideByZeroException() : base("Lỗi: Chia cho 0. Không thể tính giá trị biểu thức.") { }
        public DevideByZeroException(string message) : base(message) { }
        public DevideByZeroException(string message, Exception inner) : base(message, inner) { }
    }

    public class NotNegativeException : Exception
    {
        public NotNegativeException() : base("Lỗi: Giá trị dưới dấu căn nhỏ hơn 0. Không thể tính căn bậc hai của số âm.") { }
        public NotNegativeException(string message) : base(message) { }
        public NotNegativeException(string message, Exception inner) : base(message, inner) { }
    }

    internal class Program
    {
        public static double CalculateH(int x, int y)
        {
            
            double numerator = 3 * x + 2 * y;
            double denominator = 2 * x - y;

            
            if (denominator == 0)
            {
                throw new DevideByZeroException();
            }

           
            double valueInsideSqrt = numerator / denominator;

            
            if (valueInsideSqrt < 0)
            {
                throw new NotNegativeException();
            }

           
            return Math.Sqrt(valueInsideSqrt);
        }

        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;

            int x = 0;
            int y = 0;
            bool validInputX = false;
            bool validInputY = false;

            
            while (!validInputX)
            {
                Console.Write("Nhập số nguyên x: ");
                string? inputX = Console.ReadLine();
                if (string.IsNullOrEmpty(inputX))
                {
                    Console.WriteLine("Lỗi: Đầu vào không được để trống.");
                    continue;
                }
                try
                {
                    x = int.Parse(inputX);
                    validInputX = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Đầu vào không hợp lệ. Vui lòng nhập số nguyên cho x.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Lỗi: Số quá lớn hoặc quá nhỏ. Vui lòng nhập số nguyên hợp lệ cho x.");
                }
            }

            
            while (!validInputY)
            {
                Console.Write("Nhập số nguyên y: ");
                string? inputY = Console.ReadLine();
                if (string.IsNullOrEmpty(inputY))
                {
                    Console.WriteLine("Lỗi: Đầu vào không được để trống.");
                    continue;
                }
                try
                {
                    y = int.Parse(inputY);
                    validInputY = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi: Đầu vào không hợp lệ. Vui lòng nhập số nguyên cho y.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Lỗi: Số quá lớn hoặc quá nhỏ. Vui lòng nhập số nguyên hợp lệ cho y.");
                }
            }

            double? resultH = null;

            try
            {
                resultH = CalculateH(x, y);
                Console.WriteLine($"Giá trị của H = {resultH}");

                
                try
                {
                    File.WriteAllText("input.txt", $"x = {x}\ny = {y}\nH = {resultH}\n", Encoding.UTF8);
                    Console.WriteLine("Kết quả đã được lưu vào file input.txt");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Lỗi khi ghi file input.txt: {ex.Message}");
                }
            }
            catch (DevideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotNegativeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi không mong muốn: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}