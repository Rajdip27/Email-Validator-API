namespace EmailValidatorAPI.Helpers;

public static class TypoSuggestions
{
    private static readonly List<string> KnownDomains = new() { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com" };

    public static string? Suggest(string domain)
    {
        return KnownDomains
            .Select(d => new { Domain = d, Distance = Levenshtein(domain, d) })
            .OrderBy(x => x.Distance)
            .FirstOrDefault(x => x.Distance <= 2)?.Domain;
    }

    private static int Levenshtein(string s, string t)
    {
        var dp = new int[s.Length + 1, t.Length + 1];
        for (int i = 0; i <= s.Length; i++) dp[i, 0] = i;
        for (int j = 0; j <= t.Length; j++) dp[0, j] = j;

        for (int i = 1; i <= s.Length; i++)
            for (int j = 1; j <= t.Length; j++)
            {
                int cost = s[i - 1] == t[j - 1] ? 0 : 1;
                dp[i, j] = new[] {
                dp[i - 1, j] + 1,
                dp[i, j - 1] + 1,
                dp[i - 1, j - 1] + cost
            }.Min();
            }
        return dp[s.Length, t.Length];
    }
}
