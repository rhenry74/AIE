using System.Collections;

namespace AIE_InterThread
{
    public class InterThread
    {
        private Dictionary<string, Queue<string>> Queues = new Dictionary<string, Queue<string>>();

        public Queue<string> AutomationLog { get; set; } = new Queue<string>();

        public bool Altered(string key)
        {
            return Queues.ContainsKey(key);
        }

        public void Enqueue(string key, string value)
        {
            if (Queues.ContainsKey(key)) 
            {
                Queues[key].Enqueue(value);
            }
            else
            {
                var queue = new Queue<string>();
                queue.Enqueue(value);
                Queues.Add(key, queue);
            }
        }

        public string Dequeue(string key)
        {
            if (Queues.ContainsKey(key))
            {
                var value = Queues[key].Dequeue();
                if (Queues[key].Count == 0)
                {
                    Queues.Remove(key);
                }
                return value;
            }
            else
            {
                return "";
            }
        }
    }
}
