using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class TimeBlock : UserControl
    {
        public DateTime HourOnDay { get; }
        public List<CalendarEvent> Events { get; }

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

        public event EventHandler TimeBlockClick;

        public TimeBlock()
        {
            InitializeComponent();
        }

        public TimeBlock(DateTime hourOnDay, List<CalendarEvent> events) : this()
        {
            HourOnDay = hourOnDay;
            Events = events;
        }

        private void TimeBlock_Load(object sender, EventArgs e)
        {
            btTime.Text = HourOnDay.ToShortTimeString();
            btTime.BackColor = Events == null ? Color.SeaShell : Events.Count > 0 ? Color.LightBlue : Color.SeaShell;
        }

        public override void Refresh()
        {
            base.Refresh();
        }

        private void btTime_Click(object sender, EventArgs e)
        {
            if (TimeBlockClick != null)
            {
                TimeBlockClick(this, e);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            var color = Color.FromArgb(100, Color.Goldenrod);
            var brush = new SolidBrush(color);
            foreach(var calendarEvent in Events)
            {
                if (calendarEvent.Start < this.HourOnDay)
                {
                    //the event started on the previous day
                    int location = 1;
                    var diff = this.HourOnDay.Subtract(calendarEvent.Start).TotalMinutes;
                    diff = calendarEvent.Duration - diff;
                    int size = (int)(diff * panel.Width / 60);
                    e.Graphics.FillRectangle(brush, 2 + location, 2, size, panel.Height - 4);
                }
                else
                {
                    int size = (int)(calendarEvent.Duration * panel.Width / 60);
                    int location = (int)(calendarEvent.Start.Minute * panel.Width / 60);
                    e.Graphics.FillRectangle(brush, 2 + location, 2, size, panel.Height - 4);
                    e.Graphics.DrawLine(Pens.Gray, 2 + location, 2, 2 + location, panel.Height - 4);
                }
            }
        }

    }
}
