using System;
using dashboard_api.Models;

namespace dashboard_api.Data
{
	public class DataSeed
	{
        private readonly ApiContext _context;

        public DataSeed(ApiContext context)
        {
            _context = context;
        }

        private static List<string> usaStates = Helpers.usaStates;

        public void SeedData(int nCustomers, int nOrders)
        {
            //if there are no customers in our database any means any then seed
            if (!_context.Customers.Any())
            {
                SeedCustomers(nCustomers);
                _context.SaveChanges();
            }

            if (!_context.Orders.Any())
            {
                SeedOrders(nOrders);
                _context.SaveChanges();
            }

            if (!_context.Servers.Any())
            {
                SeedServers();
                _context.SaveChanges();
            }
        }

        internal void SeedCustomers(int n)
        {
            var customers = BuildCustomerList(n);

            foreach (var customer in customers)
            {
                _context.Customers.Add(customer);
            }
        }

        internal void SeedOrders(int n)
        {
            var orders = BuildOrderList(n);

            foreach (var order in orders)
            {
                _context.Orders.Add(order);
            }
        }

        internal void SeedServers()
        {
            var servers = BuildServerList();

            foreach (var server in servers)
            {
                _context.Servers.Add(server);
            }
        }

        internal static List<Customer> BuildCustomerList(int n)
        {
            var customers = new List<Customer>();

            for (var i = 1; i <= n; i++)
            {
                //make this a local variable instead of  Name = name, bc email uses it
                var name = Helpers.MakeCustomerName();

                customers.Add(new Customer
                {
                    Name = name,
                    State = Helpers.GetRandom(usaStates),
                    Email = Helpers.MakeEmail(name)
                });
            }

            return customers;
        }

        internal List<Order> BuildOrderList(int n)
        {
            var orders = new List<Order>();

            for (var i = 1; i <= n; i++)
            {
                var placed = Helpers.GetRandOrderPlaced();
                var completed = Helpers.GetRandOrderCompleted(placed);

                orders.Add(new Order
                {
                    Customer = Helpers.GetRandomCustomer(_context),
                    OrderTotal = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }

            return orders;
        }

        internal static List<Server> BuildServerList()
        {
            return new List<Server>()
            {
                new Server
                {
                    Name = "Dev-Web",
                    IsOnline = true
                },

                new Server
                {
                    Name = "Dev-Analysis",
                    IsOnline = true
                },

                new Server
                {
                    Name = "Dev-Mail",
                    IsOnline = true
                },

                new Server
                {
                    Name = "QA-Web",
                    IsOnline = true
                },

                new Server
                {
                    Name = "QA-Analysis",
                    IsOnline = true
                },

                new Server
                {
                    Name = "QA-Mail",
                    IsOnline = true
                },

                new Server
                {
                    Name = "Prod-Web",
                    IsOnline = true
                },

                new Server
                {
                    Name = "Prod-Analysis",
                    IsOnline = true
                },

                new Server
                {
                    Name = "Prod-Mail",
                    IsOnline = true
                },
            };
        }
    }
}
