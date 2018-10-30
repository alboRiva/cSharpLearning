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
using knowledgeBaseLibrary.Exceptions;

namespace knowledgeBaseUI
{
    public partial class PostDetailsTest : Form
    {
        private Post _post;
        private readonly IDataConnection _dataConnection;
        
        public PostDetailsTest(Post selectedItem, IDataConnection dataConnection)
        {
            InitializeComponent();
            _dataConnection = dataConnection;
            _post = selectedItem;
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
            this.Text = "Show/edit post";
            SubmitButton.Enabled = false;          
            TitleTextBox.Text = _post.Title;
            DescriptionRichTextBox.Text = _post.Description;
        }

        private void SpawnNewPostForm()
        {
            this.Text = "New post";
            DeleteButton.Hide();
            EditButton.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure to delete this post?",
                "Confirm Delete",
                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _dataConnection.DeletePost(_post);
                    MessageBox.Show(this, "Post eliminato dal database", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
                this.Close();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
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
                try
                {
                    _dataConnection.AddOrUpdatePost(_post);
                    //MessageBox.Show(this,"Post modificato e aggiunto con successo al database",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Close();
                }
                catch (ModifiedByOtherUserException ex)
                {
                    if (MessageBox.Show(this,
                            "The post was modified by some other user. Do you want to overwrite those changes?", this.Text,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    _dataConnection.AddOrUpdatePost(_post, true);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Fallimento nell'inserimento del post: {ex.Message}", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(this,"Inserire un titolo e una descrizione",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
