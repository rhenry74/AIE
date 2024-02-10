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
            label3 = new Label();
            tbPrompt = new TextBox();
            tbResponse = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tbAutomationStatus
            // 
            tbAutomationStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAutomationStatus.Location = new Point(3, 455);
            tbAutomationStatus.Multiline = true;
            tbAutomationStatus.Name = "tbAutomationStatus";
            tbAutomationStatus.ReadOnly = true;
            tbAutomationStatus.Size = new Size(361, 107);
            tbAutomationStatus.TabIndex = 16;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(3, 437);
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
            splitContainer1.Location = new Point(0, 2);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(tbPrompt);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tbResponse);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Size = new Size(366, 432);
            splitContainer1.SplitterDistance = 216;
            splitContainer1.TabIndex = 19;
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
            tbPrompt.Size = new Size(357, 166);
            tbPrompt.TabIndex = 14;
            // 
            // tbResponse
            // 
            tbResponse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbResponse.Location = new Point(3, 21);
            tbResponse.Multiline = true;
            tbResponse.Name = "tbResponse";
            tbResponse.ReadOnly = true;
            tbResponse.Size = new Size(357, 160);
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
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 589);
            Controls.Add(splitContainer1);
            Controls.Add(tbAutomationStatus);
            Controls.Add(label4);
            Name = "MainWin";
            Text = "AIE Broker";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
    }
}