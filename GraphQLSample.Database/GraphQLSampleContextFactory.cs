using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GraphQLSample.Database
{
    public class GraphQLSampleContextFactory : IDesignTimeDbContextFactory<GraphQLSampleContext>
    {
        public GraphQLSampleContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<GraphQLSampleContext>();
            var connectionString = configuration.GetConnectionString("MyDb");
            builder.UseSqlServer(connectionString);

            return new GraphQLSampleContext(builder.Options);
        }
    }
}
