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


    //so if i do this, first how do I get an instance of the LoggerService?
    //does this replace it's predecessor in startup?
    public class NewLoggerService : ILoggerService
    {
        
        public void Log(string message, object source)
        {
            throw new NotImplementedException();
        }

        public void newfunction(string test)
        {

        }
    }
}