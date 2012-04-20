using Raven.Client.Shard.ShardStrategy;
using Raven.Client.Shard.ShardStrategy.ShardAccess;
using Raven.Client.Shard.ShardStrategy.ShardResolution;
using Raven.Client.Shard.ShardStrategy.ShardSelection;

namespace RavenDbSharding.RavenDb
{
    /// <summary>
    /// This is the main point for Raven DB to determine item's location in a shard
    /// </summary>
    internal class UserShardStrategy : IShardStrategy
    {
        public IShardSelectionStrategy ShardSelectionStrategy { get; private set; }
        public IShardResolutionStrategy ShardResolutionStrategy { get; private set; }
        public IShardAccessStrategy ShardAccessStrategy { get; private set; }

        public UserShardStrategy()
        {
            ShardAccessStrategy = new ParallelShardAccessStrategy(); //default
            ShardSelectionStrategy = new UserShardSelectionStrategy(); //defined by user
            ShardResolutionStrategy = new AllShardsResolutionStrategy(); //default
        }
    }
}