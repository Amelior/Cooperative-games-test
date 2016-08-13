namespace General.Coalitions
{
    partial class IncooperativeGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncooperativeGameForm));
            this.GenerationPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.D = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.testPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.navigationPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.taskContentPanel.SuspendLayout();
            this.GenerationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.D)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            resources.ApplyResources(this.navigationPanel, "navigationPanel");
            // 
            // headerLabel
            // 
            resources.ApplyResources(this.headerLabel, "headerLabel");
            // 
            // taskLabel
            // 
            resources.ApplyResources(this.taskLabel, "taskLabel");
            // 
            // SkipButton
            // 
            resources.ApplyResources(this.SkipButton, "SkipButton");
            this.SkipButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SkipButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // FinishButton
            // 
            resources.ApplyResources(this.FinishButton, "FinishButton");
            this.FinishButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FinishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // headerPanel
            // 
            resources.ApplyResources(this.headerPanel, "headerPanel");
            // 
            // contentPanel
            // 
            resources.ApplyResources(this.contentPanel, "contentPanel");
            this.contentPanel.Controls.Add(this.label3);
            this.contentPanel.Controls.Add(this.D);
            this.contentPanel.Controls.Add(this.label2);
            // 
            // taskContentPanel
            // 
            resources.ApplyResources(this.taskContentPanel, "taskContentPanel");
            // 
            // errorCounter
            // 
            resources.ApplyResources(this.errorCounter, "errorCounter");
            this.errorCounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(179)))), ((int)(((byte)(120)))));
            // 
            // GenerationPanel
            // 
            resources.ApplyResources(this.GenerationPanel, "GenerationPanel");
            this.GenerationPanel.BackColor = System.Drawing.Color.Transparent;
            this.GenerationPanel.Controls.Add(this.label1);
            this.GenerationPanel.Controls.Add(this.progressBar1);
            this.GenerationPanel.Name = "GenerationPanel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Step = 25;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // D
            // 
            resources.ApplyResources(this.D, "D");
            this.D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.D.Name = "D";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // testPanel
            // 
            resources.ApplyResources(this.testPanel, "testPanel");
            this.testPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(157)))), ((int)(((byte)(188)))));
            this.testPanel.Name = "testPanel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // IncooperativeGameForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.testPanel);
            this.Controls.Add(this.GenerationPanel);
            this.Name = "IncooperativeGameForm";
            this.Controls.SetChildIndex(this.headerPanel, 0);
            this.Controls.SetChildIndex(this.contentPanel, 0);
            this.Controls.SetChildIndex(this.navigationPanel, 0);
            this.Controls.SetChildIndex(this.GenerationPanel, 0);
            this.Controls.SetChildIndex(this.testPanel, 0);
            this.navigationPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.taskContentPanel.ResumeLayout(false);
            this.taskContentPanel.PerformLayout();
            this.GenerationPanel.ResumeLayout(false);
            this.GenerationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.D)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel GenerationPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView D;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel testPanel;
        private System.Windows.Forms.Label label3;
    }
}
