using System;
using System.Collections.Generic;
using System.Linq;

namespace FunWithEnumerables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IEnumerable<int> myEnumerable = CreateSqueareNumbers()
                .Where(i => i % 2 == 0)
                .Select(i => i * -1)
                .OrderBy(i => i % 10);


            var type = myEnumerable.GetType();
            Console.WriteLine(type.Name);

            //var enum1 = myEnumerable.GetEnumerator();

            //while (enum1.MoveNext())
            //{
            //    var item = enum1.Current;
            //    Console.WriteLine(item);
            //}

            //enum1.Dispose();

            while (true)
            {

                foreach (var item in myEnumerable)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }

        public static IEnumerable<int> CreateSqueareNumbers()
        {
            var i = 1;
            while (i <= 30)
            {
                yield return i * i;
                i++;
            }
        }
    }
}
