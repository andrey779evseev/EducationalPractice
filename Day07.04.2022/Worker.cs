using System;

namespace Day07._04._2022
{
    public class Worker
    {
        public Worker(string secondName, string name, string middleName, string address, DateTime hireDate)
        {
            SecondName = secondName;
            Name = name;
            MiddleName = middleName;
            Address = address;
            HireDate = hireDate;
        }

        public string SecondName { get; }
        public string Name { get; }
        public string MiddleName { get; }
        public string Address { get; }
        public DateTime HireDate { get; }
    }
}