namespace Orderappis.Services.Logger
{
    public class ActionLogger
    {
        public static void Log(string action, string message)
        {
            string logFile = "LogFile.txt";

            string logRow = $"[{action}]:::{message}:::{DateTime.Now.ToString()}";

            File.AppendAllText(logFile, logRow + Environment.NewLine);
        }
    }
}
