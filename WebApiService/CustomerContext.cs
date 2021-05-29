using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiService.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApiService
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
            
        }
        

        public DbSet<Customer> Customer { get; set; }
    }
}
