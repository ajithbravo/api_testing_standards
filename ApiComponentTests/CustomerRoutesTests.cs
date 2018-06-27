using System;
using System.Linq;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using WebApiTestingStandards;
using WebApiTestingStandards.Models;

namespace ApiComponentTests
{
    public class CustomerRoutesTests
    {
        [Test]
        public void GetCustomers_GetCustomersRoute_ReturnsCustomers()
        {
            using (var server = TestServer.Create<Startup>())
            {
                server.BaseAddress = new Uri("http://localhost:4000/");
                var response = server.HttpClient.GetAsync(server.BaseAddress + "api/customers")
                    .Result.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<CustomerSearchResults>(response.Result);
                Assert.True(responseJson.Customers.Any());
            }
        }
    }
}