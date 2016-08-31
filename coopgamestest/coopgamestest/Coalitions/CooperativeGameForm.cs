using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using UI;

namespace General.Coalitions
{
    public partial class CooperativeGameForm : General.MasterPages.simpleMasterPage
    {
        TestForm parent;
        BimatrixGame G;

        UI.StrategiesGrid Ga, Gb;
        List<List<int>> CoalitionStrategiesCombination = new List<List<int>>();
        List<bool> Matches = new List<bool>();
        List<NumericTextBox> PayoffDistributionTB = new List<NumericTextBox>();
        string Coalition;

        Size GridSizeforTaskOne = new Size(5, 5);

        public CooperativeGameForm(TestForm parent, string Coalition)
        {
            InitializeComponent();
            G = Database.G.FindGame(Coalition);
            this.parent = parent;
            this.Coalition = Coalition;
            UI_FirstSetup();
            CGStudentProgress.CurrentSection = 2;
        }


        #region First Setup - Strategies formation

        private void UI_FirstSetup()
        {
            #region Grids
            //Create grid that shows strategies number
            UI.TWDNGrid Gs = new UI.TWDNGrid(S, 1, Database.G.N);
            Gs.InitializeHeaders("", "Количество стратегий", "Игрок", false, true);
            Gs.InitializeGrid(Database.G.S);
            S.ReadOnly = true;

            //Create grid for strategies combination
            UI.Grid Ga = new UI.Grid(A, Math.Min(GridSizeforTaskOne.Height, G.SingleGames[0].A.Count),
                Math.Min(GridSizeforTaskOne.Width, G.SingleGames[0].A[0].Count));
            A.Tag = Ga;
            Ga.InitializeHeaders("Стратегии", 100, 50);
            Ga.InitializeGrid();
            A.EditMode = DataGridViewEditMode.EditProgrammatically;
            A.ReadOnly = true;
            A.StandardTab = true;
            #endregion

            outerblocks.Add(AddHeader(true));
            outerblocks.Add(AddMainContent());
            outerblocks.Add(AddNavigationBar());

            AlignForm();

            A.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(ColumnHeadersMouseClick);
            A.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(RowHeaderMouseClick);
            B.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(ColumnHeadersMouseClick);
            B.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(RowHeaderMouseClick);
        }

        protected override void AddTaskContent()
        {
            base.AddTaskContent();
            blocks.Last().AddElement(firstTaskPanel);
            blocks.Last().Left = 2;
            blocks.Last().Right = 2;
            blocks.Last().Bottom = 2;
        }

        protected override ControlsAligner AddMainContent()
        {
            blocks.Add(new ControlsAligner(strategiesPanel));
            blocks.Last().AddElement(strategiesLabel);
            blocks.Last().AddElement(S);
            blocks.Last().Left = 0;
            blocks.Last().Right = 0;
            blocks.Last().Bottom = 0;

            blocks.Add(new ControlsAligner(payoffsPanel));
            blocks.Last().AddElement(payoffsLabel);
            blocks.Last().AddElement(A);
            blocks.Last().Left = 0;
            blocks.Last().Right = 0;
            blocks.Last().Bottom = 0;

            base.AddMainContent();
            blocks.Last().AddElement(strategiesPanel);
            blocks.Last().AddElement(payoffsPanel);
            blocks.Last().VerticalInterval *= 2;
            return blocks.Last();

        }

