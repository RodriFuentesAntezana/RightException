using RightException.Services.Errors;

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
        if (divisor == 0)
        {
            throw new DivisionError("Cannot divide by zero.");
        }

        var result = dividend / divisor;

        return result;
    }
}
