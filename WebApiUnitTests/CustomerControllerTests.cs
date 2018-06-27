using Moq;
using NUnit.Framework;
using System.Web.Http.Results;
using WebApiTestingStandards.Controllers;
using WebApiTestingStandards.Roles;

namespace WebApiUnitTests
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly CustomerController _customerController;

        public CustomerControllerTests()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _customerController = new CustomerController(_mockCustomerService.Object);
        }

        [Test(Description = "ApiResponseConvention")]
        public void CustomerById_IncorrectOrNotFoBundId_ReturnsBadRequest()
        {
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(mc => mc.GetCustomer(It.IsAny<int>()))
                .Returns(() => null);
            var customerController = new CustomerController(mockCustomerService.Object);
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(customerController.GetCustomer(20));
        }

        [Test(Description = "ApiResponseConvention")]
        public void CustomerById_NoIdProvided_ReturnsBadRequest()
        {
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(_customerController.GetCustomer(null));
        }

        [Test(Description = "ApiServiceRole/Collaboration")]
        public void CustomersServiceRole_CustomerControllerInvokesRole_ServiceIsInvoked()
        {
            _customerController.Get();
            _mockCustomerService.Verify(s => s.GetCustomers());
        }

        [Test(Description = "ApiServiceRole/Collaboration")]
        public void CustomerIdServiceRole_CustomerControllerInvokesRole_ServiceIsInvoked()
        {
            _customerController.GetCustomer(5);
            _mockCustomerService.Verify(s => s.GetCustomer(5));
        }
    }
}