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
            ((System.ComponentModel.ISupportInitialize)(this.GridControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridControl)).BeginInit();
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
            this.GridControlResults.Location = new System.Drawing.Point(164, 115);
            this.GridControlResults.MainView = this.searchGridControl;
            this.GridControlResults.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GridControlResults.Name = "GridControlResults";
            this.GridControlResults.Size = new System.Drawing.Size(861, 426);
            this.GridControlResults.TabIndex = 5;
            this.GridControlResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.searchGridControl});
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
            this.searchBarInput.Location = new System.Drawing.Point(164, 63);
            this.searchBarInput.Margin = new System.Windows.Forms.Padding(4);
            this.searchBarInput.Name = "searchBarInput";
            this.searchBarInput.Size = new System.Drawing.Size(477, 22);
            this.searchBarInput.TabIndex = 7;
            this.searchBarInput.TextChanged += new System.EventHandler(this.searchBarInput_TextChanged);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Title.Location = new System.Drawing.Point(34, 61);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(83, 28);
            this.Title.TabIndex = 8;
            this.Title.Text = "SEARCH";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Search";
            this.Text = "KnowledgeBase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.GridControlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridControl)).EndInit();
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
    }
}