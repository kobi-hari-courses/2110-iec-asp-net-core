using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MoreFun
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Here we go");
            var s = new Stopwatch();
            s.Start();

            var lowPrimesTask = PrimesCalculator.GetAllPrimesAsync(1, 100000);
            var highPrimesTask = PrimesCalculator.GetAllPrimesAsync(100001, 200000);

            var primesTask = Task.WhenAll(new[] { lowPrimesTask, highPrimesTask });

            var primes = (await primesTask)
                .SelectMany(i => i)
                .ToList();

            s.Stop();
            Console.WriteLine($"There are {primes.Count} primes");
            Console.WriteLine($"It took {s.ElapsedMilliseconds} millis to calculate it");
        }
    }
}
