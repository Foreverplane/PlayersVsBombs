namespace Assets.Scripts.Logger
{
    public interface ILogger
    {
        void Log(string s);
        void LogError(string s);
        void LogWarning(string s);
    }
}