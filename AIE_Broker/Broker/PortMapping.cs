
namespace Broker
{
    public class PortMapping
    {
        public int Port { get; set; }
        public string Server { get; set; }
        public string Name { get; set; }
        public int ProcessId { get; set; }
        public DateTime Started { get; internal set; }
    }
}