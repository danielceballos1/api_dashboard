using System;
using dashboard_api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dashboard_api.Data
{
	public class ApiContext : DbContext
	{
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Server> Servers { get; set; }
    }
}

