using System;
using dashboard_api.Data;
using dashboard_api.Interfaces;
using dashboard_api.Models;

namespace dashboard_api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApiContext _context;

        public CustomerRepository(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.OrderBy(c => c.Id);
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}