namespace WinFormsUI
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
            splitContainer1.Size = new Size(332, 25);
            splitContainer1.SplitterDistance = 161;
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
            cbExecute.Location = new Point(6, 31);
            cbExecute.Name = "cbExecute";
            cbExecute.Size = new Size(67, 19);
            cbExecute.TabIndex = 1;
            cbExecute.Text = "Execute";
            cbExecute.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 31);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 2;
            label1.Text = "Likeness:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbLikeness
            // 
            lbLikeness.BorderStyle = BorderStyle.Fixed3D;
            lbLikeness.Location = new Point(136, 31);
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
            label3.Location = new Point(202, 31);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "State:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ActionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbState);
            Controls.Add(label3);
            Controls.Add(lbLikeness);
            Controls.Add(label1);
            Controls.Add(cbExecute);
            Controls.Add(splitContainer1);
            Name = "ActionControl";
            Size = new Size(338, 50);
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
    }
}
