using System.Collections.Generic;

namespace RavenDbSharding.Model
{
    internal class User
    {
        public int Id { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> SubscribersIds { get; set; }
        public List<Tweet> PostedTweets { get; set; }
    }
}