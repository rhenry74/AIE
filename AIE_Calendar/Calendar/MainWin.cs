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
            try
            {
                if (Program.SharedContext.Altered(Constants.TITLE_KEY))
                {
                    tbTitle.Text = Program.SharedContext.Dequeue(Constants.TITLE_KEY);
                    return;
                }

                if (Program.SharedContext.Altered(Constants.FROM_KEY))
                {
                    var text = Program.SharedContext.Dequeue(Constants.FROM_KEY);
                    DateTime from;
                    DateTime.TryParse(text, out from);
                    _lastEventDay = new DateTime(from.Year, from.Month, from.Day);
                    dtpDate.Value = from;
                    dtpTime.Value = from;
                    //GenerateEventDay();
                    return;
                }

                if (Program.SharedContext.Altered(Constants.DESCRIPTION_KEY))
                {
                    while (Program.SharedContext.Altered(Constants.DESCRIPTION_KEY))
                    {
                        var text = Program.SharedContext.Dequeue(Constants.DESCRIPTION_KEY);
                        tbBody.AppendText(text);
                        tbBody.AppendText(Environment.NewLine);
                    }
                    return;
                }

                while (Program.SharedContext.AutomationLog.Count > 0)
                {
                    tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
                }
            }
            catch (Exception ex) 
            {
                tbAutomationStatus.AppendText("UI_UpdateTimer_Tick fail: " + ex.ToString() + Environment.NewLine);
            }
        }

        private CalendarEvent _eventBeingEdited;

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
                //(StartA < EndB) and (EndA > StartB) overlap test
                DateTime eventEnd(CalendarEvent e) => e.Start.AddMinutes(e.Duration);
                var dayEnd = day.AddHours(1);
                var hoursEvents = Program.Events.Where(e => e.Start < dayEnd && eventEnd(e) > day)
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
            if (this._currentTimeBlock != null)
            {
                this._currentTimeBlock.IsCurrent = false;
            }
            TimeBlock blockGraphic = (TimeBlock)sender;
            blockGraphic.IsCurrent = true;
            _currentTimeBlock = blockGraphic;
            dtpTime.Value = blockGraphic.HourOnDay;

            if (blockGraphic.Events.Count == 1)
            {
                SetEventEdits(blockGraphic.Events[0]);
            }
            if (blockGraphic.Events.Count == 0)
            {
                ClearEventEdits();
            }
            if (blockGraphic.Events.Count > 1)
            {
                GenerateDaysEvents(blockGraphic);
            }
        }

        private void ClearEventEdits()
        {
            this.nudDuration.Value = 30;
            this.tbTitle.Text = "";
            this.tbBody.Text = "";
            btDelete.Enabled = false;
            btUpdate.Enabled = false;
        }

        private void SetEventEdits(CalendarEvent calEvent)
        {
            this.dtpDate.Value = calEvent.Start;
            this.dtpTime.Value = calEvent.Start;
            this.nudDuration.Value = calEvent.Duration;
            this.tbTitle.Text = calEvent.Title;
            this.tbBody.Lines = calEvent.Description;
            btDelete.Enabled = true;
            btUpdate.Enabled = true;
            _eventBeingEdited = calEvent;
        }

        private void GenerateDaysEvents(TimeBlock block)
        {
            layoutDay.Controls.Clear();
            var backButton = new Button();
            backButton.Text = "< " + block.HourOnDay.ToShortTimeString();
            backButton.Click += (s, e) =>
            {
                ClearEventEdits();
                GenerateEventDay();
            };
            layoutDay.Controls.Add(backButton);

            ClearEventEdits();

            foreach (var calEvent in block.Events)
            {
                var blockGraphic = new AnEvent(calEvent);
                layoutDay.Controls.Add(blockGraphic);
                blockGraphic.CalendarEventClick += BlockGraphic_CalendarEventClick;
            }
        }

        private AnEvent? _previousAnEvent = null;
        private void BlockGraphic_CalendarEventClick(object? sender, EventArgs e)
        {
            AnEvent blockGraphic = (AnEvent)sender;
            if (_previousAnEvent != blockGraphic)
            {
                SetEventEdits(blockGraphic.Event);
                if (_previousAnEvent != null)
                {
                    _previousAnEvent.IsCurrent = false;
                }
                blockGraphic.IsCurrent = true;
                _previousAnEvent = blockGraphic;
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
                this.nudDuration.Value = 30;
                this.tbTitle.Text = "";
                this.tbBody.Text = "";
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

        private void UpdateBlocks()
        {
            foreach(Control control in layoutDay.Controls)
            {
                control.Refresh();//works partially
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            _eventBeingEdited.Description = tbBody.Lines;
            _eventBeingEdited.Start = this.dtpDate.Value;
            _eventBeingEdited.Title = this.tbTitle.Text;
            _eventBeingEdited.Duration = (int)this.nudDuration.Value;
            Task.Run(() => Program.SaveEventsAsync()).Wait();
            GenerateEventDay();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            Program.Events.Remove(_eventBeingEdited);
            Task.Run(() => Program.SaveEventsAsync()).Wait();
            GenerateEventDay();
        }
    }
}
