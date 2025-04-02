using System.Text;

namespace giai_bai_ktr_dthuan
{
    internal class giai_bai_ktra_dthuan
    {
        public struct HANGHOA
        {
            public string maHang;
            public string tenHang;
            public int soLuong;
            public double donGia;

            public HANGHOA(string maHang, string tenHang, int soLuong, double donGia)
            {
                this.maHang = maHang;
                this.tenHang = tenHang;
                this.soLuong = soLuong;
                this.donGia = donGia;
            }

            public string hangHoaInfo()
            {
                return $"Mã hàng: {maHang}  \ntên hàng: {tenHang}  \nsố lượng: {soLuong}  \nđơn giá: {donGia}";
            }
        }

        public class QUANLY
        {
            public static void NhapHangHoa(HANGHOA[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Nhập thông tin cho hàng hóa thứ [{0}]", i + 1);
                    Console.Write("Nhập mã hàng: ");
                    arr[i].maHang = Console.ReadLine();
                    Console.Write("tên hàng: ");
                    arr[i].tenHang = Console.ReadLine();
                    while (true)
                    {
                        Console.Write("Số lượng: ");
                        if (!int.TryParse(Console.ReadLine(), out arr[i].soLuong))
                        {
                            Console.WriteLine("Phải là số nguyên");
                        }    
                        else
                        {
                            break;
                        }    
                    }
                    while (true)
                    {
                        Console.Write("Đơn giá: ");
                        if (!double.TryParse(Console.ReadLine(), out arr[i].donGia))
                        {
                            Console.WriteLine("Phải là số thực");
                        }
                        else break;
                    }
                }    
            }

            //out hang hoa
            public static void XuatHangHoa(HANGHOA[] arr)
            {
                Console.WriteLine("------Thông tin hàng hóa------");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i].hangHoaInfo());
                }    
            }

            //sắp xếp tên hangf tăng dần
            public static void SapXepTenHang(HANGHOA[] arr)
            {
                int min;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    min = i;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (string.Compare(arr[j].tenHang, arr[min].tenHang) < 0)
                        {
                            min = j;
                        }    
                    }    
                    
                    HANGHOA temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
                Console.WriteLine("----Danh sách [tên hàng] tăng dần-----");
                QUANLY.XuatHangHoa(arr);
            }

            //sắp xếp số lượng giảm dần
            public static void SapXepSoLuong(HANGHOA[] arr)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = arr.Length - 1; j > i; j--)
                    {
                        if (arr[j - 1].soLuong < arr[j].soLuong)
                        {
                            HANGHOA temp = arr[j];
                            arr[j] = arr[j -1];
                            arr[j - 1] = temp;
                        }    
                    }    
                }
                Console.WriteLine("----Danh sách [số lượng] giảm dần-----");
                QUANLY.XuatHangHoa(arr);
            }

            //tìm x tên hàng
            public static int TimKiemTenHangX(HANGHOA[] arr, string tenHang)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].tenHang.ToLower() == tenHang.ToLower())
                        return i;
                }    
                return -1;
            }

            //public sửa số lượng hàng
            public static void SuaSoLuongDonHang(HANGHOA[] arr, int viTri)
            {
                if (viTri >= 0 && viTri < arr.Length)
                {
                    while(true)
                    {
                        Console.Write("Nhập số lượng mới: ");
                        if (!int.TryParse(Console.ReadLine(), out arr[viTri].soLuong))
                        {
                            Console.WriteLine("Phải là số nguyên");
                        }    
                        else break;
                    }    
                }
                else Console.WriteLine("Vị trí mà bạn tìm để sửa số lượng: không hợp lệ");

                Console.WriteLine("---Số lượng của đơn hàng sau khi sửa---");
                Console.WriteLine(arr[viTri].hangHoaInfo());
            }

            //tìm kiếm mã hàng (nhị phân)
            public static int TimMaHangNhiPhan(HANGHOA[] arr, string maHang)
            {
                int left = 0;
                int right = arr.Length - 1;
                int mid;

                while (left <= right)
                {
                    mid = (left + right) / 2;
                    if (arr[mid].maHang == maHang)
                    {
                        return mid;
                    }    
                    else if (string.Compare(maHang, arr[mid].maHang) < 0)
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

            //xóa hàng hóa đã tìm
            public static void XoasHangHoa(HANGHOA[] arr, int viTri)
            {
                if (viTri >= 0 && viTri < arr.Length)
                {
                    for (int i = viTri + 1; i < arr.Length; i++)
                    {
                        arr[i - 1] = arr[i];
                    }

                    //Array.Reverse(arr);
                    Array.Resize(ref arr, arr.Length -1);

                    Console.WriteLine("----Danh sách hàng hóa sau khi đã xóa-----");
                    Console.WriteLine(arr[viTri].hangHoaInfo());
                }
                else Console.WriteLine("Vị trí mà bạn tìm để xóa: không hợp lệ");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");

            int n = 0;

            while (true)
            {
                Console.Write("Nhập số lượng hàng hóa: ");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("phải là số nguyên");
                }    
                else break;
            }

            HANGHOA[] hanghoa = new HANGHOA[n];

            //input
            QUANLY.NhapHangHoa(hanghoa);

            //output
            QUANLY.XuatHangHoa(hanghoa);

            //tên hàng tăng dần
            QUANLY.SapXepTenHang(hanghoa);

            //số lượng giảm dần
            QUANLY.SapXepSoLuong(hanghoa);

            Console.Write("Nhập [tên hàng] cần tìm để sửa: ");
            string x = Console.ReadLine();
            int viTri = QUANLY.TimKiemTenHangX(hanghoa, x);

            if (viTri != -1)
            {
                QUANLY.SuaSoLuongDonHang(hanghoa, viTri);
            }    
            else Console.WriteLine("Vị trí [tên hàng] không tồn tại");

            //
            Console.Write("Nhập [mã hàng] cần tìm để xóa: ");
            string maHang = Console.ReadLine();
            int viTri2 = QUANLY.TimMaHangNhiPhan(hanghoa, maHang);

            if (viTri2 != -1)
            {
                QUANLY.XoasHangHoa(hanghoa, viTri2);
            }
            else Console.WriteLine("Vị trí [mã hàng] không tồn tại");
        }
    }
}
