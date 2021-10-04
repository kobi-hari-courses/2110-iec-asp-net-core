using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithTpl
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

        public static List<int> GetAllPrimesUpTo(int number)
        {
            return Enumerable.Range(2, number - 1)
                             .Where(i => i.IsPrime())
                             .ToList();

            //for (int i = 2;  i <= number; i ++)
            //{
            //    if (i.IsPrime()) yield return i;
            //}
        }

        public static Task<List<int>> GetAllPrimesAsync(int number)
        {
            return Task.Factory.StartNew(() => GetAllPrimesUpTo(number));
        }
    }
}
