using Raven.Client.Shard.ShardStrategy.ShardSelection;
using RavenDbSharding.Model;

namespace RavenDbSharding.RavenDb
{
    /// <summary>
    /// Resolves a shard for specific user
    /// </summary>
    internal class UserShardSelectionStrategy : IShardSelectionStrategy
    {
        /// <summary>
        /// Resolve a shard based on user id, this can be overriden, 
        /// in a sense not only id can be used, but any other filed, for example
        /// Dates - store items created in each month in different shards
        /// </summary>
        public string ShardIdForNewObject(object obj)
        {
            var user = obj as User;
            if (user != null)
            {
                if (user.Id <= 10)
                    return "user_1_10";
                if (user.Id <= 20)
                    return "user_10_20";
                if (user.Id <= 30)
                    return "user_20_30";
            }

            return null;
        }

        public string ShardIdForExistingObject(object obj)
        {
            return ShardIdForNewObject(obj);
        }
    }
}