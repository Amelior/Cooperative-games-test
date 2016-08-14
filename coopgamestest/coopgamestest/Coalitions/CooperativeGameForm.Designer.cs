namespace General.Coalitions
{
    partial class CooperativeGameForm
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
            this.firstTaskPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.S = new System.Windows.Forms.DataGridView();
            this.strategiesPanel = new System.Windows.Forms.Panel();
            this.strategiesLabel = new System.Windows.Forms.Label();
            this.payoffsPanel = new System.Windows.Forms.Panel();
            this.payoffsLabel = new System.Windows.Forms.Label();
            this.A = new System.Windows.Forms.DataGridView();
            this.B = new System.Windows.Forms.DataGridView();
            this.navigationPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.taskContentPanel.SuspendLayout();
            this.errorCounterPanel.SuspendLayout();
            this.firstTaskPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.S)).BeginInit();
            this.strategiesPanel.SuspendLayout();
            this.payoffsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.A)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            this.navigationPanel.Location = new System.Drawing.Point(12, 725);
            this.navigationPanel.Size = new System.Drawing.Size(643, 52);
            // 
            // headerLabel
            // 
            this.headerLabel.Size = new System.Drawing.Size(256, 32);
            this.headerLabel.Text = "Cooperative Game";
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
            this.FinishButton.Location = new System.Drawing.Point(508, 12);
            // 
            // headerPanel
            // 
            this.headerPanel.Size = new System.Drawing.Size(643, 370);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.Controls.Add(this.payoffsPanel);
            this.contentPanel.Controls.Add(this.strategiesPanel);
            this.contentPanel.Location = new System.Drawing.Point(12, 388);
            this.contentPanel.Size = new System.Drawing.Size(643, 331);
            // 
            // taskContentPanel
            // 
            this.taskContentPanel.BackColor = System.Drawing.Color.Maroon;
            this.taskContentPanel.Controls.Add(this.firstTaskPanel);
            this.taskContentPanel.Size = new System.Drawing.Size(618, 269);
            this.taskContentPanel.Controls.SetChildIndex(this.firstTaskPanel, 0);
            this.taskContentPanel.Controls.SetChildIndex(this.taskLabel, 0);
            // 
            // errorCounterPanel
            // 
            this.errorCounterPanel.Location = new System.Drawing.Point(354, 16);
            // 
            // taskLabel
            // 
            this.taskLabel.ForeColor = System.Drawing.Color.White;
            this.taskLabel.Location = new System.Drawing.Point(79, 9);
            this.taskLabel.Size = new System.Drawing.Size(453, 20);
            this.taskLabel.Text = "Составьте матрицы биматричной кооперативной игры";
            // 
            // firstTaskPanel
            // 
            this.firstTaskPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.firstTaskPanel.Controls.Add(this.label10);
            this.firstTaskPanel.Controls.Add(this.label9);
            this.firstTaskPanel.Controls.Add(this.label3);
            this.firstTaskPanel.Controls.Add(this.label1);
            this.firstTaskPanel.Controls.Add(this.pictureBox1);
            this.firstTaskPanel.Controls.Add(this.label8);
            this.firstTaskPanel.Controls.Add(this.label6);
            this.firstTaskPanel.Controls.Add(this.label7);
            this.firstTaskPanel.Controls.Add(this.label2);
            this.firstTaskPanel.Controls.Add(this.label11);
            this.firstTaskPanel.Location = new System.Drawing.Point(3, 32);
            this.firstTaskPanel.Name = "firstTaskPanel";
            this.firstTaskPanel.Size = new System.Drawing.Size(612, 234);
            this.firstTaskPanel.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(4, 163);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(562, 19);
            this.label10.TabIndex = 37;
            this.label10.Text = "Для изменения стратегии щелкните ячейке которую хотите заполнить.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(5, 130);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(576, 19);
            this.label9.TabIndex = 36;
            this.label9.Text = "Порядок стратегий роли не играет, вы можете заполнять их произвольно.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(155, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(372, 38);
            this.label3.TabIndex = 35;
            this.label3.Text = "В данном задании представлена неполная\r\nматрица для уменьшения размерности задачи" +
    ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(155, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 38);
            this.label1.TabIndex = 33;
            this.label1.Text = "Каждой строке/столбцу соответствует \r\nопределенная комбинация стратегий игроков.\r" +
    "\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::General.Properties.Resources.CoalitionMatrixExampleImage;
            this.pictureBox1.Location = new System.Drawing.Point(9, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 85);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(5, 191);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(491, 19);
            this.label8.TabIndex = 32;
            this.label8.Text = "После заполнения нажмите \"Далее\" для  проверки результата.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(4, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(514, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "От вас требуется заполнить заголовки столбцов и строк матрицы.\r\n";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 144);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(577, 19);
            this.label7.TabIndex = 31;
            this.label7.Text = "_______________________________________________________________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(155, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(425, 19);
            this.label2.TabIndex = 34;
            this.label2.Text = "____________________________________________________";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(4, 172);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(577, 19);
            this.label11.TabIndex = 38;
            this.label11.Text = "_______________________________________________________________________";
            // 
            // S
            // 
            this.S.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.S.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.S.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.S.Location = new System.Drawing.Point(4, 31);
            this.S.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.S.Name = "S";
            this.S.Size = new System.Drawing.Size(589, 52);
            this.S.TabIndex = 1;
            // 
            // strategiesPanel
            // 
            this.strategiesPanel.BackColor = System.Drawing.Color.Maroon;
            this.strategiesPanel.Controls.Add(this.strategiesLabel);
            this.strategiesPanel.Controls.Add(this.S);
            this.strategiesPanel.Location = new System.Drawing.Point(12, 12);
            this.strategiesPanel.Name = "strategiesPanel";
            this.strategiesPanel.Size = new System.Drawing.Size(597, 88);
            this.strategiesPanel.TabIndex = 3;
            // 
            // strategiesLabel
            // 
            this.strategiesLabel.AutoSize = true;
            this.strategiesLabel.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strategiesLabel.ForeColor = System.Drawing.Color.White;
            this.strategiesLabel.Location = new System.Drawing.Point(116, 5);
            this.strategiesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.strategiesLabel.Name = "strategiesLabel";
            this.strategiesLabel.Size = new System.Drawing.Size(306, 21);
            this.strategiesLabel.TabIndex = 36;
            this.strategiesLabel.Text = "Количество стратегий игроков";
            // 
            // payoffsPanel
            // 
            this.payoffsPanel.BackColor = System.Drawing.Color.Maroon;
            this.payoffsPanel.Controls.Add(this.payoffsLabel);
            this.payoffsPanel.Controls.Add(this.A);
            this.payoffsPanel.Controls.Add(this.B);
            this.payoffsPanel.Location = new System.Drawing.Point(12, 106);
            this.payoffsPanel.Name = "payoffsPanel";
            this.payoffsPanel.Size = new System.Drawing.Size(593, 129);
            this.payoffsPanel.TabIndex = 2;
            // 
            // payoffsLabel
            // 
            this.payoffsLabel.AutoSize = true;
            this.payoffsLabel.Font = new System.Drawing.Font("Bookman Old Style", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payoffsLabel.ForeColor = System.Drawing.Color.White;
            this.payoffsLabel.Location = new System.Drawing.Point(183, 14);
            this.payoffsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.payoffsLabel.Name = "payoffsLabel";
            this.payoffsLabel.Size = new System.Drawing.Size(220, 21);
            this.payoffsLabel.TabIndex = 37;
            this.payoffsLabel.Text = "Матрицы выигрышей";
            // 
            // A
            // 
            this.A.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.A.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.A.Location = new System.Drawing.Point(15, 40);
            this.A.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(235, 79);
            this.A.TabIndex = 0;
            // 
            // B
            // 
            this.B.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.B.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.B.Location = new System.Drawing.Point(331, 40);
            this.B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(242, 79);
            this.B.TabIndex = 1;
            this.B.Visible = false;
            // 
            // CooperativeGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(764, 886);
            this.Name = "CooperativeGameForm";
            this.navigationPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.taskContentPanel.ResumeLayout(false);
            this.taskContentPanel.PerformLayout();
            this.errorCounterPanel.ResumeLayout(false);
            this.errorCounterPanel.PerformLayout();
            this.firstTaskPanel.ResumeLayout(false);
            this.firstTaskPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.S)).EndInit();
            this.strategiesPanel.ResumeLayout(false);
            this.strategiesPanel.PerformLayout();
            this.payoffsPanel.ResumeLayout(false);
            this.payoffsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.A)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel firstTaskPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel strategiesPanel;
        private System.Windows.Forms.Label strategiesLabel;
        private System.Windows.Forms.DataGridView S;
        private System.Windows.Forms.Panel payoffsPanel;
        private System.Windows.Forms.Label payoffsLabel;
        private System.Windows.Forms.DataGridView A;
        private System.Windows.Forms.DataGridView B;
    }
}
