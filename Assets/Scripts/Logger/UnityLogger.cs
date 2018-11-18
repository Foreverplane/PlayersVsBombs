using UnityEngine;

namespace Assets.Scripts.Logger
{
    public class UnityLogger : ILogger
    {
        public void Log(string s)
        {
            Debug.Log(s);
        }

        public void LogError(string s)
        {
            Debug.LogError(s);
        }

        public void LogWarning(string s)
        {
            Debug.LogWarning(s);
        }
    }
}