using System.Text.Json.Serialization;
using Chirp.Api.Comments;
using Chirp.Api.Posts;
using Chirp.Api.Users;
using Chirp.Api.Votes;

[JsonSerializable(typeof(UserEntity))]
[JsonSerializable(typeof(IEnumerable<UserEntity>))]
[JsonSerializable(typeof(PostEntity))]
[JsonSerializable(typeof(IEnumerable<PostEntity>))]
[JsonSerializable(typeof(CommentEntity))]
[JsonSerializable(typeof(IEnumerable<CommentEntity>))]
[JsonSerializable(typeof(VoteEntity))]
[JsonSerializable(typeof(IEnumerable<VoteEntity>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }
