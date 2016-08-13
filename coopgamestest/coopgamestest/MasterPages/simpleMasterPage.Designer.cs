namespace General.MasterPages
{
    partial class simpleMasterPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(simpleMasterPage));
            this.headerLabel = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.errorCounterPanel = new System.Windows.Forms.Panel();
            this.errorCounter = new System.Windows.Forms.Label();
            this.taskContentPanel = new System.Windows.Forms.Panel();
            this.taskLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.navigationPanel = new System.Windows.Forms.Panel();
            this.FinishButton = new System.Windows.Forms.Button();
            this.SkipButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.languageLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.languageComboBox = new System.Windows.Forms.ToolStripDropDownButton();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.русскийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerPanel.SuspendLayout();
            this.errorCounterPanel.SuspendLayout();
            this.taskContentPanel.SuspendLayout();
            this.navigationPanel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            resources.ApplyResources(this.headerLabel, "headerLabel");
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.ForeColor = System.Drawing.Color.Black;
            this.headerLabel.Name = "headerLabel";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(179)))), ((int)(((byte)(120)))));
            this.headerPanel.Controls.Add(this.errorCounterPanel);
            this.headerPanel.Controls.Add(this.taskContentPanel);
            this.headerPanel.Controls.Add(this.headerLabel);
            resources.ApplyResources(this.headerPanel, "headerPanel");
            this.headerPanel.Name = "headerPanel";
            // 
            // errorCounterPanel
            // 
            this.errorCounterPanel.BackColor = System.Drawing.Color.Transparent;
            this.errorCounterPanel.Controls.Add(this.errorCounter);
            resources.ApplyResources(this.errorCounterPanel, "errorCounterPanel");
            this.errorCounterPanel.Name = "errorCounterPanel";
            // 
            // errorCounter
            // 
            resources.ApplyResources(this.errorCounter, "errorCounter");
            this.errorCounter.ForeColor = System.Drawing.Color.Black;
            this.errorCounter.Name = "errorCounter";
            // 
            // taskContentPanel
            // 
            this.taskContentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(157)))), ((int)(((byte)(188)))));
            this.taskContentPanel.Controls.Add(this.taskLabel);
            resources.ApplyResources(this.taskContentPanel, "taskContentPanel");
            this.taskContentPanel.Name = "taskContentPanel";
            // 
            // taskLabel
            // 
            resources.ApplyResources(this.taskLabel, "taskLabel");
            this.taskLabel.ForeColor = System.Drawing.Color.Black;
            this.taskLabel.Name = "taskLabel";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(179)))), ((int)(((byte)(120)))));
            resources.ApplyResources(this.contentPanel, "contentPanel");
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.TabStop = true;
            // 
            // navigationPanel
            // 
            this.navigationPanel.BackColor = System.Drawing.Color.Transparent;
            this.navigationPanel.Controls.Add(this.FinishButton);
            this.navigationPanel.Controls.Add(this.SkipButton);
            resources.ApplyResources(this.navigationPanel, "navigationPanel");
            this.navigationPanel.Name = "navigationPanel";
            // 
            // FinishButton
            // 
            this.FinishButton.BackColor = System.Drawing.Color.Maroon;
            this.FinishButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FinishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.FinishButton, "FinishButton");
            this.FinishButton.ForeColor = System.Drawing.Color.White;
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.UseVisualStyleBackColor = false;
            // 
            // SkipButton
            // 
            this.SkipButton.BackColor = System.Drawing.Color.Maroon;
            this.SkipButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SkipButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.SkipButton, "SkipButton");
            this.SkipButton.ForeColor = System.Drawing.Color.White;
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(179)))), ((int)(((byte)(120)))));
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageLabel,
            this.languageComboBox});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // languageLabel
            // 
            resources.ApplyResources(this.languageLabel, "languageLabel");
            this.languageLabel.ForeColor = System.Drawing.Color.Black;
            this.languageLabel.Name = "languageLabel";
            // 
            // languageComboBox
            // 
            this.languageComboBox.BackColor = System.Drawing.Color.Transparent;
            this.languageComboBox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.languageComboBox.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.русскийToolStripMenuItem});
            this.languageComboBox.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.languageComboBox, "languageComboBox");
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.languageComboBox_DropDownItemClicked);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            // 
            // русскийToolStripMenuItem
            // 
            this.русскийToolStripMenuItem.Checked = true;
            this.русскийToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.русскийToolStripMenuItem.Name = "русскийToolStripMenuItem";
            resources.ApplyResources(this.русскийToolStripMenuItem, "русскийToolStripMenuItem");
            // 
            // simpleMasterPage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(88)))), ((int)(((byte)(114)))));
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.navigationPanel);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "simpleMasterPage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.simpleMasterPage_FormClosed);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.errorCounterPanel.ResumeLayout(false);
            this.errorCounterPanel.PerformLayout();
            this.taskContentPanel.ResumeLayout(false);
            this.taskContentPanel.PerformLayout();
            this.navigationPanel.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel navigationPanel;
        protected System.Windows.Forms.Label headerLabel;
        protected System.Windows.Forms.Button SkipButton;
        protected System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.ToolStripStatusLabel languageLabel;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem русскийToolStripMenuItem;
        public System.Windows.Forms.Panel headerPanel;
        public System.Windows.Forms.Panel contentPanel;
        public System.Windows.Forms.Panel taskContentPanel;
        public System.Windows.Forms.ToolStripDropDownButton languageComboBox;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.Label errorCounter;
        protected System.Windows.Forms.Panel errorCounterPanel;
        public System.Windows.Forms.Label taskLabel;
    }
}