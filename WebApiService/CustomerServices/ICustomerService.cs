using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiService.Model;

namespace WebApiService.CustomerServices
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer customer);

        List<Customer> GetCustomers();

        void UpdateCustomer(Customer customer);

        void DeleteCustomer(int Id);

        Customer GetCustomer(int Id);
    }
}
