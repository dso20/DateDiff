using System;
using DateDiffMVC.Models;

namespace DateDiffMVC.Services
{
    public interface ICalendarService
    {
        Tuple<int, int, int> Result(IDate start, IDate end);

    }
}