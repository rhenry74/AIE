namespace Calendar
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
            tbTitle = new TextBox();
            label2 = new Label();
            label1 = new Label();
            UI_UpdateTimer = new System.Windows.Forms.Timer(components);
            splitContainer1 = new SplitContainer();
            dtpDate = new DateTimePicker();
            label5 = new Label();
            dtpTime = new DateTimePicker();
            label6 = new Label();
            btSave = new Button();
            nudDuration = new NumericUpDown();
            layoutDay = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
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
            tbAutomationStatus.Size = new Size(409, 47);
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
            tbBody.Size = new Size(401, 126);
            tbBody.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 4);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 13;
            label3.Text = "Description:";
            // 
            // tbTitle
            // 
            tbTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbTitle.Location = new Point(14, 77);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(493, 23);
            tbTitle.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 59);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 11;
            label2.Text = "Title:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 9);
            label1.Name = "label1";
            label1.Size = new Size(34, 15);
            label1.TabIndex = 9;
            label1.Text = "Date:";
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
            splitContainer1.BackColor = SystemColors.ControlLight;
            splitContainer1.BorderStyle = BorderStyle.FixedSingle;
            splitContainer1.Location = new Point(182, 106);
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
            splitContainer1.Size = new Size(427, 231);
            splitContainer1.SplitterDistance = 153;
            splitContainer1.TabIndex = 17;
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(16, 27);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(102, 23);
            dtpDate.TabIndex = 18;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(133, 9);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 19;
            label5.Text = "Time:";
            // 
            // dtpTime
            // 
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(133, 27);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(92, 23);
            dtpTime.TabIndex = 20;
            dtpTime.ValueChanged += dtpTime_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(243, 9);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 21;
            label6.Text = "Duration:";
            // 
            // btSave
            // 
            btSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btSave.Location = new Point(530, 30);
            btSave.Name = "btSave";
            btSave.Size = new Size(53, 44);
            btSave.TabIndex = 23;
            btSave.Text = "Add";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // nudDuration
            // 
            nudDuration.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudDuration.Location = new Point(243, 27);
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(61, 23);
            nudDuration.TabIndex = 24;
            nudDuration.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // layoutDay
            // 
            layoutDay.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            layoutDay.AutoScroll = true;
            layoutDay.BackColor = SystemColors.ControlLight;
            layoutDay.Location = new Point(12, 106);
            layoutDay.Margin = new Padding(1);
            layoutDay.Name = "layoutDay";
            layoutDay.Size = new Size(166, 231);
            layoutDay.TabIndex = 25;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 339);
            Controls.Add(layoutDay);
            Controls.Add(nudDuration);
            Controls.Add(btSave);
            Controls.Add(label6);
            Controls.Add(dtpTime);
            Controls.Add(label5);
            Controls.Add(dtpDate);
            Controls.Add(splitContainer1);
            Controls.Add(tbTitle);
            Controls.Add(label2);
            Controls.Add(label1);
            MinimumSize = new Size(623, 342);
            Name = "MainWin";
            Text = "MainWin";
            Load += MainWin_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbAutomationStatus;
        private Label label4;
        private TextBox tbBody;
        private Label label3;
        private TextBox tbTitle;
        private Label label2;
        private Label label1;
        private System.Windows.Forms.Timer UI_UpdateTimer;
        private SplitContainer splitContainer1;
        private DateTimePicker dtpDate;
        private Label label5;
        private DateTimePicker dtpTime;
        private Label label6;
        private Button btSave;
        private NumericUpDown nudDuration;
        private FlowLayoutPanel layoutDay;
    }
}