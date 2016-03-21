namespace General
{
    partial class TestSelectionForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.C_kernel_button = new System.Windows.Forms.Button();
            this.shapley_button = new System.Windows.Forms.Button();
            this.coop_games_button = new System.Windows.Forms.Button();
            this.CGResult = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CKResult = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ShapleyResult = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.CGResult.SuspendLayout();
            this.CKResult.SuspendLayout();
            this.ShapleyResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.ShapleyResult);
            this.panel1.Controls.Add(this.CKResult);
            this.panel1.Controls.Add(this.CGResult);
            this.panel1.Controls.Add(this.C_kernel_button);
            this.panel1.Controls.Add(this.shapley_button);
            this.panel1.Controls.Add(this.coop_games_button);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 174);
            this.panel1.TabIndex = 0;
            // 
            // C_kernel_button
            // 
            this.C_kernel_button.BackColor = System.Drawing.Color.Transparent;
            this.C_kernel_button.Enabled = false;
            this.C_kernel_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.C_kernel_button.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C_kernel_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.C_kernel_button.Location = new System.Drawing.Point(21, 67);
            this.C_kernel_button.Name = "C_kernel_button";
            this.C_kernel_button.Size = new System.Drawing.Size(212, 40);
            this.C_kernel_button.TabIndex = 2;
            this.C_kernel_button.Text = "С-ядро";
            this.C_kernel_button.UseVisualStyleBackColor = false;
            // 
            // shapley_button
            // 
            this.shapley_button.BackColor = System.Drawing.Color.Transparent;
            this.shapley_button.Enabled = false;
            this.shapley_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.shapley_button.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shapley_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.shapley_button.Location = new System.Drawing.Point(21, 113);
            this.shapley_button.Name = "shapley_button";
            this.shapley_button.Size = new System.Drawing.Size(212, 40);
            this.shapley_button.TabIndex = 1;
            this.shapley_button.Text = "Вектор Шепли";
            this.shapley_button.UseVisualStyleBackColor = false;
            // 
            // coop_games_button
            // 
            this.coop_games_button.BackColor = System.Drawing.Color.Maroon;
            this.coop_games_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.coop_games_button.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coop_games_button.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.coop_games_button.Location = new System.Drawing.Point(21, 21);
            this.coop_games_button.Name = "coop_games_button";
            this.coop_games_button.Size = new System.Drawing.Size(212, 40);
            this.coop_games_button.TabIndex = 0;
            this.coop_games_button.Text = "Кооперативные игры";
            this.coop_games_button.UseVisualStyleBackColor = false;
            this.coop_games_button.Click += new System.EventHandler(this.coop_games_button_Click);
            // 
            // CGResult
            // 
            this.CGResult.BackColor = System.Drawing.Color.DimGray;
            this.CGResult.Controls.Add(this.label1);
            this.CGResult.Location = new System.Drawing.Point(239, 21);
            this.CGResult.Name = "CGResult";
            this.CGResult.Size = new System.Drawing.Size(228, 40);
            this.CGResult.TabIndex = 3;
            this.CGResult.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество ошибок: ";
            // 
            // CKResult
            // 
            this.CKResult.BackColor = System.Drawing.Color.DimGray;
            this.CKResult.Controls.Add(this.label2);
            this.CKResult.Location = new System.Drawing.Point(239, 67);
            this.CKResult.Name = "CKResult";
            this.CKResult.Size = new System.Drawing.Size(228, 40);
            this.CKResult.TabIndex = 4;
            this.CKResult.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Количество ошибок: ";
            // 
            // ShapleyResult
            // 
            this.ShapleyResult.BackColor = System.Drawing.Color.DimGray;
            this.ShapleyResult.Controls.Add(this.label3);
            this.ShapleyResult.Location = new System.Drawing.Point(239, 113);
            this.ShapleyResult.Name = "ShapleyResult";
            this.ShapleyResult.Size = new System.Drawing.Size(228, 40);
            this.ShapleyResult.TabIndex = 5;
            this.ShapleyResult.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Количество ошибок: ";
            // 
            // TestSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(516, 201);
            this.Controls.Add(this.panel1);
            this.Name = "TestSelectionForm";
            this.Text = "Выберите тест";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestSelectionForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.CGResult.ResumeLayout(false);
            this.CGResult.PerformLayout();
            this.CKResult.ResumeLayout(false);
            this.CKResult.PerformLayout();
            this.ShapleyResult.ResumeLayout(false);
            this.ShapleyResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button coop_games_button;
        private System.Windows.Forms.Button C_kernel_button;
        private System.Windows.Forms.Button shapley_button;
        private System.Windows.Forms.Panel ShapleyResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel CKResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel CGResult;
        private System.Windows.Forms.Label label1;
    }
}