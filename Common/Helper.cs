using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Common
{
    public delegate void RunDelegate();

    public static class Helper
    {
        public static void ContinuousRun(RunDelegate run)
        {
            run();
            Console.WriteLine("Do you want to run it again? (y/n)");
            var input = Console.ReadLine();
            if (input == "y")
                ContinuousRun(run);
        }

        public static List<T> ReadFromJson<T>(string path)
        {
            return JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path)) ?? new List<T>();
        }

        public static void AddToJson<T>(string path, T item)
        {
            var items = ReadFromJson<T>(path);
            items.Add(item);
            File.WriteAllText(path, JsonConvert.SerializeObject(items.Distinct()));
        }

        public static void AddToJson<T>(string path, List<T> items)
        {
            var existingItems = ReadFromJson<T>(path);
            existingItems.AddRange(items);
            File.WriteAllText(path, JsonConvert.SerializeObject(existingItems.Distinct()));
        }

        public static void RewriteToJson<T>(string path, List<T> items)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(items.Distinct()));
        }
    }
}