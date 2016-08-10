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
            this.ShapleyResult = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.CKResult = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.CGResult = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CKernelButton = new System.Windows.Forms.Button();
            this.shapleyButton = new System.Windows.Forms.Button();
            this.coopGamesButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.ShapleyResult.SuspendLayout();
            this.CKResult.SuspendLayout();
            this.CGResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.ShapleyResult);
            this.panel1.Controls.Add(this.CKResult);
            this.panel1.Controls.Add(this.CGResult);
            this.panel1.Controls.Add(this.CKernelButton);
            this.panel1.Controls.Add(this.shapleyButton);
            this.panel1.Controls.Add(this.coopGamesButton);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 174);
            this.panel1.TabIndex = 0;
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
            // CKernelButton
            // 
            this.CKernelButton.BackColor = System.Drawing.Color.Transparent;
            this.CKernelButton.Enabled = false;
            this.CKernelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CKernelButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CKernelButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CKernelButton.Location = new System.Drawing.Point(21, 67);
            this.CKernelButton.Name = "CKernelButton";
            this.CKernelButton.Size = new System.Drawing.Size(212, 40);
            this.CKernelButton.TabIndex = 2;
            this.CKernelButton.Text = "С-ядро";
            this.CKernelButton.UseVisualStyleBackColor = false;
            this.CKernelButton.Click += new System.EventHandler(this.CKernelButton_Click);
            // 
            // shapleyButton
            // 
            this.shapleyButton.BackColor = System.Drawing.Color.Transparent;
            this.shapleyButton.Enabled = false;
            this.shapleyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.shapleyButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shapleyButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.shapleyButton.Location = new System.Drawing.Point(21, 113);
            this.shapleyButton.Name = "shapleyButton";
            this.shapleyButton.Size = new System.Drawing.Size(212, 40);
            this.shapleyButton.TabIndex = 1;
            this.shapleyButton.Text = "Вектор Шепли";
            this.shapleyButton.UseVisualStyleBackColor = false;
            this.shapleyButton.Click += new System.EventHandler(this.shapleyButton_Click);
            // 
            // coopGamesButton
            // 
            this.coopGamesButton.BackColor = System.Drawing.Color.Maroon;
            this.coopGamesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.coopGamesButton.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coopGamesButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.coopGamesButton.Location = new System.Drawing.Point(21, 21);
            this.coopGamesButton.Name = "coopGamesButton";
            this.coopGamesButton.Size = new System.Drawing.Size(212, 40);
            this.coopGamesButton.TabIndex = 0;
            this.coopGamesButton.Text = "Кооперативные игры";
            this.coopGamesButton.UseVisualStyleBackColor = false;
            this.coopGamesButton.Click += new System.EventHandler(this.coopGamesButton_Click);
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
            this.ShapleyResult.ResumeLayout(false);
            this.ShapleyResult.PerformLayout();
            this.CKResult.ResumeLayout(false);
            this.CKResult.PerformLayout();
            this.CGResult.ResumeLayout(false);
            this.CGResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button coopGamesButton;
        private System.Windows.Forms.Button CKernelButton;
        private System.Windows.Forms.Button shapleyButton;
        private System.Windows.Forms.Panel ShapleyResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel CKResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel CGResult;
        private System.Windows.Forms.Label label1;
    }
}