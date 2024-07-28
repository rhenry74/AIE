

using System.Linq.Expressions;

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
                tbElementDef.Text = Program.SharedContext.Dequeue(Constants.TEXT_KEY);
                lbElements.Items.Add(GraphicElementFactory.InitializeFrom("Lable: " + tbElementDef.Text));
                this.Refresh();
            }

            if (Program.SharedContext.Altered(Constants.LINE_KEY))
            {
                tbElementDef.Text = Program.SharedContext.Dequeue(Constants.LINE_KEY);
                lbElements.Items.Add(GraphicElementFactory.InitializeFrom("Line: " + tbElementDef.Text));
                this.Refresh();
            }

            while (Program.SharedContext.AutomationLog.Count > 0)
            {
                tbAutomationStatus.AppendText(Program.SharedContext.AutomationLog.Dequeue() + Environment.NewLine);
            }

        }

        private void btTopAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var elementForm = new DrawElement();
                var result = elementForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    lbElements.Items.Add(elementForm.Element);
                }
                this.Refresh();
            }
            catch (Exception any)
            {
                Program.SharedContext.AutomationLog.Enqueue(any.ToString());
            }
        }

        private void pSurface_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                foreach (var element in lbElements.Items)
                {
                    ((IGraphicElement)element).DrawOn(e.Graphics);
                }
            }
            catch (Exception any)
            {
                Program.SharedContext.AutomationLog.Enqueue(any.ToString());
            }
        }

        private void lbElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbElements.SelectedItem != null)
                {
                    tbElementDef.Text = lbElements.SelectedItem.ToString();
                }
            }
            catch (Exception any)
            {
                Program.SharedContext.AutomationLog.Enqueue(any.ToString());
            }
        }

        private void btDefAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var element = GraphicElementFactory.InitializeFrom(tbElementDef.Text);
                lbElements.Items.Add(element);
                this.Refresh();
            }
            catch (Exception any)
            {
                Program.SharedContext.AutomationLog.Enqueue(any.ToString());
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var index = lbElements.SelectedIndex;
                lbElements.Items.RemoveAt(index);
                this.Refresh();
            }
            catch (Exception any)
            {
                Program.SharedContext.AutomationLog.Enqueue(any.ToString());
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var index = lbElements.SelectedIndex;
                var element = GraphicElementFactory.InitializeFrom(tbElementDef.Text);
                lbElements.Items.Insert(index, element);
                lbElements.Items.RemoveAt(index + 1);
                lbElements.SelectedIndex = index;
                this.Refresh();
            }
            catch (Exception any)
            {
                Program.SharedContext.AutomationLog.Enqueue(any.ToString());
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            this.Text = "AIE Draw on Port " + Program.PortText;
        }
    }
}
