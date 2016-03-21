namespace General.Coalitions
{
    partial class IncooperativeGame
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.GenerationPanel = new System.Windows.Forms.Panel();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.D = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.TestPanel = new System.Windows.Forms.Panel();
            this.SkipBTN = new System.Windows.Forms.Button();
            this.FinishBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.GenerationPanel.SuspendLayout();
            this.GridPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.D)).BeginInit();
            this.TestPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 32);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(411, 23);
            this.progressBar1.Step = 25;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Генерирование биматричных игр";
            // 
            // GenerationPanel
            // 
            this.GenerationPanel.BackColor = System.Drawing.Color.Transparent;
            this.GenerationPanel.Controls.Add(this.label1);
            this.GenerationPanel.Controls.Add(this.progressBar1);
            this.GenerationPanel.Location = new System.Drawing.Point(12, 154);
            this.GenerationPanel.Name = "GenerationPanel";
            this.GenerationPanel.Size = new System.Drawing.Size(446, 73);
            this.GenerationPanel.TabIndex = 2;
            // 
            // GridPanel
            // 
            this.GridPanel.BackColor = System.Drawing.Color.Transparent;
            this.GridPanel.Controls.Add(this.D);
            this.GridPanel.Controls.Add(this.label2);
            this.GridPanel.Location = new System.Drawing.Point(12, 12);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(446, 136);
            this.GridPanel.TabIndex = 3;
            // 
            // D
            // 
            this.D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.D.Location = new System.Drawing.Point(26, 44);
            this.D.Name = "D";
            this.D.Size = new System.Drawing.Size(370, 74);
            this.D.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выигрыши игроков в парных биматричных играх";
            // 
            // TestPanel
            // 
            this.TestPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TestPanel.Controls.Add(this.SkipBTN);
            this.TestPanel.Controls.Add(this.FinishBTN);
            this.TestPanel.Controls.Add(this.label3);
            this.TestPanel.Location = new System.Drawing.Point(12, 243);
            this.TestPanel.Name = "TestPanel";
            this.TestPanel.Size = new System.Drawing.Size(446, 136);
            this.TestPanel.TabIndex = 4;
            this.TestPanel.Visible = false;
            // 
            // SkipBTN
            // 
            this.SkipBTN.BackColor = System.Drawing.Color.Cornsilk;
            this.SkipBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SkipBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.SkipBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SkipBTN.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SkipBTN.ForeColor = System.Drawing.Color.Black;
            this.SkipBTN.Location = new System.Drawing.Point(28, 72);
            this.SkipBTN.Name = "SkipBTN";
            this.SkipBTN.Size = new System.Drawing.Size(144, 37);
            this.SkipBTN.TabIndex = 8;
            this.SkipBTN.Text = "Пропустить";
            this.SkipBTN.UseVisualStyleBackColor = false;
            this.SkipBTN.Click += new System.EventHandler(this.SkipBTN_Click);
            // 
            // FinishBTN
            // 
            this.FinishBTN.BackColor = System.Drawing.Color.Cornsilk;
            this.FinishBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FinishBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Brown;
            this.FinishBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FinishBTN.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FinishBTN.ForeColor = System.Drawing.Color.Black;
            this.FinishBTN.Location = new System.Drawing.Point(178, 72);
            this.FinishBTN.Name = "FinishBTN";
            this.FinishBTN.Size = new System.Drawing.Size(233, 37);
            this.FinishBTN.TabIndex = 7;
            this.FinishBTN.Text = "Проверить результат";
            this.FinishBTN.UseVisualStyleBackColor = false;
            this.FinishBTN.Click += new System.EventHandler(this.FinishBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(434, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Заполните выигрыши игроков и цену игры:";
            // 
            // IncooperativeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(470, 385);
            this.ControlBox = false;
            this.Controls.Add(this.TestPanel);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.GenerationPanel);
            this.Name = "IncooperativeGame";
            this.Text = "Некооперативная игра";
            this.GenerationPanel.ResumeLayout(false);
            this.GenerationPanel.PerformLayout();
            this.GridPanel.ResumeLayout(false);
            this.GridPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.D)).EndInit();
            this.TestPanel.ResumeLayout(false);
            this.TestPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel GenerationPanel;
        private System.Windows.Forms.Panel GridPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView D;
        private System.Windows.Forms.Panel TestPanel;
        private System.Windows.Forms.Button FinishBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SkipBTN;
    }
}