namespace Tcraft.Ace.Api.Core
{
    public static class Utils
    {
        /// <summary>
        /// Generates a list of prime numbers up to a specified limit using the Sieve of Eratosthenes algorithm.
        /// </summary>
        /// <param name="limit">The upper limit for prime numbers to be generated.</param>
        /// <returns>A list of prime numbers up to the specified limit.</returns>
        public static List<int> GeneratePrimesUpToLimit(int limit)
        {
            var primes = new List<int>();
            var sieve = new bool[limit + 1];
            for (var i = 2; i <= limit; i++)
            {
                if (sieve[i]) continue;
                primes.Add(i);
                for (var j = i * i; j <= limit; j += i)
                {
                    sieve[j] = true;
                }
            }
            return primes;
        }

        /// <summary>
        /// Calculates the nth Fibonacci number.
        /// </summary>
        /// <param name="n">The position in the Fibonacci sequence to calculate. The position is 0-indexed.</param>
        /// <returns>The nth Fibonacci number.</returns>
        public static long Fibonacci(int n)
        {
            var fibNumbers = new List<long> { 0, 1 };

            while (fibNumbers.Count <= n)
            {
                var previous = fibNumbers[^1];
                var nextToLast = fibNumbers[^2];
                fibNumbers.Add(previous + nextToLast);
            }

            return fibNumbers[n];
        }
    }
}
