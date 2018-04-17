namespace DateDiffMVC.Controllers
{
    //ensuring child class can sub for parent
    //I assume inheriting from an interface that is a sub is ok, but inheriting from an interface that isn't realated is not?
    //basically shouldn;t be making interfaces from other differing interfaces. classes should not be exposed to methods they don't need
    //a client should define the interface
    public interface IDecoratorLoggerService : ILoggerService
    {
        void Newfunction(string test);
    }
}