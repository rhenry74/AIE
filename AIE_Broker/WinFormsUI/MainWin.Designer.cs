namespace WinFormsUI
{
    partial class MainWin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tbAutomationStatus = new TextBox();
            label4 = new Label();
            UI_UpdateTimer = new System.Windows.Forms.Timer(components);
            splitContainer1 = new SplitContainer();
            button1 = new Button();
            label3 = new Label();
            tbPrompt = new TextBox();
            btEditResponse = new Button();
            tbResponse = new TextBox();
            label5 = new Label();
            toolTip1 = new ToolTip(components);
            splitContainer2 = new SplitContainer();
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
            // tbAutomationStatus
            // 
            tbAutomationStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAutomationStatus.Location = new Point(5, 19);
            tbAutomationStatus.Multiline = true;
            tbAutomationStatus.Name = "tbAutomationStatus";
            tbAutomationStatus.ReadOnly = true;
            tbAutomationStatus.Size = new Size(381, 147);
            tbAutomationStatus.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 2);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 15;
            label4.Text = "Automation:";
            // 
            // UI_UpdateTimer
            // 
            UI_UpdateTimer.Enabled = true;
            UI_UpdateTimer.Interval = 555;
            UI_UpdateTimer.Tick += UI_UpdateTimer_Tick;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Location = new Point(0, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(tbPrompt);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btEditResponse);
            splitContainer1.Panel2.Controls.Add(tbResponse);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Size = new Size(390, 337);
            splitContainer1.SplitterDistance = 167;
            splitContainer1.TabIndex = 19;
            // 
            // button1
            // 
            button1.AccessibleDescription = "Generate";
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = SystemColors.ButtonFace;
            button1.BackgroundImage = Properties.Resources.brain;
            button1.BackgroundImageLayout = ImageLayout.Zoom;
            button1.Location = new Point(10, 135);
            button1.Name = "button1";
            button1.Size = new Size(25, 25);
            button1.TabIndex = 16;
            button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 15;
            label3.Text = "Prompt:";
            // 
            // tbPrompt
            // 
            tbPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbPrompt.Location = new Point(3, 21);
            tbPrompt.Multiline = true;
            tbPrompt.Name = "tbPrompt";
            tbPrompt.Size = new Size(381, 108);
            tbPrompt.TabIndex = 14;
            // 
            // btEditResponse
            // 
            btEditResponse.AccessibleDescription = "Edit Response";
            btEditResponse.AccessibleName = "";
            btEditResponse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btEditResponse.BackColor = SystemColors.ButtonFace;
            btEditResponse.BackgroundImage = Properties.Resources.edit1;
            btEditResponse.BackgroundImageLayout = ImageLayout.Zoom;
            btEditResponse.Location = new Point(10, 134);
            btEditResponse.Name = "btEditResponse";
            btEditResponse.Size = new Size(25, 25);
            btEditResponse.TabIndex = 21;
            toolTip1.SetToolTip(btEditResponse, "Edit Response");
            btEditResponse.UseVisualStyleBackColor = false;
            btEditResponse.Click += bt_EditResponse_Click;
            // 
            // tbResponse
            // 
            tbResponse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbResponse.Location = new Point(3, 21);
            tbResponse.Multiline = true;
            tbResponse.Name = "tbResponse";
            tbResponse.ReadOnly = true;
            tbResponse.Size = new Size(381, 107);
            tbResponse.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 3);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 19;
            label5.Text = "Response:";
            // 
            // toolTip1
            // 
            toolTip1.ToolTipTitle = "Generate";
            // 
            // splitContainer2
            // 
            splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Location = new Point(-5, -6);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            splitContainer2.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tbAutomationStatus);
            splitContainer2.Panel2.Controls.Add(label4);
            splitContainer2.Panel2.RightToLeft = RightToLeft.No;
            splitContainer2.Size = new Size(394, 516);
            splitContainer2.SplitterDistance = 344;
            splitContainer2.TabIndex = 20;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 510);
            Controls.Add(splitContainer2);
            Name = "MainWin";
            Text = "AIE Broker";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbAutomationStatus;
        private Label label4;
        private System.Windows.Forms.Timer UI_UpdateTimer;
        private SplitContainer splitContainer1;
        private Label label3;
        private TextBox tbPrompt;
        private TextBox tbResponse;
        private Label label5;
        private Button button1;
        private Button btEditResponse;
        private ToolTip toolTip1;
        private SplitContainer splitContainer2;
    }
}