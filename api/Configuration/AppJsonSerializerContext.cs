using System.Text.Json.Serialization;
using Chirp.Api.Domain;

namespace Chirp.Api.Configuration;

[JsonSerializable(typeof(User))]
[JsonSerializable(typeof(IEnumerable<User>))]
[JsonSerializable(typeof(Post))]
[JsonSerializable(typeof(IEnumerable<Post>))]
[JsonSerializable(typeof(Comment))]
[JsonSerializable(typeof(IEnumerable<Comment>))]
[JsonSerializable(typeof(Vote))]
[JsonSerializable(typeof(IEnumerable<Vote>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext { }
