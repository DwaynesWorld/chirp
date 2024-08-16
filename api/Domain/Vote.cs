namespace Chirp.Api.Domain;

public class Vote
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int VoteTypeId { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public int UserId { get; set; }
    public int? BountyAmount { get; set; }
}
