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
            this.B_label = new System.Windows.Forms.Label();
            this.A_label = new System.Windows.Forms.Label();
            this.payoffsLabel = new System.Windows.Forms.Label();
            this.A = new System.Windows.Forms.DataGridView();
            this.B = new System.Windows.Forms.DataGridView();
            this.secondTaskPanel = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.PayoffDivisionPanel = new System.Windows.Forms.Panel();
            this.RationalityPanel = new System.Windows.Forms.Panel();
            this.NoRB_RD = new System.Windows.Forms.RadioButton();
            this.YesRB_RD = new System.Windows.Forms.RadioButton();
            this.y = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.Label();
            this.DistributionRationalityLabel = new System.Windows.Forms.Label();
            this.CoalitionBPayoffLabel = new System.Windows.Forms.Label();
            this.CoalitionAPayoffLabel = new System.Windows.Forms.Label();
            this.GameFunctionLabel = new System.Windows.Forms.Label();
            this.NoRB_CG = new System.Windows.Forms.RadioButton();
            this.YesRB_CG = new System.Windows.Forms.RadioButton();
            this.SufficiencyLabel = new System.Windows.Forms.Label();
            this.PayoffDivisionLabel = new System.Windows.Forms.Label();
            this.FirstLine = new System.Windows.Forms.Label();
            this.SecondLine = new System.Windows.Forms.Label();
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
            this.secondTaskPanel.SuspendLayout();
            this.PayoffDivisionPanel.SuspendLayout();
            this.RationalityPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // navigationPanel
            // 
            this.navigationPanel.Location = new System.Drawing.Point(15, 925);
            this.navigationPanel.Size = new System.Drawing.Size(640, 52);
            // 
            // headerLabel
            // 
            this.headerLabel.Location = new System.Drawing.Point(9, 5);
            this.headerLabel.Size = new System.Drawing.Size(256, 32);
            this.headerLabel.Text = "Cooperative Game";
            // 
            // SkipButton
            // 
            this.SkipButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SkipButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.SkipButton.Click += new System.EventHandler(this.SkipButton_Click);
            // 
            // FinishButton
            // 
            this.FinishButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FinishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FinishButton.Location = new System.Drawing.Point(473, 7);
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
            // 
            // headerPanel
            // 
            this.headerPanel.Size = new System.Drawing.Size(643, 417);
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.Transparent;
            this.contentPanel.Controls.Add(this.PayoffDivisionPanel);
            this.contentPanel.Controls.Add(this.payoffsPanel);
            this.contentPanel.Controls.Add(this.strategiesPanel);
            this.contentPanel.Location = new System.Drawing.Point(15, 435);
            this.contentPanel.Size = new System.Drawing.Size(643, 474);
            // 
            // taskContentPanel
            // 
            this.taskContentPanel.BackColor = System.Drawing.Color.Maroon;
            this.taskContentPanel.Controls.Add(this.secondTaskPanel);
            this.taskContentPanel.Controls.Add(this.firstTaskPanel);
            this.taskContentPanel.Location = new System.Drawing.Point(15, 54);
            this.taskContentPanel.Size = new System.Drawing.Size(618, 352);
            this.taskContentPanel.Controls.SetChildIndex(this.firstTaskPanel, 0);
            this.taskContentPanel.Controls.SetChildIndex(this.taskLabel, 0);
            this.taskContentPanel.Controls.SetChildIndex(this.secondTaskPanel, 0);
            // 
            // errorCounterPanel
            // 
            this.errorCounterPanel.Location = new System.Drawing.Point(389, 3);
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
            this.strategiesPanel.Size = new System.Drawing.Size(612, 88);
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
            this.payoffsPanel.Controls.Add(this.B_label);
            this.payoffsPanel.Controls.Add(this.A_label);
            this.payoffsPanel.Controls.Add(this.payoffsLabel);
            this.payoffsPanel.Controls.Add(this.A);
            this.payoffsPanel.Controls.Add(this.B);
            this.payoffsPanel.Location = new System.Drawing.Point(12, 106);
            this.payoffsPanel.Name = "payoffsPanel";
            this.payoffsPanel.Size = new System.Drawing.Size(612, 129);
            this.payoffsPanel.TabIndex = 2;
            // 
            // B_label
            // 
            this.B_label.AutoSize = true;
            this.B_label.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_label.ForeColor = System.Drawing.Color.White;
            this.B_label.Location = new System.Drawing.Point(322, 63);
            this.B_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.B_label.Name = "B_label";
            this.B_label.Size = new System.Drawing.Size(69, 32);
            this.B_label.TabIndex = 39;
            this.B_label.Text = "B = ";
            this.B_label.Visible = false;
            // 
            // A_label
            // 
            this.A_label.AutoSize = true;
            this.A_label.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A_label.ForeColor = System.Drawing.Color.White;
            this.A_label.Location = new System.Drawing.Point(11, 63);
            this.A_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.A_label.Name = "A_label";
            this.A_label.Size = new System.Drawing.Size(67, 32);
            this.A_label.TabIndex = 38;
            this.A_label.Text = "A = ";
            this.A_label.Visible = false;
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
            this.A.Location = new System.Drawing.Point(83, 40);
            this.A.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(156, 79);
            this.A.TabIndex = 0;
            // 
            // B
            // 
            this.B.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.B.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.B.Location = new System.Drawing.Point(399, 40);
            this.B.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.B.Name = "B";
            this.B.Size = new System.Drawing.Size(194, 79);
            this.B.TabIndex = 1;
            this.B.Visible = false;
            // 
            // secondTaskPanel
            // 
            this.secondTaskPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(237)))));
            this.secondTaskPanel.Controls.Add(this.label25);
            this.secondTaskPanel.Controls.Add(this.label26);
            this.secondTaskPanel.Controls.Add(this.label27);
            this.secondTaskPanel.Location = new System.Drawing.Point(3, 274);
            this.secondTaskPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.secondTaskPanel.Name = "secondTaskPanel";
            this.secondTaskPanel.Size = new System.Drawing.Size(612, 75);
            this.secondTaskPanel.TabIndex = 29;
            this.secondTaskPanel.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(8, 47);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(491, 19);
            this.label25.TabIndex = 9;
            this.label25.Text = "После заполнения нажмите \"Далее\" для  проверки результата.";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(8, 26);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(602, 19);
            this.label26.TabIndex = 7;
            this.label26.Text = "Для того чтобы удалить строку или столбец, щелкните ПКМ по его заголовку.";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(8, 7);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(461, 19);
            this.label27.TabIndex = 4;
            this.label27.Text = "Сократите матрицу используя отношение доминирования.";
            // 
            // PayoffDivisionPanel
            // 
            this.PayoffDivisionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(179)))), ((int)(((byte)(120)))));
            this.PayoffDivisionPanel.Controls.Add(this.RationalityPanel);
            this.PayoffDivisionPanel.Controls.Add(this.y);
            this.PayoffDivisionPanel.Controls.Add(this.x);
            this.PayoffDivisionPanel.Controls.Add(this.DistributionRationalityLabel);
            this.PayoffDivisionPanel.Controls.Add(this.CoalitionBPayoffLabel);
            this.PayoffDivisionPanel.Controls.Add(this.CoalitionAPayoffLabel);
            this.PayoffDivisionPanel.Controls.Add(this.GameFunctionLabel);
            this.PayoffDivisionPanel.Controls.Add(this.NoRB_CG);
            this.PayoffDivisionPanel.Controls.Add(this.YesRB_CG);
            this.PayoffDivisionPanel.Controls.Add(this.SufficiencyLabel);
            this.PayoffDivisionPanel.Controls.Add(this.PayoffDivisionLabel);
            this.PayoffDivisionPanel.Controls.Add(this.FirstLine);
            this.PayoffDivisionPanel.Controls.Add(this.SecondLine);
            this.PayoffDivisionPanel.Location = new System.Drawing.Point(12, 242);
            this.PayoffDivisionPanel.Name = "PayoffDivisionPanel";
            this.PayoffDivisionPanel.Size = new System.Drawing.Size(615, 226);
            this.PayoffDivisionPanel.TabIndex = 13;
            this.PayoffDivisionPanel.Visible = false;
            // 
            // RationalityPanel
            // 
            this.RationalityPanel.Controls.Add(this.NoRB_RD);
            this.RationalityPanel.Controls.Add(this.YesRB_RD);
            this.RationalityPanel.ForeColor = System.Drawing.Color.Black;
            this.RationalityPanel.Location = new System.Drawing.Point(0, 188);
            this.RationalityPanel.Name = "RationalityPanel";
            this.RationalityPanel.Size = new System.Drawing.Size(575, 26);
            this.RationalityPanel.TabIndex = 19;
            // 
            // NoRB_RD
            // 
            this.NoRB_RD.AutoSize = true;
            this.NoRB_RD.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoRB_RD.ForeColor = System.Drawing.Color.Black;
            this.NoRB_RD.Location = new System.Drawing.Point(344, 2);
            this.NoRB_RD.Name = "NoRB_RD";
            this.NoRB_RD.Size = new System.Drawing.Size(57, 24);
            this.NoRB_RD.TabIndex = 16;
            this.NoRB_RD.TabStop = true;
            this.NoRB_RD.Text = "Нет";
            this.NoRB_RD.UseVisualStyleBackColor = true;
            // 
            // YesRB_RD
            // 
            this.YesRB_RD.AutoSize = true;
            this.YesRB_RD.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesRB_RD.ForeColor = System.Drawing.Color.Black;
            this.YesRB_RD.Location = new System.Drawing.Point(132, 3);
            this.YesRB_RD.Name = "YesRB_RD";
            this.YesRB_RD.Size = new System.Drawing.Size(48, 24);
            this.YesRB_RD.TabIndex = 15;
            this.YesRB_RD.TabStop = true;
            this.YesRB_RD.Text = "Да";
            this.YesRB_RD.UseVisualStyleBackColor = true;
            // 
            // y
            // 
            this.y.AutoSize = true;
            this.y.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y.ForeColor = System.Drawing.Color.Black;
            this.y.Location = new System.Drawing.Point(361, 126);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(43, 20);
            this.y.TabIndex = 18;
            this.y.Text = "y = (";
            // 
            // x
            // 
            this.x.AutoSize = true;
            this.x.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x.ForeColor = System.Drawing.Color.Black;
            this.x.Location = new System.Drawing.Point(277, 127);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(43, 20);
            this.x.TabIndex = 17;
            this.x.Text = "x = (";
            // 
            // DistributionRationalityLabel
            // 
            this.DistributionRationalityLabel.AutoSize = true;
            this.DistributionRationalityLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DistributionRationalityLabel.ForeColor = System.Drawing.Color.Black;
            this.DistributionRationalityLabel.Location = new System.Drawing.Point(13, 165);
            this.DistributionRationalityLabel.Name = "DistributionRationalityLabel";
            this.DistributionRationalityLabel.Size = new System.Drawing.Size(550, 20);
            this.DistributionRationalityLabel.TabIndex = 14;
            this.DistributionRationalityLabel.Text = "Соблюдается ли условие индивидуальной рациональности дележа?";
            // 
            // CoalitionBPayoffLabel
            // 
            this.CoalitionBPayoffLabel.AutoSize = true;
            this.CoalitionBPayoffLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoalitionBPayoffLabel.ForeColor = System.Drawing.Color.Black;
            this.CoalitionBPayoffLabel.Location = new System.Drawing.Point(249, 28);
            this.CoalitionBPayoffLabel.Name = "CoalitionBPayoffLabel";
            this.CoalitionBPayoffLabel.Size = new System.Drawing.Size(21, 20);
            this.CoalitionBPayoffLabel.TabIndex = 12;
            this.CoalitionBPayoffLabel.Text = "v ";
            // 
            // CoalitionAPayoffLabel
            // 
            this.CoalitionAPayoffLabel.AutoSize = true;
            this.CoalitionAPayoffLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoalitionAPayoffLabel.ForeColor = System.Drawing.Color.Black;
            this.CoalitionAPayoffLabel.Location = new System.Drawing.Point(8, 29);
            this.CoalitionAPayoffLabel.Name = "CoalitionAPayoffLabel";
            this.CoalitionAPayoffLabel.Size = new System.Drawing.Size(21, 20);
            this.CoalitionAPayoffLabel.TabIndex = 11;
            this.CoalitionAPayoffLabel.Text = "v ";
            // 
            // GameFunctionLabel
            // 
            this.GameFunctionLabel.AutoSize = true;
            this.GameFunctionLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameFunctionLabel.ForeColor = System.Drawing.Color.Black;
            this.GameFunctionLabel.Location = new System.Drawing.Point(8, 9);
            this.GameFunctionLabel.Name = "GameFunctionLabel";
            this.GameFunctionLabel.Size = new System.Drawing.Size(115, 20);
            this.GameFunctionLabel.TabIndex = 10;
            this.GameFunctionLabel.Text = "Цена игры = ";
            // 
            // NoRB_CG
            // 
            this.NoRB_CG.AutoSize = true;
            this.NoRB_CG.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoRB_CG.ForeColor = System.Drawing.Color.Black;
            this.NoRB_CG.Location = new System.Drawing.Point(287, 73);
            this.NoRB_CG.Name = "NoRB_CG";
            this.NoRB_CG.Size = new System.Drawing.Size(57, 24);
            this.NoRB_CG.TabIndex = 7;
            this.NoRB_CG.TabStop = true;
            this.NoRB_CG.Text = "Нет";
            this.NoRB_CG.UseVisualStyleBackColor = true;
            // 
            // YesRB_CG
            // 
            this.YesRB_CG.AutoSize = true;
            this.YesRB_CG.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YesRB_CG.ForeColor = System.Drawing.Color.Black;
            this.YesRB_CG.Location = new System.Drawing.Point(133, 76);
            this.YesRB_CG.Name = "YesRB_CG";
            this.YesRB_CG.Size = new System.Drawing.Size(48, 24);
            this.YesRB_CG.TabIndex = 6;
            this.YesRB_CG.TabStop = true;
            this.YesRB_CG.Text = "Да";
            this.YesRB_CG.UseVisualStyleBackColor = true;
            // 
            // SufficiencyLabel
            // 
            this.SufficiencyLabel.AutoSize = true;
            this.SufficiencyLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SufficiencyLabel.ForeColor = System.Drawing.Color.Black;
            this.SufficiencyLabel.Location = new System.Drawing.Point(18, 48);
            this.SufficiencyLabel.Name = "SufficiencyLabel";
            this.SufficiencyLabel.Size = new System.Drawing.Size(464, 20);
            this.SufficiencyLabel.TabIndex = 5;
            this.SufficiencyLabel.Text = "Является ли данная кооперативная игра существенной?";
            // 
            // PayoffDivisionLabel
            // 
            this.PayoffDivisionLabel.AutoSize = true;
            this.PayoffDivisionLabel.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayoffDivisionLabel.ForeColor = System.Drawing.Color.Black;
            this.PayoffDivisionLabel.Location = new System.Drawing.Point(18, 114);
            this.PayoffDivisionLabel.Name = "PayoffDivisionLabel";
            this.PayoffDivisionLabel.Size = new System.Drawing.Size(252, 20);
            this.PayoffDivisionLabel.TabIndex = 4;
            this.PayoffDivisionLabel.Text = "Определите дележ выигрыша";
            // 
            // FirstLine
            // 
            this.FirstLine.AutoSize = true;
            this.FirstLine.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstLine.ForeColor = System.Drawing.Color.Black;
            this.FirstLine.Location = new System.Drawing.Point(8, 95);
            this.FirstLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FirstLine.Name = "FirstLine";
            this.FirstLine.Size = new System.Drawing.Size(561, 19);
            this.FirstLine.TabIndex = 9;
            this.FirstLine.Text = "_____________________________________________________________________";
            // 
            // SecondLine
            // 
            this.SecondLine.AutoSize = true;
            this.SecondLine.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecondLine.ForeColor = System.Drawing.Color.Black;
            this.SecondLine.Location = new System.Drawing.Point(5, 146);
            this.SecondLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SecondLine.Name = "SecondLine";
            this.SecondLine.Size = new System.Drawing.Size(561, 19);
            this.SecondLine.TabIndex = 13;
            this.SecondLine.Text = "_____________________________________________________________________";
            // 
            // CooperativeGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.ClientSize = new System.Drawing.Size(666, 1045);
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
            this.secondTaskPanel.ResumeLayout(false);
            this.secondTaskPanel.PerformLayout();
            this.PayoffDivisionPanel.ResumeLayout(false);
            this.PayoffDivisionPanel.PerformLayout();
            this.RationalityPanel.ResumeLayout(false);
            this.RationalityPanel.PerformLayout();
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
        private System.Windows.Forms.Panel secondTaskPanel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel PayoffDivisionPanel;
        private System.Windows.Forms.Panel RationalityPanel;
        private System.Windows.Forms.RadioButton NoRB_RD;
        private System.Windows.Forms.RadioButton YesRB_RD;
        private System.Windows.Forms.Label y;
        private System.Windows.Forms.Label x;
        private System.Windows.Forms.Label DistributionRationalityLabel;
        private System.Windows.Forms.Label CoalitionBPayoffLabel;
        private System.Windows.Forms.Label CoalitionAPayoffLabel;
        private System.Windows.Forms.Label GameFunctionLabel;
        private System.Windows.Forms.RadioButton NoRB_CG;
        private System.Windows.Forms.RadioButton YesRB_CG;
        private System.Windows.Forms.Label SufficiencyLabel;
        private System.Windows.Forms.Label PayoffDivisionLabel;
        private System.Windows.Forms.Label FirstLine;
        private System.Windows.Forms.Label SecondLine;
        private System.Windows.Forms.Label B_label;
        private System.Windows.Forms.Label A_label;
    }
}
