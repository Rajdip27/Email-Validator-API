using EmailValidatorAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailValidatorAPI.Controllers;

[ApiController]
[Route("api/v1/email-validator")]
public class EmailValidatorController(IEmailValidationService emailValidationService) : ControllerBase
{
    [HttpGet("validate")]
    public async Task<IActionResult> Validate(string email)
    {
        var result = await emailValidationService.ValidateEmailAsync(email);
        return Ok(result);
    }
}
