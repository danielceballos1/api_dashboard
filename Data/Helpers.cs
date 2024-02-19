using System;
using dashboard_api.Models;

namespace dashboard_api.Data
{
	public class Helpers
	{
        //use this to get a random number from the count of items in list.
        private static Random _rand = new Random();

        internal static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        //use this to generate a random name
        internal static string MakeCustomerName()
        {
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);

            return prefix + suffix;
        }

        //use this to generate a random email
        internal static string MakeEmail(string name)
        {
            return $"contact@{name.ToLower()}_{DateTime.Now:fff}.com";
        }
        //use this to generate a random sstatae
        internal static readonly List<string> usaStates = new List<string>()
        {
            "AK", "AL","AZ",  "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
        };

        //use this to generate a random prefix
        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC",
            "XYZ",
            "Acme",
            "MainSt",
            "Ready",
            "Magic",
            "Fluent",
            "Peak",
            "Forward",
            "Enterprise",
            "Sales"
        };

        //use this to generate a random order placed
        internal static DateTime GetRandOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }

        //use this to generate a random prefix
        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Co",
            "Corp",
            "Holdings",
            "Corporation",
            "Movers",
            "Cleaners",
            "Bakery",
            "Apparel",
            "Rentals",
            "Storage",
            "Transit",
            "Logistics"
        };

        //use this to generate a random order complete
        public static DateTime? GetRandOrderCompleted(DateTime placed)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - placed;

            if (timePassed < minLeadTime)
            {
                return null;
            }

            return placed.AddHours(_rand.Next(10, 90));
        }

        //use this to get a random customer 
        public static Customer GetRandomCustomer(ApiContext ctx)
        {
            var randomId = _rand.Next(1, ctx.Customers.Count());
            return ctx.Customers.First(c => c.Id == randomId);
        }

        public static decimal GetRandomOrderTotal()
        {
            return _rand.Next(25, 1000);
        }
    }
}