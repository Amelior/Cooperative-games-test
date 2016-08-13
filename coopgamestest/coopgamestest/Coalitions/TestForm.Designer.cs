namespace General.Coalitions
{
    partial class TestForm
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
            this.actualTaskLabel = new System.Windows.Forms.Label();
            this.defPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.taskPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.possibleCoalitionsPanel = new System.Windows.Forms.Panel();
            this.possibleCoalitionsLabel = new System.Windows.Forms.Label();
            this.navigationPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.taskContentPanel.SuspendLayout();
            this.errorCounterPanel.SuspendLayout();
            this.defPanel.SuspendLayout();
            this.taskPanel.SuspendLayout();
            this.possibleCoalitionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            this.navigationPanel.Location = new System.Drawing.Point(12, 462);
            this.navigationPanel.Size = new System.Drawing.Size(847, 64);
            // 
            // headerLabel
            // 
            this.headerLabel.Size = new System.Drawing.Size(439, 32);
            this.headerLabel.Text = "Fill information about coalitions";
            // 
            // taskLabel
            // 
            this.taskLabel.Location = new System.Drawing.Point(99, 13);
            this.taskLabel.Size = new System.Drawing.Size(96, 20);
            this.taskLabel.Text = "Definitions";
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
            this.FinishButton.Location = new System.Drawing.Point(696, 3);
            this.FinishButton.Size = new System.Drawing.Size(148, 45);
            // 
            // headerPanel
            // 
            this.headerPanel.Size = new System.Drawing.Size(847, 328);
            // 
            // contentPanel
            // 
            this.contentPanel.Location = new System.Drawing.Point(12, 386);
            this.contentPanel.Size = new System.Drawing.Size(847, 73);
            // 
            // taskContentPanel
            // 
            this.taskContentPanel.Controls.Add(this.taskPanel);
            this.taskContentPanel.Controls.Add(this.defPanel);
            this.taskContentPanel.Controls.Add(this.actualTaskLabel);
            this.taskContentPanel.Size = new System.Drawing.Size(806, 238);
            this.taskContentPanel.Controls.SetChildIndex(this.taskLabel, 0);
            this.taskContentPanel.Controls.SetChildIndex(this.actualTaskLabel, 0);
            this.taskContentPanel.Controls.SetChildIndex(this.defPanel, 0);
            this.taskContentPanel.Controls.SetChildIndex(this.taskPanel, 0);
            // 
            // errorCounterPanel
            // 
            this.errorCounterPanel.Location = new System.Drawing.Point(451, 16);
            // 
            // actualTaskLabel
            // 
            this.actualTaskLabel.AutoSize = true;
            this.actualTaskLabel.Location = new System.Drawing.Point(452, 13);
            this.actualTaskLabel.Name = "actualTaskLabel";
            this.actualTaskLabel.Size = new System.Drawing.Size(45, 20);
            this.actualTaskLabel.TabIndex = 3;
            this.actualTaskLabel.Text = "Task";
            // 
            // defPanel
            // 
            this.defPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(179)))), ((int)(((byte)(120)))));
            this.defPanel.Controls.Add(this.label2);
            this.defPanel.Controls.Add(this.textBox3);
            this.defPanel.Controls.Add(this.label3);
            this.defPanel.Controls.Add(this.textBox2);
            this.defPanel.Controls.Add(this.label4);
            this.defPanel.Controls.Add(this.textBox1);
            this.defPanel.Location = new System.Drawing.Point(16, 46);
            this.defPanel.Name = "defPanel";
            this.defPanel.Size = new System.Drawing.Size(272, 103);
            this.defPanel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(62, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "Состояние не определено";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(88)))), ((int)(((byte)(114)))));
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(21, 69);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(35, 20);
            this.textBox3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(62, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Несущественная игра";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Maroon;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(21, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(35, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(62, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Существенная игра";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(21, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 0;
            // 
            // taskPanel
            // 
            this.taskPanel.BackColor = System.Drawing.Color.White;
            this.taskPanel.Controls.Add(this.label8);
            this.taskPanel.Controls.Add(this.label6);
            this.taskPanel.Controls.Add(this.label5);
            this.taskPanel.Controls.Add(this.label7);
            this.taskPanel.Controls.Add(this.label9);
            this.taskPanel.Location = new System.Drawing.Point(307, 46);
            this.taskPanel.Name = "taskPanel";
            this.taskPanel.Size = new System.Drawing.Size(483, 182);
            this.taskPanel.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(9, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(399, 38);
            this.label8.TabIndex = 9;
            this.label8.Text = "После заполнения нажмите \"Далее\" для  проверки\r\nрезультата.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(11, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(297, 57);
            this.label6.TabIndex = 7;
            this.label6.Text = "Работа с коалициями:\r\n      ЛКМ - открыть биматричную игру\r\n      ПКМ - изменить " +
    "статус игры\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(469, 38);
            this.label5.TabIndex = 4;
            this.label5.Text = "Выделите существенные игры из конфигураций коалиций,\r\nпредставленных ниже.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(5, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(473, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "__________________________________________________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(5, 110);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(473, 19);
            this.label9.TabIndex = 8;
            this.label9.Text = "__________________________________________________________";
            // 
            // possibleCoalitionsPanel
            // 
            this.possibleCoalitionsPanel.Controls.Add(this.possibleCoalitionsLabel);
            this.possibleCoalitionsPanel.Location = new System.Drawing.Point(12, 346);
            this.possibleCoalitionsPanel.Name = "possibleCoalitionsPanel";
            this.possibleCoalitionsPanel.Size = new System.Drawing.Size(847, 34);
            this.possibleCoalitionsPanel.TabIndex = 6;
            // 
            // possibleCoalitionsLabel
            // 
            this.possibleCoalitionsLabel.AutoSize = true;
            this.possibleCoalitionsLabel.Font = new System.Drawing.Font("Bookman Old Style", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.possibleCoalitionsLabel.ForeColor = System.Drawing.Color.White;
            this.possibleCoalitionsLabel.Location = new System.Drawing.Point(315, 0);
            this.possibleCoalitionsLabel.Name = "possibleCoalitionsLabel";
            this.possibleCoalitionsLabel.Size = new System.Drawing.Size(198, 24);
            this.possibleCoalitionsLabel.TabIndex = 0;
            this.possibleCoalitionsLabel.Text = "Possible coalitions";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(871, 556);
            this.Controls.Add(this.possibleCoalitionsPanel);
            this.Name = "TestForm";
            this.Controls.SetChildIndex(this.headerPanel, 0);
            this.Controls.SetChildIndex(this.contentPanel, 0);
            this.Controls.SetChildIndex(this.navigationPanel, 0);
            this.Controls.SetChildIndex(this.possibleCoalitionsPanel, 0);
            this.navigationPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.taskContentPanel.ResumeLayout(false);
            this.taskContentPanel.PerformLayout();
            this.errorCounterPanel.ResumeLayout(false);
            this.errorCounterPanel.PerformLayout();
            this.defPanel.ResumeLayout(false);
            this.defPanel.PerformLayout();
            this.taskPanel.ResumeLayout(false);
            this.taskPanel.PerformLayout();
            this.possibleCoalitionsPanel.ResumeLayout(false);
            this.possibleCoalitionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label actualTaskLabel;
        private System.Windows.Forms.Panel defPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel taskPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel possibleCoalitionsPanel;
        private System.Windows.Forms.Label possibleCoalitionsLabel;
    }
}
