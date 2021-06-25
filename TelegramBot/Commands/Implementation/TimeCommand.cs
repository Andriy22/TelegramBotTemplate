using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Commands.Abstraction;
using TelegramBot.Constants;

namespace TelegramBot.Commands.Implementation
{
    public class TimeCommand : ACommand
    {
        public TimeCommand() : base(CommandsConstants.TimeCommand, null) { }

        public override async void Execute<T>(TelegramBotClient telegramBot, T arg)
        {
            var model = arg as Message;

            await telegramBot.SendTextMessageAsync(model.Chat, $"Current time: {DateTime.Now.ToString("G")}", parseMode: Telegram.Bot.Types.Enums.ParseMode.Default);
        }
    }
}