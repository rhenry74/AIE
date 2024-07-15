namespace Broker
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            tbUserName = new TextBox();
            btClearCapabilityVectors = new Button();
            toolTip1 = new ToolTip(components);
            cbDateTime = new CheckBox();
            cbUserName = new CheckBox();
            SuspendLayout();
            // 
            // tbUserName
            // 
            tbUserName.Location = new Point(120, 66);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(300, 23);
            tbUserName.TabIndex = 1;
            // 
            // btClearCapabilityVectors
            // 
            btClearCapabilityVectors.Location = new Point(12, 208);
            btClearCapabilityVectors.Name = "btClearCapabilityVectors";
            btClearCapabilityVectors.Size = new Size(177, 23);
            btClearCapabilityVectors.TabIndex = 2;
            btClearCapabilityVectors.Text = "Clear Capability Vectors";
            toolTip1.SetToolTip(btClearCapabilityVectors, resources.GetString("btClearCapabilityVectors.ToolTip"));
            btClearCapabilityVectors.UseVisualStyleBackColor = true;
            btClearCapabilityVectors.Click += btClearCapabilityVectors_Click;
            // 
            // cbDateTime
            // 
            cbDateTime.AutoSize = true;
            cbDateTime.Location = new Point(31, 102);
            cbDateTime.Name = "cbDateTime";
            cbDateTime.Size = new Size(145, 19);
            cbDateTime.TabIndex = 3;
            cbDateTime.Text = "Current Date and Time";
            cbDateTime.UseVisualStyleBackColor = true;
            // 
            // cbUserName
            // 
            cbUserName.AutoSize = true;
            cbUserName.Location = new Point(31, 70);
            cbUserName.Name = "cbUserName";
            cbUserName.Size = new Size(87, 19);
            cbUserName.TabIndex = 4;
            cbUserName.Text = "User Name:";
            cbUserName.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbUserName);
            Controls.Add(cbDateTime);
            Controls.Add(btClearCapabilityVectors);
            Controls.Add(tbUserName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Settings";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbUserName;
        private Button btClearCapabilityVectors;
        private ToolTip toolTip1;
        private CheckBox cbDateTime;
        private CheckBox cbUserName;
    }
}