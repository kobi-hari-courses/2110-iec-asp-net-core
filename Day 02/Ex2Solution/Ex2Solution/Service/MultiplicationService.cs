using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ex2Solution.Service
{
    public class MultiplicationService
    {
        public int[,] CreateTable(int size)
        {
            var res = new int[size, size];

            for (int i = 1; i <= size; i++)
            {
                for (int j = 1; j <= size; j++)
                {
                    res[i - 1, j - 1] = i * j;
                }
            }

            return res;
        }
    }
}
