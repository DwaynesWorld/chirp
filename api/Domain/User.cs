namespace Chirp.Api.Domain;

public class User
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int Reputation { get; set; }
    public string DisplayName { get; set; } = null!;
    public string? AboutMe { get; set; }
    public int Views { get; set; }
    public int UpVotes { get; set; }
    public int DownVotes { get; set; }
    public string? WebsiteURL { get; set; }
    public string? Location { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset LastAccessDate { get; set; }
}
