namespace RightException.Services.Business;

public interface IMathService
{
    int DivideWithBadExceptions(int dividend, int divisor);

    int DivideWithRightExceptions(int dividend, int divisor);
}
