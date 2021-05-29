using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiService.Model;
using WebApiService.CustomerServices;

namespace WebApiService.Controllers
{
    [Route("/api/Customer/")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _customerService.GetCustomers();
        }

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerService.UpdateCustomer(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var existingcustomer = _customerService.GetCustomer(id);
            if (existingcustomer != null)
            {
                _customerService.DeleteCustomer(existingcustomer.CustomerId);
                return Ok();
            }
            return NotFound($"Customer Not Found with ID : {existingcustomer.CustomerId}");
        }

        [HttpGet("{id}")]
        public Customer GetCustomer(int id)
        {

            var result = _customerService.GetCustomer(id);
           if(result==null)
               result= new Customer{};
           return result;
        }

     
    }
}
