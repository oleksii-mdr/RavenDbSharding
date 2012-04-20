using System;
using System.Collections.Generic;
using RavenDbSharding.Model;

namespace RavenDbSharding.Utils
{
    /// <summary>
    /// Prints some data into console
    /// </summary>
    internal static class ConsoleOutput
    {
        internal static void PrintTweetsPostedBy(User user)
        {
            Console.WriteLine("Tweets by " + user.FirstName + " " + user.LastName);
            foreach (Tweet tweet in user.PostedTweets)
            {
                Console.WriteLine(tweet.Text);
            }
        }

        internal static void PrintUsersInfo(IEnumerable<User> users)
        {
            foreach (User user in users)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName);
                Console.WriteLine(" Subscribes count: " + user.SubscribersIds.Count);
                Console.WriteLine(" Tweets count: " + user.PostedTweets.Count);
                Console.WriteLine("---------");
            }
        }
    }
}