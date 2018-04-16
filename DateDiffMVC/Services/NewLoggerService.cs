using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DateDiffMVC.Controllers;

namespace DateDiffMVC.Interfaces
{
    public class NewLoggerService : ILoggerService
    {
        private readonly ILoggerService _baselog;

        public NewLoggerService(ILoggerService baselog)
        {
            _baselog = baselog;
        }

        public void Log(string message, object source)
        {
           //_baselog.Log(message,source);
            var test = "test";
        }

        public string test()
        {
            throw new NotImplementedException();
        }
    }
}