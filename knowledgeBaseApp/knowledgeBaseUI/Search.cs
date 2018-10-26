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
            SetButtonsIcons();
            _dataConnection = dataConnection;     
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

        private void SetButtonsIcons()
        {
            AddButton.Image =
                Image.FromFile(
                    @"C:\Users\rivaa\source\repos\cSharpLearning\knowledgeBaseApp\knowledgeBaseUI\Resources\Add.ico");
            RefreshButton.Image = Image.FromFile(@"C:\Users\rivaa\source\repos\cSharpLearning\knowledgeBaseApp\knowledgeBaseUI\Resources\Refresh.ico");
        }
    }

}