        /// <summary>
        /// Analyze user input in order to check answer
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Analyze cell input according to the format
        /// </summary>
        /// <param name="s"></param>
        /// <param name="Letters"></param>
        /// <param name="CoalitionSize"></param>
        /// <returns></returns>
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
                        CGStudentProgress.GenerateError("Повторное заполнение одинаковой коалиции.", null);
                        return false;
                    }
                    break;
                }
            }
            return true;
        }

        #endregion

        #region Second Setup - Domination

        private void UI_SecondSetup()
        {
            firstTaskPanel.Hide();
            secondTaskPanel.Show();
            strategiesPanel.Hide();
            B.Show();
            CreateArrays(0, 1);

            #region Alignment
            foreach (ControlsAligner block in blocks)
            {
                //remove old task panel                
                if (block.container == taskContentPanel)
                {
                    block.RemoveElement(firstTaskPanel.Name);
                    block.AddElement(secondTaskPanel);
                    taskLabel.Text = "Сократите матрицы используя отношение доминирования";
                }

                //remove strategies panel
                if (block.container == contentPanel)
                {
                    block.RemoveElement(strategiesPanel.Name);
                    block.container.BackColor = headerPanel.BackColor;
                }

                if (block.container == payoffsPanel)
                {
                    block.Left = block.Right = block.Top = block.Bottom = 15;
                    block.HorizontalInterval = 80;
                    block.RemoveElement(A.Name);

                    A_label.Show();
                    block.AddElement(A_label);
                    block.AddElement(A, false, "HorBind");

                    B_label.Show();
                    block.AddElement(B_label,false);
                    block.AddElement(B, false, "HorBind");
                }
            }

            AlignForm();            
            #endregion
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

        #endregion

        #region Third Setup - Analyze
        private void UI_ThirdSetup()
        {
            CreateQuizPanel();
            //RationalityPanel.Top -= 10;

            //PayoffDivisionPanel.Show();
            //payoffsPanel.Hide();

            //UI.ControlsAligner form = new UI.ControlsAligner(this);
            //form.AddElement(PayoffDivisionPanel);
            //form.AddElement(SkipButton, true, "Left");
            //form.AddElement(FinishButton, false, "Right");
            //form.Align();

            //UI.ControlsAligner rpanel = new UI.ControlsAligner(RationalityPanel);
            //rpanel.AddElement(YesRB_RD);
            //rpanel.AddElement(NoRB_RD, false);
            //rpanel.Align(true);
        }

        private void CreateQuizPanel()
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

            blocks.Add(new ControlsAligner(PayoffDivisionPanel));
            for (int i = 0; i < Database.G.N; i++)
            {
                Label l = new Label();
                l.Text = "µ(" + (i + 1) + ") = ";
                l.Font = new System.Drawing.Font("Bookman Old Style", 14);
                l.ForeColor = Color.White;
                l.Size = TextRenderer.MeasureText(l.Text, l.Font);

                NumericTextBox tb = new NumericTextBox();
                tb.Font = new System.Drawing.Font("Bookman Old Style", 16);
                tb.NumericTB.TextAlign = HorizontalAlignment.Center;
                tb.Width = 100;
                tb.Text = "";

                if (i == 0)
                    blocks.Last().AddElement(l, true);
                else
                    blocks.Last().AddElement(l, false);
                blocks.Last().AddElement(tb, false, "HorBind");

                PayoffDivisionPanel.Controls.Add(l);
                PayoffDivisionPanel.Controls.Add(tb);
                PayoffDistributionTB.Add(tb);
            }

            blocks.Last().AddElement(GameFunctionLabel);
            blocks.Last().AddElement(CoalitionAPayoffLabel);
            blocks.Last().AddElement(CoalitionBPayoffLabel, false);
            blocks.Last().AddElement(x);
            blocks.Last().AddElement(y);
            blocks.Last().AddElement(SufficiencyLabel);
            blocks.Last().AddElement(YesRB_CG);
            blocks.Last().AddElement(NoRB_CG, false);
            blocks.Last().AddElement(FirstLine);
            blocks.Last().AddElement(PayoffDivisionLabel);

            blocks.Last().AddElement(SecondLine);

            blocks.Last().AddElement(DistributionRationalityLabel);
            blocks.Last().AddElement(RationalityPanel, true, "Stretch");
            blocks.Last().Align();
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
                CGStudentProgress.GenerateError("Ошибка при определении существенности", null);
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
                    CGStudentProgress.GenerateError("Ошибка при подсчете выражения для " + (i + 1) + " игрока.", null);
                    return false;
                }
                if (ActualValue < Database.G.payoffs[i])

                    Rational = false;
            }

            if (((DivisionRational) && (!Rational)) || ((!DivisionRational) && (Rational)))
            {
                CGStudentProgress.GenerateError("Ошибка при определении рациональности дележа", null);
                return false;
            }

            return true;
        }
        #endregion 

        #region General

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

        #endregion

        #region Buttons Interaction

        private void AdjustFormPosition()
        {
            this.Location = new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2, 50);
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            switch (CGStudentProgress.CurrentSection)
            {
                case 2:
                    if (CheckStudentsStrategies())
                        SkipButton_Click(this, new EventArgs());
                    break;
                case 3:
                    {
                        SingleGame D = G.SingleGames[0].Dominate();
                        if (CheckStudentDomination(D))
                            SkipButton_Click(this, new EventArgs());
                        else
                            CGStudentProgress.GenerateError("Должны получиться матрицы размерностью " +
                                D.A.Count + "x" + D.A[0].Count, null);
                    }
                    break;
                case 4:
                    if (CheckDivisionAndSufficiency(Coalition, YesRB_CG.Checked, YesRB_RD.Checked))
                        SkipButton_Click(this, new EventArgs());
                    break;
                case 5:
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

        private void SkipButton_Click(object sender, EventArgs e)
        {
            CGStudentProgress.NewSection();
            switch (CGStudentProgress.CurrentSection)
            {
                case 3:
                    {
                        UI_SecondSetup();
                        break;
                    }
                case 4:
                    {
                        UI_ThirdSetup();
                        break;
                    }
                case 5:
                    {
                        parent.UpdateFirstGameState(Coalition, YesRB_CG.Checked);
                        this.Close();
                        break;
                    }
                case 6:
                    {
                        parent.UpdateFirstGameState(Coalition, false);
                        this.Close();
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        #endregion
    }
}
