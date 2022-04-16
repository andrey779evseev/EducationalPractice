using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day06._04._2022
{
    class Program
    {
        static void Main()
        {
            Helper.ContinuousRun(Run);
        }

        static void Run()
        {
            Console.WriteLine("Enter n:");
            var n = int.Parse(Console.ReadLine());
            var matrix = new int[n, n];
            var r = new Random();
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    matrix[i, j] = 1;
                }
            }

            while (matrix.Cast<int>().Count(x => x == 1) > n)
                matrix[r.Next(0, n), r.Next(0, n)] = 0;

            PrintMatrix(matrix);

            if (Check(matrix))
                Console.WriteLine("Матрица уже удовлетворяет условиям");
            else
            {
                var isSuccess = false;
                var iteration = 1;
                var pairs = new List<Tuple<int, int>>();
                while (iteration <= 200)
                {
                    var i = r.Next(0, n);
                    var j = r.Next(0, n);
                    matrix = SwapRows(matrix, i, j);
                    pairs.Add(new Tuple<int, int>(i, j));
                    if (Check(matrix))
                    {
                        isSuccess = true;
                        break;
                    }

                    iteration++;
                }

                if (isSuccess)
                {
                    Console.WriteLine("Для этого понадобилось {0} итераций", iteration);
                    foreach (var pair in pairs)
                        Console.WriteLine("{0} {1}", pair.Item1, pair.Item2);
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Председатель жюри не смог получить подхрдяшее расписание");
                }
            }
        }

        static bool Check(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                var column = new List<int>();
                for (var j = 0; j < matrix.GetLength(0); j++)
                {
                    column.Add(matrix[j, i]);
                }

                for (var j = 0; j < column.Count; j++)
                {
                    if (
                        j + 1 < column.Count - 1 &&
                        column[j] == 1 && column[j + 1] == 0
                    )
                    {
                        if (column.Skip(j + 1).Take(column.Count - (j + 1)).Any(x => x == 1))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,4}", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        static int[,] SwapRows(int[,] matrix, int i, int j)
        {
            for (var k = 0; k < matrix.GetLength(0); k++)
            {
                (matrix[k, j], matrix[k, i]) = (matrix[k, i], matrix[k, j]);
            }

            return matrix;
        }
    }
}