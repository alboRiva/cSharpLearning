﻿using System;
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
            //TODO: come posso generalizzare questo codice in modo che funzioni anche per SQL?
     
            GridControlResults.DataSource = _dataConnection.GetPostList(Enumerable.Empty<String>());
            SearchBarControl.Client = GridControlResults;
            GridControlResults.MouseDoubleClick += new MouseEventHandler(this.MouseDoubleClickOnItem);
        }

        private void MouseDoubleClickOnItem(object sender, MouseEventArgs e)
        {
          //ShowPost showPost = new ShowPost(_dataConnection.GetPost(Guid.Parse((GridControlResults.SelectedValue).ToString())));
          //showPost.Show();
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var newPost = new NewPost(_dataConnection);
            newPost.Show();
        }

        /// <summary>
        /// Updates the list -  but in an unoptimized way
        /// TODO: change DataBinding implementation in order to speed up refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click(object sender, EventArgs e)
        {
           
        }

        private void searchGridControl_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView) sender;
            Post post = view.GetFocusedRow() as Post;
            if (post == null)
                return;

            ShowPost showPost = new ShowPost(post);
            showPost.Show();
        }
    }

}
