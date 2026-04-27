using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Security.AccessControl;
using System.Linq;
using System.Collections;

namespace ProjectEuler {
    class Soru1
    {
        public static long CalculateSum()
        {
            long sum = 0;
            for (int i = 0; i < 1000; i++) if (i % 3 == 0 || i % 5 == 0) sum += i;
            return sum; 
        }
    }
    class Soru2
    {
        public static long FibonacciSum()
        {
            long a = 0; long b = 1; long c;; long sum = a; int hedef = 4000000;
            while (a < hedef)
            {
                c = b + a; 
                a = b;
                b = c;
                if (a % 2 == 0) sum += a;
            }
            return sum;
        }
    }
    class Soru3
    {
        public static long PrimerNumber()
        {
            long target = 600851475143;
            long maxPrime = -1; long number = 2;

            while (target != 1)
            {
                if (target % number == 0)
                {
                    target = target / number;
                    maxPrime = number;
                    continue;
                } 
                number++;
            }
            return maxPrime;
        }
    }
    class Soru4
    {
        public static long PolindromNumber()
        {
            int ust = 999; int alt = 100; int bigPolindrom = -1; int temp; 
            for (int i = ust; i > alt; i--)
            {
                for (int j = ust; j > alt; j--)
                {
                    temp = i * j; int sum = 0; int dump = temp;
                    while (temp != 0)
                    {
                        sum *= 10;
                        sum += temp % 10;
                        temp /= 10;
                    }
                    if (sum == dump)
                    {
                        if (bigPolindrom <= sum) bigPolindrom = sum;
                    }
                }
            }
            return bigPolindrom;
        }
    }
    class Soru5
    {
        public static long EKOK()
        {
            Dictionary<int, int> primeNums = new Dictionary<int, int>();
            long multiple = 1;
            for (int i = 20; i >= 2; i--)
            {
                int n = 2;
                Dictionary <int, int> dump = new Dictionary<int, int>();
                int a = i;
                while (a != 1)
                {
                    if (a % n == 0)
                    {
                        a /= n;
                        if (dump.ContainsKey(n)) dump[n]++;
                        else dump[n] = 1;
                        continue;
                    }
                    n++;
                }
                foreach (int j in dump.Keys)
                {
                    if (primeNums.ContainsKey(j))
                    {
                        if (dump[j] > primeNums[j]) primeNums[j] = dump[j];
                    }
                    else
                    {
                        primeNums[j] = dump[j];
                    }
                }
            }
            foreach (var primes in primeNums)
            {
                multiple *= (long) Math.Pow(primes.Key, primes.Value);
            }
            return multiple;
        }
    }
    class Soru6
    {
        private static long SquareSum(int limit)
        {
            long sum = 0;
            for (int i = 0; i <= limit; i++) sum += (long) Math.Pow(i, 2);
            return sum;
        }
        private static long TotalSquare(int limit)
        {
            long total = 0;
            for (int i = 0; i <= limit; i++) total += i;
            return (long) Math.Pow(total, 2);
        }
        public static long Diff()
        {    
        int limit = 100;
        long smallNumber = SquareSum(limit);
        long bigNumber = TotalSquare(limit);
        return bigNumber - smallNumber;
        }
    }
    class Soru7
    {
        private static bool IsPrime(int number)
        {
            int i = 2;
            int numberRoot = (int) Math.Pow(number, 0.5) + 1;
            while (numberRoot > i)
            {
                if (number % i == 0) return false;
                i++;
            }
            return true;
        }
        public static int Prime10001()
        {
            int sira = 0;
            int i = 2;
            while (true)
            {
                if (IsPrime(i)) sira++;
                if (sira == 10001) return i;
                i++;
            }
        }
    }    
    class Soru8
    {
        public static long LargestProduct()
        {
            string number = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450";            
            long maxProduct = 0;
            for (int i = 0; i < number.Length - 12; i++)
            {
                long currentProduct = 1;
                for (int j = i; j < i + 13; j++)
                {
                    int digit = number[j] - '0';
                    currentProduct *= digit;
                }
                if (currentProduct > maxProduct) maxProduct = currentProduct;
            }
            return maxProduct;
        }
    }
    class Soru9
    {
        public static long ProductABC()
        {
            int target = 1000;
            for (int a = 1; a < target; a++)
            {
                for (int b = 1; b < a; b++)
                {
                    int c = target - a - b;
                    if ((int) Math.Pow(c, 2) == (int) Math.Pow(b, 2) + (int) Math.Pow(a, 2)) return a * b * c;
                }
            }
            return -1;
        }
    }
    class Soru10
    {
        private const int limit = 2000000; // sabit olduğu için const yaptık.
        private static bool[] Primes = new bool[limit+1];
        public static long EratostenKalburu()
        {
            Primes[0] = true;
            Primes[1] = true; 
            long totalPrimers = 0;
            int i = 2;
            while (i <= limit)
            {
                int j = i;
                if (!Primes[j])
                {
                    totalPrimers += j;
                    while(j + i < limit)
                    {
                        j += i;
                        Primes[j] = true;
                    }
                }
                i++;
            }
            return totalPrimers;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Soru10.EratostenKalburu());
        }
    }
}