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
    public partial class Search : Form
    {
        private readonly IDataConnection _dataConnection;
        public Search(IDataConnection dataConnection)
        {
            InitializeComponent();
            _dataConnection = dataConnection;     
            GridControlResults.DataSource = _dataConnection.GetPostList(Enumerable.Empty<String>());
            SearchBarControl.Client = GridControlResults;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var showPost = new ShowPost(null,_dataConnection);
            showPost.Show();
        }


        private void searchGridControl_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView) sender;
            Post post = view.GetFocusedRow() as Post;
            if (post == null)
                return;

            ShowPost showPost = new ShowPost(post,_dataConnection);
            showPost.Show();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            GridControlResults.DataSource = _dataConnection.GetPostList(Enumerable.Empty<String>());
        }
    }

}
