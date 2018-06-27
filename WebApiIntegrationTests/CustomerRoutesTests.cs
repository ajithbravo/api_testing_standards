using System.Collections.Generic;
using Microsoft.Owin.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using WebApiTestingStandards;
using WebApiTestingStandards.Controllers;

namespace WebApiComponentTests
{
    public class CustomerRoutesTests
    {
        [Test]
        public void GetCustomers_GetCustomersRoute_ReturnsCustomers()
        {
            using (var server = TestServer.Create<Startup>())
            {
                var result = await server.HttpClient.GetAsync("customer/customers");
                string responseContent = await result.Content.ReadAsStringAsync();
                var entity = JsonConvert.DeserializeObject<CustomerSearchResults>(responseContent);

                Assert.IsTrue(entity.Count == 3);
            }
        }
    }
}
