using System;

namespace Day05._04._2022
{
    public class Data
    {
        public Data()
        {
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;
            Day = DateTime.Now.Day;
        }

        public Data(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        private int _year;
        private int _month;
        private int _day;

        public int Year
        {
            get => _year;
            set
            {
                if (value > 0)
                    _year = value;
                else
                    throw new Exception("Год должен быть положительным");
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
                    throw new Exception("Месяц должен быть положительным и не больше 12");
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
                    throw new Exception("День должен быть положительным и не больше 31");
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
                throw new Exception("Колво дней должно быть положительным");
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
                throw new Exception("Колво месяцев должно быть положительным");
        }

        public void AddYears(int years)
        {
            if (years > 0)
                _year += years;
            else
                throw new Exception("Колво лет должно быть положительным");
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }
    }
}