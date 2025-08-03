namespace EmailValidatorAPI.Models;

public class EmailValidationResult
{
    public bool IsValid { get; set; }
    public bool IsDisposable { get; set; }
    public bool HasMxRecord { get; set; }
    public bool IsFormatValid { get; set; }
    public bool IsDomainValid { get; set; }
    public string? ErrorMessage { get; set; }
    public List<string> Warnings { get; set; } = new();
    public string? DidYouMean { get; set; }
    public string? Domain { get; set; }
    public DateTime ValidatedAt { get; set; } = DateTime.UtcNow;
}
