
using System;

namespace TelegramBot.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Error(string msg)
        {
            Log(msg, ConsoleColor.Red);
        }

        public void Info(string msg)
        {
            Log(msg, ConsoleColor.Cyan);
        }

        public void Warn(string msg)
        {
            Log(msg, ConsoleColor.DarkYellow);
        }

        private void Log(string msg, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine($"{DateTime.Now.ToString("G")}: {msg}");
            Console.ResetColor();
        }
    }
}
