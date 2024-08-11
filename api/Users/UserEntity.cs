namespace Chirp.Api.Users;

public class UserEntity(
    int Id,
    int AccountId,
    int Reputation,
    string DisplayName,
    string AboutMe,
    int Views,
    int UpVotes,
    int DownVotes,
    string? WebsiteUrl,
    string? Location,
    DateTime CreationDate,
    DateTime LastAccessDate
)
{
    public int Id { get; private set; } = Id;
    public int AccountId { get; private set; } = AccountId;
    public int Reputation { get; private set; } = Reputation;
    public string DisplayName { get; private set; } = DisplayName;
    public string AboutMe { get; private set; } = AboutMe;
    public int Views { get; private set; } = Views;
    public int UpVotes { get; private set; } = UpVotes;
    public int DownVotes { get; private set; } = DownVotes;
    public string? WebsiteURL { get; private set; } = WebsiteUrl;
    public string? Location { get; private set; } = Location;
    public DateTime CreationDate { get; private set; } = CreationDate;
    public DateTime LastAccessDate { get; private set; } = LastAccessDate;
}
