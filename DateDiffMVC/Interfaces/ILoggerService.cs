using DateDiffMVC.Models;

namespace DateDiffMVC.Controllers
{
    public interface ILoggerService
    {
        void Log(string message,object source);
    }
}