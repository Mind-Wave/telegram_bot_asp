using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotAsp.Helpers;

namespace TelegramBotAsp.Commands
{
    /// <summary>
    /// Base class for all Commands
    /// </summary>
    public abstract class CommandBase
    {
        /// <summary>
        /// Gets Command name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public abstract string Name { get; }

        /// <summary>
        /// Command action.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client">The client.</param>
        public abstract void Execute(Message message, TelegramBotClient client);

        /// <summary>
        /// Checks the command contains in message text.
        /// </summary>
        /// <param name="commandTextToCheck">The command text to check.</param>
        /// <returns></returns>
        public bool CheckCommandContains(string commandTextToCheck)
        {
            return commandTextToCheck.Contains($"/{this.Name}");
        }

        /// <summary>
        /// Check if the bot contains a call by name in the message.
        /// </summary>
        /// <param name="commandTextToCheck">The command text to check.</param>
        /// <returns></returns>
        public static bool CheckPersonalCommand(string commandTextToCheck)
        {
            return commandTextToCheck.Contains(BotSettings.BotName);
        }
    }
}