using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DateDiffMVC.Models;

namespace DateDiffMVC.Services
{
    // only real question is should I be exposing more functions than this. The Leap year, 
    //numbers of days in a date and number of days in a month all could be sueful in a hypothetical project
    public class CalendarService : ICalendarService
    {
        public Tuple<int,int,int> Result(IDate start, IDate end)
        {
            var startDays = ToDays(start);
            var endDays = ToDays(end);

            //find the difference
            var timespan = (new TimeSpan(endDays, 0, 0, 0) - (new TimeSpan(startDays, 0, 0, 0)));

            return Diff(timespan.Days, start);
        }


        // the main responsibility of this class is the above, but two other funcs including the below are hypothetically useful
        //so I expose them. As far as I can see this doesn't break rule 1 of SOLID
        public static int ToDays(IDate date)
        {
            var days = date.Day;
            var months = MonthYearDays(date.Month, date.Year);

            return days += months;
        }

        //combined these two into 1
        private static int MonthYearDays(int month, int yearZero = 1582)
        {
            //want only full months, if jan then no full month to count
            month -= 1;

            var days = 0;
            for (int i = 1; i <= month; i++)
            {
                days += Months[i];
            }

            //factor in leap year
            days += month >= 2 ? LeapYear(yearZero) : 0;

            for (int i = yearZero; i <= yearZero; i++)
            {
                days += 365 + LeapYear(i);
            }

            return days;
        }


        private static Tuple<int, int, int> Diff(double diff, IDate dateStart)
        {

            //so we could assume the number of days in a year and dateStart subtracting 365.24
            var years = (int)Math.Floor(diff / 365.24);

            diff -= years == 0 ? (years * 365) : 0;

            //now need to do the same with months 30.437
            var months = 0;
            int days = 0;

            //count month if days remaining are more than in a month
            while (diff >= Months[dateStart.Month])
            {
                diff -= (dateStart.Month != 2 ? Months[dateStart.Month] : Months[dateStart.Month] + LeapYear(dateStart.Year));
                months++;
                dateStart.Month++;
                dateStart.Month = dateStart.Month == 13 ? 1 : dateStart.Month;
            }

            days = (int)Math.Ceiling(diff);

            return Tuple.Create(days, months, years);
        }


        //below could be considered props of dates no?
        // can we use instance of this in date to get props?
        public static int LeapYear(int year)
        {
            return year%4 == 0 ? 0 : year%100 == 0 ? 1 : 0;
        }

        private static readonly Dictionary<int, int> Months = new Dictionary<int, int>()
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
    }
}