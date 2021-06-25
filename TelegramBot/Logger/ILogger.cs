namespace TelegramBot.Logger
{
    public interface ILogger
    {
        public void Info(string msg);
        public void Warn(string msg);
        public void Error(string msg);
    }
}
