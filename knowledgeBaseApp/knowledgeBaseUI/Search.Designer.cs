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
            this.AddButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.GridControlResults = new DevExpress.XtraGrid.GridControl();
            this.searchGridControl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuthor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastModifiedTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.searchBarInput = new System.Windows.Forms.TextBox();
            this.Title = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barStaticItem_Show = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem_Delete = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem_NewPost = new DevExpress.XtraBars.BarStaticItem();
            this.barSubItem_New = new DevExpress.XtraBars.BarSubItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GridControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.Location = new System.Drawing.Point(705, 58);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(149, 31);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "AddKnowledge";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.GridControlResults.Size = new System.Drawing.Size(986, 429);
            this.GridControlResults.TabIndex = 5;
            this.GridControlResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.searchGridControl});
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
            this.searchGridControl.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.searchGridControl_CustomColumnDisplayText);
            this.searchGridControl.DoubleClick += new System.EventHandler(this.SearchGridControl_DoubleClick);
            // 
            // colTitle
            // 
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
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 25;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 450;
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
            this.colAuthor.Width = 98;
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
            // searchBarInput
            // 
            this.searchBarInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBarInput.Location = new System.Drawing.Point(39, 63);
            this.searchBarInput.Margin = new System.Windows.Forms.Padding(4);
            this.searchBarInput.Name = "searchBarInput";
            this.searchBarInput.Size = new System.Drawing.Size(477, 22);
            this.searchBarInput.TabIndex = 7;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Title.Location = new System.Drawing.Point(34, 23);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(83, 28);
            this.Title.TabIndex = 8;
            this.Title.Text = "SEARCH";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barStaticItem_Show,
            this.barStaticItem_Delete,
            this.barStaticItem_NewPost});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
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
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1074, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 554);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1074, 24);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 503);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1074, 51);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 503);
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
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1074, 578);
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
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItem_New;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_Show;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_Delete;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem_NewPost;
    }
}