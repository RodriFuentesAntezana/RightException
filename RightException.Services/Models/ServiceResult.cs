namespace RightException.Services.Models;

public class ServiceResult<T>
{
    public T? Success { get; set; }
    public IServiceError? Error { get; set; }
}
