namespace DateDiffMVC.Controllers
{
    //ensuring child class can sub for parent
    public interface IDecoratorLoggerService : ILoggerService
    {
        void Newfunction(string test);
    }
}