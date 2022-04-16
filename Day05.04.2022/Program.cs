using System;
using Common;

namespace Day05._04._2022
{
    class Program
    {
        static void Main()
        {
            Helper.ContinuousRun(Run);
        }

        static void Run()
        {
            Console.WriteLine("Введите месяц: ");
            var month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите день: ");
            var day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите год: ");
            var year = Convert.ToInt32(Console.ReadLine());

            var data = new Data(year, month, day);
            var now = new Data();

            Console.WriteLine("Введенная дата " + data);
            Console.WriteLine("Автоматически сгенерированная сегодняшняя дата " + now);

            Console.WriteLine("Обновление данных через методы: ");
            Console.WriteLine("Введите колво дней: ");
            var days = Convert.ToInt32(Console.ReadLine());
            data.AddDays(days);
            Console.WriteLine(data);
            Console.WriteLine("Введите колво месяцев: ");
            var months = Convert.ToInt32(Console.ReadLine());
            data.AddMonths(months);
            Console.WriteLine(data);
            Console.WriteLine("Введите колво лет: ");
            var years = Convert.ToInt32(Console.ReadLine());
            data.AddYears(years);
            Console.WriteLine(data);

            Console.WriteLine("Ввод через обновление публичных полей: ");
            Console.WriteLine("Введите день: ");
            var day1 = Convert.ToInt32(Console.ReadLine());
            data.Day = day1;
            Console.WriteLine("Введите месяц: ");
            var month1 = Convert.ToInt32(Console.ReadLine());
            data.Month = month1;
            Console.WriteLine("Введите год: ");
            var year1 = Convert.ToInt32(Console.ReadLine());
            data.Year = year1;
            Console.WriteLine(data);
        }
    }
}