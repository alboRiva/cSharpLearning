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
        private readonly IDataConnection _dataConnection;
        
        public ShowPost(object selectedItem, IDataConnection dataConnection)
        {
            InitializeComponent();
            _dataConnection = dataConnection;
            _post = (Post) selectedItem;
            //Se post e' null -> l'utente vuole inserire un nuovo post da zero
            //if (_post == null)
            //{
            //    SpawnNewPostForm();
            //}
            //else
            //{
            //    SpawnShowPostForm();
            //}
            //TitleTextBox.Enabled = false;
            DescriptionRichTextBox.Enabled = false;
            SubmitEdited.Enabled = false;
            TitleTextBox.Text = _post.Title;
            DescriptionRichTextBox.Text = _post.Description;
        }

        private void SpawnShowPostForm()
        {
            throw new NotImplementedException();
        }

        private void SpawnNewPostForm()
        {
            throw new NotImplementedException();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _dataConnection.DeletePost(_post);
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
                _dataConnection.AddOrUpdatePost(_post);
                MessageBox.Show("Post modificato e aggiunto con successo al database");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallimento nell'inserimento del post");
            }
        }
    }
}
