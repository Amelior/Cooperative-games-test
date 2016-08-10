namespace General.Shapley
{
    partial class ShapleyTask
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
            this.navigationPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskHeaderLabel
            // 
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            // 
            // headerLabel
            // 
            this.headerLabel.Location = new System.Drawing.Point(6, 16);
            this.headerLabel.Size = new System.Drawing.Size(214, 32);
            this.headerLabel.Text = "Вектор Шепли";
            // 
            // SkipButton
            // 
            this.SkipButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SkipButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            // 
            // FinishButton
            // 
            this.FinishButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FinishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            // 
            // ShapleyTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(955, 510);
            this.Name = "ShapleyTask";
            this.navigationPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
