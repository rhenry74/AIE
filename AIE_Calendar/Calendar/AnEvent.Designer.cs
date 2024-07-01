namespace Calendar
{
    partial class AnEvent
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btTime = new Button();
            checkBox1 = new CheckBox();
            nudDuration = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudDuration).BeginInit();
            SuspendLayout();
            // 
            // btTime
            // 
            btTime.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btTime.Location = new Point(14, 0);
            btTime.Name = "btTime";
            btTime.Size = new Size(68, 24);
            btTime.TabIndex = 0;
            btTime.Text = "12:00 AM";
            btTime.TextAlign = ContentAlignment.MiddleLeft;
            btTime.UseVisualStyleBackColor = true;
            btTime.Click += btTime_Click;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new Point(0, 6);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 1;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // nudDuration
            // 
            nudDuration.Location = new Point(83, 2);
            nudDuration.Name = "nudDuration";
            nudDuration.Size = new Size(54, 23);
            nudDuration.TabIndex = 2;
            // 
            // AnEvent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(nudDuration);
            Controls.Add(checkBox1);
            Controls.Add(btTime);
            Name = "AnEvent";
            Size = new Size(137, 24);
            Load += TimeBlock_Load;
            ((System.ComponentModel.ISupportInitialize)nudDuration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btTime;
        private CheckBox checkBox1;
        private NumericUpDown nudDuration;
    }
}
