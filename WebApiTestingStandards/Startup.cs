using System;
using System.Net.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using WebApiTestingStandards.Controllers;
using WebApiTestingStandards.Roles;
using WebApiTestingStandards.Services;

namespace WebApiTestingStandards
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var builder = new ContainerBuilder();

            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<CustomerService>().As<ICustomerService>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
            SwaggerConfig.Register(config);

            appBuilder.UseWebApi(config);
        }
    }

    public class MyActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var service = new CustomerService();
            return new CustomerController(service);
        }
    }
}