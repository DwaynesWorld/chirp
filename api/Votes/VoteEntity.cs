namespace Chirp.Api.Votes;

public class VoteEntity(
    int Id,
    int PostId,
    int VoteTypeId,
    DateTime CreationDate,
    int UserId,
    int? BountyAmount
)
{
    public int Id { get; private set; } = Id;
    public int PostId { get; private set; } = PostId;
    public int VoteTypeId { get; private set; } = VoteTypeId;
    public DateTime CreationDate { get; private set; } = CreationDate;
    public int UserId { get; private set; } = UserId;
    public int? BountyAmount { get; private set; } = BountyAmount;
}
