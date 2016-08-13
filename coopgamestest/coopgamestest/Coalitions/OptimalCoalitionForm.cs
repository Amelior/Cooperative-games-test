using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace General.Coalitions
{
    public partial class OptimalCoalitionForm : Form
    {
        UI.ControlsAligner pp;
        List<CheckBox> CB = new List<CheckBox>();
        List<TextBox> TB = new List<TextBox>();
        List<TextBox> NTB = new List<TextBox>();

        BimatrixGame G = new BimatrixGame();
        List<string> Coalitions;

        public OptimalCoalitionForm(List<string> Coalitions)
        {
            InitializeComponent();
            this.Coalitions = Coalitions;
            pp = new UI.ControlsAligner(PanelsPanel);
            FirstInterfaceSetup_Stability();
        }

        private void FirstInterfaceSetup_Stability()
        {
            GenerateCoalitionPanel(Coalitions[0], true);
            for (int i = 1; i < Coalitions.Count; i++)
                GenerateCoalitionPanel(Coalitions[i], false);
            pp.Align(true);

            UI.ControlsAligner form = new UI.ControlsAligner(this);
            form.AddElement(PanelsPanel);
            form.AddElement(FinishBTN, true, "Right");
            form.Align();
        }

        private void GenerateCoalitionPanel(string Coalition, bool first)
        {
            BimatrixGame G = Database.G.FindGame(Coalition);

            Panel p = new Panel();
            PanelsPanel.Controls.Add(p);
            p.BackColor = Color.Silver;

            Label name = new Label();
            name.Text = Coalition;
            name.Font = new System.Drawing.Font("Bookman Old Style", 16);
            name.Width = TextRenderer.MeasureText(name.Text, name.Font).Width;
            name.Height += 5;
            name.BackColor = Color.Maroon;
            name.ForeColor = Color.White;

            Label outcome = new Label();
            outcome.Text = "V = " + G.outcome.ToString("0.00");
            outcome.Font = new Font(name.Font.Name, name.Font.Size - 2);
            outcome.Size = TextRenderer.MeasureText(outcome.Text, outcome.Font);

            Label v1 = new Label();
            v1.Text = "V" + G.SingleGames[0].FirstPlayer + " = " + G.SingleGames[0].Ha.ToString("0.00");
            v1.Font = new Font(name.Font.Name, name.Font.Size - 4);
            v1.Size = TextRenderer.MeasureText(v1.Text, v1.Font);

            Label v2 = new Label();
            v2.Text = "V" + G.SingleGames[0].SecondPlayer + " = " + G.SingleGames[0].Hb.ToString("0.00");
            v2.Font = new Font(name.Font.Name, name.Font.Size - 4);
            v2.Size = TextRenderer.MeasureText(v2.Text, v2.Font);

            CheckBox c = new CheckBox();
            c.Text = "Экономически устойчивая";
            c.Font = new System.Drawing.Font("Bookman Old Style", 12);
            c.Size = TextRenderer.MeasureText(c.Text, c.Font);
            c.Tag = G;
            c.Width += 20;
            c.Height += 10;
            CB.Add(c);


            p.Controls.Add(name);
            p.Controls.Add(outcome);
            p.Controls.Add(v1);
            p.Controls.Add(v2);
            p.Controls.Add(c);

            UI.ControlsAligner panel = new UI.ControlsAligner(p);
            panel.AddElement(name);
            panel.AddElement(outcome);
            panel.AddElement(v1);
            panel.AddElement(v2, false);
            panel.AddElement(c);
            panel.Align();
            pp.AddElement(p, first);
        }


        private void SecondInterfaceSetup_PayoffDivision()
        {
            //PanelsPanel.Hide();
            DivisionPanel.Show();

            UI.ControlsAligner cpanel = new UI.ControlsAligner(PanelsPanel.Controls[0]);
            for (int i = 0; i < PanelsPanel.Controls[0].Controls.Count - 1; i++)
                cpanel.AddElement(PanelsPanel.Controls[0].Controls[i]);
            cpanel.AddElement(PanelsPanel.Controls[0].Controls[PanelsPanel.Controls[0].Controls.Count - 1], false);
            cpanel.Align();

            UI.ControlsAligner spanel = new UI.ControlsAligner(PanelsPanel);
            spanel.AddElement(PanelsPanel.Controls[0]);
            spanel.Align(true);

            UI.ControlsAligner dpanel = new UI.ControlsAligner(DivisionPanel);
            dpanel.AddElement(PayoffDivisionLabel);
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
                    dpanel.AddElement(l, true);
                else
                    dpanel.AddElement(l, false);
                dpanel.AddElement(tb, false, "HorBind");

                DivisionPanel.Controls.Add(l);
                DivisionPanel.Controls.Add(tb);
                TB.Add(tb);
            }
            dpanel.AddElement(RationalityCB, true, "Left");
            dpanel.Align();

            UI.ControlsAligner form = new UI.ControlsAligner(this);
            form.AddElement(PanelsPanel);
            form.AddElement(DivisionPanel,false);
            form.AddElement(FinishBTN,true,"Right");
            form.Align();
        }

        private void ThirdInterfaceSetup_CGNecessity()
        {
            if (RationalityCB.Checked)
            {
                for (int i = 0; i < TB.Count; i++)
                    TB[i].Enabled = false;
                RationalityCB.Enabled = false;

                NecessityPanel.Show();

                //delete
                string Coalition = PanelsPanel.Controls[0].Controls[0].Text;
                List<List<int>> C = new List<List<int>>();
                for (int i = 0; i < Coalition.Length; i++)
                {
                    if (Coalition[i] == '{')
                        C.Add(new List<int>());
                    if ((Coalition[i] >= '0') && (Coalition[i] <= '9'))
                        C.Last().Add(Convert.ToInt32(Coalition[i] - '0'));
                }


                for (int i = 0; i < TB.Count; i++)
                {
                    double ActualValue;
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
                    TB[i].Text = ActualValue.ToString("0.00");
                }

                UI.ControlsAligner npanel = new UI.ControlsAligner(NecessityPanel);
                npanel.AddElement(NecessityLabel);
                for (int i = 0; i < Database.G.N; i++)
                {
                    Label l = new Label();
                    l.Text = "ΔV(" + (i + 1) + ") = ";
                    l.Font = new System.Drawing.Font("Bookman Old Style", 14);
                    l.ForeColor = Color.White;
                    l.Size = TextRenderer.MeasureText(l.Text, l.Font);

                    TextBox tb = new TextBox();
                    tb.Font = new System.Drawing.Font("Bookman Old Style", 16);
                    tb.TextAlign = HorizontalAlignment.Center;
                    tb.Width = 100;
                    tb.Text = "";

                    if (i == 0)
                        npanel.AddElement(l, true);
                    else
                        npanel.AddElement(l, false);
                    npanel.AddElement(tb, false, "HorBind");

                    NecessityPanel.Controls.Add(l);
                    NecessityPanel.Controls.Add(tb);
                    NTB.Add(tb);
                }
                npanel.Align();

                UI.ControlsAligner form = new UI.ControlsAligner(this);
                form.AddElement(PanelsPanel);
                form.AddElement(DivisionPanel, false);
                form.AddElement(NecessityPanel);
                form.AddElement(FinishBTN, true, "Right");
                form.Align();
            }
            else
            {
                //Different division method
            }
        }


        private bool CheckEconStability()
        {
            double max = 0;
            for (int i = 0; i < CB.Count; i++)
                max = Math.Max(max, (CB[i].Tag as BimatrixGame).outcome);
            for (int i = 0; i < CB.Count; i++)
            {
                if (((CB[i].Checked) && ((CB[i].Tag as BimatrixGame).outcome != max)) ||
                    ((!CB[i].Checked) && ((CB[i].Tag as BimatrixGame).outcome == max)))
                {
                    CGStudentProgress.GenerateError("Ошибка при определении экономической устойчивости коалиции",null);
                    return false;
                }                
            }

            for (int i = 0; i < CB.Count; i++)
                if (CB[i].Checked)
                {
                    G = (CB[i].Tag as BimatrixGame);
                    CB[i].Hide();
                }
                else
                    CB[i].Parent.Dispose();

            for (int i = 0; i < CB.Count; i++)
                CB[i].Dispose();
            

            return true;
        }

        private bool CheckDivision(bool DivisionRational)
        {
            string Coalition = PanelsPanel.Controls[0].Controls[0].Text;
            List<List<int>> C = new List<List<int>>();
            for (int i = 0; i < Coalition.Length; i++)
            {
                if (Coalition[i] == '{')
                    C.Add(new List<int>());
                if ((Coalition[i] >= '0') && (Coalition[i] <= '9'))
                    C.Last().Add(Convert.ToInt32(Coalition[i] - '0'));
            }

            bool Rational = true;
            for (int i = 0; i < TB.Count; i++)
            {
                double value = CGStudentProgress.ReadValue(TB[i].Text);
                if (value == -1)
                    return false;

                double ActualValue;
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

                if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
                {
                    CGStudentProgress.GenerateError("Ошибка при подсчете выражения для " + (i + 1) + " игрока.",null);
                    return false;
                }
                if (ActualValue < Database.G.payoffs[i])

                    Rational = false;
            }

            if (((DivisionRational) && (!Rational)) || ((!DivisionRational) && (Rational)))
            {
                CGStudentProgress.GenerateError("Ошибка при определении рациональности дележа",null);
                return false;
            }

            return true;
        }

        private bool CheckNecessity()
        {
            for (int i = 0; i < NTB.Count; i++)
            {
                double value = CGStudentProgress.ReadValue(NTB[i].Text);
                if (value == -1)
                    return false;

                double ActualValue = Convert.ToDouble(TB[i].Text) - Database.G.payoffs[i];

                if ((value > 1.1 * ActualValue) || (value < 0.9 * ActualValue))
                {
                    CGStudentProgress.GenerateError("Ошибка при подсчете выражения для " + (i + 1) + " игрока.", null);
                    return false;
                }
            }

            return true;
        }


        private void FinishBTN_Click(object sender, EventArgs e)
        {
            switch (CGStudentProgress.CurrentSection)
            {
                case 7:
                    {
                        if (CheckEconStability())
                        {
                            CGStudentProgress.NewSection();
                            SecondInterfaceSetup_PayoffDivision();
                        }
                    }
                    break;
                case 8:
                    {
                        if (CheckDivision(RationalityCB.Checked))
                        {
                            CGStudentProgress.NewSection();
                            ThirdInterfaceSetup_CGNecessity();
                        }
                    }
                    break;
                case 9:
                    {
                        if (CheckNecessity())
                        {
                            for (int i = 0; i < CGStudentProgress.FormsOpened.Count; i++)
                                CGStudentProgress.FormsOpened[i].Close();
                            CGStudentProgress.Finished = true;
                            TestSelectionForm TF = new TestSelectionForm();
                            TF.StartPosition = FormStartPosition.CenterScreen;
                            TF.Show();
                            this.Close();
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
