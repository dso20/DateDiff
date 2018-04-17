namespace DateDiffMVC.Controllers
{
    //so below can now stand in for above where it's used, but at the same time has provided a newfunction for whatever needs it
    //autofac can account for decorators, so the correct object is passed to the controller
    public class DecoratorLoggerService : IDecoratorLoggerService
    {
        private readonly ILoggerService _logger;

        public DecoratorLoggerService(ILoggerService logger)
        {
            _logger = logger;
        }

        public void Log(string message, object source)
        {
            _logger.Log(message,source);
            // or can ad extra logic here
        }

        public void Newfunction(string test)
        {   
           
        }
    }
}