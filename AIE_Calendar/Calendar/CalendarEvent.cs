using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public record CalendarEvent
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public DateTime Start { get; set; } 
        public string[] Description { get; set; }
        public int Duration { get; set; }
    }
}
