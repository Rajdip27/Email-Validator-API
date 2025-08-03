using System.Text.RegularExpressions;
using DnsClient;

namespace EmailValidatorAPI.Helpers;

public static class EmailValidationHelper
{
    // RFC5322-compliant regex pattern for email validation
    public static bool IsValidEmailRFC5322(string email)
    {
        var pattern = @"^(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\-]*[a-zA-Z0-9])?\.)+[a-zA-Z]{2,}|localhost)$";
        return Regex.IsMatch(email, pattern);
    }

    // Checks if the domain has a valid MX record
    public static async Task<bool> HasValidMxRecordAsync(string domain)
    {
        var lookup = new LookupClient();
        var result = await lookup.QueryAsync(domain, QueryType.MX);
        return result.Answers.MxRecords().Any();
    }
}
