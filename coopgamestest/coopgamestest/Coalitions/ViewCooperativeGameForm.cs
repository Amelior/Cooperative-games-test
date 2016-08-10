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
    public partial class ViewCooperativeGameForm : Form
    {
        CoalitionChooseForm parent;
        BimatrixGame G;

        UI.StrategiesGrid Ga, Gb;
        List<List<int>> CoalitionStrategiesCombination = new List<List<int>>();
        List<bool> Matches = new List<bool>();
        List<TextBox> PayoffDistributionTB = new List<TextBox>();
        string Coalition;

        public ViewCooperativeGameForm(CoalitionChooseForm parent, string Coalition)
        {
            InitializeComponent();
            G = Database.G.FindGame(Coalition);
            this.parent = parent;
            this.Coalition = Coalition;
            if (CGStudentProgress.CurrentSection == 6)
            {
                CreateArrays(0, 1);
                UI.ControlsAligner mpanel = new UI.ControlsAligner(MatrixesPanel);
                mpanel.AddElement(A);
                mpanel.AddElement(B,false);
                mpanel.Align();

                RP_v1.Text += G.SingleGames[0].FirstPlayer + " = " + G.SingleGames[0].Ha.ToString("0.00");
                RP_v2.Text += G.SingleGames[0].SecondPlayer + " = " + G.SingleGames[0].Hb.ToString("0.00"); ;
                RP_PriceLabel.Text += (G.SingleGames[0].Ha + G.SingleGames[0].Hb).ToString("0.00");
                for (int i = 0; i < G.SingleGames[0].x.Count; i++)
                    RP_x.Text += G.SingleGames[0].x[i].ToString("0.00") + " ";
                RP_x.Text += ")";

                for (int i = 0; i < G.SingleGames[0].y.Count; i++)
                    RP_y.Text += G.SingleGames[0].y[i].ToString("0.00") + " ";
                RP_y.Text += ")";


                UI.ControlsAligner rpanel = new UI.ControlsAligner(GameResultPanel);
                rpanel.AddElement(RP_PriceLabel);
                rpanel.AddElement(RP_v1);
                rpanel.AddElement(RP_v2, false);
                rpanel.AddElement(RP_x);
                rpanel.AddElement(RP_y);
                rpanel.Align();
                SkipBTN.Text = "Несущественная";
                SkipBTN.Width = 200;
                FinishBTN.Text = "Существенная";
                FinishBTN.Width = SkipBTN.Width;
                GameResultPanel.Show();

                UI.ControlsAligner form = new UI.ControlsAligner(this);
                Task1Panel.Hide();
                form.AddElement(NavigationPanel);
                form.AddElement(MatrixesPanel);
                form.AddElement(GameResultPanel);
                form.AddElement(SkipBTN, true, "Left");
                form.AddElement(FinishBTN, false, "Right");
                form.Align();
                CreateNavigationPanel();
            }
            else
            {
                this.ControlBox = false;
                SecondInterfaceSetup_Domination();
                CGStudentProgress.NewSection();
                A.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(ColumnHeadersMouseClick);
                A.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(RowHeaderMouseClick);
                B.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(ColumnHeadersMouseClick);
                B.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(RowHeaderMouseClick);
            }
        }
        //Test
        //public ViewCooperativeGameForm()
        //{
        //    InitializeComponent();
        //    Database.G = new CooperativeGame();
        //    Database.G.Generate(3);
        //    Database.G.GenerateCoalitions();
        //    Database.G.SolveCooperativeGame();
        //    G = Database.G.FindGame(Database.G.CoalitionsInText[0][0]);
        //    CGStudentProgress.SectionsCount = 2;

        //    FirstInterfaceSetup_CooperativeGameModelFormation();
        //    //SecondInterfaceSetup_Domination();
        //}

        private void FirstInterfaceSetup_CooperativeGameModelFormation()
        {
            StrategiesPanel.Show();
            B.Hide();

            UI.TWDNGrid Gs = new UI.TWDNGrid(S, 1, Database.G.N);
            Gs.InitializeHeaders("", "Количество стратегий", "Игрок", false, true);
            Gs.InitializeGrid(Database.G.S);

            UI.Grid Ga = new UI.Grid(A, Math.Min(10,G.SingleGames[0].A.Count), Math.Min(10,G.SingleGames[0].A[0].Count));
            A.Tag = Ga;
            Ga.InitializeHeaders("Стратегии", 100, 50);
            Ga.InitializeGrid();
            A.EditMode = DataGridViewEditMode.EditProgrammatically;
            A.ReadOnly = true;
            A.StandardTab = true;

            UI.ControlsAligner form = new UI.ControlsAligner(this);
            form.AddElement(NavigationPanel,true,"Stretch");
            form.AddElement(Task1Panel);
            form.AddElement(StrategiesPanel);
            form.AddElement(MatrixesPanel);
            form.AddElement(SkipBTN, true, "Left");
            form.AddElement(FinishBTN, false, "Right");

            UI.ControlsAligner spanel = new UI.ControlsAligner(StrategiesPanel);
            spanel.AddElement(S);
            spanel.Align(true);

            UI.ControlsAligner mpanel = new UI.ControlsAligner(MatrixesPanel);
            mpanel.AddElement(A);
            mpanel.Align(true);

            form.Align();
            CreateNavigationPanel();
            this.Text = "Заполните вектора стратегий";
        }
        
        private bool CheckStudentsStrategies()
        {
            List<List<int>> Coalitions = new List<List<int>>();
            Coalitions.Add(new List<int>());
            for (int i = 0; i < Coalition.Length; i++)
            {
                if ((Coalition[i] >= '0') && (Coalition[i] <= '9'))
                    Coalitions.Last().Add(Convert.ToInt32(Coalition[i] - '1'));
                if (Coalition[i] == '-')
                    Coalitions.Add(new List<int>());
            }
            char[] Symbols = { 'x', 'y', 'z', 'v', 'w' };
            List<List<char>> Letters = new List<List<char>>();
            Letters.Add(new List<char>());
            Letters.Add(new List<char>());
            int s1 = 1, s2 = 1;
            for (int i = 0; i < Coalitions[0].Count; i++)
            {
                s1 *= Database.G.S[Coalitions[0][i]];
                Letters[0].Add(Symbols[Coalitions[0][i]]);
            }
            for (int i = 0; i < Coalitions[1].Count; i++)
            {
                s2 *= Database.G.S[Coalitions[1][i]];
                Letters[1].Add(Symbols[Coalitions[1][i]]);
            }

            List<int> Index = new List<int>();
            for (int i = 0; i < Coalitions[0].Count; i++)
                Index.Add(0);
            for (int i = 0; i < s1; i++)
            {
                CoalitionStrategiesCombination.Add(new List<int>());
                Matches.Add(false);
                for (int j = 0; j < Coalitions[0].Count; j++)
                    CoalitionStrategiesCombination[i].Add(Index[j]);
                IncrementIndexes(Index, Coalitions[0]);
            }

            for (int i = 0; i < A.Rows.Count; i++)
            {
                string s = "";
                try
                {
                    s = A.Rows[i].HeaderCell.Value.ToString();
                }
                catch (NullReferenceException)
                {
                    System.Windows.Forms.MessageBox.Show
                        ("Ячейка [" + (i + 1) + "] в первой коалиции пустая",
                        "Неправильный ввод");
                    return false;
                }
                if (s == "")
                {
                    System.Windows.Forms.MessageBox.Show
                        ("Ячейка [" + (i + 1) + "] в первой коалиции пустая",
                        "Неправильный ввод");
                    return false;
                }
                if (!AnalyzeCell(s, Letters[0], Coalitions[0].Count))
                    return false;
            }

            Index = new List<int>();
            for (int i = 0; i < Coalitions[1].Count; i++)
                Index.Add(0);
            CoalitionStrategiesCombination.Clear();
            Matches.Clear();
            for (int i = 0; i < s2; i++)
            {
                CoalitionStrategiesCombination.Add(new List<int>());
                Matches.Add(false);
                for (int j = 0; j < Coalitions[1].Count; j++)
                    CoalitionStrategiesCombination[i].Add(Index[j]);
                IncrementIndexes(Index, Coalitions[1]);
            }

            for (int i = 0; i < A.Columns.Count; i++)
            {
                string s = "";
                try
                {
                    s = A.Columns[i].HeaderCell.Value.ToString();
                }
                catch (NullReferenceException)
                {
                    System.Windows.Forms.MessageBox.Show
                        ("Ячейка [" + (i + 1) + "] в первой коалиции пустая",
                        "Неправильный ввод");
                    return false;
                }
                if (s == "")
                {
                    System.Windows.Forms.MessageBox.Show
                        ("Ячейка [" + (i + 1) + "] в первой коалиции пустая",
                        "Неправильный ввод");
                    return false;
                }

                if (!AnalyzeCell(s, Letters[1], Coalitions[1].Count))
                    return false;
            }
            return true;
        }

        private bool AnalyzeCell(string s, List<char> Letters, int CoalitionSize)
        {
            List<int> Combination = new List<int>();
            for (int j = 0; j < CoalitionSize; j++)
                Combination.Add(-1);
            int player = -1;
            for (int i = 0; i < Letters.Count; i++)
                if (s[0] == Letters[i])
                    player = i;
            if (player == -1)
            {
                System.Windows.Forms.MessageBox.Show
                    ("Первым символом ячейки должна быть буква, соответствующая игроку",
                    "Неправильный ввод");
                return false;
            }

            string number = "";
            for (int i = 1; i < s.Length; i++)
            {
                if ((s[i] >= '0') && (s[i] <= '9'))
                    number += s[i];
                else
                {
                    if (number == "")
                    {
                        System.Windows.Forms.MessageBox.Show
                            ("Некорректно составленная стратегия",
                            "Неправильный ввод");
                        return false;
                    }
                    Combination[player] = Convert.ToInt32(number);
                    number = "";
                    player = -1;
                    for (int j = 0; j < Letters.Count; i++)
                        if (s[i] == Letters[j])
                            player = j;
                    if (player == -1)
                    {
                        System.Windows.Forms.MessageBox.Show
                            ("Некорректно составленная стратегия",
                            "Неправильный ввод");
                        return false;
                    }
                }
            }

            for (int i = 0; i < CoalitionStrategiesCombination.Count; i++)
            {
                if (CoalitionStrategiesCombination[i] == Combination)
                {
                    if (Matches[i] == false)
                        Matches[i] = true;
                    else
                    {
                        CGStudentProgress.GenerateError("Повторное заполнение одинаковой коалиции.");
                        return false;
                    }
                    break;
                }
            }
            return true;
        }



        private void SecondInterfaceSetup_Domination()
        {
            Task1Panel.Hide();
            Task2Panel.Show();
            NavigationPanel.Hide();
            StrategiesPanel.Hide();
            B.Show();
            CreateArrays(0, 1);

            UI.ControlsAligner gpanel = new UI.ControlsAligner(MatrixesPanel);
            gpanel.AddElement(A);
            gpanel.AddElement(B, false);
            gpanel.Align();

            UI.ControlsAligner form = new UI.ControlsAligner(this);
            form.AddElement(Task2Panel);
            form.AddElement(MatrixesPanel);
            form.AddElement(SkipBTN, true, "Left");
            form.AddElement(FinishBTN, false, "Right");            
            form.Align();

            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, 50);
            this.Text = "Сократите матрицы используя отношение доминирования";
        }

        private void CreateNavigationPanel()
        {
            UI.ControlsAligner npanel = new UI.ControlsAligner(NavigationPanel);
            for (int i = 0; i < G.SingleGames.Count; i++)
            {
                CreateNavigationButton(i);
                if (i == 0)
                    npanel.AddElement(NavigationPanel.Controls[NavigationPanel.Controls.Count - 1], true, "Stretch");
                else
                    npanel.AddElement(NavigationPanel.Controls[NavigationPanel.Controls.Count - 1], false, "Stretch");
            }
            npanel.WidthFixed = true;
            npanel.Align(true);
        }

        private void CreateArrays(int pl1, int pl2)
        {
            SingleGame SG = G.FindGame(this, pl1, pl2);
            Ga = new UI.StrategiesGrid(A, SG.A.Count, SG.A[0].Count);
            Ga.LimitedSize = true;
            Ga.InitializeHeaders("", SG.FirstPlayer, SG.SecondPlayer, Database.G.S);
            Ga.InitializeGrid(SG.A);

            Gb = new UI.StrategiesGrid(B, SG.A.Count, SG.A[0].Count);
            Gb.LimitedSize = true;
            Gb.InitializeHeaders("", SG.FirstPlayer, SG.SecondPlayer, Database.G.S);
            Gb.InitializeGrid(SG.B);

        }

        void Dominate(object sender, EventArgs e, object r)
        {
            if (r is DataGridViewRow)
            {
                int ind = (r as DataGridViewRow).Index;
                A.Rows.RemoveAt(ind);
                B.Rows.RemoveAt(ind);
                int h = A.ColumnHeadersHeight + 3;
                for (int i = 0; i < A.Rows.Count; i++)
                    h += A.Rows[i].Height;
                if (h < 500)
                {
                    if (A.Height == 500)
                    {
                        A.Width -= 17;
                        B.Width -= 17;
                    }
                    A.Height = h;
                    B.Height = h;
                }
            }
            if (r is DataGridViewColumn)
            {
                int ind = (r as DataGridViewColumn).Index;
                A.Columns.RemoveAt(ind);
                B.Columns.RemoveAt(ind);

                int w = A.RowHeadersWidth + 3;
                if (A.Height == Ga.MaximumSize.Height)
                    w += 17;
                for (int i = 0; i < A.Columns.Count; i++)
                    w += A.Columns[i].Width;
                A.Width = w;
                B.Width = w;
            }

        }

        private bool CheckStudentDomination(SingleGame Answer)
        {
            if (Answer.A.Count == A.Rows.Count)
                if (Answer.A[0].Count == A.Columns.Count)
                {
                    for (int i = 0; i < Answer.A.Count; i++)
                        for (int j = 0; j < Answer.A[0].Count; j++)
                        {
                            if ((Answer.A[i][j] != Convert.ToDouble(A[j, i].Value))
                                || (Answer.B[i][j] != Convert.ToDouble(B[j, i].Value)))
                                return false;
                        }
                }
                else
                    return false;
            else
                return false;
            return true;
        }

        

        private void ThirdInterfaceSetup_GraphicalSolution(bool skipped)
        {
            Task2Panel.Hide();

            if (skipped)
            {
                List<int> Drows = new List<int>();
                List<int> Dcolumns = new List<int>();
                List<string> Cheaders = new List<string>();
                List<string> Rheaders = new List<string>();
                SingleGame D = G.SingleGames[0].Dominate(Drows, Dcolumns);

                for (int i = 0; i < Drows.Count; i++)
                    Rheaders.Add(A.Rows[Drows[i]].HeaderCell.Value.ToString());
                for (int i = 0; i < Dcolumns.Count; i++)
                    Cheaders.Add(A.Columns[Dcolumns[i]].HeaderCell.Value.ToString());
                Ga = new UI.StrategiesGrid(A, D.A.Count, D.A[0].Count);
                Gb = new UI.StrategiesGrid(B, D.A.Count, D.A[0].Count);
                Ga.LimitedSize = true;
                Gb.LimitedSize = true;
                Ga.InitializeHeaders("", G.SingleGames[0].FirstPlayer, G.SingleGames[0].SecondPlayer, Database.G.S);
                Gb.InitializeHeaders("", G.SingleGames[0].FirstPlayer, G.SingleGames[0].SecondPlayer, Database.G.S);
                Ga.InitializeGrid(D.A);
                Gb.InitializeGrid(D.B);
                for (int i = 0; i < A.Rows.Count; i++)
                {
                    A.Rows[i].HeaderCell.Value = Rheaders[i];
                    B.Rows[i].HeaderCell.Value = Rheaders[i];
                }
                for (int j = 0; j < A.ColumnCount; j++)
                {
                    A.Columns[j].HeaderCell.Value = Cheaders[j];
                    B.Columns[j].HeaderCell.Value = Cheaders[j];
                }
            }

            if ((A.Rows.Count == 2) && (A.Columns.Count == 2))
            {
                Graphical2x2SolutionPanel.Show();

                UI.ControlsAligner gpanel = new UI.ControlsAligner(MatrixesPanel);
                gpanel.AddElement(A);
                gpanel.AddElement(B, false);
                gpanel.Align();

                UI.ControlsAligner form = new UI.ControlsAligner(this);
                form.AddElement(MatrixesPanel);
                form.AddElement(Graphical2x2SolutionPanel);
                form.AddElement(SkipBTN, true, "Left");
                form.AddElement(FinishBTN, false, "Right");
                form.Align();
            }
            else
            {
                CGStudentProgress.NewSection();
                FourthInterfaceSetup_PayoffDistributionAndSufficiency();
            }

        }

        private void FourthInterfaceSetup_PayoffDistributionAndSufficiency()
        {
            Random R = new Random((int)DateTime.Now.Ticks);
            //CGStudentProgress.DistributionType = R.Next(0, 2); //0 = contribution in a coalition price; 1 = incooperative payoff
            CGStudentProgress.DistributionType = 1;
            if (CGStudentProgress.DistributionType == 0)
                PayoffDivisionLabel.Text += " с учетом индивидуальных вкладов\nигроков в выигрыш коалиции.";
            else
                PayoffDivisionLabel.Text += " с учетом индивидуальных выигрышей\nигроков в некооперативной игре.";

            PayoffDivisionLabel.TextAlign = ContentAlignment.MiddleCenter;

            CoalitionAPayoffLabel.Text += G.SingleGames[0].FirstPlayer + " = " + G.SingleGames[0].Ha.ToString("0.00");
            CoalitionBPayoffLabel.Text += G.SingleGames[0].SecondPlayer + " = " + G.SingleGames[0].Hb.ToString("0.00"); ;
            GameFunctionLabel.Text += (G.SingleGames[0].Ha + G.SingleGames[0].Hb).ToString("0.00");
            for (int i = 0; i < G.SingleGames[0].x.Count; i++)
                x.Text += G.SingleGames[0].x[i].ToString("0.00") + " ";
            x.Text += ")";

            for (int i = 0; i < G.SingleGames[0].y.Count; i++)
                y.Text += G.SingleGames[0].y[i].ToString("0.00") + " ";
            y.Text += ")";

            UI.ControlsAligner quizpanel = new UI.ControlsAligner(PayoffDivisionPanel);
            quizpanel.AddElement(GameFunctionLabel);
            quizpanel.AddElement(CoalitionAPayoffLabel);
            quizpanel.AddElement(CoalitionBPayoffLabel, false);
            quizpanel.AddElement(x);
            quizpanel.AddElement(y);
            quizpanel.AddElement(SufficiencyLabel);
            quizpanel.AddElement(YesRB_CG);
            quizpanel.AddElement(NoRB_CG, false);

            quizpanel.AddElement(FirstLine);

            quizpanel.AddElement(PayoffDivisionLabel);
            for (int i = 0; i < Database.G.N; i++)
            {
                Label l = new Label();
                l.Text = "µ(" + (i + 1) + ") = ";
                l.Font = new System.Drawing.Font("Bookman Old Style", 14);
                l.ForeColor = Color.White;
                l.Size = TextRenderer.MeasureText(l.Text, l.Font);

                TextBox tb = new TextBox();
                tb.Font = new System.Drawing.Font("Bookman Old Style", 16);
                tb.TextAlign = HorizontalAlignment.Center;
                tb.Width = 100;
                tb.Text = "";

                if (i == 0)
                    quizpanel.AddElement(l, true);
                else
                    quizpanel.AddElement(l, false);
                quizpanel.AddElement(tb, false, "HorBind");

                PayoffDivisionPanel.Controls.Add(l);
                PayoffDivisionPanel.Controls.Add(tb);
                PayoffDistributionTB.Add(tb);
            }

            quizpanel.AddElement(SecondLine);

            quizpanel.AddElement(DistributionRationalityLabel);
            quizpanel.AddElement(RationalityPanel, true, "Stretch");
            quizpanel.Align();
            RationalityPanel.Top -= 10;

            Graphical2x2SolutionPanel.Hide();
            PayoffDivisionPanel.Show();
            MatrixesPanel.Hide();

            UI.ControlsAligner form = new UI.ControlsAligner(this);
            form.AddElement(PayoffDivisionPanel);
            form.AddElement(SkipBTN, true, "Left");
            form.AddElement(FinishBTN, false, "Right");
            form.Align();

            UI.ControlsAligner rpanel = new UI.ControlsAligner(RationalityPanel);
            rpanel.AddElement(YesRB_RD);
            rpanel.AddElement(NoRB_RD, false);
            rpanel.Align(true);
        }

        private bool CheckStudentGameSolution()
        {
            double value = CGStudentProgress.ReadValue(textBox1.Text),
                ActualValue = Convert.ToDouble(A[1, 1].Value) -
                Convert.ToDouble(A[2, 1].Value) - Convert.ToDouble(A[1, 2].Value) +
                Convert.ToDouble(A[2, 2].Value);
            if (value == -1)
                return false;
            if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
            {
                CGStudentProgress.GenerateError("Ошибка в формуле выигрыша первого игрока");
                return false;
            }

            value = CGStudentProgress.ReadValue(textBox2.Text);
            ActualValue = Convert.ToDouble(A[2, 1].Value) -
                Convert.ToDouble(A[2, 2].Value);
            if (value == -1)
                return false;
            if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
            {
                CGStudentProgress.GenerateError("Ошибка в формуле выигрыша первого игрока");
                return false;
            }

            value = CGStudentProgress.ReadValue(textBox3.Text);
            ActualValue = Convert.ToDouble(A[1, 2].Value) -
                Convert.ToDouble(A[2, 2].Value);
            if (value == -1)
                return false;
            if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
            {
                CGStudentProgress.GenerateError("Ошибка в формуле выигрыша первого игрока");
                return false;
            }

            value = CGStudentProgress.ReadValue(textBox4.Text);
            ActualValue = Convert.ToDouble(A[2, 2].Value);
            if (value == -1)
                return false;
            if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
            {
                CGStudentProgress.GenerateError("Ошибка в формуле выигрыша первого игрока");
                return false;
            }

            value = CGStudentProgress.ReadValue(textBox5.Text);
            ActualValue = Convert.ToDouble(B[1, 1].Value) -
                Convert.ToDouble(B[2, 1].Value) - Convert.ToDouble(B[1, 2].Value) +
                Convert.ToDouble(B[2, 2].Value);
            if (value == -1)
                return false;
            if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
            {
                CGStudentProgress.GenerateError("Ошибка в формуле выигрыша первого игрока");
                return false;
            }

            value = CGStudentProgress.ReadValue(textBox6.Text);
            ActualValue = Convert.ToDouble(B[2, 1].Value) -
                Convert.ToDouble(B[2, 2].Value);
            if (value == -1)
                return false;
            if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
            {
                CGStudentProgress.GenerateError("Ошибка в формуле выигрыша первого игрока");
                return false;
            }

            value = CGStudentProgress.ReadValue(textBox7.Text);
            ActualValue = Convert.ToDouble(B[1, 2].Value) -
                Convert.ToDouble(B[2, 2].Value);
            if (value == -1)
                return false;
            if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
            {
                CGStudentProgress.GenerateError("Ошибка в формуле выигрыша первого игрока");
                return false;
            }

            value = CGStudentProgress.ReadValue(textBox8.Text);
            ActualValue = Convert.ToDouble(B[2, 2].Value);
            if (value == -1)
                return false;
            if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
            {
                CGStudentProgress.GenerateError("Ошибка в формуле выигрыша первого игрока");
                return false;
            }

            return true;
        }

        public bool CheckDivisionAndSufficiency(string Coalition, bool Sufficient, bool DivisionRational)
        {
            List<List<int>> C = new List<List<int>>();
            for (int i = 0; i < Coalition.Length; i++)
            {
                if (Coalition[i] == '{')
                    C.Add(new List<int>());
                if ((Coalition[i] >= '0') && (Coalition[i] <= '9'))
                    C.Last().Add(Convert.ToInt32(Coalition[i] - '0'));
            }
            BimatrixGame G = Database.G.FindGame(Coalition);
            if (((Database.G.outcome > G.SingleGames[0].Ha + G.SingleGames[0].Hb) && (Sufficient)) ||
                ((Database.G.outcome < G.SingleGames[0].Ha + G.SingleGames[0].Hb) && (!Sufficient)))
            {
                CGStudentProgress.GenerateError("Ошибка при определении существенности");
                return false;
            }

            bool Rational = true;
            for (int i = 0; i < PayoffDistributionTB.Count; i++)
            {
                double value = CGStudentProgress.ReadValue(PayoffDistributionTB[i].Text);
                if (value == -1)
                    return false;

                double ActualValue;
                if (CGStudentProgress.DistributionType == 1)
                {
                    double IncooperativePrize = Database.G.payoffs[i],
                        CoalitionPrize = 0,
                        CoalitionPlayersPayoffs = 0;
                    int CoalitionIndex = -1;
                    for (int p = 0; p < C.Count; p++)
                        for (int q = 0; q < C[p].Count; q++)
                            if (C[p][q] - 1 == i)
                                CoalitionIndex = p;
                    CoalitionPrize = G.payoffs[CoalitionIndex];
                    for (int j = 0; j < C[CoalitionIndex].Count; j++)
                        CoalitionPlayersPayoffs += Database.G.payoffs[C[CoalitionIndex][j] - 1];
                    ActualValue = IncooperativePrize * CoalitionPrize / CoalitionPlayersPayoffs;
                }
                else
                    throw new NotImplementedException();

                if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
                {
                    CGStudentProgress.GenerateError("Ошибка при подсчете выражения для " + (i + 1) + " игрока.");
                    return false;
                }
                if (ActualValue < Database.G.payoffs[i])

                    Rational = false;
            }

            if (((DivisionRational) && (!Rational)) || ((!DivisionRational) && (Rational)))
            {
                CGStudentProgress.GenerateError("Ошибка при определении рациональности дележа");
                return false;
            }

            return true;
        }

        private void FinishBTN_Click(object sender, EventArgs e)
        {
            switch (CGStudentProgress.CurrentSection)
            {
                case 2:
                    if (CheckStudentsStrategies())
                        SkipBTN_Click(this, new EventArgs());
                    break;
                case 3:
                    {
                        SingleGame D = G.SingleGames[0].Dominate();
                        if (CheckStudentDomination(D))
                            SkipBTN_Click(this, new EventArgs());
                        else
                            CGStudentProgress.GenerateError("Должны получиться матрицы размерностью " +
                                D.A.Count + "x" + D.A[0].Count);
                    }
                    break;
                case 4:
                    if (CheckStudentGameSolution())//graphical 2x2
                        SkipBTN_Click(this, new EventArgs());
                    break;
                case 5:
                    if (CheckDivisionAndSufficiency(Coalition, YesRB_CG.Checked, YesRB_RD.Checked))
                        SkipBTN_Click(this, new EventArgs());
                    break;
                case 6:
                    {
                        parent.UpdateFirstGameState(Coalition, true);
                        this.Close();
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void SkipBTN_Click(object sender, EventArgs e)
        {
            switch (CGStudentProgress.CurrentSection)
            {
                case 2:
                    {
                        CGStudentProgress.NewSection();
                        SecondInterfaceSetup_Domination();
                    }
                    break;
                case 3:
                    {
                        CGStudentProgress.NewSection(); //4
                        if (sender is Button)
                            ThirdInterfaceSetup_GraphicalSolution(true);
                        else
                            ThirdInterfaceSetup_GraphicalSolution(false);                  
                            
                    }
                    break;
                case 4:
                    {
                            CGStudentProgress.NewSection(); //5
                            FourthInterfaceSetup_PayoffDistributionAndSufficiency();
                    }
                    break;
                case 5:
                    {
                            parent.UpdateFirstGameState(Coalition, YesRB_CG.Checked);
                            CGStudentProgress.NewSection(); //6
                            this.Close();
                    }
                    break;
                case 6:
                    {
                        parent.UpdateFirstGameState(Coalition, false);
                        this.Close();
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }



        //General

        void ShowAnotherGame(object sender, EventArgs e)
        {
            if (NavigationPanel.Controls.Count > 1)
                throw new NotImplementedException();
        }

        private void IncrementIndexes(List<int> index, List<int> players)
        {
            bool incremented = false;
            int ind = index.Count - 1;
            while (!incremented)
            {
                index[ind]++;
                if ((index[ind] == Database.G.S[players[ind]]) && (ind > 0))

                    index[ind--] = 0;
                else
                    incremented = true;
            }
        }

        private void CreateNavigationButton(int c)
        {
            Button b = new Button();
            b.Font = new System.Drawing.Font("Bookman Old Style", 14);
            b.BackColor = NavigationPanel.BackColor;
            b.ForeColor = Color.White;
            b.Text = "Коалиция "+ G.SingleGames[c].FirstPlayer + " <-> " + "Коалиция " + G.SingleGames[c].SecondPlayer;
            b.Height = NavigationPanel.Height;
            b.FlatStyle = FlatStyle.Popup;

            //Position
            if (c == 0)
                b.Left = 0;
            else
                b.Left = NavigationPanel.Controls[NavigationPanel.Controls.Count - 1].Right;
            b.Top = 0;

            //Clicking
            b.Click += new EventHandler(ShowAnotherGame);
            NavigationPanel.Controls.Add(b);
        }

        void RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Left) && (CGStudentProgress.CurrentSection == 2))
                ((sender as DataGridView).Tag as UI.Grid).
                    BeginEdit((sender as DataGridView).Rows[e.RowIndex].HeaderCell);
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (CGStudentProgress.CurrentSection == 3))
            {
                ContextMenuStrip CMS = new System.Windows.Forms.ContextMenuStrip();
                ToolStripMenuItem t1 = new ToolStripMenuItem("Удалить");
                t1.Click += (new_sender, new_e) => Dominate(sender, e, (sender as DataGridView).Rows[e.RowIndex]);
                CMS.Items.Add(t1);
                CMS.Show(MousePosition);
            }
        }

        void ColumnHeadersMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == System.Windows.Forms.MouseButtons.Left) && (CGStudentProgress.CurrentSection == 2))
                ((sender as DataGridView).Tag as UI.Grid).
                    BeginEdit((sender as DataGridView).Columns[e.ColumnIndex].HeaderCell);
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (CGStudentProgress.CurrentSection == 3))
            {
                ContextMenuStrip CMS = new System.Windows.Forms.ContextMenuStrip();
                ToolStripMenuItem t1 = new ToolStripMenuItem("Удалить");
                t1.Click += (new_sender, new_e) => Dominate(sender, e, (sender as DataGridView).Columns[e.ColumnIndex]);
                CMS.Items.Add(t1);
                CMS.Show(MousePosition);
            }
        }
    }
}
