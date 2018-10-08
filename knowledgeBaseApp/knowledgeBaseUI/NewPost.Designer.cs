namespace knowledgeBaseUI
{
    partial class NewPost
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
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Location = new System.Drawing.Point(136, 72);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(27, 13);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Title";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(136, 155);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "Description";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(138, 102);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(76, 20);
            this.TitleTextBox.TabIndex = 2;
            // 
            // DescriptionRichTextBox
            // 
            this.DescriptionRichTextBox.Location = new System.Drawing.Point(138, 182);
            this.DescriptionRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.DescriptionRichTextBox.Name = "DescriptionRichTextBox";
            this.DescriptionRichTextBox.Size = new System.Drawing.Size(361, 79);
            this.DescriptionRichTextBox.TabIndex = 3;
            this.DescriptionRichTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(416, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "KnowledgeBase";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(442, 277);
            this.AddButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(56, 19);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Submit";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // NewPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionRichTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.TitleLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewPost";
            this.Text = "7";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.RichTextBox DescriptionRichTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddButton;
    }
}