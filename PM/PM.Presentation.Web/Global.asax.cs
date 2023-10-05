using System;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PM.Presentation.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}