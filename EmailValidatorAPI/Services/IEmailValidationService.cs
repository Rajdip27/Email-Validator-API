using EmailValidatorAPI.Helpers;
using EmailValidatorAPI.Models;

namespace EmailValidatorAPI.Services;

public interface IEmailValidationService
{
    Task<EmailValidationResult> ValidateEmailAsync(string email);
}
public class EmailValidationService : IEmailValidationService
{
    /// <summary>
    /// Validates the specified email address asynchronously.
    /// </summary>
    /// <param name="email">The email address to validate.</param>
    /// <returns>An EmailValidationResult containing validation details.</returns>
    public async Task<EmailValidationResult> ValidateEmailAsync(string email)
    {
        var result = new EmailValidationResult();

        // Check for empty or whitespace email
        if (string.IsNullOrWhiteSpace(email))
        {
            result.ErrorMessage = "Email is required";
            return result;
        }

        // Validate email format using RFC5322
        result.IsFormatValid = EmailValidationHelper.IsValidEmailRFC5322(email);
        if (!result.IsFormatValid)
        {
            result.ErrorMessage = "Invalid email format";
            return result;
        }

        // Split email into local part and domain
        var parts = email.Split('@');
        if (parts.Length != 2)
        {
            result.ErrorMessage = "Email must contain exactly one '@' character";
            return result;
        }

        var domain = parts[1];
        result.Domain = domain;

        // Check if domain is blacklisted
        if (DomainBlacklist.IsBlacklisted(domain))
        {
            result.IsDomainValid = false;
            result.ErrorMessage = "Domain is blacklisted";
            return result;
        }
        result.IsDomainValid = true;

        // Check if domain is disposable
        result.IsDisposable = DisposableDomains.IsDisposable(domain);
        if (result.IsDisposable)
        {
            result.Warnings.Add("Disposable domain detected");
        }

        // Check for MX record
        result.HasMxRecord = await EmailValidationHelper.HasValidMxRecordAsync(domain);
        if (!result.HasMxRecord)
        {
            result.ErrorMessage = "No MX record found for domain";
            return result;
        }

        // Suggest possible typo corrections for domain
        result.DidYouMean = TypoSuggestions.Suggest(domain);

        // Set overall validity
        result.IsValid = result.IsFormatValid && result.IsDomainValid && result.HasMxRecord;

        return result;
    }
}