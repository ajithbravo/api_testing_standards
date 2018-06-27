using Swashbuckle.Application;
using System.Web.Http;

namespace WebApiTestingStandards
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            config.EnableSwagger(c => { c.SingleApiVersion("v1", "CustomersApi"); })
                .EnableSwaggerUi(c => { });
        }
    }
}