using System;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace AIE_Chart
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void SetGridDataOnChart()
        {
            int x = 0;
            Series series1 = chart1.Series[0];
            series1.Points.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    double i;
                    double.TryParse((string)(row.Cells[1].Value), out i);
                    DataPoint dataPoint1 = new DataPoint(x, i);
                    dataPoint1.AxisLabel = (string)(row.Cells[0].Value);
                    series1.Points.Add(dataPoint1);
                }
                catch (Exception ex)
                {
                    Program.SharedContext.AutomationLog.Enqueue($"Could not set row {x} on chart");
                    Program.SharedContext.AutomationLog.Enqueue(ex.ToString());
                }

                x++;
                //2 extra rows for some reason
                if (x > dataGridView1.Rows.Count - 2)
                    break;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SetGridDataOnChart();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.SharedContext.Altered(Constants.TITLE_KEY))
            {
                chart1.Titles[0].Text = Program.SharedContext.Dequeue(Constants.TITLE_KEY);
            }

            if (Program.SharedContext.Altered(Constants.SERIES_KEY))
            {
                var seriesDef = Program.SharedContext.Dequeue(Constants.SERIES_KEY);
                var pairs = seriesDef.Split(',');
                dataGridView1.Rows.Clear();
                foreach (var pair in pairs)
                {
                    try
                    {
                        var lableAndVal = pair.Split("=");
                        int index = dataGridView1.Rows.Add();
                        dataGridView1.Rows[index].Cells[0].Value = lableAndVal[0];
                        dataGridView1.Rows[index].Cells[1].Value = lableAndVal[1];
                    }
                    catch (Exception ex)
                    {
                        Program.SharedContext.AutomationLog.Enqueue("Could not add pair: " + pair.ToString());
                        Program.SharedContext.AutomationLog.Enqueue(ex.ToString());
                    }
                }
                SetGridDataOnChart();
            }

            while (Program.SharedContext.AutomationLog.Count > 0)
            {
                tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
            }

        }

        private void btSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using var file = saveFileDialog1.OpenFile();
            chart1.SaveImage(file, ChartImageFormat.Png);
        }

        private void tbSeriesDef_Leave(object sender, EventArgs e)
        {
            Program.SharedContext.Enqueue(Constants.SERIES_KEY, tbSeriesDef.Text);
        }
    }
}
