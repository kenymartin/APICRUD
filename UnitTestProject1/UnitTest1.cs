using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestMethod;
using WebApiService.Controllers;
using WebApiService.CustomerServices;
using WebApiService.Model;


using Xunit;
using Chinook.API;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly ICustomerService _customerService;
        [TestMethod]
        public void TestMethod1()
        {

            // Act
            var obj = new MyClass();
            var result = obj.IsNegative(-2);

            // Assert

            Assert.AreEqual(true, result, "good");

        }
        [TestMethod]
        public void EmployeeGetById()
        {
            // Set up Prerequisites   
            var controller = new CustomerController(_customerService);
            controller.Request = new HttpRequestMessage();
            controller.co.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Get(1);
            // Assert the result  
            Employee employee;
            Assert.IsTrue(response.TryGetContentValue<Customer>(out employee));
            Assert.AreEqual("Jignesh", employee.Name);
        }
    }

}

namespace TestMethod
{
    public class MyClass
    {
        public MyClass()
        {

        }
        public bool IsNegative(int number)
        {
            return number < 0;
        }
    }
    
}
