using System.Collections.Generic;
using Telegram.Bot;
using TelegramBotAsp.Commands;

namespace TelegramBotAsp.Helpers
{
    /// <summary>
    /// Managing the bot client and bot commands
    /// </summary>
    public static class BotClientManager
    {
        private static TelegramBotClient _client;

        /// <summary>
        /// Gets the commands.
        /// </summary>
        /// <value>
        /// The commands.
        /// </value>
        public static IReadOnlyCollection<CommandBase> Commands { get; private set; }

        /// <summary>
        /// Gets the bot client.
        /// </summary>
        /// <returns></returns>
        public static TelegramBotClient GetClient()
        {
            if (_client == null)
            {
                Initial();
            }

            return _client;
        }

        /// <summary>
        /// Initialization of the bot client
        /// </summary>
        public static void Initial()
        {
            _client = new TelegramBotClient(BotSettings.TelegramBotKey);

            //Add all new commands here
            Commands = new List<CommandBase>()
            {

            };

            string hookLink = $"";
            _client.SetWebhookAsync(hookLink);
        }
    }
}