using System;

namespace ucln_ngaythang_snt.Models
{
    public class MayTinh
    {
        public int UCLN(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public int SoNgayTrongThang(int thang, int nam)
        {
            if (thang < 1 || thang > 12)
                throw new ArgumentOutOfRangeException("Tháng không hợp lệ");

            return thang switch
            {
                1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
                4 or 6 or 9 or 11 => 30,
                2 => (nam % 4 == 0 && (nam % 100 != 0 || nam % 400 == 0)) ? 29 : 28,
                _ => throw new ArgumentOutOfRangeException("Tháng không hợp lệ"),
            };
        }

        public int TongSoNguyenTo(int[] arr)
        {
            int sum = 0;
            foreach (var num in arr)
            {
                if (IsPrime(num))
                {
                    sum += num;
                }
            }
            return sum;
        }

        private bool IsPrime(int n)
        {
            if (n <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
}
