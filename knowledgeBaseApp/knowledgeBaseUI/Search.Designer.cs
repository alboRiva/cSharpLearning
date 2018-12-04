using System;
using knowledgeBaseLibrary.DataAccess;

namespace knowledgeBaseUI
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.AddButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.GridControlResults = new DevExpress.XtraGrid.GridControl();
            this.searchGridControl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastModifiedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.searchBarInput = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem_Show = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem_Delete = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem_NewPost = new DevExpress.XtraBars.BarStaticItem();
            this.barSubItem_New = new DevExpress.XtraBars.BarSubItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.numberOfRecordsLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.Location = new System.Drawing.Point(705, 58);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(149, 31);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "New Post";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshButton.Image")));
            this.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RefreshButton.Location = new System.Drawing.Point(876, 58);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(149, 31);
            this.RefreshButton.TabIndex = 4;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // GridControlResults
            // 
            this.GridControlResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridControlResults.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridControlResults.Location = new System.Drawing.Point(39, 112);
            this.GridControlResults.MainView = this.searchGridControl;
            this.GridControlResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridControlResults.Name = "GridControlResults";
            this.GridControlResults.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1,
            this.repositoryItemTextEdit1});
            this.GridControlResults.Size = new System.Drawing.Size(987, 415);
            this.GridControlResults.TabIndex = 5;
            this.GridControlResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.searchGridControl});
            this.GridControlResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridControlResults_KeyPress);
            this.GridControlResults.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GridControlResults_MouseUp);
            // 
            // searchGridControl
            // 
            this.searchGridControl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colDescription,
            this.colId,
            this.colAuthor,
            this.LastModifiedTime});
            this.searchGridControl.GridControl = this.GridControlResults;
            this.searchGridControl.Name = "searchGridControl";
            this.searchGridControl.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.searchGridControl.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.searchGridControl.OptionsBehavior.Editable = false;
            this.searchGridControl.OptionsBehavior.ReadOnly = true;
            this.searchGridControl.OptionsCustomization.AllowRowSizing = true;
            this.searchGridControl.OptionsFind.AllowFindPanel = false;
            this.searchGridControl.RowHeight = 60;
            this.searchGridControl.RowSeparatorHeight = 5;
            this.searchGridControl.DoubleClick += new System.EventHandler(this.SearchGridControl_DoubleClick);
            // 
            // colTitle
            // 
            this.colTitle.AppearanceCell.Options.UseTextOptions = true;
            this.colTitle.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTitle.Caption = "Title";
            this.colTitle.FieldName = "Title";
            this.colTitle.MinWidth = 25;
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 200;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 25;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 449;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.repositoryItemRichTextEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Html;
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.ShowCaretInReadOnly = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Width = 93;
            // 
            // colAuthor
            // 
            this.colAuthor.Caption = "Author";
            this.colAuthor.FieldName = "Author";
            this.colAuthor.MinWidth = 27;
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.Visible = true;
            this.colAuthor.VisibleIndex = 2;
            this.colAuthor.Width = 97;
            // 
            // LastModifiedTime
            // 
            this.LastModifiedTime.Caption = "LastModified";
            this.LastModifiedTime.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
            this.LastModifiedTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.LastModifiedTime.FieldName = "LastModifiedTime";
            this.LastModifiedTime.MinWidth = 27;
            this.LastModifiedTime.Name = "LastModifiedTime";
            this.LastModifiedTime.Visible = true;
            this.LastModifiedTime.VisibleIndex = 3;
            this.LastModifiedTime.Width = 79;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemTextEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // searchBarInput
            // 
            this.searchBarInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBarInput.Location = new System.Drawing.Point(37, 63);
            this.searchBarInput.Margin = new System.Windows.Forms.Padding(4);
            this.searchBarInput.Name = "searchBarInput";
            this.searchBarInput.Size = new System.Drawing.Size(491, 22);
            this.searchBarInput.TabIndex = 7;
            this.searchBarInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBarInput_KeyDown);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Title.Location = new System.Drawing.Point(35, 23);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(83, 28);
            this.Title.TabIndex = 8;
            this.Title.Text = "SEARCH";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem_Show,
            this.barStaticItem_Delete,
            this.barStaticItem_NewPost});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1075, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 578);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1075, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 578);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1075, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 578);
            // 
            // barStaticItem_Show
            // 
            this.barStaticItem_Show.Caption = "Show/Edit";
            this.barStaticItem_Show.Id = 1;
            this.barStaticItem_Show.Name = "barStaticItem_Show";
            this.barStaticItem_Show.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ShowNewClicked);
            // 
            // barStaticItem_Delete
            // 
            this.barStaticItem_Delete.Caption = "Delete";
            this.barStaticItem_Delete.Id = 2;
            this.barStaticItem_Delete.Name = "barStaticItem_Delete";
            this.barStaticItem_Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DeleteSelectedRow);
            // 
            // barStaticItem_NewPost
            // 
            this.barStaticItem_NewPost.Caption = "New Post";
            this.barStaticItem_NewPost.Id = 3;
            this.barStaticItem_NewPost.Name = "barStaticItem_NewPost";
            this.barStaticItem_NewPost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.popupMenu_NewClicked);
            // 
            // barSubItem_New
            // 
            this.barSubItem_New.Caption = "New";
            this.barSubItem_New.Id = 0;
            this.barSubItem_New.Name = "barSubItem_New";
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_Show),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_Delete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem_NewPost)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            this.bar3.Visible = false;
            // 
            // numberOfRecordsLabel
            // 
            this.numberOfRecordsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numberOfRecordsLabel.AutoSize = true;
            this.numberOfRecordsLabel.Location = new System.Drawing.Point(851, 541);
            this.numberOfRecordsLabel.Name = "numberOfRecordsLabel";
            this.numberOfRecordsLabel.Size = new System.Drawing.Size(174, 17);
            this.numberOfRecordsLabel.TabIndex = 13;
            this.numberOfRecordsLabel.Text = "Number of records: 00000";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(558, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 21);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "Exact Search";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1075, 578);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numberOfRecordsLabel);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.GridControlResults);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.searchBarInput);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Search";
            this.Text = "KnowledgeBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.GridControlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RefreshButton;
        private DevExpress.XtraGrid.GridControl GridControlResults;
        private DevExpress.XtraGrid.Views.Grid.GridView searchGridControl;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAuthor;
        private DevExpress.XtraGrid.Columns.GridColumn LastModifiedTime;
        private System.Windows.Forms.TextBox searchBarInput;
        private System.Windows.Forms.Label Title;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem_New;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_Show;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_Delete;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_NewPost;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraBars.Bar bar3;
        private System.Windows.Forms.Label numberOfRecordsLabel;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}