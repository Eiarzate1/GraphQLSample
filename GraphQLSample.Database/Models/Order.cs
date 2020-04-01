using System;

namespace GraphQLSample.Database.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public DateTime DatePlaced { get; set; }
        public DateTime DateShipped { get; set; }
        public DateTime DateArrived { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
