namespace Email
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
            tbBody = new TextBox();
            label3 = new Label();
            tbSubject = new TextBox();
            label2 = new Label();
            tbRecipients = new TextBox();
            label1 = new Label();
            UI_UpdateTimer = new System.Windows.Forms.Timer(components);
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tbAutomationStatus
            // 
            tbAutomationStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAutomationStatus.Location = new Point(13, 22);
            tbAutomationStatus.Multiline = true;
            tbAutomationStatus.Name = "tbAutomationStatus";
            tbAutomationStatus.ReadOnly = true;
            tbAutomationStatus.ScrollBars = ScrollBars.Both;
            tbAutomationStatus.Size = new Size(919, 100);
            tbAutomationStatus.TabIndex = 16;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(13, 4);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 15;
            label4.Text = "Automation:";
            // 
            // tbBody
            // 
            tbBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbBody.Location = new Point(13, 22);
            tbBody.Multiline = true;
            tbBody.Name = "tbBody";
            tbBody.Size = new Size(911, 241);
            tbBody.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 4);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 13;
            label3.Text = "Body:";
            // 
            // tbSubject
            // 
            tbSubject.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSubject.Location = new Point(14, 77);
            tbSubject.Name = "tbSubject";
            tbSubject.Size = new Size(912, 23);
            tbSubject.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 59);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 11;
            label2.Text = "Subject:";
            // 
            // tbRecipients
            // 
            tbRecipients.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbRecipients.Location = new Point(14, 28);
            tbRecipients.Name = "tbRecipients";
            tbRecipients.Size = new Size(834, 23);
            tbRecipients.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 10);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 9;
            label1.Text = "Recipients:";
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
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Location = new Point(-1, 101);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tbBody);
            splitContainer1.Panel1.Controls.Add(label3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tbAutomationStatus);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Size = new Size(939, 403);
            splitContainer1.SplitterDistance = 270;
            splitContainer1.TabIndex = 17;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(936, 506);
            Controls.Add(splitContainer1);
            Controls.Add(tbSubject);
            Controls.Add(label2);
            Controls.Add(tbRecipients);
            Controls.Add(label1);
            Name = "MainWin";
            Text = "MainWin";
            Load += MainWin_Load;
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
        private TextBox tbBody;
        private Label label3;
        private TextBox tbSubject;
        private Label label2;
        private TextBox tbRecipients;
        private Label label1;
        private System.Windows.Forms.Timer UI_UpdateTimer;
        private SplitContainer splitContainer1;
    }
}