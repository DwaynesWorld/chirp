namespace Chirp.Api.Posts;

public record PostEntity(
    int Id,
    PostType PostTypeId,
    int? AcceptedAnswerId,
    DateTime CreationDate,
    int Score,
    int ViewCount,
    string Body,
    int? OwnerUserId,
    string OwnerDisplayName,
    int? LastEditorUserId,
    string LastEditorDisplayName,
    DateTime? LastEditDate,
    DateTime LastActivityDate,
    string Title,
    string Tags,
    int AnswerCount,
    int CommentCount,
    int FavoriteCount,
    string ContentLicense,
    int? ParentId,
    DateTime? CommunityOwnerDate,
    DateTime? ClosedDate
)
{
    public int Id { get; private set; } = Id;
    public PostType PostTypeId { get; private set; } = PostTypeId;
    public int? AcceptedAnswerId { get; private set; } = AcceptedAnswerId;
    public DateTime CreationDate { get; private set; } = CreationDate;
    public int Score { get; private set; } = Score;
    public int ViewCount { get; private set; } = ViewCount;
    public string Body { get; private set; } = Body;
    public int? OwnerUserId { get; private set; } = OwnerUserId;
    public string OwnerDisplayName { get; private set; } = OwnerDisplayName;
    public int? LastEditorUserId { get; private set; } = LastEditorUserId;
    public string LastEditorDisplayName { get; private set; } = LastEditorDisplayName;
    public DateTime? LastEditDate { get; private set; } = LastEditDate;
    public DateTime LastActivityDate { get; private set; } = LastActivityDate;
    public string Title { get; private set; } = Title;
    public string Tags { get; private set; } = Tags;
    public int AnswerCount { get; private set; } = AnswerCount;
    public int CommentCount { get; private set; } = CommentCount;
    public int FavoriteCount { get; private set; } = FavoriteCount;
    public string ContentLicense { get; private set; } = ContentLicense;
    public int? ParentId { get; private set; } = ParentId;
    public DateTime? CommunityOwnerDate { get; private set; } = CommunityOwnerDate;
    public DateTime? ClosedDate { get; private set; } = ClosedDate;
}

public enum PostType
{
    Question = 1,
    Answer = 2,
    Wiki = 3,
    TagWikiExcerpt = 4,
    TagWiki = 5,
    ModeratorNomination = 6,
    WikiPlaceholder = 7,
    PrivilegeWiki = 8
}
