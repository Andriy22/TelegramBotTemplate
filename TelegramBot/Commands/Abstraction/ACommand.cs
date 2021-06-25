using Telegram.Bot;

namespace TelegramBot.Commands.Abstraction
{
    public abstract class ACommand
    {
        protected ACommand(string command, string[] args)
        {
            Command = command;
            Args = args;
        }

        public string Command { get; set; }
        public string[] Args { get; set; }

        /// <summary>
        /// Telegram bot command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="telegramBot"></param>
        /// <param name="arg">Model that contains args</param>
        public abstract void Execute<T>(TelegramBotClient telegramBot, T arg);
    }
}