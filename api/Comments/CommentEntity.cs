namespace Chirp.Api.Comments;

public class CommentEntity(
    int Id,
    int PostId,
    int Score,
    string Text,
    DateTimeOffset CreationDate,
    int UserId,
    string UserDisplayName
)
{
    public int Id { get; } = Id;
    public int PostId { get; } = PostId;
    public int Score { get; } = Score;
    public string Text { get; } = Text;
    public DateTimeOffset CreationDate { get; } = CreationDate;
    public int UserId { get; } = UserId;
    public string UserDisplayName { get; } = UserDisplayName;
};
