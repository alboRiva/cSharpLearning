using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using knowledgeBaseLibrary;

namespace KnowledgeBaseUI
{
    public partial class SubmitPostPage : Form
    {
        public SubmitPostPage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var post = new Post(TitleTexBox.Text,DescriptionTextBox.Text);

                //clean-up form
                TitleTexBox.Text = "";
                DescriptionTextBox.Text = "";
                foreach (IDataConnection db in GlobalConfig.Connections)
                {
                    db.CreatePost(post);
                }
            }
        }
        /// <summary>
        /// Private method to keep the events clean - on submit btn clicked
        /// </summary>
        /// <returns></returns>
        private bool ValidateForm()
        {

            if (TitleTexBox.Text.Equals(""))
            {
                return false;
            }

            if (DescriptionTextBox.Text.Equals(""))
            {
                return false;
            }

            return true;
        }
    }
}
