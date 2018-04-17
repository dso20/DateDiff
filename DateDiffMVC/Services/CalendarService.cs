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


        public static int ToDays(IDate date)
        {
            var days = date.Day;
            days += MonthYearToDays(date.Month, date.Year);

            return days;
        }


        private static int MonthYearToDays(int month, int year)
        {
            //want only full months, if jan then no full month to count
            int yearZero = 1582;
            month -= 1;

            var days = 0;
            for (int i = 1; i <= month; i++)
            {
                days += Months[i];
            }

            //factor in leap year
            days += month >= 2 ? LeapYear(year) : 0;

            year -= 1;
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

            diff -= years > 0 ? (years * 365.24) : 0;

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
        private static int LeapYear(int year)
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