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
        private IDataConnection _dataConnection;
        public NewPost(IDataConnection dataConnection)
        {
            InitializeComponent();
            _dataConnection = dataConnection;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Post post = new Post(Environment.UserName, TitleTextBox.Text, DescriptionRichTextBox.Text);
            try
            {
                _dataConnection.AddPost(post);
                MessageBox.Show("Post aggiunto con successo al database");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Fallimento nell'inserimento del post: <{ex}>");
            }
            
        }
    }
}
