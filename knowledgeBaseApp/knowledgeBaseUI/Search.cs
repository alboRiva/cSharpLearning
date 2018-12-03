using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
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
            InitializeData();

            //Queries db while typing and refreshing keystrokes updates every x milliseconds
            //IDisposable subscription =
            //    Observable
            //        .FromEventPattern(
            //            h => searchBarInput.TextChanged += h,
            //            h => searchBarInput.TextChanged -= h)
            //        .Select(x => searchBarInput.Text)
            //        .Throttle(TimeSpan.FromMilliseconds(400))
            //        .Select(x => Observable.Start(() =>
            //            _dataConnection.GetPostList(Utilities.GetTagsListFromString(searchBarInput.Text))))
            //        .Switch()
            //        .ObserveOn(this)
            //        .Subscribe(x =>
            //        {
            //            GridControlResults.DataSource = x;
            //            UpdateNumberOfRecords();
            //        });

            //Queries db while typing and refreshing keystrokes updates every x milliseconds
            //IDisposable subscription =
            //    Observable
            //        .FromEventPattern(
            //            h => searchBarInput.TextChanged += h,
            //            h => searchBarInput.TextChanged -= h)
            //        .Select(x => searchBarInput.Text)
            //        .Throttle(TimeSpan.FromMilliseconds(400))
            //        .Select(x => Observable.Start(() =>
            //            _dataConnection.GetPostList(Utilities.GetTagsListFromString(searchBarInput.Text))))
            //        .Switch()
            //        .ObserveOn(this)
            //        .Subscribe(x =>
            //        {
            //            GridControlResults.DataSource = x;
            //            UpdateNumberOfRecords();
            //        });
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var showPost = new PostDetails(searchBarInput.Text,_dataConnection);
            //ShowDialog -> posso controllare il valore di ritorno
            DialogResult diagRes = showPost.ShowDialog();
            if(diagRes == DialogResult.OK)
                RefreshData();
        }


        private void SearchGridControl_DoubleClick(object sender, EventArgs e)
        {
            Post post = searchGridControl.GetFocusedRow() as Post;
            if (post == null)
                return;

            PostDetails showPost = new PostDetails(post,_dataConnection);
            DialogResult diagRes = showPost.ShowDialog();
            if (diagRes == DialogResult.OK)            
                RefreshData();            
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            //Gets all records from database
            var rawPostList = _dataConnection.GetPostList(Enumerable.Empty<String>());
            GridControlResults.DataSource = rawPostList;                        
            UpdateNumberOfRecords();
        }

        private void InitializeData()
        {
            //Gets all records from database
            var rawPostList = _dataConnection.GetPostList(Enumerable.Empty<String>());
            GridControlResults.DataSource = rawPostList;
            //List of all records in memory - generates a Trie for each post
            //PREPROCESSING for fast search
            _dataConnection.InitializeRepository(rawPostList);
            UpdateNumberOfRecords();
        }

        private void UpdateNumberOfRecords()
        {
            numberOfRecordsLabel.Text = $"Number of records: {searchGridControl.RowCount}";
        }

        private void SetButtonsIcons()
        {
            AddButton.Image =
                Image.FromFile(
                    @"C:\Users\rivaa\source\repos\cSharpLearning\knowledgeBaseApp\knowledgeBaseUI\Resources\Add.ico");
            RefreshButton.Image = Image.FromFile(@"C:\Users\rivaa\source\repos\cSharpLearning\knowledgeBaseApp\knowledgeBaseUI\Resources\Refresh.ico");
        }

        private void DeleteSelectedRow(object sender, ItemClickEventArgs e)
        {
            if (searchGridControl.GetFocusedRow() is Post post)
            {
                _dataConnection.DeletePost(post);
                RefreshData();
                popupMenu1.HidePopup();
            }
        }

        private void popupMenu_NewClicked(object sender, ItemClickEventArgs e)
        {
            popupMenu1.HidePopup();
            this.AddButton_Click(sender, e); 
        }

        private void GridControlResults_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popupMenu1.ShowPopup(Control.MousePosition);
        }

        private void ShowNewClicked(object sender, ItemClickEventArgs e)
        {
            popupMenu1.HidePopup();
            SearchGridControl_DoubleClick(sender,e);
        }

        /// <summary>
        /// Delete shortcut with D or d
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridControlResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            var pressedKey = e.KeyChar.ToString().ToUpper();
            if (pressedKey.Equals(Keys.D.ToString()))
            {
                if (searchGridControl.GetFocusedRow() is Post post)
                {
                    _dataConnection.DeletePost(post);
                    RefreshData();
                }
            }
        }

        /// <summary>
        /// Queries the posts in memory on tries (SearchTrie field)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBarInput_KeyDown(object sender, KeyEventArgs e)
        {
            var input = searchBarInput.Text;
            if(input == "")
                GridControlResults.DataSource = _dataConnection.GetPostList(null);

            if (e.KeyCode == Keys.Enter)
            {
                GridControlResults.DataSource = _dataConnection.SearchPost(input,checkBox1.Checked);
                //14 ms
            }
            UpdateNumberOfRecords();
        }
    }

}
