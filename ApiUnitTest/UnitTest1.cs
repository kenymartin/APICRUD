
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
//using Chinook.API;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using WebApiService;
using WebApiService.Controllers;
using WebApiService.CustomerServices;
using WebApiService.Model;
using System.Web.Http;
using System.Web.Http.Results;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Http;
using  Microsoft.AspNetCore.Mvc;
using Nancy.Json;

namespace ApiUnitTest
{
    public class CustomerTest
    {
        #region Properties
        private readonly HttpClient _client;
        private readonly CustomerController _controller;
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomerTest()
        {
            
        var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
            _controller = new CustomerController(_customerService);
        }
        #endregion

        #region Add
        [Fact]
        public async Task AddCustomer()
        {
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Graham",
                PhoneNumber = "616-665-0987"
            };
            var json = JsonConvert.SerializeObject(customer);
            //arrange
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("/api/Customer/", UriKind.Relative),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
             };
            //Act
            var response = await _client.SendAsync(request).ConfigureAwait(false);
            //Assert
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        #endregion

        #region Update
        [Fact]
        public async Task UpdateCustomer()
        {
            var customer = new Customer
            {
                CustomerId = 2,
                FirstName = "John",
                LastName = "Graham",
                PhoneNumber = "616-665-0987"
            };
            var json = JsonConvert.SerializeObject(customer);
            //arrange
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri("/api/Customer/", UriKind.Relative),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };
            //Act
            var response = await _client.SendAsync(request).ConfigureAwait(false);
            //Assert
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
      
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        #endregion

        #region GetAll
        [Theory]
        [InlineData("GET")]
        public async Task GetAll(string method)
        {
            //arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/Customer");
            //Act
            var response = await _client.SendAsync(request);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);
        }
        #endregion

        #region GetbyId
        [Theory]
        [InlineData("GET", 1)]
        public async Task GetById(string method, int? id)
        {
            //arrange
            var request = new HttpRequestMessage(new HttpMethod(method), $"/api/Customer/{id}");
            //Act
            var response = await _client.SendAsync(request);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task DeleteCustomer()
        {
            var customer = new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Graham",
                PhoneNumber = "616-665-0987"
            };
            var json = JsonConvert.SerializeObject(customer);
            //arrange
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("/api/Customer/", UriKind.Relative),
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
            };
            //Act
            var response = await _client.SendAsync(request).ConfigureAwait(false);
            //Assert
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync()
                .ConfigureAwait(false);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        #endregion
       
    }
}
