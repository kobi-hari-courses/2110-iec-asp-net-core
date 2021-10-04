using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreFun
{
    public static class PrimesCalculator
    {
        public static bool IsPrime(this int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static List<int> GetAllPrimes(int first, int last)
        {
            return Enumerable.Range(first, last - first + 1)
                             .Where(i => i.IsPrime())
                             .ToList();

            //for (int i = 2;  i <= number; i ++)
            //{
            //    if (i.IsPrime()) yield return i;
            //}
        }

        public static List<int> GetAllPrimesInParallel(int first, int last)
        {
            return Enumerable.Range(first, last - first + 1)
                             .AsParallel()
                             .Where(i => i.IsPrime())
                             .ToList();
        }

        public static Task<List<int>> GetAllPrimesAsync(int first, int last)
        {
            return Task.Factory.StartNew(() => GetAllPrimes(first, last));
        }

        public static Task<List<int>> GetAllPrimesInParallelAsync(int first, int last)
        {
            return Task.Factory.StartNew(() => GetAllPrimesInParallel(first, last));
        }
    }
}
