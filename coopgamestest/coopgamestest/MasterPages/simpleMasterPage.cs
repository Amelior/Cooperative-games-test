using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UI;

namespace General.MasterPages
{
    public partial class simpleMasterPage : Form
    {
        protected List<ControlsAligner> blocks = new List<ControlsAligner>();
        protected PageContentBlocks outerblocks = new PageContentBlocks();
        public simpleMasterPage()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = Database.CurrentLocale;
            Thread.CurrentThread.CurrentUICulture = Database.CurrentLocale;
            MultiFormProcessor.FormOpened();
        }

        /// <summary>
        /// Align form content
        /// </summary>
        protected void AlignForm()
        {
            //Align panels for the first time
            foreach (ControlsAligner b in blocks)
                b.Align();

            //Align the outer blocks width and set WidthFixed = True
            outerblocks.Align();

            //Align Form itself
            ControlsAligner form = new ControlsAligner(this);
            foreach (ControlsAligner b in outerblocks.blocks)
                form.AddElement(b.container);
            form.Align();

            ////Re-align blocks content with the new sizes
            //foreach (ControlsAligner b in blocks)
            //    b.Align();
        }

        /// <summary>
        /// Set panels content for alignment
        /// </summary>
        protected virtual ControlsAligner AddHeader(bool withTaskPanel = false)
        {
            //Error panel
            AddErrorPanel();

            if (withTaskPanel)
                AddTaskContent();


            //Header panel
            blocks.Add(new ControlsAligner(headerPanel));
            blocks.Last().AddElement(headerLabel, true, "Left");
            blocks.Last().AddElement(errorCounterPanel, false, "Right");
            if (withTaskPanel)
                blocks.Last().AddElement(taskContentPanel);
            return (blocks.Last());
        }        


        /// <summary>
        /// Set content of the task (text, images, etc.)
        /// </summary>
        protected virtual void AddTaskContent()
        {
            blocks.Add(new ControlsAligner(taskContentPanel));
            blocks.Last().AddElement(taskLabel);
        }

        /// <summary>
        /// Set main page content
        /// </summary>
        protected virtual ControlsAligner AddMainContent()
        {
            blocks.Add(new ControlsAligner(contentPanel));
            return (blocks.Last());
        }

        /// <summary>
        /// Add navigation buttons bar: "Skip", "Done", etc.
        /// </summary>
        protected virtual ControlsAligner AddNavigationBar()
        {
            blocks.Add(new ControlsAligner(navigationPanel));
            blocks.Last().AddElement(SkipButton, true, "Left");
            blocks.Last().AddElement(FinishButton, false, "Right");
            return (blocks.Last());
        }

        protected void AddErrorPanel()
        {
            blocks.Add(new ControlsAligner(errorCounterPanel));
            blocks.Last().AddElement(errorCounter);
        }


        //Check if this form is the last opened form -> then exit application
        private void simpleMasterPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            MultiFormProcessor.FormClosed();
        }

        //Select locale for app
        private void languageComboBox_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "English":
                    {
                        ChangeFormLanguage(languageComboBox.Owner.Parent.GetType(),"en-US");
                        break;
                    }
                case "Russian":
                    {
                        ChangeFormLanguage(languageComboBox.Owner.Parent.GetType(), "ru");
                        break;
                    }
            }
            languageComboBox.Text = e.ClickedItem.Text;
            foreach (ToolStripMenuItem languageButton in languageComboBox.DropDownItems)
            {
                languageButton.Checked = (languageButton.Text == languageComboBox.Text);
            }
        }
        //Change locale for app
        private void ChangeFormLanguage(Type form, string lang)
        {
            Database.CurrentLocale = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = Database.CurrentLocale;
            Thread.CurrentThread.CurrentUICulture = Database.CurrentLocale;
            var resources = new ComponentResourceManager(form);

            //FieldInfo fi = Database.CurrentLocale.GetType().GetField(Database.CurrentLocale.ToString());
            //string cultureInfo = "";
            //DescriptionAttribute[] attributes =
            //  (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);


            //if (attributes != null && attributes.Length > 0)
            //    cultureInfo = attributes[0].Description;
            //else
            //    cultureInfo = Database.CurrentLocale.ToString();

            ApplyNewText(this, "$this", resources, Database.CurrentLocale);
            AlignForm();
        }
        //swap controls text
        private void ApplyNewText(Control c, string Name, ComponentResourceManager resources, CultureInfo cultureInfo)
        {
            resources.ApplyResources(c, Name, cultureInfo);
            foreach (Control child in c.Controls)
                ApplyNewText(child, child.Name, resources, cultureInfo);
        }
    }
    
}
