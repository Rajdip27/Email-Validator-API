namespace EmailValidatorAPI.Helpers;

public static class DomainBlacklist
{
    private static readonly HashSet<string> Blacklisted = new() { "phishing.com", "malicious.net" };
    public static bool IsBlacklisted(string domain) => Blacklisted.Contains(domain.ToLowerInvariant());
}
