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
            this.SearchBarControl = new DevExpress.XtraEditors.SearchControl();
            this.AddButton = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.GridControlResults = new DevExpress.XtraGrid.GridControl();
            this.searchGridControl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridControl)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchBarControl
            // 
            this.SearchBarControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBarControl.Location = new System.Drawing.Point(319, 113);
            this.SearchBarControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchBarControl.Name = "SearchBarControl";
            this.SearchBarControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.SearchBarControl.Size = new System.Drawing.Size(224, 22);
            this.SearchBarControl.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(359, 164);
            this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(157, 27);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "AddKnowledge";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Refresh
            // 
            this.Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Refresh.Location = new System.Drawing.Point(525, 439);
            this.Refresh.Margin = new System.Windows.Forms.Padding(4);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(127, 28);
            this.Refresh.TabIndex = 4;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            // 
            // GridControlResults
            // 
            this.GridControlResults.Location = new System.Drawing.Point(239, 216);
            this.GridControlResults.MainView = this.searchGridControl;
            this.GridControlResults.Name = "GridControlResults";
            this.GridControlResults.Size = new System.Drawing.Size(400, 200);
            this.GridControlResults.TabIndex = 5;
            this.GridControlResults.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.searchGridControl});
            // 
            // searchGridControl
            // 
            this.searchGridControl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTitle,
            this.colDescription,
            this.colId});
            this.searchGridControl.GridControl = this.GridControlResults;
            this.searchGridControl.Name = "searchGridControl";
            this.searchGridControl.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.searchGridControl.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.searchGridControl.OptionsBehavior.Editable = false;
            this.searchGridControl.OptionsBehavior.ReadOnly = true;
            this.searchGridControl.DoubleClick += new System.EventHandler(this.searchGridControl_DoubleClick);
            // 
            // colTitle
            // 
            this.colTitle.Caption = "Title";
            this.colTitle.FieldName = "Title";
            this.colTitle.MinWidth = 25;
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            this.colTitle.Width = 94;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Description";
            this.colDescription.FieldName = "Description";
            this.colDescription.MinWidth = 25;
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 94;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Width = 94;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(827, 578);
            this.Controls.Add(this.GridControlResults);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SearchBarControl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.SearchBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridControlResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchGridControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SearchControl SearchBarControl;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button Refresh;
        private DevExpress.XtraGrid.GridControl GridControlResults;
        private DevExpress.XtraGrid.Views.Grid.GridView searchGridControl;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
    }
}