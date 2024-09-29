namespace Nucleo.DDD.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException:Exception
{
    public BusinessException()
    {
        
    }

    public BusinessException(string? message):base(message) 
    {
        
    }

    
}
