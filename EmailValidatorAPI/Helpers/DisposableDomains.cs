namespace EmailValidatorAPI.Helpers;

public static class DisposableDomains
{
    private static readonly HashSet<string> Domains = File.ReadAllLines("disposable_domains.txt")
       .Select(x => x.Trim().ToLowerInvariant())
       .ToHashSet();

    public static bool IsDisposable(string domain) => Domains.Contains(domain.ToLowerInvariant());
}
