using System;
using DateDiffMVC.Models;

namespace DateDiffMVC.Controllers
{
    public class LoggerService : ILoggerService
    {
       
        public void Log(string message, object source)
        {
            Console.WriteLine(message + " " + source.GetType());
        }
    }
}