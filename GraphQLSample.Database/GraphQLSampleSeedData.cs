using GraphQLSample.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphQLSample.Database
{
    public static class GraphQLSampleSeedData
    {
        public static void EnsureSeedData(this GraphQLSampleContext db)
        {
            if (!db.Users.Any() || !db.Orders.Any())
            {
                var users = new List<User>
                {
                    new User {
                        FirstName = "Emmanuel",
                        LastName = "Arzate",
                        DateOfBirth = new DateTime(year: 1991, month: 6, day: 4),
                        Orders = new List<Order>
                        {
                            new Order
                            {
                                Amount= 100.00f,
                                DatePlaced = new DateTime(year: 2020, month: 3, day: 31)
                            },
                            new Order
                            {
                                Amount= 200.00f,
                                DatePlaced = new DateTime(year: 2020, month: 3, day: 31)
                            },
                            new Order
                            {
                                Amount= 300.00f,
                                DatePlaced = new DateTime(year: 2020, month: 3, day: 31)
                            },
                            new Order
                            {
                                Amount= 400.00f,
                                DatePlaced = new DateTime(year: 2020, month: 3, day: 31)
                            }
                        }
                    },
                    new User { FirstName = "Axel", LastName = "Arzate", DateOfBirth = new DateTime(year: 2015, month: 3, day: 30) },
                    new User { FirstName = "Mia", LastName = "Arzate", DateOfBirth = new DateTime(year: 2016, month: 1, day: 2) },
                    new User { FirstName = "Annie", LastName = "Arzate", DateOfBirth = new DateTime(year: 2017, month: 6, day: 12) }
                };

                db.Users.AddRange(users);
                db.SaveChanges();
            }
        }
    }
}
