using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotAsp.Helpers;

namespace TelegramBotAsp.Commands
{
    /// <summary>
    /// This is the starting command that Telegram sends.
    /// </summary>
    /// <seealso cref="TelegramBotAsp.Commands.CommandBase" />
    public class StartCommand : CommandBase
    {
        /// <summary>
        /// Trigger from Telegram command name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name => "start";

        /// <summary>
        /// The command sends a list of available commands.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client">The client.</param>
        public override void Execute(Message message, TelegramBotClient client)
        {
            //The chat ID determines from which chat the message came, respectively, to which chat to send a response
            long chatId = message.Chat.Id;

            //Collecting names of all available commands
            StringBuilder builder = new StringBuilder();

            foreach (CommandBase command in BotManager.Commands)
            {
                builder.Append($"\n/{command.Name}");
            }

            //Reply to the message with the chat ID and text
            client.SendTextMessageAsync(chatId, $"You can use the following commands:{builder.ToString()}");
        }
    }
}