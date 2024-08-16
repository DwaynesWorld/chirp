namespace Chirp.Api;

public class CassandraOptions
{
    public const string SectionName = "Cassandra";

    public required string Keyspace { get; set; }
    public required string Hostname { get; set; }
    public required int Port { get; set; }
}
