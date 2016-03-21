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
    public partial class CoalitionChooseForm : Form
    {
        UI.ControlsAligner form;
        public CoalitionChooseForm()
        {
            InitializeComponent();
            GenerateCoalitionsButtons();
        }

        void GenerateCoalitionsButtons()
        {
            form = new UI.ControlsAligner(this);
            List<List<string>> Coalitions = Database.G.CoalitionsInText;
            for (int i = 0; i < Coalitions.Count; i++)
                for (int j = 0; j < Coalitions[i].Count; j++)
                    CreateButton(Coalitions[i][j]);

            UI.ControlsAligner panel = new UI.ControlsAligner(InfoPanel);
            panel.AddElement(InfoLabel, true, "VertBind");
            panel.AddElement(TaskLabel, false, "VertBind");
            panel.AddElement(GameTypePanel);
            panel.AddElement(TaskPanel, false);
            InfoLabel.Tag = GameTypePanel;
            TaskLabel.Tag = TaskPanel;
            panel.Align();

            form.AddElement(InfoPanel);
            form.AddElement(CoalLabel);
            form.AddElement(CoalitionsPanel, true, "Stretch");
            form.AddElement(SkipBTN, true, "Left");
            form.AddElement(FinishBTN, false, "Right");
            form.Align();

            panel = new UI.ControlsAligner(CoalitionsPanel);
            for (int i = 0; i < CoalitionsPanel.Controls.Count; i++)
                if (i == 0)
                    panel.AddElement(CoalitionsPanel.Controls[i]);
                else
                    panel.AddElement(CoalitionsPanel.Controls[i], false);

            panel.Align(true);
        }

        void CreateButton(string T)
        {
            Button b = new Button();
            b.Font = new System.Drawing.Font("Bookman Old Style", 14);
            b.BackColor = CoalitionsPanel.BackColor;
            b.Text = T;
            b.AutoSize = true;
            b.FlatStyle = FlatStyle.Popup;

            //Clicking
            b.MouseUp += new MouseEventHandler(ButtonMouseUp);
            CoalitionsPanel.Controls.Add(b);
        }

        void ButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenuStrip CMS = new System.Windows.Forms.ContextMenuStrip();
                ToolStripMenuItem t1 = new ToolStripMenuItem("Существенная игра");
                t1.Click += (new_sender, new_e) => ChangeButtonColor(sender, e, true);
                ToolStripMenuItem t2 = new ToolStripMenuItem("Несущественная игра");
                t2.Click += (new_sender, new_e) => ChangeButtonColor(sender, e, false);
                CMS.Items.Add(t1);
                CMS.Items.Add(t2);
                CMS.Show(MousePosition);
            }
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ViewCooperativeGameForm F = new ViewCooperativeGameForm(this, (sender as Button).Text);
                MultiFormProcessor.FormOpened();
                F.StartPosition = FormStartPosition.CenterScreen;
                if (CGStudentProgress.CurrentSection > 2)
                    F.Show();
                else
                    F.ShowDialog();
            }
        }

        void ChangeButtonColor(object sender, EventArgs e, bool sufficient)
        {
            if (sufficient)
                (sender as Button).BackColor = Color.White;
            else
                (sender as Button).BackColor = Color.Maroon;

        }

        private void CoalitionChooseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MultiFormProcessor.FormClosed();
        }

        private void FinishBTN_MouseMove(object sender, MouseEventArgs e)
        {
            FinishBTN.BackColor = Color.White;
            FinishBTN.ForeColor = Color.Black;
        }

        private void FinishBTN_MouseLeave(object sender, EventArgs e)
        {
            FinishBTN.BackColor = Color.DimGray;
            FinishBTN.ForeColor = Color.White;
        }

        private void FinishBTN_Click(object sender, EventArgs e)
        {
            bool correct = true;
            for (int i = 0; i<CoalitionsPanel.Controls.Count; i++)
            {
                BimatrixGame G = Database.G.FindGame(CoalitionsPanel.Controls[i].Text);
                if (((G.outcome > Database.G.outcome) && (CoalitionsPanel.Controls[i].BackColor == Color.Maroon)) ||
                    ((G.outcome < Database.G.outcome) && (CoalitionsPanel.Controls[i].BackColor == Color.White)))
                {
                    correct = false;
                    CGStudentProgress.GenerateError("Коалиция " + CoalitionsPanel.Controls[i].Text + " определена неверно.");
                    break;
                }
            }
            if (correct)
            {
                CGStudentProgress.NewSection();
                List<string> Sufficient = new List<string>();
                for (int i = 0; i < CoalitionsPanel.Controls.Count; i++)
                    if (CoalitionsPanel.Controls[i].BackColor == Color.White)
                        Sufficient.Add(CoalitionsPanel.Controls[i].Text);
                OptimalCoalitionForm F = new OptimalCoalitionForm(Sufficient);
                this.Close();
                F.ShowDialog();
            }
        }

        private void SkipBTN_Click(object sender, EventArgs e)
        {
            List<string> Sufficient = new List<string>();
            for (int i = 0; i < CoalitionsPanel.Controls.Count; i++)
            {
                BimatrixGame G = Database.G.FindGame(CoalitionsPanel.Controls[i].Text);
                if (G.outcome > Database.G.outcome)
                {
                    CoalitionsPanel.Controls[i].BackColor = Color.White;
                    Sufficient.Add(CoalitionsPanel.Controls[i].Text);
                }
                else
                    CoalitionsPanel.Controls[i].BackColor = Color.Maroon;
            }
            OptimalCoalitionForm F = new OptimalCoalitionForm(Sufficient);
            F.StartPosition = FormStartPosition.CenterScreen;
            CGStudentProgress.CurrentSection = 7;
            this.Close();
            F.ShowDialog();            
        }

        public void UpdateFirstGameState(string Coalition, bool Sufficient)
        {
            Button b = new Button();
            for (int i = 0; i < CoalitionsPanel.Controls.Count; i++)
                if (CoalitionsPanel.Controls[i].Text == Coalition)
                    b = (CoalitionsPanel.Controls[i] as Button);
            ChangeButtonColor(b, new EventArgs(), Sufficient);
        }
    }
}
