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
        List<TextBox> PayoffDistributionTB = new List<TextBox>();
        string Coalition;

        Size GridSizeforTaskOne = new Size(5, 5);

        public CooperativeGameForm(TestForm parent, string Coalition)
        {
            InitializeComponent();
            G = Database.G.FindGame(Coalition);
            this.parent = parent;
            this.Coalition = Coalition;
            UI_FirstSetup();
        }

        #region Interface

        #region First Setup - Strategies formation

        private void UI_FirstSetup()
        {
            #region Grids
            //Create grid that shows strategies number
            UI.TWDNGrid Gs = new UI.TWDNGrid(S, 1, Database.G.N);
            Gs.InitializeHeaders("", "Количество стратегий", "Игрок", false, true);
            Gs.InitializeGrid(Database.G.S);

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
                        CGStudentProgress.GenerateError("Повторное заполнение одинаковой коалиции.", null);
                        return false;
                    }
                    break;
                }
            }
            return true;
        }

        #endregion

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

        //private void CreateNavigationButton(int c)
        //{
        //    Button b = new Button();
        //    b.Font = new System.Drawing.Font("Bookman Old Style", 14);
        //    b.BackColor = NavigationPanel.BackColor;
        //    b.ForeColor = Color.White;
        //    b.Text = "Коалиция " + G.SingleGames[c].FirstPlayer + " <-> " + "Коалиция " + G.SingleGames[c].SecondPlayer;
        //    b.Height = NavigationPanel.Height;
        //    b.FlatStyle = FlatStyle.Popup;

        //    //Position
        //    if (c == 0)
        //        b.Left = 0;
        //    else
        //        b.Left = NavigationPanel.Controls[NavigationPanel.Controls.Count - 1].Right;
        //    b.Top = 0;

        //    //Clicking
        //    b.Click += new EventHandler(ShowAnotherGame);
        //    NavigationPanel.Controls.Add(b);
        //}

        //void RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if ((e.Button == System.Windows.Forms.MouseButtons.Left) && (CGStudentProgress.CurrentSection == 2))
        //        ((sender as DataGridView).Tag as UI.Grid).
        //            BeginEdit((sender as DataGridView).Rows[e.RowIndex].HeaderCell);
        //    if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (CGStudentProgress.CurrentSection == 3))
        //    {
        //        ContextMenuStrip CMS = new System.Windows.Forms.ContextMenuStrip();
        //        ToolStripMenuItem t1 = new ToolStripMenuItem("Удалить");
        //        t1.Click += (new_sender, new_e) => Dominate(sender, e, (sender as DataGridView).Rows[e.RowIndex]);
        //        CMS.Items.Add(t1);
        //        CMS.Show(MousePosition);
        //    }
        //}

        //void ColumnHeadersMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if ((e.Button == System.Windows.Forms.MouseButtons.Left) && (CGStudentProgress.CurrentSection == 2))
        //        ((sender as DataGridView).Tag as UI.Grid).
        //            BeginEdit((sender as DataGridView).Columns[e.ColumnIndex].HeaderCell);
        //    if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (CGStudentProgress.CurrentSection == 3))
        //    {
        //        ContextMenuStrip CMS = new System.Windows.Forms.ContextMenuStrip();
        //        ToolStripMenuItem t1 = new ToolStripMenuItem("Удалить");
        //        t1.Click += (new_sender, new_e) => Dominate(sender, e, (sender as DataGridView).Columns[e.ColumnIndex]);
        //        CMS.Items.Add(t1);
        //        CMS.Show(MousePosition);
        //    }
        //}

        #endregion

    }
}
