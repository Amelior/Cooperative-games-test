namespace General
{
    partial class NumericTextBox
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
            this.NumericTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NumericTB
            // 
            this.NumericTB.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericTB.Location = new System.Drawing.Point(0, 0);
            this.NumericTB.Name = "NumericTB";
            this.NumericTB.Size = new System.Drawing.Size(136, 30);
            this.NumericTB.TabIndex = 0;
            this.NumericTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTB_KeyPress);
            this.NumericTB.Validated += new System.EventHandler(this.NumericTB_Validated);
            // 
            // NumericTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NumericTB);
            this.Name = "NumericTextBox";
            this.Size = new System.Drawing.Size(136, 30);
            this.SizeChanged += new System.EventHandler(this.NumericTextBox_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox NumericTB;
    }
}
