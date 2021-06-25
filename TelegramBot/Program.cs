using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Commands.Abstraction;
using TelegramBot.Commands.Implementation;
using TelegramBot.Commands.Implementation.System;
using TelegramBot.Constants;
using TelegramBot.Logger;

namespace TelegramBot
{
    class Program
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient(GlobalConstants.TelegramToken);

        // Needs fix in next update
        private static readonly NotFoundCommand notFoundCommand = new NotFoundCommand();
        private static readonly NotSupportedCommand notSupportedCommand = new NotSupportedCommand();

        private static readonly List<ACommand> commands = new List<ACommand>();

        private static readonly ILogger logger = new ConsoleLogger();

        static async Task Main(string[] args)
        {
            try
            {
                commands.Add(new HelpCommand());
                commands.Add(new TestCommand());
                commands.Add(new TimeCommand());
                commands.Add(new StartCommand());

                var me = await bot.GetMeAsync();

                logger.Info($"Bot {me.FirstName} started");

                bot.OnMessage += Bot_OnMessageAsync;
                bot.StartReceiving();

                Console.ReadKey();

                bot.StopReceiving();
            } 
            catch(Exception e)
            {
                logger.Error(e.Message);
            }
        }

        private static void Bot_OnMessageAsync(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            try
            {
                logger.Info($"Received message: {e.Message.Text} from: {e.Message.From.FirstName} {e.Message.From.LastName} Message type: {e.Message.Type}");
                if (!GlobalConstants.SupportedTypes.Contains(e.Message.Type.ToString().ToLower()))
                {
                    notSupportedCommand.Execute(bot, e.Message);
                    return;
                }

                var command = commands.FirstOrDefault(x => string.Compare(x.Command, e.Message.Text, true) == 0);

                if (command != null)
                {
                    logger.Info($"Executing: {command.Command} command!");
                    command.Execute(bot, e.Message);
                }
                else
                {
                    notFoundCommand.Execute(bot, e.Message);
                    logger.Warn($"Command {e.Message.Text} not found!");
                }
            }
            catch (Exception exp)
            {
                logger.Error(exp.Message);
            }
        }
    }
}