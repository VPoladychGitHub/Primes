/*Створіть метод, який знаходить всі прості числа від 2 до n, та зберігає їх у колекції

var primes = await FindPrimesAsync(n);
Метод має перевіряти коже з чисел від 1 до n в окремому потоці
    (знаю, що є більш оптимальні алгоритми, але завдання таке). Створіть 3 реалізації метода
    (через Thread, Task, та Parallel.ForEach).

60 - будь - яка одна реалізація
75 - дві реалізація
95 - три реалізації
100 - 4 реалізації (четверта через алгоритм що перевіряє всі числа на простоту одночасно, 
і в одному потоці, а не кожне окремо)
*/

using System.Collections.Concurrent;

class Program
{

    static async Task Main()
    {
        var thread = new Thread(proc);
        thread.Start();
        thread.Join();


        async void proc()
        {
            Console.Write(" Input Int: ");
            int n = Convert.ToInt32(Console.ReadLine());
            //int n = 99;
            var primes = await FindPrimesAsync(n);
            // var primes = FindPrimesAsync(n);
            foreach (int t in primes)
            {
                Console.Write($"{t}   ");
            }

        }
    }

    static async Task<ConcurrentBag<int>> FindPrimesAsync(int n)
    {
        ConcurrentBag<int> ints = new();
        Console.WriteLine("Простые числа из диапазона ({0}, {1})", 0, n);
        for (int i = 0; i < n; i++)
        {
            if (IsPrimeNumber(i))
            {
                ints.Add(i);
            }
        }
        //  Console.WriteLine($"count: {ints.Count} ");
        return ints;
    }

    static bool IsPrimeNumber(int n)
    {
        var result = true;

        if (n > 1)
        {
            for (var i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    result = false;
                    break;
                }
            }
        }
        else
        {
            result = false;
        }

        return result;
    }
}