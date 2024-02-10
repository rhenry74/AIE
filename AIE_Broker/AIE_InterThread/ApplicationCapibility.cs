using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIE_InterThread
{
    public enum ActionType
    {
        LAUNCH,
        HTTP
    }

    public enum MethodType
    {
        GET,
        POST,
        PUT,
        DELETE,
        NA
    }

    public class ApplicationCapibility
    {
        public string Action { get; set; }
        public string AppClass { get; set; }
        public string AppPath { get; set; }
        public ActionType ActionType { get; set; }
        public string Description { get; set; }
        public string Route { get; set; }
        public MethodType Method { get; set; }
        public string ContentType { get; set; } 
        public string Contract { get; set; }
    }
}
