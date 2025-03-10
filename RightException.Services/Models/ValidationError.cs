namespace RightException.Services.Models;

public class ValidationError : IServiceError
{
    public string? Message { get; set; }
}
