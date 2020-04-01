using GraphQLSample.Database.Models;
using System.Collections.Generic;

namespace GraphQLSample.DataAccess.Repositories.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Add(User user);
    }
}
