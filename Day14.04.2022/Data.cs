using System;

namespace Day14._04._2022
{
    public class Data
    {
        public Data()
        {
            Id = Guid.NewGuid();
            Year = 2022;
            Month = 4;
            Day = 5;
        }

        public Data(int year, int month, int day)
        {
            Id = Guid.NewGuid();
            Year = year;
            Month = month;
            Day = day;
        }

        private int _year;
        private int _month;
        private int _day;
        public Guid Id { get; set; }


        public int Year
        {
            get => _year;
            set
            {
                if (value > 0)
                    _year = value;
                else
                    throw new Exception("Неверное значение года");
            }
        }

        public int Month
        {
            get => _month;
            set
            {
                if (value is > 0 and <= 12)
                    _month = value;
                else
                    throw new Exception("Неверное значение месяца");
            }
        }

        public int Day
        {
            get => _day;
            set
            {
                if (value > 0 && value <= 31)
                    _day = value;
                else
                    throw new Exception("Неверное значение дня");
            }
        }

        public void AddDays(int days)
        {
            if (days > 0)
            {
                _day += days;
                while (_day > 31)
                {
                    _day -= 31;
                    _month++;
                    if (_month > 12)
                    {
                        _month = 1;
                        _year++;
                    }
                }
            }
            else
                throw new Exception("Неверное значение дня");
        }

        public void AddMonths(int months)
        {
            if (months > 0)
            {
                _month += months;
                while (_month > 12)
                {
                    _month -= 12;
                    _year++;
                }
            }
            else
                throw new Exception("Неверное значение месяца");
        }

        public void AddYears(int years)
        {
            if (years > 0)
                _year += years;
            else
                throw new Exception("Неверное значение года");
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }

}
