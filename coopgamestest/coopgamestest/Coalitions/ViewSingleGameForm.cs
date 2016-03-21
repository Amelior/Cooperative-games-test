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
    public partial class ViewSingleGameForm : Form
    {
        public ViewSingleGameForm(SingleGame G)
        {
            InitializeComponent();

            OpenGrids(G);
        }

        private void OpenGrids(SingleGame G)
        {
            UI.Grid Ga = ShowGrid(A, G.A, G);
            UI.Grid Gb = ShowGrid(B, G.B, G);

            A.Left = 10;
            B.Left = A.Right + 50;
            panel1.Width = B.Right + 10;
            this.Width = panel1.Right + 20;

            A.Top = 50;
            B.Top = A.Top;
            panel1.Height = A.Bottom + 80;
            this.Height = panel1.Bottom + 20;


            label1.Text = "Игрок " + (G.pl1 + 1).ToString();
            label1.Top = 10;
            label1.Left = A.Left + (A.Width - label1.Width) / 2;

            label2.Text = "Игрок " + (G.pl2 + 1).ToString();
            label2.Top = label1.Top;
            label2.Left = B.Left + (B.Width - label2.Width) / 2;


            x.Text = A.Rows[0].HeaderCell.Value.ToString().Substring(0,1) + " = (";
            for (int i = 0; i < G.x.Count; i++)
            {
                x.Text += G.x[i].ToString("0.00");
                if (i != G.x.Count - 1)
                    x.Text += " ";
                else
                    x.Text += ")";
            }
            x.Top = A.Bottom + 10;
            x.Left = A.Left + (A.Width - x.Width) / 2;

            y.Text = A.Columns[0].HeaderCell.Value.ToString().Substring(0, 1) + " = (";
            for (int i = 0; i < G.y.Count; i++)
            {
                y.Text += G.y[i].ToString("0.00");
                if (i != G.y.Count - 1)
                    y.Text += " ";
                else
                    y.Text += ")";
            }
            y.Top = x.Top;
            y.Left = B.Left + (B.Width - y.Width) / 2;
        }

        private UI.Grid ShowGrid(DataGridView DG, List<List<double>> M, SingleGame SG)
        {
            int n = SG.A.Count, m = SG.A[0].Count;
            UI.StrategiesGrid G = new UI.StrategiesGrid(DG, n, m);
            G.InitializeHeaders("Выигрыши", SG.FirstPlayer, SG.SecondPlayer, Database.G.S);
            DG.ReadOnly = true;
            G.InitializeGrid(M);
            return G;
        }

        private void ViewSingleGameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            CGStudentProgress.FormsOpened.Remove(this);
        }
    }
}
