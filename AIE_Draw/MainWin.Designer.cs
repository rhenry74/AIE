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
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            btDelete = new Button();
            btTopAdd = new Button();
            lbElements = new ListBox();
            pSurface = new Panel();
            btUpdate = new Button();
            btDefAdd = new Button();
            tbElementDef = new TextBox();
            tbAutomationStatus = new TextBox();
            timer1 = new System.Windows.Forms.Timer(components);
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
            splitContainer1.Panel2.Controls.Add(btUpdate);
            splitContainer1.Panel2.Controls.Add(btDefAdd);
            splitContainer1.Panel2.Controls.Add(tbElementDef);
            splitContainer1.Panel2.Controls.Add(tbAutomationStatus);
            splitContainer1.Size = new Size(960, 682);
            splitContainer1.SplitterDistance = 548;
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
            splitContainer2.Panel1.Controls.Add(btDelete);
            splitContainer2.Panel1.Controls.Add(btTopAdd);
            splitContainer2.Panel1.Controls.Add(lbElements);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(pSurface);
            splitContainer2.Size = new Size(960, 548);
            splitContainer2.SplitterDistance = 282;
            splitContainer2.TabIndex = 1;
            // 
            // btDelete
            // 
            btDelete.Anchor = AnchorStyles.Top;
            btDelete.Location = new Point(104, 4);
            btDelete.Name = "btDelete";
            btDelete.Size = new Size(75, 23);
            btDelete.TabIndex = 2;
            btDelete.Text = "Delete";
            btDelete.UseVisualStyleBackColor = true;
            btDelete.Click += btDelete_Click;
            // 
            // btTopAdd
            // 
            btTopAdd.Anchor = AnchorStyles.Top;
            btTopAdd.Location = new Point(23, 4);
            btTopAdd.Name = "btTopAdd";
            btTopAdd.Size = new Size(75, 23);
            btTopAdd.TabIndex = 1;
            btTopAdd.Text = "Add";
            btTopAdd.UseVisualStyleBackColor = true;
            btTopAdd.Click += btTopAdd_Click;
            // 
            // lbElements
            // 
            lbElements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbElements.FormattingEnabled = true;
            lbElements.ItemHeight = 15;
            lbElements.Location = new Point(0, 33);
            lbElements.Name = "lbElements";
            lbElements.Size = new Size(279, 469);
            lbElements.TabIndex = 0;
            lbElements.SelectedIndexChanged += lbElements_SelectedIndexChanged;
            // 
            // pSurface
            // 
            pSurface.Dock = DockStyle.Fill;
            pSurface.Location = new Point(0, 0);
            pSurface.Name = "pSurface";
            pSurface.Size = new Size(674, 548);
            pSurface.TabIndex = 0;
            pSurface.Paint += pSurface_Paint;
            // 
            // btUpdate
            // 
            btUpdate.Anchor = AnchorStyles.Top;
            btUpdate.Location = new Point(893, 1);
            btUpdate.Name = "btUpdate";
            btUpdate.Size = new Size(64, 23);
            btUpdate.TabIndex = 4;
            btUpdate.Text = "Update";
            btUpdate.UseVisualStyleBackColor = true;
            btUpdate.Click += btUpdate_Click;
            // 
            // btDefAdd
            // 
            btDefAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btDefAdd.Location = new Point(830, 1);
            btDefAdd.Name = "btDefAdd";
            btDefAdd.Size = new Size(64, 23);
            btDefAdd.TabIndex = 2;
            btDefAdd.Text = "Add";
            btDefAdd.UseVisualStyleBackColor = true;
            btDefAdd.Click += btDefAdd_Click;
            // 
            // tbElementDef
            // 
            tbElementDef.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbElementDef.Location = new Point(3, 2);
            tbElementDef.Name = "tbElementDef";
            tbElementDef.Size = new Size(821, 23);
            tbElementDef.TabIndex = 1;
            // 
            // tbAutomationStatus
            // 
            tbAutomationStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAutomationStatus.Location = new Point(0, 24);
            tbAutomationStatus.Multiline = true;
            tbAutomationStatus.Name = "tbAutomationStatus";
            tbAutomationStatus.Size = new Size(960, 106);
            tbAutomationStatus.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // MainWin
            // 
            ClientSize = new Size(960, 682);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(856, 492);
            Name = "MainWin";
            Text = "AIE_Draw";
            Load += MainWin_Load;
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
        private Button btDelete;
        private Button btTopAdd;
        private ListBox lbElements;
        private TextBox tbElementDef;
        private Button btDefAdd;
        private Button btUpdate;
        private System.Windows.Forms.Timer timer1;
    }
}
