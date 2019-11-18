namespace MovieRecommender
{
    partial class UserDashboardForm
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
            this.movieListView = new BrightIdeasSoftware.ObjectListView();
            this.titleColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.genreColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.directorColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.descriptionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.priceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.statusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.likeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dislikeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.purchaseColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.viewLabel = new System.Windows.Forms.Label();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.ownedButton = new System.Windows.Forms.Button();
            this.suggestionsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.movieListView)).BeginInit();
            this.SuspendLayout();
            // 
            // movieListView
            // 
            this.movieListView.AllColumns.Add(this.titleColumn);
            this.movieListView.AllColumns.Add(this.genreColumn);
            this.movieListView.AllColumns.Add(this.directorColumn);
            this.movieListView.AllColumns.Add(this.descriptionColumn);
            this.movieListView.AllColumns.Add(this.priceColumn);
            this.movieListView.AllColumns.Add(this.statusColumn);
            this.movieListView.AllColumns.Add(this.likeColumn);
            this.movieListView.AllColumns.Add(this.dislikeColumn);
            this.movieListView.AllColumns.Add(this.purchaseColumn);
            this.movieListView.CellEditUseWholeCell = false;
            this.movieListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumn,
            this.genreColumn,
            this.directorColumn,
            this.descriptionColumn,
            this.priceColumn,
            this.statusColumn,
            this.likeColumn,
            this.dislikeColumn,
            this.purchaseColumn});
            this.movieListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.movieListView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.movieListView.HideSelection = false;
            this.movieListView.Location = new System.Drawing.Point(12, 33);
            this.movieListView.Name = "movieListView";
            this.movieListView.ShowGroups = false;
            this.movieListView.Size = new System.Drawing.Size(1267, 453);
            this.movieListView.TabIndex = 0;
            this.movieListView.UseCompatibleStateImageBehavior = false;
            this.movieListView.View = System.Windows.Forms.View.Details;
            this.movieListView.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.movieListView_ButtonClick);
            // 
            // titleColumn
            // 
            this.titleColumn.AspectName = "Title";
            this.titleColumn.Text = "Title";
            this.titleColumn.Width = 391;
            this.titleColumn.WordWrap = true;
            // 
            // genreColumn
            // 
            this.genreColumn.AspectName = "GenreString";
            this.genreColumn.Text = "Genre";
            this.genreColumn.Width = 165;
            // 
            // directorColumn
            // 
            this.directorColumn.AspectName = "Director";
            this.directorColumn.Text = "Director";
            this.directorColumn.Width = 152;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.AspectName = "DescriptionButtonText";
            this.descriptionColumn.AspectToStringFormat = "";
            this.descriptionColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.descriptionColumn.IsButton = true;
            this.descriptionColumn.Text = "Description";
            this.descriptionColumn.Width = 67;
            // 
            // priceColumn
            // 
            this.priceColumn.AspectName = "Price";
            this.priceColumn.AspectToStringFormat = "{0:N2}";
            this.priceColumn.Text = "Price";
            this.priceColumn.Width = 55;
            // 
            // statusColumn
            // 
            this.statusColumn.AspectName = "MovieStatusString";
            this.statusColumn.Text = "MovieStatus";
            this.statusColumn.Width = 95;
            // 
            // likeColumn
            // 
            this.likeColumn.AspectName = "LikeButtonText";
            this.likeColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.likeColumn.IsButton = true;
            this.likeColumn.Text = "Like";
            this.likeColumn.Width = 84;
            // 
            // dislikeColumn
            // 
            this.dislikeColumn.AspectName = "DislikeButtonText";
            this.dislikeColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.dislikeColumn.IsButton = true;
            this.dislikeColumn.Text = "Dislike";
            this.dislikeColumn.Width = 93;
            // 
            // purchaseColumn
            // 
            this.purchaseColumn.AspectName = "PurchaseButtonText";
            this.purchaseColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.purchaseColumn.IsButton = true;
            this.purchaseColumn.Text = "Purchase";
            this.purchaseColumn.Width = 76;
            // 
            // viewLabel
            // 
            this.viewLabel.AutoSize = true;
            this.viewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewLabel.Location = new System.Drawing.Point(12, 13);
            this.viewLabel.Name = "viewLabel";
            this.viewLabel.Size = new System.Drawing.Size(87, 17);
            this.viewLabel.TabIndex = 1;
            this.viewLabel.Text = "Dashboard";
            // 
            // dashboardButton
            // 
            this.dashboardButton.Location = new System.Drawing.Point(105, 10);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.Size = new System.Drawing.Size(93, 23);
            this.dashboardButton.TabIndex = 2;
            this.dashboardButton.Text = "View Dashboard";
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // ownedButton
            // 
            this.ownedButton.Location = new System.Drawing.Point(204, 10);
            this.ownedButton.Name = "ownedButton";
            this.ownedButton.Size = new System.Drawing.Size(75, 23);
            this.ownedButton.TabIndex = 3;
            this.ownedButton.Text = "View Owned";
            this.ownedButton.UseVisualStyleBackColor = true;
            this.ownedButton.Click += new System.EventHandler(this.ownedButton_Click);
            // 
            // suggestionsButton
            // 
            this.suggestionsButton.Location = new System.Drawing.Point(285, 10);
            this.suggestionsButton.Name = "suggestionsButton";
            this.suggestionsButton.Size = new System.Drawing.Size(104, 23);
            this.suggestionsButton.TabIndex = 4;
            this.suggestionsButton.Text = "View Suggestions";
            this.suggestionsButton.UseVisualStyleBackColor = true;
            this.suggestionsButton.Click += new System.EventHandler(this.suggestionsButton_Click);
            // 
            // UserDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 498);
            this.Controls.Add(this.suggestionsButton);
            this.Controls.Add(this.ownedButton);
            this.Controls.Add(this.dashboardButton);
            this.Controls.Add(this.viewLabel);
            this.Controls.Add(this.movieListView);
            this.Name = "UserDashboardForm";
            this.Text = "UserDashboardForm";
            ((System.ComponentModel.ISupportInitialize)(this.movieListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView movieListView;
        private System.Windows.Forms.Label viewLabel;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button ownedButton;
        private System.Windows.Forms.Button suggestionsButton;
        private BrightIdeasSoftware.OLVColumn titleColumn;
        private BrightIdeasSoftware.OLVColumn genreColumn;
        private BrightIdeasSoftware.OLVColumn directorColumn;
        private BrightIdeasSoftware.OLVColumn descriptionColumn;
        private BrightIdeasSoftware.OLVColumn priceColumn;
        private BrightIdeasSoftware.OLVColumn statusColumn;
        private BrightIdeasSoftware.OLVColumn likeColumn;
        private BrightIdeasSoftware.OLVColumn dislikeColumn;
        private BrightIdeasSoftware.OLVColumn purchaseColumn;
    }
}