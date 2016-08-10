using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace General
{
    public partial class TestSelectionForm : Form
    {
        public TestSelectionForm()
        {
            InitializeComponent();

            GenerateResultPanels();

            UI.ControlsAligner p = new UI.ControlsAligner(panel1);
            p.AddElement(coopGamesButton);
            if (CGStudentProgress.Finished)
                p.AddElement(CGResult, false,"HorBind");

            p.AddElement(CKernelButton, true, "Stretch");
            if (CKResult.Visible)
                p.AddElement(CKResult, false, "HorBind");

            p.AddElement(shapleyButton, true, "Stretch");
            if (ShapleyResult.Visible)
                p.AddElement(ShapleyResult, false, "HorBind");

            p.Left *= 2;
            p.Right *= 2;
            p.Top *= 2;
            p.Bottom *= 2;
            p.VerticalInterval *= 2;
            p.Align();


            UI.ControlsAligner form = new UI.ControlsAligner(this);
            form.AddElement(panel1);
            form.Align();            
        }

        private void GenerateResultPanels()
        {
            if ((CGStudentProgress.Finished)&&(!CGResult.Visible))
            {
                coopGamesButton.Enabled = false;
                coopGamesButton.BackColor = Color.Transparent;
                CGResult.Visible = true;
                CGResult.Controls[0].Text += CGStudentProgress.ErrorsNumber;
            }
        }

        private void TestSelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MultiFormProcessor.FormClosed();
        }

        private void coopGamesButton_Click(object sender, EventArgs e)
        {
            Coalitions.IncooperativeGame F = new Coalitions.IncooperativeGame();
            F.StartPosition = FormStartPosition.Manual;
            F.Location = new Point((Screen.PrimaryScreen.Bounds.Width - F.Width)/2, 200);
            this.Hide();
            F.ShowDialog();
        }

        private void shapleyButton_Click(object sender, EventArgs e)
        {

        }

        private void CKernelButton_Click(object sender, EventArgs e)
        {

        }
    }
}
