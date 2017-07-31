namespace TicketTracker
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cboSeason = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstShows = new System.Windows.Forms.ListView();
            this.colShowTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShowType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShowId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTicketsSold = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmountCollected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnDeleteShow = new System.Windows.Forms.Button();
            this.btnCreatePDF = new System.Windows.Forms.Button();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSeason
            // 
            this.cboSeason.FormattingEnabled = true;
            this.cboSeason.Location = new System.Drawing.Point(60, 36);
            this.cboSeason.Name = "cboSeason";
            this.cboSeason.Size = new System.Drawing.Size(133, 21);
            this.cboSeason.TabIndex = 0;
            this.cboSeason.SelectedIndexChanged += new System.EventHandler(this.cboSeason_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Season:";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(614, 24);
            this.mnuMain.TabIndex = 3;
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(113, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // lstShows
            // 
            this.lstShows.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShowTitle,
            this.colShowType,
            this.colShowId,
            this.colSeason,
            this.colTicketsSold,
            this.colAmountCollected});
            this.lstShows.FullRowSelect = true;
            this.lstShows.Location = new System.Drawing.Point(5, 72);
            this.lstShows.MultiSelect = false;
            this.lstShows.Name = "lstShows";
            this.lstShows.Size = new System.Drawing.Size(604, 172);
            this.lstShows.TabIndex = 5;
            this.lstShows.UseCompatibleStateImageBehavior = false;
            this.lstShows.View = System.Windows.Forms.View.Details;
            this.lstShows.DoubleClick += new System.EventHandler(this.lstShows_DoubleClick);
            // 
            // colShowTitle
            // 
            this.colShowTitle.Text = "Title";
            this.colShowTitle.Width = 250;
            // 
            // colShowType
            // 
            this.colShowType.Text = "Show Type";
            this.colShowType.Width = 150;
            // 
            // colShowId
            // 
            this.colShowId.Text = "Show Id";
            this.colShowId.Width = 0;
            // 
            // colSeason
            // 
            this.colSeason.Text = "Season";
            this.colSeason.Width = 0;
            // 
            // colTicketsSold
            // 
            this.colTicketsSold.Text = "Tickets Sold";
            this.colTicketsSold.Width = 100;
            // 
            // colAmountCollected
            // 
            this.colAmountCollected.Text = "Amount Collected";
            this.colAmountCollected.Width = 100;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(5, 248);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(89, 23);
            this.btnAddNew.TabIndex = 6;
            this.btnAddNew.Text = "Add New Show";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnDeleteShow
            // 
            this.btnDeleteShow.Location = new System.Drawing.Point(100, 248);
            this.btnDeleteShow.Name = "btnDeleteShow";
            this.btnDeleteShow.Size = new System.Drawing.Size(84, 23);
            this.btnDeleteShow.TabIndex = 7;
            this.btnDeleteShow.Text = "Delete Show";
            this.btnDeleteShow.UseVisualStyleBackColor = true;
            this.btnDeleteShow.Click += new System.EventHandler(this.btnDeleteShow_Click);
            // 
            // btnCreatePDF
            // 
            this.btnCreatePDF.Location = new System.Drawing.Point(509, 248);
            this.btnCreatePDF.Name = "btnCreatePDF";
            this.btnCreatePDF.Size = new System.Drawing.Size(75, 23);
            this.btnCreatePDF.TabIndex = 8;
            this.btnCreatePDF.Text = "Create PDF";
            this.btnCreatePDF.UseVisualStyleBackColor = true;
            this.btnCreatePDF.Click += new System.EventHandler(this.btnCreatePDF_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 283);
            this.Controls.Add(this.btnCreatePDF);
            this.Controls.Add(this.btnDeleteShow);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lstShows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSeason);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket Tracker";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSeason;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListView lstShows;
        private System.Windows.Forms.ColumnHeader colShowType;
        private System.Windows.Forms.ColumnHeader colShowTitle;
        private System.Windows.Forms.ColumnHeader colShowId;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ColumnHeader colSeason;
        private System.Windows.Forms.Button btnDeleteShow;
        private System.Windows.Forms.ColumnHeader colTicketsSold;
        private System.Windows.Forms.ColumnHeader colAmountCollected;
        private System.Windows.Forms.Button btnCreatePDF;
    }
}

