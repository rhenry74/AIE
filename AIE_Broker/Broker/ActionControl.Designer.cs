namespace Broker
{
    partial class ActionControl
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
            splitContainer1 = new SplitContainer();
            lbTopChoice = new Label();
            lbActionText = new Label();
            cbExecute = new CheckBox();
            label1 = new Label();
            lbLikeness = new Label();
            label3 = new Label();
            lbParmsEx = new Label();
            label4 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            btStatus = new Button();
            groupBox2 = new GroupBox();
            btParsed = new Button();
            btState = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Location = new Point(5, 17);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lbTopChoice);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lbActionText);
            splitContainer1.Size = new Size(446, 25);
            splitContainer1.SplitterDistance = 212;
            splitContainer1.TabIndex = 0;
            // 
            // lbTopChoice
            // 
            lbTopChoice.AutoSize = true;
            lbTopChoice.Location = new Point(3, 3);
            lbTopChoice.Name = "lbTopChoice";
            lbTopChoice.Size = new Size(38, 15);
            lbTopChoice.TabIndex = 0;
            lbTopChoice.Text = "label1";
            // 
            // lbActionText
            // 
            lbActionText.AutoSize = true;
            lbActionText.Location = new Point(3, 3);
            lbActionText.Name = "lbActionText";
            lbActionText.Size = new Size(38, 15);
            lbActionText.TabIndex = 0;
            lbActionText.Text = "label1";
            // 
            // cbExecute
            // 
            cbExecute.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbExecute.AutoSize = true;
            cbExecute.Checked = true;
            cbExecute.CheckState = CheckState.Checked;
            cbExecute.Location = new Point(11, 16);
            cbExecute.Name = "cbExecute";
            cbExecute.Size = new Size(67, 19);
            cbExecute.TabIndex = 1;
            cbExecute.Text = "Execute";
            cbExecute.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 48);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 2;
            label1.Text = "Likeness:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbLikeness
            // 
            lbLikeness.BorderStyle = BorderStyle.Fixed3D;
            lbLikeness.Location = new Point(59, 44);
            lbLikeness.MaximumSize = new Size(60, 22);
            lbLikeness.Name = "lbLikeness";
            lbLikeness.Size = new Size(60, 22);
            lbLikeness.TabIndex = 3;
            lbLikeness.Text = "label2";
            lbLikeness.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 48);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "State:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbParmsEx
            // 
            lbParmsEx.BorderStyle = BorderStyle.Fixed3D;
            lbParmsEx.Location = new Point(299, 44);
            lbParmsEx.MaximumSize = new Size(60, 22);
            lbParmsEx.Name = "lbParmsEx";
            lbParmsEx.Size = new Size(51, 22);
            lbParmsEx.TabIndex = 7;
            lbParmsEx.Text = "label2";
            lbParmsEx.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(235, 48);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 6;
            label4.Text = "Parms Exp:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(346, 48);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 8;
            label6.Text = "Parms Psd:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(btStatus);
            groupBox1.Controls.Add(cbExecute);
            groupBox1.Location = new Point(460, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(91, 71);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Execution";
            // 
            // btStatus
            // 
            btStatus.BackColor = Color.FromArgb(192, 255, 255);
            btStatus.Location = new Point(6, 44);
            btStatus.Name = "btStatus";
            btStatus.Size = new Size(80, 22);
            btStatus.TabIndex = 2;
            btStatus.Text = "Ready";
            btStatus.UseVisualStyleBackColor = false;
            btStatus.Click += btStatus_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(btState);
            groupBox2.Controls.Add(btParsed);
            groupBox2.Controls.Add(splitContainer1);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(lbLikeness);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(lbParmsEx);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(457, 71);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Compilation";
            // 
            // btParsed
            // 
            btParsed.Location = new Point(412, 44);
            btParsed.Name = "btParsed";
            btParsed.Size = new Size(34, 23);
            btParsed.TabIndex = 12;
            btParsed.Text = "0";
            btParsed.UseVisualStyleBackColor = true;
            btParsed.Click += btParsed_Click;
            // 
            // btState
            // 
            btState.BackColor = Color.FromArgb(192, 255, 255);
            btState.Location = new Point(156, 44);
            btState.Name = "btState";
            btState.Size = new Size(80, 22);
            btState.TabIndex = 12;
            btState.Text = "Ready";
            btState.UseVisualStyleBackColor = false;
            btState.Click += btState_Click;
            // 
            // ActionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ActionControl";
            Size = new Size(554, 75);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label lbTopChoice;
        private Label lbActionText;
        private CheckBox cbExecute;
        private Label label1;
        private Label lbLikeness;
        private Label label3;
        private Label lbParmsEx;
        private Label label4;
        private Label label6;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btStatus;
        private Button btParsed;
        private Button btState;
    }
}
