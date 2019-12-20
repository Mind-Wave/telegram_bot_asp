using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelegramBotAsp.Helpers;

namespace TelegramBotAsp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return $"This is Telegram bot {BotSettings.BotName} main page.";
        }
    }
}