using Microsoft.AspNetCore.Mvc;
using RightException.Services.Business;
using RightException.Services.Errors;

namespace RightException.Api.Controllers;

[ApiController]
[Route("api/maths/divide")]
public class MathController(
    IMathService mathService) : ControllerBase
{
    [HttpGet("bad-exception")]
    public IActionResult DivideWithBadExceptions(int dividend, int divisor)
    {
        try
        {
            var result = mathService.DivideWithBadExceptions(dividend, divisor);
            if (result == -1)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
        }
    }

    [HttpGet("right-exception")]
    public IActionResult DivideWithRightExceptions(int dividend, int divisor)
    {
        try
        {
            var result = mathService.DivideWithRightExceptions(dividend, divisor);
            return Ok(result);
        }
        catch (DivisionError ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
        }
    }

    [HttpGet("result-pattern")]
    public IActionResult DivideUsingResultPattern(int dividend, int divisor)
    {
        var result = mathService.DivideUsingResultPattern(dividend, divisor);

        if (result.Error is not null)
            return BadRequest(result.Error.Message);
        
        return Ok(result.Success);
    }
}
