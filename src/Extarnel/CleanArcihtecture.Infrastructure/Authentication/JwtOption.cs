namespace CleanArcihtecture.Infrastructure.Authentication;

public sealed class JwtOption
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecretKey { get; set; }
}
