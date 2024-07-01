using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void UI_UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Program.SharedContext.Altered(Constants.TITLE_KEY))
            {
                tbTitle.Text = Program.SharedContext.Dequeue(Constants.TITLE_KEY);
            }

            while (Program.SharedContext.Altered(Constants.DESCRIPTION_KEY))
            {
                var text = Program.SharedContext.Dequeue(Constants.DESCRIPTION_KEY);
                tbBody.AppendText(text);
                tbBody.AppendText(Environment.NewLine);
            }

            if (Program.SharedContext.Altered(Constants.FROM_KEY))
            {
                var text = Program.SharedContext.Dequeue(Constants.FROM_KEY);
                DateTime from;
                DateTime.TryParse(text, out from);
                dtpDate.Value = from;
                dtpTime.Value = from;
                GenerateEventDay();
            }

            while (Program.SharedContext.AutomationLog.Count > 0)
            {
                tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            this.Text = "AIE Calendar on Port " + Program.PortText;
            this.dtpDate.Value = DateTime.Now;
            this.dtpTime.Value = this.dtpDate.Value;
            this.nudDuration.Value = 30;

            GenerateEventDay();
        }

        private void GenerateEventDay()
        {
            layoutDay.Controls.Clear();
            DateTime day = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day);

            for (int block = 0; block < 24; block++)
            {
                var hoursEvents = Program.Events.Where(e => e.Start >= day && e.Start < day.AddHours(1))
                    .OrderBy(e => e.Start).ToList();

                var blockGraphic = new TimeBlock(day, hoursEvents);
                layoutDay.Controls.Add(blockGraphic);
                blockGraphic.TimeBlockClick += BlockGraphic_TimeBlockClick;

                day = day.AddHours(1);
            }
        }

        private TimeBlock _currentTimeBlock = null;
        private void BlockGraphic_TimeBlockClick(object? sender, EventArgs e)
        {
            if(this._currentTimeBlock != null) 
            {
                this._currentTimeBlock.IsCurrent = false;
            }
            TimeBlock blockGraphic = (TimeBlock)sender;
            blockGraphic.IsCurrent = true;
            _currentTimeBlock = blockGraphic;
            dtpTime.Value = blockGraphic.HourOnDay;
            if (blockGraphic.Events.Count == 1 )
            {
                this.dtpDate.Value = blockGraphic.Events[0].Start;
                this.dtpTime.Value = blockGraphic.Events[0].Start;
                this.nudDuration.Value = blockGraphic.Events[0].Duration;
                this.tbTitle.Text = blockGraphic.Events[0].Title;
                this.tbBody.Lines = blockGraphic.Events[0].Description;
            }
            if (blockGraphic.Events.Count == 0)
            {
                this.nudDuration.Value = 30;
                this.tbTitle.Text = "";
                this.tbBody.Text = "";
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var newEvent = new CalendarEvent()
            {
                Id = Guid.NewGuid(),
                Description = tbBody.Lines,
                Start = this.dtpDate.Value,
                Title = this.tbTitle.Text,
                Duration = (int)this.nudDuration.Value
            };

            Program.Events.Add(newEvent);
            Task.Run(() => Program.SaveEventsAsync()).Wait();
            GenerateEventDay();
        }

        private DateTime _lastEventDay = DateTime.MinValue;
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            var theEventDay = new DateTime(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day);
            if (_lastEventDay != theEventDay)
            {
                GenerateEventDay();
                _lastEventDay = theEventDay;
            }
            
        }

        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            var adjustedDateTime = this.dtpDate.Value;
            var newTime = this.dtpTime.Value;
            adjustedDateTime = new DateTime(adjustedDateTime.Year, adjustedDateTime.Month, adjustedDateTime.Day,
                newTime.Hour, newTime.Minute, newTime.Second);
            this.dtpDate.Value = adjustedDateTime;
        }
    }
}
