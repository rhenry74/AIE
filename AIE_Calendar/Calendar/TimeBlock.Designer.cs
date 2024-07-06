namespace Calendar
{
    partial class TimeBlock
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
            panel1 = new Panel();
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
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Location = new Point(82, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(55, 16);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // TimeBlock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(checkBox1);
            Controls.Add(btTime);
            Name = "TimeBlock";
            Size = new Size(137, 24);
            Load += TimeBlock_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btTime;
        private CheckBox checkBox1;
        private Panel panel1;
    }
}
