using System;

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
    }
}