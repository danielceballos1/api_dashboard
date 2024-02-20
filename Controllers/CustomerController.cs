using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dashboard_api.Data;
using dashboard_api.Interfaces;
using dashboard_api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dashboard_api.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{pageIndex:int}/{pageSize:int}")]
        public IActionResult Get(int pageIndex, int pageSize)
        {
            var data = _customerRepository.GetAll();
            var page = new PaginatedResponse<Customer>(data, pageIndex, pageSize);
            var totalCount = data.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            var response = new
            {
                Page = page,
                TotalPages = totalPages
            };

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _customerRepository.Add(customer);

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (customer == null || customer.Id != id)
            {
                return BadRequest();
            }

            var existingCustomer = _customerRepository.GetById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer.Email = customer.Email;
            existingCustomer.Name = customer.Name;
            existingCustomer.State = customer.State;

            _customerRepository.Update(existingCustomer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCustomer = _customerRepository.GetById(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerRepository.Delete(id);

            return NoContent();
        }
    }
}