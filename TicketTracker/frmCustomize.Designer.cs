namespace TicketTracker
{
    partial class frmCustomize
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomize));
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tpShowTypes = new System.Windows.Forms.TabPage();
            this.txtShowType = new System.Windows.Forms.TextBox();
            this.lblShowType = new System.Windows.Forms.Label();
            this.btnUpdateShowType = new System.Windows.Forms.Button();
            this.btnDeleteShowType = new System.Windows.Forms.Button();
            this.btnAddShowType = new System.Windows.Forms.Button();
            this.lstShowTypes = new System.Windows.Forms.ListView();
            this.colShowTypeDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShowTypeId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpSeason = new System.Windows.Forms.TabPage();
            this.txtSeasonDescription = new System.Windows.Forms.TextBox();
            this.lblSeasonDescription = new System.Windows.Forms.Label();
            this.btnUpdateSeason = new System.Windows.Forms.Button();
            this.btnDeleteSeason = new System.Windows.Forms.Button();
            this.btnAddSeason = new System.Windows.Forms.Button();
            this.lstSeasons = new System.Windows.Forms.ListView();
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeasonId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tcMain = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tpShowTypes.SuspendLayout();
            this.tpSeason.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(145, 317);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tpShowTypes
            // 
            this.tpShowTypes.Controls.Add(this.lstShowTypes);
            this.tpShowTypes.Controls.Add(this.txtShowType);
            this.tpShowTypes.Controls.Add(this.btnAddShowType);
            this.tpShowTypes.Controls.Add(this.btnDeleteShowType);
            this.tpShowTypes.Controls.Add(this.btnUpdateShowType);
            this.tpShowTypes.Controls.Add(this.lblShowType);
            this.tpShowTypes.Location = new System.Drawing.Point(4, 22);
            this.tpShowTypes.Name = "tpShowTypes";
            this.tpShowTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tpShowTypes.Size = new System.Drawing.Size(355, 272);
            this.tpShowTypes.TabIndex = 1;
            this.tpShowTypes.Text = "Show Types";
            this.tpShowTypes.UseVisualStyleBackColor = true;
            // 
            // txtShowType
            // 
            this.txtShowType.Location = new System.Drawing.Point(72, 5);
            this.txtShowType.Name = "txtShowType";
            this.txtShowType.Size = new System.Drawing.Size(141, 20);
            this.txtShowType.TabIndex = 7;
            // 
            // lblShowType
            // 
            this.lblShowType.AutoSize = true;
            this.lblShowType.Location = new System.Drawing.Point(11, 8);
            this.lblShowType.Name = "lblShowType";
            this.lblShowType.Size = new System.Drawing.Size(61, 13);
            this.lblShowType.TabIndex = 8;
            this.lblShowType.Text = "Show Type";
            // 
            // btnUpdateShowType
            // 
            this.btnUpdateShowType.Location = new System.Drawing.Point(87, 32);
            this.btnUpdateShowType.Name = "btnUpdateShowType";
            this.btnUpdateShowType.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateShowType.TabIndex = 9;
            this.btnUpdateShowType.Text = "Update";
            this.btnUpdateShowType.UseVisualStyleBackColor = true;
            this.btnUpdateShowType.Click += new System.EventHandler(this.btnUpdateShowType_Click);
            // 
            // btnDeleteShowType
            // 
            this.btnDeleteShowType.Location = new System.Drawing.Point(168, 32);
            this.btnDeleteShowType.Name = "btnDeleteShowType";
            this.btnDeleteShowType.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteShowType.TabIndex = 10;
            this.btnDeleteShowType.Text = "Delete";
            this.btnDeleteShowType.UseVisualStyleBackColor = true;
            this.btnDeleteShowType.Click += new System.EventHandler(this.btnDeleteShowType_Click);
            // 
            // btnAddShowType
            // 
            this.btnAddShowType.Location = new System.Drawing.Point(6, 32);
            this.btnAddShowType.Name = "btnAddShowType";
            this.btnAddShowType.Size = new System.Drawing.Size(75, 23);
            this.btnAddShowType.TabIndex = 11;
            this.btnAddShowType.Text = "Add";
            this.btnAddShowType.UseVisualStyleBackColor = true;
            this.btnAddShowType.Click += new System.EventHandler(this.btnAddShowType_Click);
            // 
            // lstShowTypes
            // 
            this.lstShowTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShowTypeDescription,
            this.colShowTypeId});
            this.lstShowTypes.FullRowSelect = true;
            this.lstShowTypes.Location = new System.Drawing.Point(6, 60);
            this.lstShowTypes.MultiSelect = false;
            this.lstShowTypes.Name = "lstShowTypes";
            this.lstShowTypes.Size = new System.Drawing.Size(342, 205);
            this.lstShowTypes.TabIndex = 12;
            this.lstShowTypes.UseCompatibleStateImageBehavior = false;
            this.lstShowTypes.View = System.Windows.Forms.View.Details;
            this.lstShowTypes.SelectedIndexChanged += new System.EventHandler(this.lstShowTypes_SelectedIndexChanged);
            // 
            // colShowTypeDescription
            // 
            this.colShowTypeDescription.Text = "Description";
            this.colShowTypeDescription.Width = 341;
            // 
            // colShowTypeId
            // 
            this.colShowTypeId.Text = "ShowTypeId";
            this.colShowTypeId.Width = 0;
            // 
            // tpSeason
            // 
            this.tpSeason.Controls.Add(this.lstSeasons);
            this.tpSeason.Controls.Add(this.txtSeasonDescription);
            this.tpSeason.Controls.Add(this.btnAddSeason);
            this.tpSeason.Controls.Add(this.btnDeleteSeason);
            this.tpSeason.Controls.Add(this.btnUpdateSeason);
            this.tpSeason.Controls.Add(this.lblSeasonDescription);
            this.tpSeason.Location = new System.Drawing.Point(4, 22);
            this.tpSeason.Name = "tpSeason";
            this.tpSeason.Padding = new System.Windows.Forms.Padding(3);
            this.tpSeason.Size = new System.Drawing.Size(355, 272);
            this.tpSeason.TabIndex = 0;
            this.tpSeason.Text = "Seasons";
            this.tpSeason.UseVisualStyleBackColor = true;
            // 
            // txtSeasonDescription
            // 
            this.txtSeasonDescription.Location = new System.Drawing.Point(72, 5);
            this.txtSeasonDescription.Name = "txtSeasonDescription";
            this.txtSeasonDescription.Size = new System.Drawing.Size(141, 20);
            this.txtSeasonDescription.TabIndex = 1;
            // 
            // lblSeasonDescription
            // 
            this.lblSeasonDescription.AutoSize = true;
            this.lblSeasonDescription.Location = new System.Drawing.Point(11, 8);
            this.lblSeasonDescription.Name = "lblSeasonDescription";
            this.lblSeasonDescription.Size = new System.Drawing.Size(60, 13);
            this.lblSeasonDescription.TabIndex = 2;
            this.lblSeasonDescription.Text = "Description";
            // 
            // btnUpdateSeason
            // 
            this.btnUpdateSeason.Location = new System.Drawing.Point(87, 32);
            this.btnUpdateSeason.Name = "btnUpdateSeason";
            this.btnUpdateSeason.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSeason.TabIndex = 3;
            this.btnUpdateSeason.Text = "Update";
            this.btnUpdateSeason.UseVisualStyleBackColor = true;
            this.btnUpdateSeason.Click += new System.EventHandler(this.btnUpdateSeason_Click);
            // 
            // btnDeleteSeason
            // 
            this.btnDeleteSeason.Location = new System.Drawing.Point(168, 32);
            this.btnDeleteSeason.Name = "btnDeleteSeason";
            this.btnDeleteSeason.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSeason.TabIndex = 4;
            this.btnDeleteSeason.Text = "Delete";
            this.btnDeleteSeason.UseVisualStyleBackColor = true;
            this.btnDeleteSeason.Click += new System.EventHandler(this.btnDeleteSeason_Click);
            // 
            // btnAddSeason
            // 
            this.btnAddSeason.Location = new System.Drawing.Point(6, 32);
            this.btnAddSeason.Name = "btnAddSeason";
            this.btnAddSeason.Size = new System.Drawing.Size(75, 23);
            this.btnAddSeason.TabIndex = 5;
            this.btnAddSeason.Text = "Add";
            this.btnAddSeason.UseVisualStyleBackColor = true;
            this.btnAddSeason.Click += new System.EventHandler(this.btnAddSeason_Click);
            // 
            // lstSeasons
            // 
            this.lstSeasons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescription,
            this.colSeasonId});
            this.lstSeasons.FullRowSelect = true;
            this.lstSeasons.Location = new System.Drawing.Point(6, 60);
            this.lstSeasons.MultiSelect = false;
            this.lstSeasons.Name = "lstSeasons";
            this.lstSeasons.Size = new System.Drawing.Size(342, 205);
            this.lstSeasons.TabIndex = 6;
            this.lstSeasons.UseCompatibleStateImageBehavior = false;
            this.lstSeasons.View = System.Windows.Forms.View.Details;
            this.lstSeasons.SelectedIndexChanged += new System.EventHandler(this.lstSeasons_SelectedIndexChanged);
            // 
            // colDescription
            // 
            this.colDescription.Text = "Description";
            this.colDescription.Width = 341;
            // 
            // colSeasonId
            // 
            this.colSeasonId.Text = "SeasonId";
            this.colSeasonId.Width = 0;
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpSeason);
            this.tcMain.Controls.Add(this.tpShowTypes);
            this.tcMain.Location = new System.Drawing.Point(6, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(363, 298);
            this.tcMain.TabIndex = 0;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // frmCustomize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 344);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customize Options";
            this.Load += new System.EventHandler(this.frmCustomize_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tpShowTypes.ResumeLayout(false);
            this.tpShowTypes.PerformLayout();
            this.tpSeason.ResumeLayout(false);
            this.tpSeason.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpSeason;
        private System.Windows.Forms.ListView lstSeasons;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colSeasonId;
        private System.Windows.Forms.TextBox txtSeasonDescription;
        private System.Windows.Forms.Button btnAddSeason;
        private System.Windows.Forms.Button btnDeleteSeason;
        private System.Windows.Forms.Button btnUpdateSeason;
        private System.Windows.Forms.Label lblSeasonDescription;
        private System.Windows.Forms.TabPage tpShowTypes;
        private System.Windows.Forms.ListView lstShowTypes;
        private System.Windows.Forms.ColumnHeader colShowTypeDescription;
        private System.Windows.Forms.ColumnHeader colShowTypeId;
        private System.Windows.Forms.TextBox txtShowType;
        private System.Windows.Forms.Button btnAddShowType;
        private System.Windows.Forms.Button btnDeleteShowType;
        private System.Windows.Forms.Button btnUpdateShowType;
        private System.Windows.Forms.Label lblShowType;
    }
}