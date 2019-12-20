using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramBotAsp.Commands;
using TelegramBotAsp.Helpers;

namespace TelegramBotAsp.Controllers
{
    public class MessageController : ApiController
    {
        /// <summary>
        /// Telegram message handler
        /// </summary>
        /// <param name="update">The update.</param>
        /// <returns></returns>
        [Route(Routes.MessageController)]
        public OkResult Update([FromBody]Update update)
        {
            //Taking message text from data sent by telegrams
            Message msg = update.Message;

            //Check if the message contains one of the bot commands
            IReadOnlyCollection<CommandBase> commands = BotManager.Commands;
            foreach (CommandBase command in commands)
            {
                if (command.CheckCommandContains(msg.Text))
                {
                    //If the message contains a command, then perform the action according to this command
                    command.Execute(msg, BotManager.Client);
                    break;
                }
            }

            return Ok();
        }
    }
}
