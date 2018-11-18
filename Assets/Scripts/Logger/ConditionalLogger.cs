

using System.Diagnostics;

namespace Assets.Scripts.Logger
{
    // позволяет полностью отключать логирование.
    public static class ConditionalLogger
    {
        private static ILogger _logger;

        public static void Initialize(ILogger logger)
        {
            _logger = logger;
        }
        [Conditional("LOG_ENABLED")]
        public static void Log(string s)
        {
            _logger?.Log(s);
        }
        [Conditional("LOG_ENABLED")]
        public static void LogError(string s)
        {
            _logger?.LogError(s);
        }
        [Conditional("LOG_ENABLED")]
        public static void LogWarning(string s)
        {
            _logger?.LogWarning(s);
        }

        
    }
}
