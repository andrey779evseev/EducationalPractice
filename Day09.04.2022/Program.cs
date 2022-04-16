using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Day09._04._2022
{
    class Program
    {
        private const string Path = @"../../../../Day09.04.2022/heap.dat";
        static void Main()
        {
            Helper.ContinuousRun(Run);
        }
        static Product GetProduct(string productName)
        {
            var products = Helper.ReadFromJson<Product>(Path);
            return products.FirstOrDefault(x => x.ProductName == productName);
        }
        static double GetTotalPrice()
        {
            var products = Helper.ReadFromJson<Product>(Path);
            return products.Sum(x => x.TotalPrice);
        }
        static List<Product> GetProducts(int min, int max)
        {
            var products = Helper.ReadFromJson<Product>(Path);
            return products.Where(x => x.ProductNumber >= min && x.ProductNumber <= max).ToList();
        }
        static Product GetMaxPriceProduct()
        {
            var products = Helper.ReadFromJson<Product>(Path);
            return products.OrderByDescending(x => x.TotalPrice).FirstOrDefault();
        }
        static List<Product> GetProductsByName(string name)
        {
            var products = Helper.ReadFromJson<Product>(Path);
            return products.Where(x => x.ProductName.StartsWith(name)).ToList();
        }
        static void PrintProducts(List<Product> products, int index = 0)
        {
            Console.WriteLine($"{products[index].ProductNumber} {products[index].ProductName} {products[index].Count} {products[index].Price} {products[index].TotalPrice}");
            if (index + 1 < products.Count)
                PrintProducts(products, index + 1);
        }
        static void InputProduct()
        {
            Console.WriteLine("Input product");
            Console.Write("Product number: ");
            var productNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Product name: ");
            var productName = Console.ReadLine();
            Console.Write("Count: ");
            var count = Convert.ToInt32(Console.ReadLine());
            Console.Write("Price: ");
            var price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Total price: ");
            var totalPrice = Convert.ToDouble(Console.ReadLine());
            var product = new Product(productNumber, productName, count, price, totalPrice);
            Helper.AddToJson(Path, product);
            Console.WriteLine("Do you want to input more products? (y/n)");
            if (Console.ReadLine() == "y")
                InputProduct();
        }
        static void Run()
        {
            Console.WriteLine("Do you want to add product? (y/n)");
            if (Console.ReadLine() == "y")
                InputProduct();

            PrintProducts(Helper.ReadFromJson<Product>(Path));
            
            Console.WriteLine("Input product name for filter");
            var productName = Console.ReadLine();
            Console.WriteLine(GetProduct(productName).ToString());
            
            
            Console.WriteLine("Total price " + GetTotalPrice());
            
            
            Console.WriteLine("Input min and max for filter");
            Console.Write("Min: ");
            var min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Max: ");
            var max = Convert.ToInt32(Console.ReadLine());
            PrintProducts(GetProducts(min, max));
            
            Console.WriteLine("Max price product: " + GetMaxPriceProduct());
            
            Console.WriteLine("Input start name for filter");
            var startName = Console.ReadLine();
            PrintProducts(GetProductsByName(startName));
        }
    }
}