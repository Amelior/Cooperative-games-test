namespace General.Coalitions
{
    partial class OptimalCoalitionForm
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
            this.PanelsPanel = new System.Windows.Forms.Panel();
            this.FinishBTN = new System.Windows.Forms.Button();
            this.DivisionPanel = new System.Windows.Forms.Panel();
            this.PayoffDivisionLabel = new System.Windows.Forms.Label();
            this.RationalityCB = new System.Windows.Forms.CheckBox();
            this.NecessityPanel = new System.Windows.Forms.Panel();
            this.NecessityLabel = new System.Windows.Forms.Label();
            this.DivisionPanel.SuspendLayout();
            this.NecessityPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelsPanel
            // 
            this.PanelsPanel.Location = new System.Drawing.Point(12, 12);
            this.PanelsPanel.Name = "PanelsPanel";
            this.PanelsPanel.Size = new System.Drawing.Size(585, 100);
            this.PanelsPanel.TabIndex = 0;
            // 
            // FinishBTN
            // 
            this.FinishBTN.BackColor = System.Drawing.Color.DimGray;
            this.FinishBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FinishBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FinishBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FinishBTN.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishBTN.ForeColor = System.Drawing.Color.White;
            this.FinishBTN.Location = new System.Drawing.Point(510, 369);
            this.FinishBTN.Name = "FinishBTN";
            this.FinishBTN.Size = new System.Drawing.Size(87, 37);
            this.FinishBTN.TabIndex = 9;
            this.FinishBTN.Text = "Далее";
            this.FinishBTN.UseVisualStyleBackColor = false;
            this.FinishBTN.Click += new System.EventHandler(this.FinishBTN_Click);
            // 
            // DivisionPanel
            // 
            this.DivisionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DivisionPanel.Controls.Add(this.RationalityCB);
            this.DivisionPanel.Controls.Add(this.PayoffDivisionLabel);
            this.DivisionPanel.Location = new System.Drawing.Point(12, 118);
            this.DivisionPanel.Name = "DivisionPanel";
            this.DivisionPanel.Size = new System.Drawing.Size(586, 110);
            this.DivisionPanel.TabIndex = 10;
            this.DivisionPanel.Visible = false;
            // 
            // PayoffDivisionLabel
            // 
            this.PayoffDivisionLabel.AutoSize = true;
            this.PayoffDivisionLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayoffDivisionLabel.ForeColor = System.Drawing.Color.White;
            this.PayoffDivisionLabel.Location = new System.Drawing.Point(14, 13);
            this.PayoffDivisionLabel.Name = "PayoffDivisionLabel";
            this.PayoffDivisionLabel.Size = new System.Drawing.Size(548, 40);
            this.PayoffDivisionLabel.TabIndex = 5;
            this.PayoffDivisionLabel.Text = "Определите дележ с учетом индивидуальных выигрышей игроков\r\nв некооперативной игр" +
    "е";
            this.PayoffDivisionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RationalityCB
            // 
            this.RationalityCB.AutoSize = true;
            this.RationalityCB.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RationalityCB.ForeColor = System.Drawing.Color.White;
            this.RationalityCB.Location = new System.Drawing.Point(18, 73);
            this.RationalityCB.Name = "RationalityCB";
            this.RationalityCB.Size = new System.Drawing.Size(282, 24);
            this.RationalityCB.TabIndex = 6;
            this.RationalityCB.Text = "индивидуальная рациональность";
            this.RationalityCB.UseVisualStyleBackColor = true;
            // 
            // NecessityPanel
            // 
            this.NecessityPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NecessityPanel.Controls.Add(this.NecessityLabel);
            this.NecessityPanel.Location = new System.Drawing.Point(12, 234);
            this.NecessityPanel.Name = "NecessityPanel";
            this.NecessityPanel.Size = new System.Drawing.Size(586, 110);
            this.NecessityPanel.TabIndex = 11;
            this.NecessityPanel.Visible = false;
            // 
            // NecessityLabel
            // 
            this.NecessityLabel.AutoSize = true;
            this.NecessityLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NecessityLabel.ForeColor = System.Drawing.Color.White;
            this.NecessityLabel.Location = new System.Drawing.Point(63, 9);
            this.NecessityLabel.Name = "NecessityLabel";
            this.NecessityLabel.Size = new System.Drawing.Size(427, 40);
            this.NecessityLabel.TabIndex = 5;
            this.NecessityLabel.Text = "Определите предпосылки игроков для организации\r\nкооперативной игры";
            this.NecessityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OptimalCoalitionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(623, 418);
            this.Controls.Add(this.NecessityPanel);
            this.Controls.Add(this.DivisionPanel);
            this.Controls.Add(this.FinishBTN);
            this.Controls.Add(this.PanelsPanel);
            this.Name = "OptimalCoalitionForm";
            this.Text = "OptimalCoalitionForm";
            this.DivisionPanel.ResumeLayout(false);
            this.DivisionPanel.PerformLayout();
            this.NecessityPanel.ResumeLayout(false);
            this.NecessityPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelsPanel;
        private System.Windows.Forms.Button FinishBTN;
        private System.Windows.Forms.Panel DivisionPanel;
        private System.Windows.Forms.Label PayoffDivisionLabel;
        private System.Windows.Forms.CheckBox RationalityCB;
        private System.Windows.Forms.Panel NecessityPanel;
        private System.Windows.Forms.Label NecessityLabel;

    }
}