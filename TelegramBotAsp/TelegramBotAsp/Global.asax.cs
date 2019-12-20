using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using TelegramBotAsp.Helpers;

namespace TelegramBotAsp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Initialize Telegram bot
            BotManager.Initial();
        }
    }
}
