using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Commands.Abstraction;
using TelegramBot.Constants;

namespace TelegramBot.Commands.Implementation
{
    public class TestCommand : ACommand
    {
        public TestCommand() : base(CommandsConstants.TestCommand, null) { }

        public override async void Execute<T>(TelegramBotClient telegramBot, T arg)
        {
            var model = arg as Message;

            await telegramBot.SendTextMessageAsync(model.Chat, $"This is test command:)", parseMode: Telegram.Bot.Types.Enums.ParseMode.Default);
        }
    }
}