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

    //so below can now stand in for above where it's used, but at the same time has provided a newfunction for whatever needs it
    //autofac can account for decorators, so the correct object is passed to the controller
    public class DecoratorLoggerService : ILoggerService
    {
        private readonly ILoggerService _logger;

        public DecoratorLoggerService(ILoggerService logger)
        {
            _logger = logger;
        }

        public void Log(string message, object source)
        {
            _logger.Log(message,source);
        }

        public void Newfunction(string test)
        {

        }
    }
}