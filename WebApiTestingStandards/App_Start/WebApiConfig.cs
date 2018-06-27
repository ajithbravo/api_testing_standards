using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace WebApiTestingStandards
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "CustomerApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new MyActivator());

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}