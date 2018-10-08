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
    public partial class ShowPost : Form
    {
        private Post _post;
        private IDataConnection _dataConnection  = new XmlConnector(@"C:\Users\rivaa\source\repos\cSharpLearning\knowledgeBaseApp\knowledgeBaseLibrary\Data\PostRepository.xml");

        public ShowPost(object selectedItem)
        {
            InitializeComponent();
            _post = (Post) selectedItem;
            TitleTextBox.Enabled = false;
            DescriptionRichTextBox.Enabled = false;
            SubmitEdited.Enabled = false;
            TitleTextBox.Text = _post.Title;
            DescriptionRichTextBox.Text = _post.Description;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _dataConnection.DeletePost(_post);
            //TODO: Come posso controllare la correttezza delle operazioni sul db
            MessageBox.Show("Post eliminato dal database");
            this.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            DescriptionRichTextBox.Enabled = true;
            TitleTextBox.Enabled = true;
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            SubmitEdited.Enabled = true;
        }

        private void DescriptionRichTextBox_TextChanged(object sender, EventArgs e)
        {
            SubmitEdited.Enabled = true;
        }

        private void SubmitEdited_EnabledChanged(object sender, EventArgs e)
        {
            SubmitEdited.BackColor = Color.LightBlue;
        }

        private void SubmitEdited_Click(object sender, EventArgs e)
        {
            _post = new Post(_post.Id,_post.Author,TitleTextBox.Text,DescriptionRichTextBox.Text,DateTime.UtcNow);
            try
            {
                _dataConnection.AddPost(_post);
                MessageBox.Show("Post modificato e aggiunto con successo al database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallimento nell'inserimento del post");
            }
            this.Close();
        }
    }
}
