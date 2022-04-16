using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Day07._04._2022;

namespace Day08._04._2022
{
    class Program
    {
        private const string Path = @"../../../../Day08.04.2022/workers.json";

        static void Main()
        {
            Helper.ContinuousRun(Run);
        }

        static void Run()
        {
            Helper.AddToJson(Path, new List<Worker>
            {
                new("Петров", "Алексей", "Батькович", "улица дом квартира Петровых",
                    DateTime.Today.AddDays(255)),
                new("Петрова", "Александра", "Батьковна", "улица дом квартира Петровых",
                    DateTime.Today.AddDays(15)),
                new("Иван", "Иванович", "Иванов", "улица дом квартира", DateTime.Today.AddDays(25)),
            });

            Console.WriteLine("Введите данные работников в формате: Фамилия Имя Отчество Адрес Дата найма");
            Console.WriteLine("Для завершения ввода введите пустую строку");
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    break;
                var worker = input.Split(' ');
                if (worker.Length != 5)
                {
                    Console.WriteLine("Неверный формат ввода");
                    continue;
                }

                Helper.AddToJson(Path,
                    new Worker(worker[0], worker[1], worker[2], worker[3], DateTime.Parse(worker[4])));
            }


            Console.WriteLine("\nСортировка по году поступления на работу");

            foreach (var item in Helper.ReadFromJson<Worker>(Path))
                Console.WriteLine(item.Name + " " + item.SecondName + ". дата найма: " + item.HireDate);

            Console.WriteLine("\nЗаписи содержащие Петров или Петрова");

            var arrayByCondition = Helper.ReadFromJson<Worker>(@"../../../workers.json")
                .Where(a => a.SecondName is "Петрова" or "Петров")
                .OrderBy(a => a.HireDate);

            var stack = new Stack<Worker>();

            foreach (var item in arrayByCondition)
            {
                Console.WriteLine(item.Name + " " + item.SecondName + ". address: " + item.Address);
                stack.Push(item);
            }
        }
    }
}