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
            this.TitleLabel = new System.Windows.Forms.Label();
            this.PostListControl = new DevExpress.XtraEditors.ListBoxControl();
            this.SearchBarControl = new DevExpress.XtraEditors.SearchControl();
            this.AddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PostListControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBarControl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.SystemColors.Control;
            this.TitleLabel.Location = new System.Drawing.Point(336, 76);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(109, 17);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "KnowledgeBase";
            // 
            // PostListControl
            // 
            this.PostListControl.DisplayMember = "title";
            this.PostListControl.Location = new System.Drawing.Point(216, 223);
            this.PostListControl.Name = "PostListControl";
            this.PostListControl.Size = new System.Drawing.Size(409, 134);
            this.PostListControl.TabIndex = 1;
            this.PostListControl.ValueMember = "description";
            // 
            // SearchBarControl
            // 
            this.SearchBarControl.Location = new System.Drawing.Point(288, 115);
            this.SearchBarControl.Name = "SearchBarControl";
            this.SearchBarControl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.SearchBarControl.Size = new System.Drawing.Size(197, 22);
            this.SearchBarControl.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(325, 165);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(129, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "AddKnowledge";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SearchBarControl);
            this.Controls.Add(this.PostListControl);
            this.Controls.Add(this.TitleLabel);
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.PostListControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SearchBarControl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private DevExpress.XtraEditors.ListBoxControl PostListControl;
        private DevExpress.XtraEditors.SearchControl SearchBarControl;
        private System.Windows.Forms.Button AddButton;
    }
}