using System.Collections.Generic;
using Telegram.Bot;
using TelegramBotAsp.Commands;

namespace TelegramBotAsp.Helpers
{
    /// <summary>
    /// Managing the bot client and bot commands
    /// </summary>
    public static class BotManager
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
        public static TelegramBotClient Client
        {
            get
            {
                if (_client == null)
                {
                    Initial();
                }

                return _client;
            }
        }

        /// <summary>
        /// Initialization of the bot client
        /// </summary>
        public static void Initial()
        {
            //Initial client
            _client = new TelegramBotClient(BotSettings.TelegramBotKey);

            //Add all new commands here
            Commands = new List<CommandBase>()
            {

            };

            //Telegram bot webhook
            //Telegram will notify the application about new messages via this link
            string hookLink = $"{BotSettings.BotUrl}{Routes.MessageController}";
            _client.SetWebhookAsync(hookLink);
        }
    }
}