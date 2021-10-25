using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnumerables
{
    public static class MyLinq
    {
        public static IEnumerable<K> Tivchar<T, K>(this IEnumerable<T> source, Func<T, K> selector)
        {
            foreach (var item in source)
            {
                var res = selector(item);
                yield return res;
            }
        }
    }
}
