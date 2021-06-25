using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Commands.Abstraction;
using TelegramBot.Constants;

namespace TelegramBot.Commands.Implementation.System
{
    public class NotSupportedCommand : ACommand
    {
        public NotSupportedCommand() : base(CommandsConstants.NotSupportedCommand, null) { }

        public override async void Execute<T>(TelegramBotClient telegramBot, T arg)
        {
            var model = arg as Message;

            await telegramBot.SendTextMessageAsync(model.Chat, $"Sorry, this command not supported:(", parseMode: Telegram.Bot.Types.Enums.ParseMode.Default);
        }
    }
}