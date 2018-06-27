using NUnit.Framework;
using System;
using ApprovalTests;
using ApprovalTests.Reporters;
using Microsoft.Owin.Testing;
using WebApiTestingStandards;

namespace WebApiApprovalContractTests
{
    [UseReporter(typeof(DiffReporter))]
    public class CustomerContractTests
    {
        [Test]
        public void CustomerContract_VerifyTheCustomerContract_ApproveTheCurrentVersion()
        {
            using (var server = TestServer.Create<Startup>())
            {
                server.BaseAddress = new Uri("http://localhost:4000/swagger/docs/v1");
                var response = server.HttpClient.GetAsync(server.BaseAddress)
                    .Result.Content.ReadAsStringAsync();
                Approvals.VerifyJson(response.Result);
            }
        }
    }
}