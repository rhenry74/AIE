using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class AnEvent : UserControl
    {
        public CalendarEvent Event { get; }

        private bool _isCurrent;

        public bool IsCurrent
        {
            get { return _isCurrent; }
            set
            {
                _isCurrent = value;
                this.checkBox1.Checked = _isCurrent;
            }
        }

        public event EventHandler CalendarEventClick;

        public AnEvent()
        {
            InitializeComponent();
        }

        public AnEvent(CalendarEvent calEvent) : this()
        {
            Event = calEvent;
        }

        private void TimeBlock_Load(object sender, EventArgs e)
        {
            btTime.Text = Event.Start.ToShortTimeString();
            btTime.BackColor = Color.LightBlue;
            nudDuration.Value = Event.Duration;
        }

        private void btTime_Click(object sender, EventArgs e)
        {
            if (CalendarEventClick != null)
            {
                CalendarEventClick(this, e);
            }
        }
    }
}
