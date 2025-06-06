﻿using System.Globalization;
using System.Text;

namespace bai2_chuong3
{
    internal class bai_2_chuong_3
    {
        //struct
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
                return $"Mã sách: {maSach} \nTựa sách: {tuaSach} \nNăm xuất bản: {namXuatBan} \nGiá: {gia}";
            }
        }
        public class QUANLY
        {
            //input
            public static void NhapSach(THUVIEN[] arr)
            {
                string maSach, tuaSach;
                int namXuatBan = 0;
                double gia = 0;
                DateTime ngayMua;

                for (int i = 0; i < arr.Length; i++)
                {
                    //sách thứ i
                    Console.WriteLine("Nhập thông tin cho sách thứ: [{0}]", i + 1);

                    //mã sách
                    while (true)
                    {
                        Console.Write("Nhập mã sách: ");
                        maSach = Console.ReadLine();
                        if (maSach.Length < 0 || maSach.Length > 6)
                        {
                            Console.WriteLine("Mã sách không thể nhỏ hoặc lớn 6 kí tự");
                        }
                        else
                        {
                            arr[i].maSach = maSach;
                            break;
                        }
                    }

                    //tựa sách
                    while (true)
                    {
                        Console.Write("Nhập tựa sách: ");
                        tuaSach = Console.ReadLine();
                        if (tuaSach.Length > 30)
                        {
                            Console.WriteLine("Quá 30 kí tự, vui lòng nhập lại");
                        }
                        else
                        {
                            arr[i].tuaSach = tuaSach;
                            break;
                        }
                    }

                    //năm xuất
                    while (true)
                    {
                        Console.Write("Nhập năm xuất bản: ");
                        if (!int.TryParse(Console.ReadLine(), out namXuatBan) || namXuatBan < 1990)
                        {
                            Console.WriteLine("Năm xuất bản phải là số nguyên và lớn hơn 1990");
                        }
                        else
                        {
                            arr[i].namXuatBan = namXuatBan;
                            break;
                        }
                    }

                    //giá
                    while (true)
                    {
                        Console.Write("Nhập giá: ");
                        if (!double.TryParse(Console.ReadLine(), out gia) || gia > 999999)
                        {
                            Console.WriteLine("Giá phải là số nguyên và không thể lớn hơn 6 chữ số");
                        }
                        else
                        {
                            arr[i].gia = gia;
                            break;
                        }
                    }
                }
            }

            //xuat
            public static void XuatSach(THUVIEN[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("------Thông tin sách------");
                    Console.WriteLine(arr[i].SachInfo());
                }    
            }

            //xuat sau sap xep
            public static void XuatSachSapXep(THUVIEN[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("--------Sách sau sắp xếp--------");
                    Console.WriteLine("Mã sách: " + arr[i].maSach);
                    Console.WriteLine("Tựa sách: " + arr[i].tuaSach);
                    Console.WriteLine("Năm xuất bản: " + arr[i].namXuatBan);
                    Console.WriteLine("Giá: " + arr[i].gia);
                }
            }

            ///mã sách | tăng
            public static void SapXepTangDanSelectionSort(THUVIEN[] arr)
            {
                int min;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    min = i;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (String.Compare(arr[j].maSach, arr[min].maSach) < 0)//tăng dần
                        {
                            min = j;
                        }    
                    }
                    THUVIEN temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Sách sau khi tăng dần từ mã sách");
                QUANLY.XuatSachSapXep(arr);
            }

            //năm xuất bản | giảm
            public static void SapXepGiamDanInsertionSort(THUVIEN[] arr)
            {
                int j;
                THUVIEN key;
                for (int i = 1; i < arr.Length; i++)
                {
                    key = arr[i];
                    j = i - 1;
                    
                    while (j >= 0 && key.namXuatBan > arr[j].namXuatBan)//giảm dần
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }

                    //đặt key vào
                    arr[j + 1] = key;
                }
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Sách sau khi giảm dần từ năm xuất bản");
                QUANLY.XuatSachSapXep(arr);
            }

            //tựa sách | tăng
            public static void SapXepTangDanBubbleSort(THUVIEN[] arr)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = arr.Length -1; j > i; j--)
                    {
                        if (String.Compare(arr[j -1].tuaSach, arr[j].tuaSach) < 0)//tăng dần
                        {
                            THUVIEN temp = arr[j];
                            arr[j] = arr[j - 1];
                            arr[j - 1] = temp;
                        }    
                    }    
                }
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Sách sau khi tăng dần từ tựa sách");
                QUANLY.XuatSachSapXep(arr);
            }

            //giá | giảm
            public static void SapXepGiamDanQuickSort(THUVIEN[] arr, int left, int right)
            {
                if (left >= right) return;

                int i = left, j = right;
                double mid = arr[(left + right) / 2].gia;

                while (i <= j)
                {
                    while (arr[i].gia > mid) i++;
                    while (arr[j].gia < mid) j--;

                    if (i <= j)
                    {
                        //hoán vị arr[j] và arr[i]
                        THUVIEN temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                        i++; j--;
                    }
                }

                SapXepGiamDanQuickSort(arr, left, j);
                SapXepGiamDanQuickSort(arr, i, right);
            }
            public static void SapXepGiaGiamDan(THUVIEN[] arr)
            {
                SapXepGiamDanQuickSort(arr, 0, arr.Length - 1);
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Sách sau khi giảm dần theo giá");
                QUANLY.XuatSachSapXep(arr);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");

            int n = 0;

            while (true)
            {
                Console.Write("Nhập số lượng sách: ");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine("Phải là số nguyên");
                }
                else break;
            }

            THUVIEN[] thuVien = new THUVIEN[n];

            //input sach
            QUANLY.NhapSach(thuVien);

            //output
            QUANLY.XuatSach(thuVien);

            //tăng dần mã sách
            QUANLY.SapXepTangDanSelectionSort(thuVien);

            //giảm dần năm xuất
            QUANLY.SapXepGiamDanInsertionSort(thuVien);

            //Tăng dần theo tựa sách
            QUANLY.SapXepTangDanBubbleSort(thuVien);

            //giảm dần theo giá
            QUANLY.SapXepGiaGiamDan(thuVien);
        }
    }
}
