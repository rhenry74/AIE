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
            SuspendLayout();
            // 
            // tbAutomationStatus
            // 
            tbAutomationStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAutomationStatus.Location = new Point(14, 421);
            tbAutomationStatus.Multiline = true;
            tbAutomationStatus.Name = "tbAutomationStatus";
            tbAutomationStatus.ReadOnly = true;
            tbAutomationStatus.ScrollBars = ScrollBars.Both;
            tbAutomationStatus.Size = new Size(886, 57);
            tbAutomationStatus.TabIndex = 16;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(14, 403);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 15;
            label4.Text = "Automation:";
            // 
            // tbBody
            // 
            tbBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbBody.Location = new Point(14, 126);
            tbBody.Multiline = true;
            tbBody.Name = "tbBody";
            tbBody.Size = new Size(886, 274);
            tbBody.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 108);
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
            tbSubject.Size = new Size(886, 23);
            tbSubject.TabIndex = 12;
            tbSubject.TextChanged += tbSubject_TextChanged;
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
            tbRecipients.Size = new Size(808, 23);
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
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 488);
            Controls.Add(tbAutomationStatus);
            Controls.Add(label4);
            Controls.Add(tbBody);
            Controls.Add(label3);
            Controls.Add(tbSubject);
            Controls.Add(label2);
            Controls.Add(tbRecipients);
            Controls.Add(label1);
            Name = "MainWin";
            Text = "MainWin";
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
    }
}