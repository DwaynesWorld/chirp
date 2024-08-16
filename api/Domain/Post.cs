namespace Chirp.Api.Domain;

public record Post
{
    public int Id { get; set; }
    public int? OwnerUserId { get; set; }
    public string OwnerDisplayName { get; set; } = null!;
    public int? ParentId { get; set; }
    public int? AcceptedAnswerId { get; set; }
    public PostType PostType { get; set; }
    public string Title { get; set; } = null!;
    public string Body { get; set; } = null!;
    public int Score { get; set; }
    public int ViewCount { get; set; }
    public string Tags { get; set; } = null!;
    public int AnswerCount { get; set; }
    public int CommentCount { get; set; }
    public int FavoriteCount { get; set; }
    public string ContentLicense { get; set; } = null!;
    public int LastEditorUserId { get; set; }
    public string LastEditorDisplayName { get; set; } = null!;
    public DateTimeOffset LastEditDate { get; set; }
    public DateTimeOffset LastActivityDate { get; set; }
    public DateTimeOffset? CommunityOwnerDate { get; set; }
    public DateTimeOffset? ClosedDate { get; set; }
    public DateTimeOffset CreationDate { get; set; }
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
