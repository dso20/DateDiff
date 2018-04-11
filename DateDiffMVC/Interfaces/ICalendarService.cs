using System;
using DateDiffMVC.Models;

namespace DateDiffMVC.Services
{
    public interface ICalendarService
    {
        string Result(IDate start, IDate end);
        //int ToDays(IDate date);
        //Tuple<int, int, int> Diff(double days, Date dateStart);
    }
}