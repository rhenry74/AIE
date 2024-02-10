namespace AIE_InterThread
{
    public class InterThread
    {
        private Dictionary<string, string> KeyValuePairs = new Dictionary<string, string>();
        private Dictionary<string, bool> AlteredState = new Dictionary<string, bool>();
        public Queue<string> AutomationLog = new Queue<string>();

        public bool Altered(string key)
        {
            return AlteredState.ContainsKey(key) ? AlteredState[key] : false;
        }

        public void SetAltered(string key, bool value) 
        {
            AlteredState[key] = value;
        }

        public void SetPair(string key, string value)
        {
            if (KeyValuePairs.ContainsKey(key)) 
            { 
                KeyValuePairs[key] = value; 
            }
            else
            { 
                KeyValuePairs.Add(key, value);
            }
            SetAltered(key, true);
        }

        public string GetValue(string key)
        {
            if (KeyValuePairs.ContainsKey(key))
            {
                return KeyValuePairs[key];
            }
            else
            {
                return "";
            }
        }
    }
}
