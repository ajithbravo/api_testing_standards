using System.Net;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using WebApiTestingStandards.Models;
using WebApiTestingStandards.Roles;

namespace WebApiTestingStandards.Controllers
{
    [RoutePrefix("api")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("customers")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(CustomerSearchResults))]
        [ApiHeader(typeof(string), "CorrelationId", "Correlation ID", true)]
        public IHttpActionResult Get()
        {
            return Ok(_customerService.GetCustomers());
        }

        [HttpGet]
        [Route("customer")]
        public IHttpActionResult GetCustomer(int? id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("Customer ID mandatory");
            }

            var customer = _customerService.GetCustomer(id);
            if (customer == null)
            {
                return BadRequest("Customer ID not found");
            }

            return Ok(customer);
        }

        [HttpPost]
        [Route("newCustomer")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Customer))]
        public IHttpActionResult Post([FromBody] NewCustomerRequest request)
        {
            return Ok(new Customer
            {
                Name = request.Name,
                Address = request.Address,
                Telephone = request.Telephone
            });
        }
    }
}