using System;
using System.Collections.Generic;

namespace GraphQLSample.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
