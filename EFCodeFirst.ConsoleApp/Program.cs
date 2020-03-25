using ClassLibraryNetCore.Model;
using System;
using System.Collections.Generic;

namespace ClassLibrayNetCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestPerson();
            TesTOneToMany();
            TestManyToMany();
        }

        static void TestPerson()
        {
            string firstName, lastName, middleName, telephoneNumber;
            Console.WriteLine("Enter FirstName");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter LastName");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter MiddleName");
            middleName = Console.ReadLine();
            Console.WriteLine("Enter TelephoneNumber");
            telephoneNumber = Console.ReadLine();
            using (ModelContext context = new ModelContext())
            {
                Person p = new Person()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    TelephoneNumber = telephoneNumber
                };
                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;
                foreach (var x in items)
                {
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
                }
            }
        }
        static void TesTOneToMany()
        {
            Console.WriteLine("One to many association");
            string customerName, customerCity;
            decimal o1Total, o2Total;
            Console.WriteLine("Enter Customer Name");
            customerName = Console.ReadLine();
            Console.WriteLine("Enter Customer City");
            customerCity = Console.ReadLine();
            Console.WriteLine("Enter Total value for Order 1");
            decimal.TryParse(Console.ReadLine(), out o1Total);
            Console.WriteLine("Enter Total value for Order 2");
            decimal.TryParse(Console.ReadLine(), out o2Total);
            using (ModelContext context =
           new ModelContext())
            {
                Customer c = new Customer()
                {
                    Name = customerName,
                    City = customerCity
                };
                Order o1 = new Order()
                {
                    TotalValue = o1Total,
                    Date = DateTime.Now,
                    Customer = c
                };
                Order o2 = new Order()
                {
                    TotalValue = o2Total,
                    Date = DateTime.Now,
                    Customer = c
                };
                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();
                var items = context.Customers;
                foreach (var x in items)
                {
                    Console.WriteLine("Customer : {0}, {1}, {2}",
                   x.CustomerId, x.Name, x.City);
                    foreach (var ox in x.Orders)
                        Console.WriteLine("\tOrders: {0}, {1}, {2}",
                       ox.OrderId, ox.Date, ox.TotalValue);
                }
            }
        }

        static void TestManyToMany()
        {
            Console.WriteLine("Many to many association");
            string artistFirstName, artistLastName, albumName;
            Console.WriteLine("Enter Artist First Name");
            artistFirstName = Console.ReadLine();
            Console.WriteLine("Enter Artist Last Name");
            artistLastName = Console.ReadLine();
            Console.WriteLine("Enter Album Name");
            albumName = Console.ReadLine();
            using (ModelContext context =
           new ModelContext())
            {
                Artist c = new Artist()
                {
                    FirstName = artistFirstName,
                    LastName = artistLastName
                };

                Artist cp = new Artist()
                {
                    FirstName = artistLastName,
                    LastName = artistFirstName
                };
                Album a = new Album()
                {
                    AlbumName = albumName,
                    Artists = new List<Artist>
                    {
                        c,cp
                    }
                };

                c.Albums.Add(a);
                cp.Albums.Add(a);
                context.Artists.Add(c);
                context.Artists.Add(cp);
                context.Albums.Add(a);
                context.SaveChanges();
                var items = context.Albums;
                foreach (var x in items)
                {
                    Console.WriteLine("Album : {0}, {1}",
                   x.AlbumId, x.AlbumName);
                    foreach (var ox in x.Artists)
                        Console.WriteLine("Artists: {0}, {1}, {2}",
                       ox.ArtistId, ox.FirstName, ox.LastName);
                }
            }
        }
    }
}
