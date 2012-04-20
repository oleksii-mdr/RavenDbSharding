using System.Collections.Generic;
using System.Linq;
using Raven.Client;
using RavenDbSharding.Model;

namespace RavenDbSharding.RavenDb
{
    /// <summary>
    /// Wraps RavenDB interactions
    /// </summary>
    internal class UserRepository
    {
        private readonly IDocumentStore _store;

        public UserRepository(IDocumentStore store)
        {
            _store = store;
        }

        internal void SaveAll(IEnumerable<User> users)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                users.ToList().ForEach(session.Store);
                session.SaveChanges();
            }
        }

        internal IEnumerable<User> FindAll()
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                return session
                    .Advanced
                    .LuceneQuery<User>()
                    .WaitForNonStaleResults()
                    .ToArray();
            }
        }

        internal User FindUserById(int userId)
        {
            using (IDocumentSession session = _store.OpenSession())
            {
                return session.Advanced.LuceneQuery<User>()
                    .WaitForNonStaleResults()
                    .WhereEquals("Id", userId)
                    .FirstOrDefault();
            }
        }
    }
}