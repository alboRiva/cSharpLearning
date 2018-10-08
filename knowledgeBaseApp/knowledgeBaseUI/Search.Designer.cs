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
            this.SearchListControl = new DevExpress.XtraEditors.ListBoxControl();
            this.SearchBarControl = new DevExpress.XtraEditors.SearchControl();
            this.AddButton = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SearchListControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBarControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchListControl
            // 
            this.SearchListControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchListControl.DisplayMember = "title";
            this.SearchListControl.Location = new System.Drawing.Point(162, 181);
            this.SearchListControl.Margin = new System.Windows.Forms.Padding(2);
            this.SearchListControl.Name = "SearchListControl";
            this.SearchListControl.Size = new System.Drawing.Size(327, 155);
            this.SearchListControl.TabIndex = 1;
            this.SearchListControl.ValueMember = "id";
            this.SearchListControl.DataSourceChanged += new System.EventHandler(this.SearchListControl_DataSourceChanged);
            // 
            // SearchBarControl
            // 
            this.SearchBarControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchBarControl.Location = new System.Drawing.Point(239, 92);
            this.SearchBarControl.Margin = new System.Windows.Forms.Padding(2);
            this.SearchBarControl.Name = "SearchBarControl";
            this.SearchBarControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.SearchBarControl.Size = new System.Drawing.Size(168, 20);
            this.SearchBarControl.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(269, 133);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(118, 22);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "AddKnowledge";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Refresh
            // 
            this.Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Refresh.Location = new System.Drawing.Point(394, 357);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(95, 23);
            this.Refresh.TabIndex = 4;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(620, 470);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SearchBarControl);
            this.Controls.Add(this.SearchListControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.SearchListControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBarControl.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.ListBoxControl SearchListControl;
        private DevExpress.XtraEditors.SearchControl SearchBarControl;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button Refresh;
    }
}