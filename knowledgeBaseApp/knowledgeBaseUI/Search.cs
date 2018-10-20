using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using knowledgeBaseLibrary;
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
            //TODO: don't load all records - make display of records fast -> done: I display first 100 entries of db
            //TODO: Unit Testing?
            RefreshData();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var showPost = new PostDetails(null,_dataConnection);
            //ShowDialog -> posso controllare il valore di ritorno
            DialogResult diagRes = showPost.ShowDialog();
            if(diagRes == DialogResult.OK)
                RefreshData();
        }


        private void SearchGridControl_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView) sender;
            Post post = view.GetFocusedRow() as Post;
            if (post == null)
                return;

            PostDetails showPost = new PostDetails(post,_dataConnection);
            DialogResult diagRes = showPost.ShowDialog();
            if (diagRes == DialogResult.OK)
                RefreshData();
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            GridControlResults.DataSource = _dataConnection.GetPostList(Enumerable.Empty<String>());
        }

        private void searchBarInput_TextChanged(object sender, EventArgs e)
        {
            var filtered = _dataConnection.GetPostList(Utilities.GetTagsListFromString(searchBarInput.Text));
            GridControlResults.DataSource = filtered;          
        }


        private void RefreshData()
        {
            GridControlResults.DataSource = _dataConnection.GetPostList(Enumerable.Empty<String>());
        }
    }

}
