using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using knowledgeBaseLibrary;
using knowledgeBaseLibrary.DataAccess;
using knowledgeBaseLibrary.Models;
using DevExpress.Xpf;
using HtmlAgilityPack;


namespace knowledgeBaseUI
{
    public partial class Search : Form
    {
        private readonly IDataConnection _dataConnection;
        public Search(IDataConnection dataConnection)
        {
            InitializeComponent();
            //barDockControlTop.Hide();
            SetButtonsIcons();
            _dataConnection = dataConnection; 
            RefreshData();
            //Queries db while typing and refreshing keystrokes updates every x milliseconds
            IDisposable subscription =
                Observable
                    .FromEventPattern(
                        h => searchBarInput.TextChanged += h,
                        h => searchBarInput.TextChanged -= h)
                    .Select(x => searchBarInput.Text)
                    .Throttle(TimeSpan.FromMilliseconds(300))
                    .Select(x => Observable.Start(() =>
                        _dataConnection.GetPostList(Utilities.GetTagsListFromString(searchBarInput.Text))))
                    .Switch()
                    .ObserveOn(this)
                    .Subscribe(x => GridControlResults.DataSource = x);
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
            //var view = (DevExpress.XtraGrid.Views.Grid.GridView) sender;

            Post post = searchGridControl.GetFocusedRow() as Post;
            if (post == null)
                return;

            PostDetails showPost = new PostDetails(post,_dataConnection);
            DialogResult diagRes = showPost.ShowDialog();
            if (diagRes == DialogResult.OK)
            {
                RefreshData();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshData();
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
            this.AddButton_Click(sender, e);
        }

        private void GridControlResults_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                popupMenu1.ShowPopup(Control.MousePosition);
        }

        private void ShowNewClicked(object sender, ItemClickEventArgs e)
        {
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
    }

}
