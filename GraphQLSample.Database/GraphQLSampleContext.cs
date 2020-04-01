using GraphQLSample.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Database
{
    public class GraphQLSampleContext: DbContext
    {
        public GraphQLSampleContext(DbContextOptions<GraphQLSampleContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
