//
// Домашнее задание к занятию 23. Асинхронное программирование.
//
// Задача 1. Разработать асинхронный метод для вычисления факториала числа.
// В методе Main выполнить проверку работы метода.
//


namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер факториала: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n)) { Console.WriteLine("Ошибка ввода. "); }
            Console.WriteLine();
            if (n > 12)
            {
                Console.WriteLine("Очень большое число");
                n = 12;
                Console.WriteLine();
            }
            else if (n <0) 
            {
                Console.WriteLine("Введено отрицательное число");
               n=0;
            }
            else if (n==0)
            {
                Console.WriteLine("Факториал 0!=1");
                n = 0;
            }

            SumAsync(n);

            for (int i = 1; i < n + 1; i++)
                {
                    int factN = Factorial(i);
                    Console.WriteLine("Факториал {0}!={1}", i, factN);
                }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Конец программы");
            Console.ReadKey();
        }
        static int Factorial(int n)
        {
            if (n == 1) return 1;

            return n * Factorial(n - 1);
        }
        static void Sum(int n)
        {
            int s = 1;
            for (int i = 1; i < n+1; i++)
            {
                s=s*i;
                Thread.Sleep(1000);
                Console.WriteLine("Факториал Sum {0}!={1}", i, s);
            }

        }
        static async void SumAsync(int n)
        {
           await Task.Run(()=>Sum(n));
        }
    }
}

