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
            lbState = new Label();
            label3 = new Label();
            lbParmsEx = new Label();
            label4 = new Label();
            lbParmsParsed = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lbTopChoice);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lbActionText);
            splitContainer1.Size = new Size(610, 25);
            splitContainer1.SplitterDistance = 295;
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
            cbExecute.AutoSize = true;
            cbExecute.Checked = true;
            cbExecute.CheckState = CheckState.Checked;
            cbExecute.Location = new Point(6, 30);
            cbExecute.Name = "cbExecute";
            cbExecute.Size = new Size(67, 19);
            cbExecute.TabIndex = 1;
            cbExecute.Text = "Execute";
            cbExecute.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 30);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 2;
            label1.Text = "Likeness:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbLikeness
            // 
            lbLikeness.BorderStyle = BorderStyle.Fixed3D;
            lbLikeness.Location = new Point(136, 30);
            lbLikeness.MaximumSize = new Size(60, 17);
            lbLikeness.Name = "lbLikeness";
            lbLikeness.Size = new Size(60, 17);
            lbLikeness.TabIndex = 3;
            lbLikeness.Text = "label2";
            lbLikeness.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbState
            // 
            lbState.BorderStyle = BorderStyle.Fixed3D;
            lbState.Location = new Point(244, 30);
            lbState.MaximumSize = new Size(60, 17);
            lbState.Name = "lbState";
            lbState.Size = new Size(60, 17);
            lbState.TabIndex = 5;
            lbState.Text = "label2";
            lbState.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(202, 30);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "State:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbParmsEx
            // 
            lbParmsEx.BorderStyle = BorderStyle.Fixed3D;
            lbParmsEx.Location = new Point(377, 30);
            lbParmsEx.MaximumSize = new Size(60, 17);
            lbParmsEx.Name = "lbParmsEx";
            lbParmsEx.Size = new Size(38, 17);
            lbParmsEx.TabIndex = 7;
            lbParmsEx.Text = "label2";
            lbParmsEx.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(313, 30);
            label4.Name = "label4";
            label4.Size = new Size(65, 15);
            label4.TabIndex = 6;
            label4.Text = "Parms Exp:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbParmsParsed
            // 
            lbParmsParsed.BorderStyle = BorderStyle.Fixed3D;
            lbParmsParsed.Location = new Point(481, 30);
            lbParmsParsed.MaximumSize = new Size(60, 17);
            lbParmsParsed.Name = "lbParmsParsed";
            lbParmsParsed.Size = new Size(38, 17);
            lbParmsParsed.TabIndex = 9;
            lbParmsParsed.Text = "label5";
            lbParmsParsed.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(416, 30);
            label6.Name = "label6";
            label6.Size = new Size(65, 15);
            label6.TabIndex = 8;
            label6.Text = "Parms Psd:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ActionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbParmsParsed);
            Controls.Add(label6);
            Controls.Add(lbParmsEx);
            Controls.Add(label4);
            Controls.Add(lbState);
            Controls.Add(label3);
            Controls.Add(lbLikeness);
            Controls.Add(label1);
            Controls.Add(cbExecute);
            Controls.Add(splitContainer1);
            Name = "ActionControl";
            Size = new Size(616, 48);
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

        private SplitContainer splitContainer1;
        private Label lbTopChoice;
        private Label lbActionText;
        private CheckBox cbExecute;
        private Label label1;
        private Label lbLikeness;
        private Label lbState;
        private Label label3;
        private Label lbParmsEx;
        private Label label4;
        private Label lbParmsParsed;
        private Label label6;
    }
}
