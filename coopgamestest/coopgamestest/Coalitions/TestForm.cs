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
    public partial class TestForm : General.MasterPages.simpleMasterPage
    {
        public TestForm()
        {           
            InitializeComponent();
            UI_FirstSetup();
        }

        #region Interface

        #region First Setup - General view

        private void UI_FirstSetup()
        {
            #region Coalition buttons

            List<List<string>> Coalitions = Database.G.CoalitionsInText;
            for (int i = 0; i < Coalitions.Count; i++)
                for (int j = 0; j < Coalitions[i].Count; j++)
                    CreateButton(Coalitions[i][j]);
            #endregion

            #region Alignment
            //1
            outerblocks.Add(AddHeader(true));
            //2
            blocks.Add(new UI.ControlsAligner(possibleCoalitionsPanel));
            blocks.Last().AddElement(possibleCoalitionsLabel);
            blocks.Last().VerticalInterval = 0;
            outerblocks.Add(blocks.Last());
            //3
            outerblocks.Add(AddMainContent());
            //4
            outerblocks.Add(AddNavigationBar());

            //Align
            AlignForm();
            #endregion
        }

        protected override void AddTaskContent()
        {
            blocks.Add(new ControlsAligner(taskContentPanel));

            blocks.Last().AddElement(taskLabel, true, "VertBind");
            taskLabel.Tag = defPanel;
            blocks.Last().AddElement(actualTaskLabel,false, "VertBind");
            actualTaskLabel.Tag = taskPanel;

            blocks.Last().AddElement(defPanel);
            blocks.Last().AddElement(taskPanel, false);

        }

        protected override ControlsAligner AddMainContent()
        {
            base.AddMainContent();
            for (int i = 0; i < contentPanel.Controls.Count; i++)
                if (i == 0)
                    blocks.Last().AddElement(contentPanel.Controls[i]);
                else
                    blocks.Last().AddElement(contentPanel.Controls[i], false);
            return blocks.Last();
        }

        #region Coalitions Panel

        void CreateButton(string T)
        {
            Button b = new Button();
            b.Font = new System.Drawing.Font("Bookman Old Style", 14);
            b.BackColor = taskContentPanel.BackColor;
            b.Text = T;
            b.AutoSize = true;
            b.FlatStyle = FlatStyle.Popup;

            //Clicking
            b.MouseUp += new MouseEventHandler(ButtonMouseUp);
            contentPanel.Controls.Add(b);
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
                CooperativeGameForm F = new CooperativeGameForm(this, (sender as Button).Text);
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

        public void UpdateFirstGameState(string Coalition, bool Sufficient)
        {
            Button b = new Button();
            for (int i = 0; i < contentPanel.Controls.Count; i++)
                if (contentPanel.Controls[i].Text == Coalition)
                    b = (contentPanel.Controls[i] as Button);
            ChangeButtonColor(b, new EventArgs(), Sufficient);
        }
        #endregion

        #endregion

        #endregion
    }
}
