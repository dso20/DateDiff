using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateDiffMVC.Models;

namespace DateDiffMVC.Services
{
    //The client should define the interface, therefore,
    //expose function that returns the result
    //also it takes 2 dates, which are the original parameters of the controllers viewmodel
    //following that the variables that that func needs should be worked out in here too

    //so this class looks a little large
    //also what functions should we choose to expose?
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

        //single responsibility. Even if this was an exposed function it could stay here because
        //eg the above could not "change" independetly of this
        private static int ToDays(IDate date)
        {
            var days = date.Day;
            var months = MonthDays(date.Month, date.Year);
            var years = YearDays(date.Year);

            return days += months += years;
        }


        private static int MonthDays(int month, int year)
        {
            //want only full months, if jan then no full month to count
            month -= 1;

            var days = 0;
            for (int i = 1; i <= month; i++)
            {
                days += Months[i];
            }

            //factor in leap year
            days += month >= 2 ? LeapYear(year) : 0;

            return days;
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


        private static Tuple<int, int, int> Diff(double diff, IDate dateStart)
        {

            //so we could assume the number of days in a year and dateStart subtracting 365.24
            var years = (int)Math.Floor(diff / 365.24);

            if (years > 0)
            { diff -= (years * 365.24); }

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


            //so we can test need a quantifiable val here
            return Tuple.Create(days, months, years);
        }




        private static int LeapYear(int year)
        {
            return year%4 == 0 ? 0 : year%100 == 0 ? 1 : 0;

            //if (year % 4 == 0)
            //{
            //    if (year % 100 == 0)
            //    {
            //        if (year % 400 == 0)
            //        {
            //            return 1;
            //        }
            //    }
            //    return 1;
            //}
            //return 0;
        }

        private readonly static Dictionary<int, int> Months = new Dictionary<int, int>()
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