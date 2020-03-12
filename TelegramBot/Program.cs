using System;
using Telegram.Bot;

namespace TelegramBot
{
    class Program
    {
        private static readonly string token = "Your Token";
        private static readonly TelegramBotClient bot = new TelegramBotClient(token);
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
