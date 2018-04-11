using DateDiffMVC.Models;

namespace DateDiffMVC.Services
{
    public interface ICalendarService
    {
        int GetDateTotalDays(Date date);
    }
}