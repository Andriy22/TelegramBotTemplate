using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Commands.Abstraction;
using TelegramBot.Constants;

namespace TelegramBot.Commands.Implementation.System
{
    public class NotFoundCommand : ACommand
    {
        public NotFoundCommand() : base(CommandsConstants.NotFoundCommand, null) { }

        public override async void Execute<T>(TelegramBotClient telegramBot, T arg)
        {
            var model = arg as Message;

            await telegramBot.SendTextMessageAsync(model.Chat, $"We couldn't find this command:(\nUse /help to see all commands!", parseMode: Telegram.Bot.Types.Enums.ParseMode.Default);
        }
    }
}