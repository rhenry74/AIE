namespace Broker
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
            UI_UpdateTimer = new System.Windows.Forms.Timer(components);
            splitContainer1 = new SplitContainer();
            btSeePrompt = new Button();
            tbRate = new Button();
            btClearChat = new Button();
            btPromptLLM = new Button();
            label3 = new Label();
            tbPrompt = new TextBox();
            btLearn = new Button();
            btRun = new Button();
            tbCompile = new Button();
            btEditResponse = new Button();
            tbResponse = new TextBox();
            label5 = new Label();
            toolTip1 = new ToolTip(components);
            splitContainer2 = new SplitContainer();
            splitContainer3 = new SplitContainer();
            flCommands = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer3).BeginInit();
            splitContainer3.Panel1.SuspendLayout();
            splitContainer3.Panel2.SuspendLayout();
            splitContainer3.SuspendLayout();
            SuspendLayout();
            // 
            // tbAutomationStatus
            // 
            tbAutomationStatus.Dock = DockStyle.Fill;
            tbAutomationStatus.Location = new Point(0, 0);
            tbAutomationStatus.Multiline = true;
            tbAutomationStatus.Name = "tbAutomationStatus";
            tbAutomationStatus.ReadOnly = true;
            tbAutomationStatus.ScrollBars = ScrollBars.Vertical;
            tbAutomationStatus.Size = new Size(344, 111);
            tbAutomationStatus.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 2);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 15;
            label4.Text = "Automation:";
            // 
            // UI_UpdateTimer
            // 
            UI_UpdateTimer.Enabled = true;
            UI_UpdateTimer.Interval = 125;
            UI_UpdateTimer.Tick += UI_UpdateTimer_Tick;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.BackColor = SystemColors.ControlLight;
            splitContainer1.BorderStyle = BorderStyle.Fixed3D;
            splitContainer1.Location = new Point(0, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btSeePrompt);
            splitContainer1.Panel1.Controls.Add(tbRate);
            splitContainer1.Panel1.Controls.Add(btClearChat);
            splitContainer1.Panel1.Controls.Add(btPromptLLM);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(tbPrompt);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btLearn);
            splitContainer1.Panel2.Controls.Add(btRun);
            splitContainer1.Panel2.Controls.Add(tbCompile);
            splitContainer1.Panel2.Controls.Add(btEditResponse);
            splitContainer1.Panel2.Controls.Add(tbResponse);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Size = new Size(354, 321);
            splitContainer1.SplitterDistance = 158;
            splitContainer1.TabIndex = 19;
            // 
            // btSeePrompt
            // 
            btSeePrompt.AccessibleDescription = "";
            btSeePrompt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btSeePrompt.BackColor = SystemColors.ButtonFace;
            btSeePrompt.BackgroundImage = Properties.Resources.seePrompt_sm;
            btSeePrompt.BackgroundImageLayout = ImageLayout.Zoom;
            btSeePrompt.Location = new Point(41, 121);
            btSeePrompt.Name = "btSeePrompt";
            btSeePrompt.Size = new Size(30, 30);
            btSeePrompt.TabIndex = 23;
            toolTip1.SetToolTip(btSeePrompt, "Preview Prompt");
            btSeePrompt.UseVisualStyleBackColor = false;
            btSeePrompt.Visible = false;
            btSeePrompt.Click += btSeePrompt_Click;
            // 
            // tbRate
            // 
            tbRate.AccessibleDescription = "";
            tbRate.AccessibleName = "";
            tbRate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbRate.BackColor = SystemColors.ButtonFace;
            tbRate.BackgroundImage = Properties.Resources.rate;
            tbRate.BackgroundImageLayout = ImageLayout.Zoom;
            tbRate.Location = new Point(103, 121);
            tbRate.Name = "tbRate";
            tbRate.Size = new Size(30, 30);
            tbRate.TabIndex = 22;
            toolTip1.SetToolTip(tbRate, "Rate Response");
            tbRate.UseVisualStyleBackColor = false;
            tbRate.Visible = false;
            // 
            // btClearChat
            // 
            btClearChat.AccessibleDescription = "";
            btClearChat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btClearChat.BackColor = SystemColors.ButtonFace;
            btClearChat.BackgroundImage = Properties.Resources.clearChat;
            btClearChat.BackgroundImageLayout = ImageLayout.Zoom;
            btClearChat.Location = new Point(72, 121);
            btClearChat.Name = "btClearChat";
            btClearChat.Size = new Size(30, 30);
            btClearChat.TabIndex = 17;
            toolTip1.SetToolTip(btClearChat, "Clear All");
            btClearChat.UseVisualStyleBackColor = false;
            btClearChat.Visible = false;
            // 
            // btPromptLLM
            // 
            btPromptLLM.AccessibleDescription = "";
            btPromptLLM.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btPromptLLM.BackColor = SystemColors.ButtonFace;
            btPromptLLM.BackgroundImage = Properties.Resources.brain;
            btPromptLLM.BackgroundImageLayout = ImageLayout.Zoom;
            btPromptLLM.Location = new Point(10, 122);
            btPromptLLM.Name = "btPromptLLM";
            btPromptLLM.Size = new Size(30, 30);
            btPromptLLM.TabIndex = 16;
            toolTip1.SetToolTip(btPromptLLM, "Generate Response");
            btPromptLLM.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 3);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 15;
            label3.Text = "Prompt:";
            // 
            // tbPrompt
            // 
            tbPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbPrompt.Location = new Point(3, 21);
            tbPrompt.Multiline = true;
            tbPrompt.Name = "tbPrompt";
            tbPrompt.ScrollBars = ScrollBars.Vertical;
            tbPrompt.Size = new Size(345, 99);
            tbPrompt.TabIndex = 14;
            tbPrompt.TextChanged += tbPrompt_TextChanged_1;
            // 
            // btLearn
            // 
            btLearn.AccessibleDescription = "";
            btLearn.AccessibleName = "";
            btLearn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btLearn.BackColor = SystemColors.ButtonFace;
            btLearn.BackgroundImage = Properties.Resources.learn;
            btLearn.BackgroundImageLayout = ImageLayout.Zoom;
            btLearn.Location = new Point(103, 123);
            btLearn.Name = "btLearn";
            btLearn.Size = new Size(30, 30);
            btLearn.TabIndex = 24;
            toolTip1.SetToolTip(btLearn, "Send to School");
            btLearn.UseVisualStyleBackColor = false;
            btLearn.Visible = false;
            // 
            // btRun
            // 
            btRun.AccessibleDescription = "";
            btRun.AccessibleName = "";
            btRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btRun.BackColor = SystemColors.ButtonFace;
            btRun.BackgroundImage = Properties.Resources.run;
            btRun.BackgroundImageLayout = ImageLayout.Zoom;
            btRun.Location = new Point(72, 123);
            btRun.Name = "btRun";
            btRun.Size = new Size(30, 30);
            btRun.TabIndex = 23;
            toolTip1.SetToolTip(btRun, "Execute");
            btRun.UseVisualStyleBackColor = false;
            btRun.Visible = false;
            // 
            // tbCompile
            // 
            tbCompile.AccessibleDescription = "";
            tbCompile.AccessibleName = "";
            tbCompile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            tbCompile.BackColor = SystemColors.ButtonFace;
            tbCompile.BackgroundImage = Properties.Resources.Compile;
            tbCompile.BackgroundImageLayout = ImageLayout.Zoom;
            tbCompile.ForeColor = SystemColors.ControlText;
            tbCompile.Location = new Point(41, 122);
            tbCompile.Name = "tbCompile";
            tbCompile.Size = new Size(30, 30);
            tbCompile.TabIndex = 22;
            toolTip1.SetToolTip(tbCompile, "Compile");
            tbCompile.UseVisualStyleBackColor = false;
            tbCompile.Visible = false;
            tbCompile.Click += tbCompile_Click;
            // 
            // btEditResponse
            // 
            btEditResponse.AccessibleDescription = "";
            btEditResponse.AccessibleName = "";
            btEditResponse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btEditResponse.BackColor = SystemColors.ButtonFace;
            btEditResponse.BackgroundImage = Properties.Resources.edit1;
            btEditResponse.BackgroundImageLayout = ImageLayout.Zoom;
            btEditResponse.Location = new Point(10, 122);
            btEditResponse.Name = "btEditResponse";
            btEditResponse.Size = new Size(30, 30);
            btEditResponse.TabIndex = 21;
            toolTip1.SetToolTip(btEditResponse, "Edit Response");
            btEditResponse.UseVisualStyleBackColor = false;
            btEditResponse.Click += bt_EditResponse_Click;
            // 
            // tbResponse
            // 
            tbResponse.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbResponse.Location = new Point(3, 21);
            tbResponse.Multiline = true;
            tbResponse.Name = "tbResponse";
            tbResponse.ReadOnly = true;
            tbResponse.ScrollBars = ScrollBars.Vertical;
            tbResponse.Size = new Size(345, 100);
            tbResponse.TabIndex = 20;
            tbResponse.TextChanged += tbResponse_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 3);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 19;
            label5.Text = "Response:";
            // 
            // splitContainer2
            // 
            splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer2.BorderStyle = BorderStyle.Fixed3D;
            splitContainer2.Location = new Point(-5, -6);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(splitContainer1);
            splitContainer2.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(splitContainer3);
            splitContainer2.Panel2.Controls.Add(label4);
            splitContainer2.Panel2.RightToLeft = RightToLeft.No;
            splitContainer2.Size = new Size(358, 594);
            splitContainer2.SplitterDistance = 328;
            splitContainer2.TabIndex = 20;
            // 
            // splitContainer3
            // 
            splitContainer3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer3.BorderStyle = BorderStyle.Fixed3D;
            splitContainer3.Location = new Point(3, 21);
            splitContainer3.Name = "splitContainer3";
            splitContainer3.Orientation = Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            splitContainer3.Panel1.Controls.Add(tbAutomationStatus);
            // 
            // splitContainer3.Panel2
            // 
            splitContainer3.Panel2.AutoScroll = true;
            splitContainer3.Panel2.Controls.Add(flCommands);
            splitContainer3.Size = new Size(348, 240);
            splitContainer3.SplitterDistance = 115;
            splitContainer3.TabIndex = 18;
            // 
            // flCommands
            // 
            flCommands.AutoScroll = true;
            flCommands.Dock = DockStyle.Fill;
            flCommands.Location = new Point(0, 0);
            flCommands.Margin = new Padding(0);
            flCommands.Name = "flCommands";
            flCommands.Size = new Size(344, 117);
            flCommands.TabIndex = 0;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(348, 588);
            Controls.Add(splitContainer2);
            Name = "MainWin";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "AIE Broker";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            splitContainer3.Panel1.ResumeLayout(false);
            splitContainer3.Panel1.PerformLayout();
            splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer3).EndInit();
            splitContainer3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox tbAutomationStatus;
        private Label label4;
        private System.Windows.Forms.Timer UI_UpdateTimer;
        private SplitContainer splitContainer1;
        private Label label3;
        private TextBox tbPrompt;
        private TextBox tbResponse;
        private Label label5;
        private Button btPromptLLM;
        private Button btEditResponse;
        private ToolTip toolTip1;
        private SplitContainer splitContainer2;
        private Button btClearChat;
        private Button tbRate;
        private Button tbCompile;
        private Button btRun;
        private Button btLearn;
        private Button btSeePrompt;
        private SplitContainer splitContainer3;
        private FlowLayoutPanel flCommands;
    }
}