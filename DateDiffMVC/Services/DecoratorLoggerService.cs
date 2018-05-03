namespace DateDiffMVC.Controllers
{
    //so below can now stand in for above where it's used, but at the same time has provided a newfunction for whatever needs it
    //autofac can account for decorators, so the correct object is passed to the controller
    //you can also decorate to extend entirely diff class, eg calendar service, that could have a decorator for logging
    public class DecoratorLoggerService : IDecoratorLoggerService
    {
        private readonly ILoggerService _logger;

        public DecoratorLoggerService(ILoggerService logger)
        {
            _logger = logger;
        }

        public void Log(string message, object source)
        {
            _logger.Log(message + " Extra Decorator",source);
        }

        public void Newfunction(string test)
        {   
           
        }
    }
}