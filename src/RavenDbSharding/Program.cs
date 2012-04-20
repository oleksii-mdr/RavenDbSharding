using System;
using System.Collections.Generic;
using Raven.Client;
using Raven.Client.Shard;
using RavenDbSharding.Model;
using RavenDbSharding.RavenDb;
using RavenDbSharding.Utils;

namespace RavenDbSharding
{
    internal sealed class Program
    {
        private static readonly Random rnd = new Random();

        private static void Main()
        {
            //set up
            const int createUserCount = 30;
            Shards shards = ShardsConfiguration.SetupShards();
            IEnumerable<User> users = TestDataGenerator.GenerateUsers(createUserCount);
            var shardStore = new ShardedDocumentStore(new UserShardStrategy(), shards);
            
            //main logic
            using (IDocumentStore store = shardStore.Initialize())
            {
                //Based on user id, save users into the three shards 
                var repo = new UserRepository(store);
                repo.SaveAll(users);

                //load all from database
                //this will query all three shards
                IEnumerable<User> persistedUsers = repo.FindAll();
                ConsoleOutput.PrintUsersInfo(persistedUsers);
                Console.WriteLine("===================================================");

                //pick a random user
                int id = rnd.Next(1, createUserCount);
                //query all shards for specific user
                //user location in a shard is resolved automatically
                User user = repo.FindUserById(id);
                ConsoleOutput.PrintTweetsPostedBy(user);
                Console.WriteLine("===================================================");
            }
            Console.ReadLine();
        }
    }
}