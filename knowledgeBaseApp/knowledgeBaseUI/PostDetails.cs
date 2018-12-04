using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraRichEdit.Export;
using DevExpress.XtraRichEdit.Export.Html;
using knowledgeBaseLibrary.DataAccess;
using knowledgeBaseLibrary.Models;
using knowledgeBaseLibrary.Exceptions;

namespace knowledgeBaseUI
{
    public partial class PostDetails : Form
    {
        private Post _post;
        private readonly IDataConnection _dataConnection;
        private bool CancelClose = false;
        
        public PostDetails(Post selectedItem, IDataConnection dataConnection)
        {
            InitializeComponent();
            _dataConnection = dataConnection;
            if (selectedItem == null)
                return;
            _post = selectedItem;
            SpawnShowPostForm();          
        }

        public PostDetails(string title, IDataConnection dataConnection)
        {
            InitializeComponent();
            _dataConnection = dataConnection;
            SpawnNewPostForm(title);
        }
        private void SpawnShowPostForm()
        {
            this.Text = "Show/edit post";
            SubmitButton.Enabled = true;          
            TitleTextBox.Text = _post.Title;
            RichEditControlDescription.HtmlText = _post.Description;
            SubmitButton.Focus();
        }

        private void SpawnNewPostForm(string title)
        {
            this.Text = "New post";
            TitleTextBox.Text = title;
            DeleteButton.Hide();
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
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
                this.Close();
            }
        }

        private bool SavePost()
        {
            if (!FormValidation())
                return false;

            //Only exports part of the generated HTML document by RichEditControlDescription.HTMLText
            var options = new HtmlDocumentExporterOptions();
            options.ExportRootTag = ExportRootTag.Body;
            options.CssPropertiesExportType = CssPropertiesExportType.Inline;
            options.DefaultCharacterPropertiesExportToCss = false;
            var exporter = new HtmlExporter(RichEditControlDescription.Model, options);
            string formattedDescription = exporter.Export();

            if (_post == null)
                _post = new Post(Environment.UserName, TitleTextBox.Text, formattedDescription);
            else
                _post = new Post(_post.Id, _post.Author, TitleTextBox.Text, formattedDescription, _post.LastModifiedTime);

            try
            {
                try
                {
                    _dataConnection.AddOrUpdatePost(_post);
                    Close();
                }
                catch (ModifiedByOtherUserException ex)
                {
                    if (MessageBox.Show(this,
                            "The post was modified by some other user. Do you want to overwrite those changes?",
                            this.Text,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return false;

                    _dataConnection.AddOrUpdatePost(_post, true);
                    Close();
                }
                catch (TitleAlreadyPresentInDBException ex)
                {
                    MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Fallimento nell'inserimento del post: {ex.Message}", this.Text,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Returns true if form is valid: title and description are not empty
        /// </summary>
        /// <returns></returns>
        private bool FormValidation()
        {
            if (TitleTextBox.Text.Equals("") || RichEditControlDescription.Text.Equals(""))
            {
                MessageBox.Show(this,"Inserire un titolo e una descrizione",Text,MessageBoxButtons.OK,MessageBoxIcon.Error);
                
                return false;
            }
            return true;
        }

        private void PostDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && CancelClose)
                e.Cancel = false;

            if (DialogResult == DialogResult.Cancel && IsModified())
                if (MessageBox.Show(this, Text, "The post is modified and not changed. Are you sure to leave data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    e.Cancel = false;
        }

        private bool IsModified()
        {
            //TODO: check for modifications both empty and edited post
            return true;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            CancelClose = false;
            if (!SavePost())
                CancelClose = true;
        }
    }
}
