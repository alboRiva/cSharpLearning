namespace knowledgeBaseUI
{
    partial class PostDetailsTest1
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
            this.DescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.EditButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.tableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // DescriptionRichTextBox
            // 
            this.tableLayout.SetColumnSpan(this.DescriptionRichTextBox, 3);
            this.DescriptionRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionRichTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionRichTextBox.Location = new System.Drawing.Point(65, 137);
            this.DescriptionRichTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DescriptionRichTextBox.Name = "DescriptionRichTextBox";
            this.DescriptionRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.DescriptionRichTextBox.Size = new System.Drawing.Size(811, 297);
            this.DescriptionRichTextBox.TabIndex = 9;
            this.DescriptionRichTextBox.Text = "";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayout.SetColumnSpan(this.TitleTextBox, 3);
            this.TitleTextBox.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleTextBox.Location = new System.Drawing.Point(65, 57);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TitleTextBox.Size = new System.Drawing.Size(811, 31);
            this.TitleTextBox.TabIndex = 8;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(65, 110);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(110, 25);
            this.DescriptionLabel.TabIndex = 7;
            this.DescriptionLabel.Text = "Description";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(65, 20);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(49, 25);
            this.TitleLabel.TabIndex = 6;
            this.TitleLabel.Text = "Title";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayout
            // 
            this.tableLayout.AutoSize = true;
            this.tableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayout.ColumnCount = 5;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.821596F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.83099F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.40257F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.43575F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.46488F));
            this.tableLayout.Controls.Add(this.TitleLabel, 1, 1);
            this.tableLayout.Controls.Add(this.TitleTextBox, 1, 2);
            this.tableLayout.Controls.Add(this.DescriptionLabel, 1, 4);
            this.tableLayout.Controls.Add(this.EditButton, 3, 1);
            this.tableLayout.Controls.Add(this.SubmitButton, 3, 7);
            this.tableLayout.Controls.Add(this.DeleteButton, 3, 8);
            this.tableLayout.Controls.Add(this.DescriptionRichTextBox, 1, 5);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Location = new System.Drawing.Point(0, 0);
            this.tableLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 10;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Size = new System.Drawing.Size(1067, 554);
            this.tableLayout.TabIndex = 14;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.EditButton.Location = new System.Drawing.Point(729, 22);
            this.EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(147, 31);
            this.EditButton.TabIndex = 11;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SubmitButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitButton.ForeColor = System.Drawing.SystemColors.WindowText;
            this.SubmitButton.Location = new System.Drawing.Point(730, 460);
            this.SubmitButton.Margin = new System.Windows.Forms.Padding(4);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(145, 32);
            this.SubmitButton.TabIndex = 13;
            this.SubmitButton.Text = "SubmitButton";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitEdited_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.ForeColor = System.Drawing.Color.DarkRed;
            this.DeleteButton.Location = new System.Drawing.Point(730, 500);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(145, 32);
            this.DeleteButton.TabIndex = 14;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // PostDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.tableLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PostDetails";
            this.Text = "Knowledgebase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox DescriptionRichTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button DeleteButton;
    }
}