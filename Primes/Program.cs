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
       // int n = 99;
        Console.Write(" Input Int: ");
        int n = Convert.ToInt32(Console.ReadLine());
        var primes = await FindPrimesAsync(n);

        Console.WriteLine("count: " + primes.Count);
        foreach (int i in primes)
        {
            Console.WriteLine(i + " ");
        }
    }

    static async Task<ConcurrentBag<int>> FindPrimesAsync(int n)
    {
        ConcurrentBag<int> ints = new();
        for (int i = 0; i < n; i++)
        {
            if (IsPrimeNumber(i))
            {
                ints.Add(i);
            }
        }

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