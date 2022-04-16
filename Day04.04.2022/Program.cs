using System;
using Common;

namespace Day04._04._2022
{
    class Program
    {
        static void Main()
        {
            Helper.ContinuousRun(Run);
        }

        static int Gcd(int a, int b)
        {
            while (b > 0)
                (a, b) = (b, a % b);
            return a;
        }

        static void Run()
        {
            var ans = 0;
            Console.WriteLine("Хотите сгенерировать все числа случайным образом? (y/n)");
            var isRnd = Console.ReadLine();
            if (isRnd == "y")
            {
                var rnd = new Random();
                var n = rnd.Next(1, 10);
                Console.WriteLine($"N: {n}");
                var xfirst = rnd.Next(-100, 100);
                var yfirst = rnd.Next(-100, 100);
                Console.WriteLine($"X: {xfirst} Y: {yfirst}");
                var yprev = yfirst;
                var xprev = xfirst;
                for (var i = 0; i < n - 1; i++)
                {
                    var x = rnd.Next(-100, 100);
                    var y = rnd.Next(-100, 100);
                    Console.WriteLine($"X: {x} Y: {y}");
                    ans += Gcd(Math.Abs(x - xprev), Math.Abs(y - yprev));
                    (xprev, yprev) = (x, y);
                    ans += Gcd(Math.Abs(x - xfirst), Math.Abs(y - yfirst));
                }
            }
            else
            {
                var n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите X для точки");
                var xfirst = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите Y для точки");
                var yfirst = Convert.ToInt32(Console.ReadLine());
                var xprev = xfirst;
                var yprev = yfirst;
                for (var i = 0; i < n - 1; i++)
                {
                    Console.WriteLine("Введите X для точки");
                    var x = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите Y для точки");
                    var y = Convert.ToInt32(Console.ReadLine());
                    ans += Gcd(Math.Abs(x - xprev), Math.Abs(y - yprev));
                    (xprev, yprev) = (x, y);
                    ans += Gcd(Math.Abs(x - xfirst), Math.Abs(y - yfirst));
                }
            }

            Console.WriteLine(
                $"Количество точек число точек с целочисленными координатами, лежащих внутри многоугольника и не пересекающихся: {ans}");
        }
    }
}