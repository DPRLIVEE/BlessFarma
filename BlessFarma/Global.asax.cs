using System;
using System.Web.Routing;

namespace SWVGEAD
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }
        private static void RegisterRoutes(RouteCollection routes)
        {
            //PAGINAS

            routes.MapPageRoute("Login", "Login", "~/Paginas/Login.aspx", true);
            routes.MapPageRoute("Principal", "Principal", "~/Paginas/Principal.aspx", true);

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
