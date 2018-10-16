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
            GridControlResults.DataSource = _dataConnection.GetPostList(Enumerable.Empty<String>());
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var showPost = new ShowPost(null,_dataConnection);
            showPost.Show();
        }


        private void SearchGridControl_DoubleClick(object sender, EventArgs e)
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

        //TODO: is it necessary?
        private void tableLayout_MouseHover(object sender, EventArgs e)
        {
          //  GridControlResults.DataSource = _dataConnection.GetPostList(Enumerable.Empty<String>());
        }

        private void searchBarInput_TextChanged(object sender, EventArgs e)
        {
            var filtered = _dataConnection.GetPostList(GetTagsFromTitle(searchBarInput.Text));
            GridControlResults.DataSource = filtered;          
        }

        //TODO: improve tag extraction
        private IEnumerable<string> GetTagsFromTitle(string searchText)
        {
            return searchText.Split(' ', '\t', '\r', '\n' /*, ...*/);
        }
    }

}
