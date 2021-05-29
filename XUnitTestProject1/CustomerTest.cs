using System;
using System.Net.Http;
using System.Threading.Tasks;

using Xunit;
using WebApiService;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.TestHost;
using System.Net;
using NUnit.Framework;

namespace XUnitTestFCustomer
{
    
    public class CustomerTest
    {
        private readonly HttpClient _client;

        public CustomerTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("localhost")
                .UseStartup<Startup>());
            _client = server.CreateClient();

                
        }
         
        [Xunit.Theory]
        [InlineData("GET")]
        public async Task GetCustomer(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"api/Customer");
            
            //Act
            var response = await _client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equals(HttpStatusCode.OK, response.StatusCode);
            
        }
        [Fact]
        public void Test1()
        {
            Assert.Equals(5>1, true);

        }
    }
}
