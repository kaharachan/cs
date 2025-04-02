using System.Text;

namespace Bubble_sort
{
    internal class cac_tuan_tu_sap_xep
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Hello, World!");
            int[] a =
            {
                8, 5, 6, 3, 10, 4, 3
                //1, 4, 5, 3, 2, 13, 15, 9
            };
            int[] b =
            {
                1, 4, 5, 3, 2, 13, 15, 9
            };
            int[] c =
            {
                1, 4, 5, 3, 2, 13, 15, 9
            };
            int[] d =
            {
                1, 4, 5, 3, 2, 13, 15, 9
            };
            int[] e =
            {
                1, 4, 5, 3, 2, 13, 15, 9
            };

            Console.WriteLine("---------------Selection sort tăng---------------");
            Console.WriteLine("Sắp xếp theo kiểu đặt min tại vị trí i, rồi tìm từ trái -> phải, Nếu có j nhỏ hơn min thì");
            Console.WriteLine("đặt min = j đó. Rồi temp sẽ bằng min và min bằng i rồi i bằng temp");
            Console.WriteLine("Duyệt từ 0 đến i nhỏ hơn mảng -1 (for i = 0; i < mang - 1; i++)");
            Console.WriteLine("-Đặt min là vị trí i, sau đó j(i+1) bắt đầu tìm từ trái qua phảs cho tới cuối mảng.");
            Console.WriteLine("-Nếu j trong mảng (arr[j]) mà lớn hơn min trong mảng (arr[min]) | thì đặt min = j");
            Console.WriteLine("-Sau đó temp sẽ bằng phần tử min trong mảng (temp = arr[min]), ");
            Console.WriteLine("-p.tử min trong mảng sẽ thay vào phần tử i trong mảng (arr[min] = arr[i]) =>> hoán đổi");
            Console.WriteLine("-Lúc này i trong mảng sẽ bằng temp (arr[i] = temp)");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            int min, tempA;
            for (int i = 0; i < a.Length - 1; i++)
            {
                min = i;//đặt min = i | đặt min vào vị trí hiện tại
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[min])
                    {
                        min = j;//lưu vị trí j hiện tại vào min
                    }    
                }    
                tempA = a[min];
                a[min] = a[i];
                a[i] = tempA;
                //temp = min, min sẽ hoán đổi vị trí cho mảng i, i sẽ bằng temp(temple là j =>> thứ tự mảng i đổi cho j)
                //và hết 1 vòng lặp, lặp tiếp i++, lúc này j đứng sau i(j = i+1) rồi tìm tiếp, nếu i>j thì cho j = min, temp = min, và i = temp
                //(cho j = i nhưng qua biến temp)
            }    
            foreach (int i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n--");

            //
            Console.WriteLine("---------------Insertion sort tăng---------------");
            Console.WriteLine("Sắp xếp theo kiểu i và trước i. Luôn đặt i là 1 để so sánh i và trước i (i-1)");
            Console.WriteLine("Duyệt từ i bằng i đến i nhỏ hơn mảng (for i = 0; i < mang; i++)");
            Console.WriteLine("-Đặt key là mảng của i (key = arr[i]), đặt j là trước i(j = i -1). Sử dụng vLặp while,");
            Console.WriteLine("-Nếu j >= 0 && key < arr[j] thì mảng của j+1 sẽ bằng mảng j | arr[j + 1] = arr[j] =>> đẩy vị trí j qua phải");
            Console.WriteLine("j sẽ -1 (j--), để tìm tiếp nếu j vẫn còn lớn hơn key");
            Console.WriteLine("Cách hiểu 2: Nếu thỏa while thì mảng của j+1 sẽ bằng mảng của j (arr[j + 1] = arr[j]) =>> di chuyển nó qua phải");
            Console.WriteLine(" j sẽ -1 để tìm tiếp nếu vẫn còn phần tử j lớn hơn key");
            Console.WriteLine("-Nếu j nhỏ hơn hoặc bằng 0 và key lớn hơn j trong mảng(arr[j]) thì thoát vòng lặp while đó đi");
            Console.WriteLine("Sau đó đặt mảng của j +1 sẽ bằng key (arr[j + 1] = key");
            //Console.WriteLine("Bắt đầu từ 1, cho key = phần tử của 1, so sánh j(i - 1) là 0) với 1 | nếu j > 1 thì đẩy j qua phải và đưa key vào j");
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
            Console.WriteLine();
            
            int indexB, pos;//indexB là vị trí trong mảng
            int key;//lưu vị trí cho i
            for (indexB = 1; indexB < b.Length; indexB++)//bắt đầu từ 1
            {
                key = b[indexB];//lưu phần tử của mảng cần sắp xếp vào key
                pos = indexB - 1;//tìm vị trí trong i nhỏ hơn key để chèn key vào
                
                while (pos >= 0 && key < b[pos])//di chuyển vị trí mảng lớn hơn qua phải để có chỗ trống đặt key vào
                {
                    b[pos + 1] = b[pos];//lấy trước pos gán cho pos =>> di chuyển sang phải
                    pos--;//tiếp tục kiểm tra
                }
                //cho key vào vị trí 
                b[pos + 1] = key;
            }    
            foreach (int i in b)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n--");

            //
            Console.WriteLine("---------------Bubble sort---------------");
            Console.WriteLine("sắp xếp từ cuối mảng lên đầu mảng");
            Console.WriteLine("i = 0, j = cuối arr -1");//kiểm tra từ cuối của i(j) lên gần i, nếu i > j thì hoán đổi.
            for (int i = 0; i < c.Length; i ++)
            {
                Console.Write(c[i] + " ");
            }
            Console.WriteLine();
            
            for (int i = 0; i < c.Length - 1; i++)
            {
                for (int j = c.Length - 1; j > i; j--)//bắt đầu so sánh từ cuối mảng =>> j = arr.length -1
                {
                    if (c[j] < c[j - 1])//nếu trước j(j-1) mà lớn hơn j. thì cho j vào temp, j sẽ bằng trước j(j-1) và đặt trước j(j-1) bằng temp.
                    {
                        int tempC = c[j];
                        c[j] = c[j - 1];
                        c[j - 1] = tempC;
                    }    
                }      
            }  
            foreach (int i in c)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n--");

            //tang dan
            Console.WriteLine("---------------Interchange sort tang---------------");
            Console.WriteLine("i = 0, j = i + 1");//đặt i = 0 và j tìm từ trái qua phải(i+1), nếu j < i thì hoán đổi j với i, sau đó j tìm tiếp tại vị trí đó.
            //nếu j gặp số lớn hơn i (j < i) thì j sẽ hoán đổi j bằng i. Nếu đã hết 1 vòng for (lenght -1) thì i = 1, j sẽ = i+1. và tiếp cho tới hết.
            for (int i = 0; i < d.Length; i++)
            {
                Console.Write(d[i] + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < d.Length - 1; i++)
            {
                for (int j = i + 1; j <= d.Length - 1; j++)
                {
                    if (d[j] < d[i])
                    {
                        int tempD = d[j];
                        d[j] = d[i];
                        d[i] = tempD;
                    }
                }
            }
            foreach (int i in d)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n--");

            //giam dan
            Console.WriteLine("---------------Interchange sort giam---------------");
            for (int i = 0; i < e.Length; i++)
            {
                Console.Write(e[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < e.Length - 1; i++)
            {
                for (int j = i + 1; j <= e.Length - 1; j++)
                {
                    if (e[j] > e[i])
                    {
                        int tempE = e[j];
                        e[j] = e[i];
                        e[i] = tempE;
                    }
                }
            }

            foreach (int i in e)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n--");
        }
    }
}
