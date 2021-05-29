using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiService.Model;

namespace WebApiService.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        public CustomerContext _customerContext;
        public CustomerService(CustomerContext customerDbContext)
        {
            _customerContext = customerDbContext;
        }
        public Customer AddCustomer(Customer customer)
        {
            _customerContext.Customer.Add(customer);
            _customerContext.SaveChanges();
            return customer;
        }

        public List<Customer> GetCustomers()
        {
            return _customerContext.Customer.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            var result = _customerContext.Customer.FirstOrDefault(o => o.CustomerId == customer.CustomerId);
            if (result != null)
            {
                _customerContext.Update(customer);
                _customerContext.SaveChanges();
            }
        }

        public void DeleteCustomer(int Id)
        {
            var customer = _customerContext.Customer.FirstOrDefault(o => o.CustomerId== Id);
            if (customer != null)
            {
                _customerContext.Remove(customer);
                _customerContext.SaveChanges();
            }
        }

        public Customer GetCustomer(int Id)
        {
            var result = new Customer();
            try
            {
                result = _customerContext.Customer.FirstOrDefault(o => o.CustomerId == Id);
                if (result == null)
                    return result = new Customer();
                
            }
            catch (NullReferenceException e)
            {
                return new Customer();
            }
            return result;
        }

    }
}
