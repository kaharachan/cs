/*Nguyễn Quang Linh Bài 5
 */
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace Bai5
{
    internal class bai_5_chuong_2
    {
        //
        public struct THUVIEN
        {
            public string maSach;
            public string tuaSach;
            public int namXuatBan;
            public double gia;

            public THUVIEN(string maSach, string tuaSach, int namXuatBan, double gia)
            {
                this.maSach = maSach;
                this.tuaSach = tuaSach;
                this.namXuatBan = namXuatBan;
                this.gia = gia;
            }
            public string SachInfo()
            {
                return $"Mã sách: {maSach} \nTựa sách: {tuaSach} \nNăm xuất bản: {namXuatBan} \nGía: {gia}";
            }
        }

        internal class QUANLY
        {
            public static void SACH(THUVIEN[] arr)
            {
                string maSach, tuaSach;
                int nam = 0;
                int gia = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Sách thứ [{0}]", i + 1);

                    while (true)
                    {
                        Console.Write("Nhập mã sách (tối đa 6 kí tự): ");
                        maSach = Console.ReadLine();

                        string check = @"^[A-Za-z0-9]{6}$";

                        if (maSach.Length > 6 || maSach.Length < 6)
                        {
                            Console.WriteLine("Quá 6 kí tự hoặc nhỏ hơn");
                        }
                        else
                        {
                            arr[i].maSach = maSach;
                            break;
                        }
                    }
                    while (true)
                    {
                        Console.Write("Nhập tựa sách (tối đa 30 kí tự): ");
                        tuaSach = Console.ReadLine();

                        if (tuaSach.Length > 30)
                        {
                            Console.WriteLine("Quá 30 kí tự");
                        }
                        else
                        {
                            arr[i].tuaSach = tuaSach;
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.Write("Năm xuất bản: ");
                        if (int.TryParse(Console.ReadLine(), out nam) && nam < 1990)
                        {
                            Console.WriteLine("Năm sai");
                        }
                        else
                        {
                            arr[i].namXuatBan = nam;
                            break;
                        }
                    }

                    while (true)
                    {
                        Console.Write("Giá: ");
                        int.TryParse(Console.ReadLine(), out gia);

                        if (gia > 999999)//6
                        {
                            Console.WriteLine("Giá sai");
                        }
                        else
                        {
                            arr[i].gia = gia;
                            break;
                        }
                    }
                }    
            }
            /*public static void XuatAllSach(THUVIEN[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Thông tin Sách thứ: {0}",i + 1);
                    Console.WriteLine(arr[i].SachInfo());
                }    
            }*/

            public static void XuatSach(THUVIEN sach)
            {
                Console.WriteLine("--------");
                Console.WriteLine("Thông tin Sách");
                Console.WriteLine("Mã sách: " + sach.maSach);
                Console.WriteLine("Tựa sách: " + sach.tuaSach);
                Console.WriteLine("Năm xuất bản: " + sach.namXuatBan);
                Console.WriteLine("Giá: " + sach.gia);
            }

            public static int TimKiemTuanTu(THUVIEN[] arr, string tuaSach)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].tuaSach == tuaSach)
                    {
                        return i;
                    }    
                }    
                return -1;
            }
            public static int TimKiemNhiPhan(THUVIEN[] arr, string maSach)//tìm kiếm nhị phân
            {
                int left = 0;
                int right = arr.Length - 1;
                int mid;

                while (left <= right)
                {
                    //chia đôi
                    mid = (left + right) / 2;
                    if (arr[mid].maSach == maSach)
                    {
                        return mid;
                    }
                    else if (String.Compare(maSach, arr[mid].maSach) < 0)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                return -1;
            }

            public static void SuaGIa(THUVIEN[] arr, int viTri)
            {
                if (viTri >= 0 && viTri < arr.Length)//có
                {
                    int gia = 0;
                    while(true)
                    {
                        Console.Write("Nhập giá mới: ");
                        int.TryParse(Console.ReadLine(), out gia);

                        if (gia > 999999)
                        {
                            Console.WriteLine("Vượt mệnh giá");
                        }
                        else
                        {
                            arr[viTri].gia = gia;
                            break;
                        }
                    }
                    Console.WriteLine("Giá sách sau khi sửa");
                    XuatSach(arr[viTri]);
                }    
                else Console.WriteLine("Không tìm thấy vị trí");
            }
            public static void XoaSach(THUVIEN[] arr, int viTri)
            {
                if (viTri >= 0 && viTri < arr.Length)//có trong mảng
                {
                    for (int i = viTri + 1; i < arr.Length; i++)
                    {
                        arr[i - 1] = arr[i];
                    }
                    Array.Resize(ref arr, arr.Length - 1);

                    Console.WriteLine("Sách sau khi xóa");
                    XuatSach(arr[viTri]);
                }
                else Console.WriteLine("Không tìm thấy vị trí");
            }
        }

        //main
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");

            int n;
            while (true)
            {
                Console.Write("số lượng sách: ");
                
                if (!int.TryParse(Console.ReadLine(), out n) | n < 1)
                {
                    Console.WriteLine("sai");
                }   
                else
                {
                    break;
                }    
            }

            THUVIEN[] arrTV = new THUVIEN[n];

            QUANLY.SACH(arrTV);

            //sắp xếp 
            Array.Sort(arrTV, (x, y) => string.Compare(x.maSach, y.maSach));

            //
            Console.Write("Nhập mã tựa sách cần tìm: ");
            string? tuaSach = Console.ReadLine();
            int viTri = QUANLY.TimKiemTuanTu(arrTV, tuaSach);
            if (viTri != -1)
            {
                QUANLY.XuatSach(arrTV[viTri]);
                //sửa giá sách
                QUANLY.SuaGIa(arrTV,viTri);
            }
            else
                Console.WriteLine("Không tìm thấy");
            //
            Console.Write("Nhập mã mã sách cần tìm: ");
            string? maSach = Console.ReadLine();
            int viTri2 = QUANLY.TimKiemNhiPhan(arrTV, maSach);
            if (viTri2 != -1)
            {
                QUANLY.XuatSach(arrTV[viTri2]);
                //xóa giá sách
                QUANLY.XoaSach(arrTV, viTri2);
            }
            else
                Console.WriteLine("Không tìm thấy");


        }
    }
}
