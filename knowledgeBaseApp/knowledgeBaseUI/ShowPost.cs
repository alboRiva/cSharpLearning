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
            if (_post == null)
            {
                SpawnNewPostForm();
            }
            else
            {
                SpawnShowPostForm();
            }            
        }

        private void SpawnShowPostForm()
        {
            TitleTextBox.Enabled = false;
            DescriptionRichTextBox.Enabled = false;
            SubmitButton.Enabled = false;          
            TitleTextBox.Text = _post.Title;
            DescriptionRichTextBox.Text = _post.Description;
        }

        private void SpawnNewPostForm()
        {
            DeleteButton.Hide();
            EditButton.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                _dataConnection.DeletePost(_post);
                MessageBox.Show("Post eliminato dal database");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
            this.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            DescriptionRichTextBox.Enabled = true;
            TitleTextBox.Enabled = true;
            SubmitButton.Enabled = true;
        }

        private void SubmitEdited_Click(object sender, EventArgs e)
        {
            if (!FormValidation())
                return;

            if(_post == null)
                _post = new Post(Environment.UserName,TitleTextBox.Text,DescriptionRichTextBox.Text);
            else
                _post = new Post(_post.Id,_post.Author,TitleTextBox.Text,DescriptionRichTextBox.Text,DateTime.UtcNow);
            try
            {
                _dataConnection.AddOrUpdatePost(_post);
                MessageBox.Show("Post modificato e aggiunto con successo al database");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallimento nell'inserimento del post: " + " {0} ", ex.Message);
            }
        }
        /// <summary>
        /// Returns true if form is valid
        /// </summary>
        /// <returns></returns>
        private bool FormValidation()
        {
            if (TitleTextBox.Text.Equals("") || DescriptionRichTextBox.Text.Equals(""))
            {
                MessageBox.Show("Inserire un titolo e una descrizione");
                return false;
            }

            return true;
        }

  
    }
}
