namespace Ordering.Domain.Exceptions;
public class DomainExeption : Exception
{
    public DomainExeption(string message) 
        : base($"Domain exception: \"{message}\" throws from Domain Layer.")
    {
        
    }
}
