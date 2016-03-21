using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace General.Coalitions
{
    public partial class IncooperativeGame : Form
    {
        BackgroundWorker BW;
        List<TextBox> TB = new List<TextBox>();
        int GenerationIteration = 1;
        UI.ControlsAligner form;
        public IncooperativeGame()
        {
            InitializeComponent();
            CGStudentProgress.FormsOpened.Add(this);
            GenerateGame(3);
            CGStudentProgress.NewSection();
            
            //List<List<Double>> A = new List<List<double>>();
            //A.Add(new List<double>());
            //A.Last().Add(11); A.Last().Add(11); A.Last().Add(22);
            //A.Add(new List<double>());
            //A.Last().Add(8); A.Last().Add(39); A.Last().Add(9);
            //A.Add(new List<double>());
            //A.Last().Add(7); A.Last().Add(11); A.Last().Add(24);
            //A.Add(new List<double>());
            //A.Last().Add(12); A.Last().Add(11); A.Last().Add(22);

            //List<List<Double>> B = new List<List<double>>();
            //B.Add(new List<double>());
            //B.Last().Add(20); B.Last().Add(40); B.Last().Add(11);
            //B.Add(new List<double>());
            //B.Last().Add(13); B.Last().Add(29); B.Last().Add(36);
            //B.Add(new List<double>());
            //B.Last().Add(36); B.Last().Add(12); B.Last().Add(29);
            //B.Add(new List<double>());
            //B.Last().Add(32); B.Last().Add(39); B.Last().Add(11);

            //SingleGame Test = new SingleGame(A, B);
            //SingleGame D = Test.Dominate();
        }

        void GenerateGame(int N)
        {
            BW = new BackgroundWorker();
            BW.WorkerReportsProgress = true;
            BW.DoWork += new DoWorkEventHandler(DoBackgroundWork);
            BW.ProgressChanged += new ProgressChangedEventHandler(UpdatePB);
            BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(GenerationFinished);

            Database.G.N = N;
            progressBar1.Maximum = 114;
            SetUI();

            BW.RunWorkerAsync();
        }

        void SetUI()
        {
            form = new UI.ControlsAligner(this);
            form.AddElement(GridPanel);
            form.AddElement(GenerationPanel);

            label1.Text = "Генерирование биматричных игр (1/" +
                (Database.G.N * (Database.G.N - 1) / 2).ToString() + ")";

            UI.TWDNGrid G = new UI.TWDNGrid(D, Database.G.N, Database.G.N);
            G.InitializeHeaders("Выигрыши", "Игрок", "Игрок");
            G.InitializeGrid();
            D.ReadOnly = true;

            D.CellDoubleClick += new DataGridViewCellEventHandler(ViewGameInNewWindow);
            D.CellMouseClick += new DataGridViewCellMouseEventHandler(CellSelected);
            D.MultiSelect = true;

            UI.ControlsAligner gridpanel = new UI.ControlsAligner(GridPanel);
            gridpanel.AddElement(label2);
            gridpanel.AddElement(D);
            gridpanel.Align();

            UI.ControlsAligner genpanel = new UI.ControlsAligner(GenerationPanel);
            genpanel.AddElement(label1);
            genpanel.AddElement(progressBar1);
            genpanel.Align();

            form.Align();
        }


        void DoBackgroundWork(object sender, DoWorkEventArgs e)
        {
            Database.G.GenerateCooperativeGame(BW, progressBar1);
        }

        void UpdatePB(object sender, ProgressChangedEventArgs e)
        {
            int half = progressBar1.Maximum / 2,
                BimatrixGamesNumber = Database.G.N * (Database.G.N - 1) / 2;
            if (progressBar1.Value != progressBar1.Maximum)
                progressBar1.Value = progressBar1.Value + e.ProgressPercentage;

            if (progressBar1.Value == 0)
            {
                GenerationIteration++;
                label1.Text = "Генерирование биматричных игр [#" + GenerationIteration + "] (1/" + BimatrixGamesNumber + ")";
                label1.Left = progressBar1.Left + (progressBar1.Width - label1.Width) / 2;
                for (int i = 0; i < D.Rows.Count; i++)
                    for (int j = 0; j < D.Columns.Count; j++)
                        D[j, i].Value = null;
            }
            else if (progressBar1.Value < half)
            {
                int current = progressBar1.Value / e.ProgressPercentage + 1;
                label1.Text = "Генерирование биматричных игр ";
                if (GenerationIteration > 1)
                    label1.Text += "[#" + GenerationIteration + "] ";
                label1.Text += "(" + current + "/" + BimatrixGamesNumber + ")";
                if (Database.G.SingleGames.Count > 0)
                {
                    SingleGame G = Database.G.SingleGames.Last();
                    D[G.pl2, G.pl1].Value = G.Ha.ToString("0.00");
                    D[G.pl1, G.pl2].Value = G.Hb.ToString("0.00");
                }
            }
            else if (progressBar1.Value == half)
            {
                SingleGame G = Database.G.SingleGames.Last();
                D[G.pl2, G.pl1].Value = G.Ha.ToString("0.00");
                D[G.pl1, G.pl2].Value = G.Hb.ToString("0.00");
                label1.Text = "Проверка устойчивости ";
                if (GenerationIteration > 1)
                    label1.Text += "[#" + GenerationIteration + "] ";
                label1.Text += "(1/" + Database.G.CoalitionsCount + ")";

                label1.Left = progressBar1.Left + (progressBar1.Width - label1.Width) / 2;
            }
            else if ((progressBar1.Value > half) && (progressBar1.Value != progressBar1.Maximum))
            {
                int current = (progressBar1.Value - half) / e.ProgressPercentage + 1;
                label1.Text = "Проверка устойчивости ";
                if (GenerationIteration > 1)
                    label1.Text += "[#" + GenerationIteration + "] ";
                label1.Text += "(" + current + "/" + Database.G.CoalitionsCount + ")";
            }
        }

        void GenerationFinished(object sender, RunWorkerCompletedEventArgs e)
        {
            int i = 0, j = 1;
            while (D[i, j].Value.ToString() == D[j, i].Value.ToString())
            {
                j++;
                if (j == Database.G.N)
                {
                    j = 0;
                    if (i == Database.G.N - 1)
                        break;
                    else
                        i++;
                }
            }
            label1.Font = new System.Drawing.Font(label1.Font.Name, 10);
            label1.Text = "Матрица читается построчно. Например:\nРассмотрим игру Игрока " +
                (i + 1) + " против Игрока " + (j + 1) + ".\n             Выигрыш Игрока " + (i + 1) + " = " + D[j, i].Value +
                "\n             Выигрыш Игрока " + (j + 1) + " = " + D[i, j].Value;
            progressBar1.Hide();
            GenerateTestPanel();
        }



        void GenerateTestPanel()
        {
            int H = label3.Bottom + 10,
                S = 0;
            Font F = new Font(label1.Font.Name, label1.Font.Size + 3);

            for (int i = 0; i < Database.G.N; i++)
                for (int j = 0; j < Database.G.N; j++)
                    if (i != j)
                        S = Math.Max(S, TextRenderer.MeasureText(D[j, i].Value.ToString(), D.Font).Width);

            UI.ControlsAligner testpanel = new UI.ControlsAligner(TestPanel);
            testpanel.AddElement(label3);

            for (int i = 0; i < Database.G.N + 1; i++)
            {
                Label l = new Label();
                if (i == Database.G.N)
                    l.Text = "v(N) = ";
                else
                    l.Text = "v(" + (i + 1) + ") = ";
                l.Font = F;
                l.ForeColor = label1.ForeColor;
                l.Size = TextRenderer.MeasureText(l.Text, l.Font);
                

                TextBox t = new TextBox();
                t.Font = new System.Drawing.Font(F.Name, F.Size + 2);
                t.Width = S + 40;
                t.TextAlign = HorizontalAlignment.Center;
                if ((i == 0)||(i == Database.G.N))
                    testpanel.AddElement(l);
                else
                    testpanel.AddElement(l,false);
                testpanel.AddElement(t,false,"HorBind");
                TestPanel.Controls.Add(l);
                TB.Add(t);
                TestPanel.Controls.Add(t);
            }

            testpanel.AddElement(SkipBTN, true, "Left");
            testpanel.AddElement(FinishBTN, false, "Right");
            testpanel.VerticalInterval *= 2;
            testpanel.Align();
            TestPanel.Show();

            form.AddElement(TestPanel);
            form.VerticalInterval = 0;
            form.Align();
            label1.Top = 0;
            label1.Left = (GenerationPanel.Width - label1.Width) / 2;
        }

        void ViewGameInNewWindow(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex, j = e.ColumnIndex;
            if (i != j)
            {
                if (i > j)
                {
                    i = e.ColumnIndex;
                    j = e.RowIndex;
                }

                SingleGame G = Database.G.FindGame(sender, i, j);
                ViewSingleGameForm F = new ViewSingleGameForm(G);
                F.StartPosition = FormStartPosition.Manual;
                MultiFormProcessor.FormOpened();
                F.Location = new Point(10, 10);
                F.Show();
                CGStudentProgress.FormsOpened.Add(F);
            }
        }

        public bool CheckIncooperativeGame(List<TextBox> T)
        {
            for (int i = 0; i < T.Count; i++)
            {
                double value = CGStudentProgress.ReadValue(T[i].Text);
                if (value == -1)
                    return false;

                double ActualValue;
                if (i < T.Count - 1)
                    ActualValue = Database.G.payoffs[i];
                else
                    ActualValue = Database.G.outcome;

                if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
                {
                    CGStudentProgress.GenerateError("Ошибка при подсчете выражения для " + (i + 1) + " игрока.");
                    return false;
                }
            }

            return true;
        }

        private void FinishBTN_Click(object sender, EventArgs e)
        {
            if (CheckIncooperativeGame(TB))
            {
                SkipBTN_Click(this, new EventArgs());
            }
        }



        void CellSelected(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                if ((e.ColumnIndex > -1) && (e.RowIndex > -1))
                    D.Rows[e.ColumnIndex].Cells[e.RowIndex].Selected = true;
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    ToolStrip T = new ToolStrip();
            //    T.Items.Add("Просмотр биматричной игры");
            //    T.

            //}
        }

        private void SkipBTN_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TB.Count - 1; i++)
                TB[i].Text = Database.G.payoffs[i].ToString("0.00");
            TB.Last().Text = Database.G.outcome.ToString("0.00");

            CGStudentProgress.NewSection();
            FinishBTN.Hide();
            SkipBTN.Hide();
            label3.Hide();

            int diff = TB[0].Top - 15;
            for (int i = 0; i < TestPanel.Controls.Count; i++)
                TestPanel.Controls[i].Top -= diff;
            TestPanel.Height -= diff;
            this.Height -= diff;
            for (int i = 0; i < TB.Count; i++)
                TB[i].Enabled = false;

            this.Location = new Point(20, 20);

            CoalitionChooseForm F = new CoalitionChooseForm();
            F.StartPosition = FormStartPosition.CenterScreen;
            MultiFormProcessor.FormOpened();
            F.Show();
            this.ControlBox = false;
        }

    }
}
