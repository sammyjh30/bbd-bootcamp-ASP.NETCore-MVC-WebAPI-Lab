using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CustomerApi.Models;
using System.Linq;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerContext _context;

        public CustomerController(CustomerContext context)
        {
            _context = context;

            if (_context.CustomerItems.Count() == 0)
            {
                _context.CustomerItems.Add(new CustomerItem
                {
                    FirstName = "Harry",
                    LastName = "Potter",
                    Email = "potterh@hogwarts.wiz",
                    Phone = "0821111111",
                    Address = "4 Privet Drive",
                    City = "Surrey",
                    State = "London County",
                    PostalAddress = "Boy's Dorm Gryffindor Tower"
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<CustomerItem> GetAll()
        {
            return _context.CustomerItems.ToList();
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(long id)
        {
            var item = _context.CustomerItems.FirstOrDefault(t => t.CustomerId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CustomerItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.CustomerItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCustomer", new { id = item.CustomerId }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] CustomerItem item)
        {
            if (item == null || item.CustomerId != id)
            {
                return BadRequest();
            }

            var Customer = _context.CustomerItems.FirstOrDefault(t => t.CustomerId == id);
            if (Customer == null)
            {
                return NotFound();
            }

            Customer.FirstName = item.FirstName;
            Customer.LastName = item.LastName;
            Customer.Email = item.Email;
            Customer.Phone = item.Phone;
            Customer.Address = item.Address;
            Customer.City = item.City;
            Customer.State = item.State;
            Customer.PostalAddress = item.PostalAddress;

            _context.CustomerItems.Update(Customer);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var Customer = _context.CustomerItems.FirstOrDefault(t => t.CustomerId == id);
            if (Customer == null)
            {
                return NotFound();
            }

            _context.CustomerItems.Remove(Customer);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
