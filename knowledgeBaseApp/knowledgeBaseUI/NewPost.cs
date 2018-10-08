using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using knowledgeBaseLibrary.DataAccess;
using knowledgeBaseLibrary.Models;

namespace knowledgeBaseUI
{
    public partial class NewPost : Form
    {
        public NewPost()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Post post = new Post(Environment.UserName, TitleTextBox.Text, DescriptionRichTextBox.Text);
            XmlConnector xmlC = new XmlConnector(@"C:\Users\rivaa\OneDrive\Desktop\knowledgeBaseApp\knowledgeBaseLibrary\Data\PostRepository.xml");
            try
            {
                xmlC.AddPost(post);
                MessageBox.Show("Post aggiunto con successo al database");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fallimento nell'inserimento del post");
            }
            this.Close();
        }
    }
}
