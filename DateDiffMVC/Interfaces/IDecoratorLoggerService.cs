namespace DateDiffMVC.Controllers
{
    //ensuring child class can sub for parent
    public interface IDecoratorLoggerService : ILoggerService
    {
        void Log(string message, object source);
        void Newfunction(string test);
    }
}