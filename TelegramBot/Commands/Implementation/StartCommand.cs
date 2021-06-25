using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Commands.Abstraction;
using TelegramBot.Constants;

namespace TelegramBot.Commands.Implementation
{
    public class StartCommand : ACommand
    {
        public StartCommand() : base(CommandsConstants.StartCommand, null) { }

        public override async void Execute<T>(TelegramBotClient telegramBot, T arg)
        {
            var model = arg as Message;

            await telegramBot.SendTextMessageAsync(model.Chat, $"Hello, {model.Chat.FirstName} {model.Chat.LastName}\nThis is .NET Core Telegram Bot template. You can use /help to see all commands!\n\n.NET Core TelegramBot Template", parseMode: Telegram.Bot.Types.Enums.ParseMode.Default);
        }
    }
}