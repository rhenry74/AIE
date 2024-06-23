namespace Broker
{
    public class BrokerWorker
    {
        public enum Status
        {
            Ready,
            Executing,
            Success,
            Failure,
            Weak,
            Compiling,
            Ambigous
        };

        public List<string> Logs { get; internal set; } = new List<string>();

        public void LogMessage(string message)
        {
            Program.SharedContext.AutomationLog.Enqueue(message);
            Logs.Add(DateTime.Now.ToShortTimeString() + " " + message);
        }
    }
}