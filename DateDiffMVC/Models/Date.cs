using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace DateDiffMVC.Models
{
    public class Date : IDate
    {
        //*** Don't want to expose these props as in this prog the dates 
        //have one function and so should never be updated by client func
        [Range(1, int.MaxValue, ErrorMessage = "Select a year")]
        public int Year { get; private set; }
        [Range(1, 12, ErrorMessage = "Select a month")]
        public int Month { get; private set; }
        [Range(1, 31, ErrorMessage = "Select a day")]
        public int Day { get; private set; }


        //*** set our props in ctor as they shouldn't be changing
        // if they were to change we would want a user to create a new date
        public Date(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
        }

        private readonly static Dictionary<int, int> _months = new Dictionary<int, int>()
        {
                           { 1, 31},
                           { 2, 28},
                           { 3, 31},
                           { 4, 30},
                           { 5, 31},
                           { 6, 30},
                           { 7, 31},
                           { 8, 31},
                           { 9, 30},
                           { 10, 31},
                           { 11, 30},
                           { 12, 31}

        };


        public static int ToDays(Date date)
        {
            var days = date.Day;
            var months = MonthDays(date.Month, date.Year);
            var years = YearDays(date.Year);

            return days += months += years;

        }

        private static int MonthDays(int month, int year)
        {
            //want only full months, if jan then no full month to count
            month = month - 1;

            var day = 0;

            for (int i = 1; i <= month; i++)
            {
                day += _months[i];
            }

            //factor in leap year
            day += month >= 2 ? LeapYear(year):0;


            return day;
        }

        private static int YearDays(int year, int yearZero = 1582)
        {
            //want a full year
            year -= 1;

            var days = 0;

            for (int i = yearZero; i <= year; i++)
            {
                days += 365 + LeapYear(i);
            }

            return days;
        }


        public static Tuple<int, int, int> Diff(double diff, Date start)
        {

            //so we could assume the number of days in a year and start subtracting 365.24
            var years = (int)Math.Floor(diff / 365.24);

            if (years > 0)
            { diff -= (years * 365.24); }

            //now need to do the same with months 30.437
            var months = 0;
            int days = 0;

            //count month if days remaining are more than in a month
            while (diff >= _months[start.Month])
            {
                diff -= (start.Month != 2 ? _months[start.Month] : _months[start.Month] + LeapYear(start.Year));
                months++;
               start.Month++;
                if (start.Month == 13)
                {
                    start.Month = 1;
                }
            }

            days = (int)Math.Ceiling(diff);


            //so we can test need a quantifiable val here
            return Tuple.Create(days, months, years);
        }

        private static int LeapYear(int year)
        {

            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        return 1;
                    }
                }
                return 1;
            }
            return 0;
        }

    }

}