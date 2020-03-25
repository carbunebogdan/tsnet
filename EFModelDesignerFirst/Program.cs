using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignerFirst_L2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test model Designer First");
            //TestPerson();
            TesTOneToMany();
            Console.ReadKey();
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
            using (Model1Container context = new Model1Container())
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
                foreach(var x in items)
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
            using (ModelOneToManyContainer context =
           new ModelOneToManyContainer())
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
    }
}
