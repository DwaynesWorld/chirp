namespace Chirp.Api.Domain;

public class Comment
{
    public int Id { get; private set; }
    public int PostId { get; private set; }
    public int Score { get; private set; }
    public string Text { get; private set; } = null!;
    public DateTimeOffset CreationDate { get; private set; }
    public int UserId { get; private set; }
    public string UserDisplayName { get; private set; } = null!;
};
