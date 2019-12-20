using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotAsp.Commands
{
    /// <summary>
    /// Hello command
    /// </summary>
    /// <seealso cref="TelegramBotAsp.Commands.CommandBase" />
    public class HelloCommand : CommandBase
    {
        /// <summary>
        /// Trigger from Telegram command name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name => "hello";

        /// <summary>
        /// The command sends a welcome message
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client">The client.</param>
        public override void Execute(Message message, TelegramBotClient client)
        {
            //The chat ID determines from which chat the message came, respectively, to which chat to send a response
            long chatId = message.Chat.Id;

            //This is the ID of a specific message, it can be used to respond with a link to the message (Reply)
            int msgId = message.MessageId;

            //User nick from message
            string senderNick = message.From.Username;

            //Personal greeting or regular
            if (CheckPersonalCommand(message.Text))
            {
                //Reply to the message with the chat ID, text and link to the message
                client.SendTextMessageAsync(chatId, $"Hi {senderNick}", replyToMessageId: msgId/*This field is optional.*/);
            }
            else
            {
                //Reply to the message with the chat ID, text and link to the message
                client.SendTextMessageAsync(chatId, "Hi", replyToMessageId: msgId);
            }
        }
    }
}