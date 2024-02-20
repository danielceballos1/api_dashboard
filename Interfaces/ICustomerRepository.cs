using System;
using dashboard_api.Models;

namespace dashboard_api.Interfaces
{
        public interface ICustomerRepository
        {
            IEnumerable<Customer> GetAll();
            Customer GetById(int id);
            void Add(Customer customer);
            void Update(Customer customer);
            void Delete(int id);
        }

}

