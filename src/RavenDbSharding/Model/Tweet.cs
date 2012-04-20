using System;

namespace RavenDbSharding.Model
{
    internal class Tweet
    {
        public DateTime PublishedAt { get; set; }
        public string Text { get; set; }
    }
}