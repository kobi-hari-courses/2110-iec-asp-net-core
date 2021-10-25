using System;
using System.Linq;
using System.Linq.Expressions;

namespace FunWithExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            AcceptingLambda(i => i.ToString());
            AcceptingLambda(i => $"{i} ----> {i}");

            AcceptingExpression(i => i.ToString());
            AcceptingExpression(i => $"{i} ----> {i}");

            DisectExpression((i, j) => (i + j) * (i - j));

            var e = Enumerable
                .Range(1, 10)
                .Where(i => i % 2 == 0)
                .Select(i => i * i);

            IQueryable<int> q = null;

            q
                .Where(i => i % 2 == 0)
                .Select(i => i * i);



        }

        public static void AcceptingLambda(Func<int, string> func)
        {
            var two = func(2);
            var three = func(3);

            Console.WriteLine(func);
        }

        public static void AcceptingExpression(Expression<Func<int, string>> exp)
        {
            Console.WriteLine(exp);

            var func = exp.Compile();
            var two = func(2);
            Console.WriteLine(two);
        }

        public static void DisectExpression(Expression<Func<int, int, int>> exp)
        {
            Console.WriteLine(exp);
        }
    }
}
