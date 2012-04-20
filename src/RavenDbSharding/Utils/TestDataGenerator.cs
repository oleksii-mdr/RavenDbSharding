using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using RavenDbSharding.Model;

namespace RavenDbSharding.Utils
{
    /// <summary>
    /// Generates sample data using FizzWare.NBuilder
    /// </summary>
    internal class TestDataGenerator
    {
        private static readonly RandomGenerator rnd = new RandomGenerator();
        private static readonly UniqueRandomGenerator uniqueRnd = new UniqueRandomGenerator();

        internal static IEnumerable<User> GenerateUsers(int n)
        {
            var users = Builder<User>
                .CreateListOfSize(n)
                .Build();

            foreach (var user in users)
            {
                uniqueRnd.Reset();
                var subscribersId = Builder<int>
                    .CreateListOfSize(rnd.Next(1, n))
                    .Build()
                    .ToList();
                for (int i = 0; i < subscribersId.Count; i++)
                {
                    subscribersId[i] = uniqueRnd.Next(1, n);
                }

                user.SubscribersIds = new List<int>(subscribersId);

                var tweets = Builder<Tweet>
                    .CreateListOfSize(rnd.Next(1, n))
                    .All()
                    .Do(tweet =>
                            {
                                tweet.Text = rnd.Phrase(rnd.Next(1, 140));
                                tweet.PublishedAt = rnd.DateTime();
                            })
                    .Build();

                user.PostedTweets = new List<Tweet>(tweets);
            }
            return users;
        }
    }
}