using Cassandra;
using Cassandra.Data.Linq;
using Cassandra.Mapping;
using Chirp.Api.Domain;
using Microsoft.Extensions.Options;

namespace Chirp.Api.Database;

public interface ICassandraContext
{
    Cassandra.ISession GetSession();
    Task Configure();
}

public class CassandraContext(IOptions<CassandraOptions> options) : ICassandraContext
{
    private readonly CassandraOptions options = options.Value;

    public async Task Configure()
    {
        MappingConfiguration.Global.Define<CassandraMappings>();

        var session = GetSession();
        await new Table<User>(session).CreateIfNotExistsAsync();
        await new Table<Post>(session).CreateIfNotExistsAsync();
    }

    public Cassandra.ISession GetSession()
    {
        var cluster = Cluster
            .Builder()
            .AddContactPoint(options.Hostname)
            .WithPort(options.Port)
            .WithDefaultKeyspace(options.Keyspace)
            .Build();
        return cluster.ConnectAndCreateDefaultKeyspaceIfNotExists();
    }
}

public class CassandraMappings : Mappings
{
    public CassandraMappings()
    {
        For<User>().TableName("users").PartitionKey(u => u.Id);

        For<Post>()
            .TableName("posts")
            .PartitionKey(u => u.OwnerUserId)
            .Column(c => c.PostType, cfg => cfg.WithDbType<string>());

        For<Comment>().TableName("comments").PartitionKey(u => u.PostId);

        For<Vote>().TableName("votes").PartitionKey(u => u.PostId);
    }
}
