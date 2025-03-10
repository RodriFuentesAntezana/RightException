using RightException.Services.Errors;
using RightException.Services.Models;

namespace RightException.Services.Business;

public class MathService : IMathService
{
    public int DivideWithBadExceptions(int dividend, int divisor)
    {
        try
        {
            return dividend / divisor;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            return -1;
        }
    }

    public int DivideWithRightExceptions(int dividend, int divisor)
    {
        if (divisor is 0)
        {
            throw new DivisionError("Cannot divide by zero.");
        }

        var result = dividend / divisor;

        return result;
    }

    public ServiceResult<int> DivideUsingResultPattern(int dividend, int divisor)
    {
        var result = new ServiceResult<int>();

        if (divisor is 0)
        {
            result.Error = new ValidationError { Message = $"The dividend: {dividend} cannot be divided by zero." };
            return result;
        }

        var operation = dividend / divisor;

        result.Success = operation;

        return result;
    }
}
