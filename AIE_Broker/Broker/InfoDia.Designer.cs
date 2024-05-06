namespace Broker
{
    partial class InfoDia
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
            tbInfo = new TextBox();
            btOk = new Button();
            SuspendLayout();
            // 
            // tbInfo
            // 
            tbInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbInfo.Location = new Point(12, 12);
            tbInfo.Multiline = true;
            tbInfo.Name = "tbInfo";
            tbInfo.ScrollBars = ScrollBars.Vertical;
            tbInfo.Size = new Size(430, 220);
            tbInfo.TabIndex = 0;
            // 
            // btOk
            // 
            btOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btOk.Location = new Point(367, 238);
            btOk.Name = "btOk";
            btOk.Size = new Size(75, 23);
            btOk.TabIndex = 1;
            btOk.Text = "Ok";
            btOk.UseVisualStyleBackColor = true;
            btOk.Click += btOk_Click;
            // 
            // InfoDia
            // 
            AcceptButton = btOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 273);
            Controls.Add(btOk);
            Controls.Add(tbInfo);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "InfoDia";
            Text = "Information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btOk;
        public TextBox tbInfo;
    }
}