namespace General
{
    partial class StudentInitializationForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.StNameLB = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PassTB = new System.Windows.Forms.TextBox();
            this.PassLB = new System.Windows.Forms.Label();
            this.StartBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(74, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 29);
            this.textBox1.TabIndex = 0;
            // 
            // StNameLB
            // 
            this.StNameLB.AutoSize = true;
            this.StNameLB.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StNameLB.Location = new System.Drawing.Point(12, 19);
            this.StNameLB.Name = "StNameLB";
            this.StNameLB.Size = new System.Drawing.Size(56, 23);
            this.StNameLB.TabIndex = 1;
            this.StNameLB.Text = "Имя:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.PassTB);
            this.panel1.Controls.Add(this.PassLB);
            this.panel1.Controls.Add(this.StartBTN);
            this.panel1.Controls.Add(this.StNameLB);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 113);
            this.panel1.TabIndex = 5;
            // 
            // PassTB
            // 
            this.PassTB.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassTB.Location = new System.Drawing.Point(100, 70);
            this.PassTB.Name = "PassTB";
            this.PassTB.Size = new System.Drawing.Size(124, 29);
            this.PassTB.TabIndex = 7;
            // 
            // PassLB
            // 
            this.PassLB.AutoSize = true;
            this.PassLB.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassLB.Location = new System.Drawing.Point(12, 73);
            this.PassLB.Name = "PassLB";
            this.PassLB.Size = new System.Drawing.Size(82, 23);
            this.PassLB.TabIndex = 6;
            this.PassLB.Text = "Пароль:";
            // 
            // StartBTN
            // 
            this.StartBTN.BackColor = System.Drawing.Color.SaddleBrown;
            this.StartBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartBTN.Font = new System.Drawing.Font("Lucida Calligraphy", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartBTN.ForeColor = System.Drawing.Color.White;
            this.StartBTN.Location = new System.Drawing.Point(243, 68);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(112, 34);
            this.StartBTN.TabIndex = 5;
            this.StartBTN.Text = "Start";
            this.StartBTN.UseVisualStyleBackColor = false;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // StudentInitializationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.ClientSize = new System.Drawing.Size(389, 135);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.Name = "StudentInitializationForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Инициализация студента";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InitializationForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label StNameLB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox PassTB;
        private System.Windows.Forms.Label PassLB;
        private System.Windows.Forms.Button StartBTN;
    }
}

