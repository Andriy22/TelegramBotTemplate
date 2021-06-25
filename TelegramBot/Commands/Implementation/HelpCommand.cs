using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Commands.Abstraction;
using TelegramBot.Constants;

namespace TelegramBot.Commands.Implementation
{
    public class HelpCommand : ACommand
    {
        public HelpCommand() : base(CommandsConstants.HelpCommand, null) { }

        public override async void Execute<T>(TelegramBotClient telegramBot, T arg)
        {
            var model = arg as Message;

            await telegramBot.SendTextMessageAsync(model.Chat, $"1. /test  - test command!\n2. /time  - returns current time!", parseMode: Telegram.Bot.Types.Enums.ParseMode.Default);
        }
    }
}