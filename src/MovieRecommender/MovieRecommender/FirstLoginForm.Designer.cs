namespace MovieRecommender
{
    partial class FirstLoginForm
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
            this.favoriteGenresSelect = new System.Windows.Forms.CheckedListBox();
            this.genderDropdown = new System.Windows.Forms.ComboBox();
            this.dobPicker = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dobPickerLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // favoriteGenresSelect
            // 
            this.favoriteGenresSelect.FormattingEnabled = true;
            this.favoriteGenresSelect.Location = new System.Drawing.Point(12, 21);
            this.favoriteGenresSelect.Name = "favoriteGenresSelect";
            this.favoriteGenresSelect.Size = new System.Drawing.Size(249, 334);
            this.favoriteGenresSelect.TabIndex = 0;
            // 
            // genderDropdown
            // 
            this.genderDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderDropdown.FormattingEnabled = true;
            this.genderDropdown.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.genderDropdown.Location = new System.Drawing.Point(267, 21);
            this.genderDropdown.Name = "genderDropdown";
            this.genderDropdown.Size = new System.Drawing.Size(227, 21);
            this.genderDropdown.TabIndex = 1;
            // 
            // dobPicker
            // 
            this.dobPicker.Location = new System.Drawing.Point(267, 62);
            this.dobPicker.MaxSelectionCount = 1;
            this.dobPicker.Name = "dobPicker";
            this.dobPicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Favorite Genres";
            // 
            // dobPickerLabel
            // 
            this.dobPickerLabel.AutoSize = true;
            this.dobPickerLabel.Location = new System.Drawing.Point(265, 49);
            this.dobPickerLabel.Name = "dobPickerLabel";
            this.dobPickerLabel.Size = new System.Drawing.Size(68, 13);
            this.dobPickerLabel.TabIndex = 5;
            this.dobPickerLabel.Text = "Date Of Birth";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(268, 236);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(226, 90);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "Please complete the requested information in order to have a richer suggestion ex" +
    "perience.";
            // 
            // FirstLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 364);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dobPickerLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dobPicker);
            this.Controls.Add(this.genderDropdown);
            this.Controls.Add(this.favoriteGenresSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FirstLoginForm";
            this.Text = "FirstLoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox favoriteGenresSelect;
        private System.Windows.Forms.ComboBox genderDropdown;
        private System.Windows.Forms.MonthCalendar dobPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dobPickerLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}