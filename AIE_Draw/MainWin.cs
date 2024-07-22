

namespace AIE_Draw
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Program.SharedContext.Altered(Constants.TEXT_KEY))
            {
                tbSeriesDef.Text = Program.SharedContext.Dequeue(Constants.TEXT_KEY);
                lbElements.Items.Add(new LableElement(tbSeriesDef.Text));
            }

            if (Program.SharedContext.Altered(Constants.LINE_KEY))
            {
                tbSeriesDef.Text = Program.SharedContext.Dequeue(Constants.LINE_KEY);
                lbElements.Items.Add(new LineElement(tbSeriesDef.Text));
            }

            while (Program.SharedContext.AutomationLog.Count > 0)
            {
                tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var elementForm = new DrawElement();
            var result = elementForm.ShowDialog();
            if (result == DialogResult.OK) 
            {
                lbElements.Items.Add(elementForm.Element);
            }
            this.Refresh();
        }

        private void pSurface_Paint(object sender, PaintEventArgs e)
        {
            foreach (var element in lbElements.Items)
            {
                ((GraphicElement) element).DrawOn(e.Graphics);
            }
        }
    }
}
