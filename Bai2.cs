using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyMatHang
{
    
    struct MatHang
    {
        public int MaMH;
        public string TenMH; 
        public int SoLuong;
        public float DonGia;

        public MatHang(int MaMH, string TenMH, int SoLuong, float DonGia)
        {
            this.MaMH = MaMH;
            this.TenMH = TenMH;
            this.SoLuong = SoLuong;
            this.DonGia = DonGia;
        }
        public float ThanhTien()
        {
            return SoLuong * DonGia;
        }
    }

    class Program
    {
        static void ThemMatHang(Dictionary<int, MatHang> danhSach, MatHang m)
        {
            if (!danhSach.ContainsKey(m.MaMH))
            {
                danhSach.Add(m.MaMH, m); 
                Console.WriteLine($"Sản phẩm '{m.TenMH}' (Mã: {m.MaMH}) đã được thêm thành công.");
            }
            else
            {
                Console.WriteLine($"Lỗi: Sản phẩm có mã {m.MaMH} đã tồn tại.");
            }
        }

        static bool TimMatHang(Dictionary<int, MatHang> danhSach, int MaMH)
        {
            return danhSach.ContainsKey(MaMH);
        }

        static void XuatDanhSach(Dictionary<int, MatHang> danhSach)
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách mặt hàng trống.");
                return;
            }

            Console.WriteLine("\n--- Danh sách Mặt hàng ---");
            Console.WriteLine("{0,-10} {1,-25} {2,-10} {3,-15} {4,-15}", "MaMH", "TenMH", "SoLuong", "DonGia", "ThanhTien");
            

            
            foreach (KeyValuePair<int, MatHang> entry in danhSach)
            {
                MatHang m = entry.Value;
                Console.WriteLine("{0,-10} {1,-25} {2,-10} {3,-15} {4,-15}",
                                  m.MaMH, m.TenMH, m.SoLuong, m.DonGia, m.ThanhTien());
            }
            
        }
        static void XoaMatHang(Dictionary<int, MatHang> danhSach, int MaMH)
        {
            if (TimMatHang(danhSach, MaMH))
            {
                MatHang m = danhSach[MaMH]; 
                danhSach.Remove(MaMH);
                Console.WriteLine($"Sản phẩm '{m.TenMH}' (Mã: {MaMH}) đã được xóa thành công.");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sản phẩm có mã {MaMH}. Không thể xóa.");
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Dictionary<int, MatHang> danhSachMatHang = new Dictionary<int, MatHang>();
            string continueInput = "y";

            
            Console.WriteLine("--- Nhập thông tin Mặt hàng ---");
            while (continueInput.ToLower() == "y")
            {
                int maMH;
                string? tenMHInput; 
                int soLuong;
                float donGia;

                Console.Write("Nhập Mã Mặt hàng (số nguyên): ");
                while (!int.TryParse(Console.ReadLine(), out maMH))
                {
                    Console.Write("Đầu vào không hợp lệ. Vui lòng nhập số nguyên cho Mã Mặt hàng: ");
                }

                Console.Write("Nhập Tên Mặt hàng (chuỗi): ");
                tenMHInput = Console.ReadLine();
                string tenMH = tenMHInput ?? string.Empty; 


                Console.Write("Nhập Số lượng (số nguyên): ");
                while (!int.TryParse(Console.ReadLine(), out soLuong))
                {
                    Console.Write("Đầu vào không hợp lệ. Vui lòng nhập số nguyên cho Số lượng: ");
                }

                Console.Write("Nhập Đơn giá (số thực): ");
                while (!float.TryParse(Console.ReadLine(), out donGia))
                {
                    Console.Write("Đầu vào không hợp lệ. Vui lòng nhập số cho Đơn giá: ");
                }

                MatHang newMatHang = new MatHang(maMH, tenMH, soLuong, donGia);
                ThemMatHang(danhSachMatHang, newMatHang);

                Console.Write("Bạn có muốn tiếp tục thêm sản phẩm? (y/n): ");
                string? input = Console.ReadLine();
                continueInput = input ?? "n"; 
                Console.WriteLine();
            }

            
            XuatDanhSach(danhSachMatHang);

            
            Console.WriteLine("\n--- Xóa Mặt hàng ---");
            Console.Write("Nhập Mã Mặt hàng cần tìm và xóa: ");
            int maMHToDelete;
            while (!int.TryParse(Console.ReadLine(), out maMHToDelete))
            {
                Console.Write("Đầu vào không hợp lệ. Vui lòng nhập số nguyên cho Mã Mặt hàng: ");
            }

            if (TimMatHang(danhSachMatHang, maMHToDelete))
            {
                Console.WriteLine($"Đã tìm thấy sản phẩm có mã {maMHToDelete}. Đang xóa...");
                XoaMatHang(danhSachMatHang, maMHToDelete);
                Console.WriteLine("\nDanh sách mặt hàng sau khi xóa:");
                XuatDanhSach(danhSachMatHang);
            }
            else
            {
                Console.WriteLine($"Không tìm thấy sản phẩm có mã {maMHToDelete}. Không thực hiện xóa.");
            }
            Console.ReadKey();
        }
    }
}