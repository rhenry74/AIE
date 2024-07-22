namespace AIE_Draw
{
    partial class MainWin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            lbElements = new ListBox();
            pSurface = new Panel();
            tbSeriesDef = new TextBox();
            tbAutomationStatus = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tbSeriesDef);
            splitContainer1.Panel2.Controls.Add(tbAutomationStatus);
            splitContainer1.Size = new Size(840, 453);
            splitContainer1.SplitterDistance = 364;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(button3);
            splitContainer2.Panel1.Controls.Add(button2);
            splitContainer2.Panel1.Controls.Add(button1);
            splitContainer2.Panel1.Controls.Add(lbElements);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(pSurface);
            splitContainer2.Size = new Size(840, 364);
            splitContainer2.SplitterDistance = 247;
            splitContainer2.TabIndex = 1;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top;
            button3.Location = new Point(167, 4);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.Location = new Point(86, 4);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Location = new Point(5, 4);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lbElements
            // 
            lbElements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbElements.FormattingEnabled = true;
            lbElements.ItemHeight = 15;
            lbElements.Location = new Point(0, 33);
            lbElements.Name = "lbElements";
            lbElements.Size = new Size(244, 289);
            lbElements.TabIndex = 0;
            // 
            // pSurface
            // 
            pSurface.Dock = DockStyle.Fill;
            pSurface.Location = new Point(0, 0);
            pSurface.Name = "pSurface";
            pSurface.Size = new Size(589, 364);
            pSurface.TabIndex = 0;
            pSurface.Paint += pSurface_Paint;
            // 
            // tbSeriesDef
            // 
            tbSeriesDef.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSeriesDef.Location = new Point(3, 2);
            tbSeriesDef.Name = "tbSeriesDef";
            tbSeriesDef.Size = new Size(834, 23);
            tbSeriesDef.TabIndex = 1;
            // 
            // tbAutomationStatus
            // 
            tbAutomationStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAutomationStatus.Location = new Point(0, 24);
            tbAutomationStatus.Multiline = true;
            tbAutomationStatus.Name = "tbAutomationStatus";
            tbAutomationStatus.Size = new Size(840, 61);
            tbAutomationStatus.TabIndex = 0;
            // 
            // MainWin
            // 
            ClientSize = new Size(840, 453);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(856, 492);
            Name = "MainWin";
            Text = "AIE_Draw";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel pSurface;
        private TextBox tbAutomationStatus;
        private SplitContainer splitContainer2;
        private Button button3;
        private Button button2;
        private Button button1;
        private ListBox lbElements;
        private TextBox tbSeriesDef;
    }
}
