using Raven.Client.Document;
using Raven.Client.Shard;

namespace RavenDbSharding.RavenDb
{
    internal class ShardsConfiguration
    {
        internal static Shards SetupShards()
        {
            return new Shards
                       {
                           SetupOneShard("user_1_10", "http://localhost:8081"),
                           SetupOneShard("user_10_20", "http://localhost:8082"),
                           SetupOneShard("user_20_30", "http://localhost:8083"),
                       };
        }

        private static DocumentStore SetupOneShard(string shardName, string url)
        {
            return new DocumentStore
                       {
                           Identifier = shardName,
                           Url = url,
                       };
        }
    }
}