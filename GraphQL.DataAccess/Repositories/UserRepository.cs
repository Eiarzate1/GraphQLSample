using GraphQLSample.DataAccess.Repositories.Contracts;
using GraphQLSample.Database;
using GraphQLSample.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQLSample.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GraphQLSampleContext _dbContext;

        public UserRepository(GraphQLSampleContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User GetById(int id)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Id == id);
        }
    }
}
