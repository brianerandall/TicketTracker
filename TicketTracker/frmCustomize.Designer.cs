﻿namespace TicketTracker
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpSeason = new System.Windows.Forms.TabPage();
            this.btnAddSeason = new System.Windows.Forms.Button();
            this.btnDeleteSeason = new System.Windows.Forms.Button();
            this.btnUpdateSeason = new System.Windows.Forms.Button();
            this.lblSeasonDescription = new System.Windows.Forms.Label();
            this.txtSeasonDescription = new System.Windows.Forms.TextBox();
            this.dgvSeason = new System.Windows.Forms.DataGridView();
            this.tpShowTypes = new System.Windows.Forms.TabPage();
            this.btnAddShowType = new System.Windows.Forms.Button();
            this.btnDeleteShowType = new System.Windows.Forms.Button();
            this.btnUpdateShowType = new System.Windows.Forms.Button();
            this.lblShowType = new System.Windows.Forms.Label();
            this.txtShowType = new System.Windows.Forms.TextBox();
            this.dgvShowType = new System.Windows.Forms.DataGridView();
            this.tpPrices = new System.Windows.Forms.TabPage();
            this.udAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.btnAddPrice = new System.Windows.Forms.Button();
            this.btnDeletePrice = new System.Windows.Forms.Button();
            this.btnUpdatePrice = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtPriceDescription = new System.Windows.Forms.TextBox();
            this.dgvPrices = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lstSeasons = new System.Windows.Forms.ListView();
            this.colDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeasonId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tcMain.SuspendLayout();
            this.tpSeason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeason)).BeginInit();
            this.tpShowTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowType)).BeginInit();
            this.tpPrices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpSeason);
            this.tcMain.Controls.Add(this.tpShowTypes);
            this.tcMain.Controls.Add(this.tpPrices);
            this.tcMain.Location = new System.Drawing.Point(6, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(363, 512);
            this.tcMain.TabIndex = 0;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tpSeason
            // 
            this.tpSeason.Controls.Add(this.lstSeasons);
            this.tpSeason.Controls.Add(this.btnAddSeason);
            this.tpSeason.Controls.Add(this.btnDeleteSeason);
            this.tpSeason.Controls.Add(this.btnUpdateSeason);
            this.tpSeason.Controls.Add(this.lblSeasonDescription);
            this.tpSeason.Controls.Add(this.txtSeasonDescription);
            this.tpSeason.Controls.Add(this.dgvSeason);
            this.tpSeason.Location = new System.Drawing.Point(4, 22);
            this.tpSeason.Name = "tpSeason";
            this.tpSeason.Padding = new System.Windows.Forms.Padding(3);
            this.tpSeason.Size = new System.Drawing.Size(355, 486);
            this.tpSeason.TabIndex = 0;
            this.tpSeason.Text = "Seasons";
            this.tpSeason.UseVisualStyleBackColor = true;
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
            // lblSeasonDescription
            // 
            this.lblSeasonDescription.AutoSize = true;
            this.lblSeasonDescription.Location = new System.Drawing.Point(11, 8);
            this.lblSeasonDescription.Name = "lblSeasonDescription";
            this.lblSeasonDescription.Size = new System.Drawing.Size(60, 13);
            this.lblSeasonDescription.TabIndex = 2;
            this.lblSeasonDescription.Text = "Description";
            // 
            // txtSeasonDescription
            // 
            this.txtSeasonDescription.Location = new System.Drawing.Point(72, 5);
            this.txtSeasonDescription.Name = "txtSeasonDescription";
            this.txtSeasonDescription.Size = new System.Drawing.Size(141, 20);
            this.txtSeasonDescription.TabIndex = 1;
            // 
            // dgvSeason
            // 
            this.dgvSeason.AllowUserToAddRows = false;
            this.dgvSeason.AllowUserToDeleteRows = false;
            this.dgvSeason.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeason.Location = new System.Drawing.Point(6, 61);
            this.dgvSeason.Name = "dgvSeason";
            this.dgvSeason.ReadOnly = true;
            this.dgvSeason.Size = new System.Drawing.Size(344, 137);
            this.dgvSeason.TabIndex = 0;
            this.dgvSeason.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeason_CellClick);
            // 
            // tpShowTypes
            // 
            this.tpShowTypes.Controls.Add(this.btnAddShowType);
            this.tpShowTypes.Controls.Add(this.btnDeleteShowType);
            this.tpShowTypes.Controls.Add(this.btnUpdateShowType);
            this.tpShowTypes.Controls.Add(this.lblShowType);
            this.tpShowTypes.Controls.Add(this.txtShowType);
            this.tpShowTypes.Controls.Add(this.dgvShowType);
            this.tpShowTypes.Location = new System.Drawing.Point(4, 22);
            this.tpShowTypes.Name = "tpShowTypes";
            this.tpShowTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tpShowTypes.Size = new System.Drawing.Size(355, 486);
            this.tpShowTypes.TabIndex = 1;
            this.tpShowTypes.Text = "Show Types";
            this.tpShowTypes.UseVisualStyleBackColor = true;
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
            // lblShowType
            // 
            this.lblShowType.AutoSize = true;
            this.lblShowType.Location = new System.Drawing.Point(11, 8);
            this.lblShowType.Name = "lblShowType";
            this.lblShowType.Size = new System.Drawing.Size(61, 13);
            this.lblShowType.TabIndex = 8;
            this.lblShowType.Text = "Show Type";
            // 
            // txtShowType
            // 
            this.txtShowType.Location = new System.Drawing.Point(72, 5);
            this.txtShowType.Name = "txtShowType";
            this.txtShowType.Size = new System.Drawing.Size(141, 20);
            this.txtShowType.TabIndex = 7;
            // 
            // dgvShowType
            // 
            this.dgvShowType.AllowUserToAddRows = false;
            this.dgvShowType.AllowUserToDeleteRows = false;
            this.dgvShowType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowType.Location = new System.Drawing.Point(6, 61);
            this.dgvShowType.Name = "dgvShowType";
            this.dgvShowType.ReadOnly = true;
            this.dgvShowType.Size = new System.Drawing.Size(343, 136);
            this.dgvShowType.TabIndex = 6;
            this.dgvShowType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowType_CellClick);
            // 
            // tpPrices
            // 
            this.tpPrices.Controls.Add(this.udAmount);
            this.tpPrices.Controls.Add(this.lblAmount);
            this.tpPrices.Controls.Add(this.btnAddPrice);
            this.tpPrices.Controls.Add(this.btnDeletePrice);
            this.tpPrices.Controls.Add(this.btnUpdatePrice);
            this.tpPrices.Controls.Add(this.lblDescription);
            this.tpPrices.Controls.Add(this.txtPriceDescription);
            this.tpPrices.Controls.Add(this.dgvPrices);
            this.tpPrices.Location = new System.Drawing.Point(4, 22);
            this.tpPrices.Name = "tpPrices";
            this.tpPrices.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrices.Size = new System.Drawing.Size(355, 486);
            this.tpPrices.TabIndex = 2;
            this.tpPrices.Text = "Prices";
            this.tpPrices.UseVisualStyleBackColor = true;
            // 
            // udAmount
            // 
            this.udAmount.DecimalPlaces = 2;
            this.udAmount.Location = new System.Drawing.Point(268, 6);
            this.udAmount.Name = "udAmount";
            this.udAmount.Size = new System.Drawing.Size(82, 20);
            this.udAmount.TabIndex = 20;
            this.udAmount.ThousandsSeparator = true;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(221, 8);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 19;
            this.lblAmount.Text = "Amount";
            // 
            // btnAddPrice
            // 
            this.btnAddPrice.Location = new System.Drawing.Point(6, 32);
            this.btnAddPrice.Name = "btnAddPrice";
            this.btnAddPrice.Size = new System.Drawing.Size(75, 23);
            this.btnAddPrice.TabIndex = 17;
            this.btnAddPrice.Text = "Add";
            this.btnAddPrice.UseVisualStyleBackColor = true;
            this.btnAddPrice.Click += new System.EventHandler(this.btnAddPrice_Click);
            // 
            // btnDeletePrice
            // 
            this.btnDeletePrice.Location = new System.Drawing.Point(168, 32);
            this.btnDeletePrice.Name = "btnDeletePrice";
            this.btnDeletePrice.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePrice.TabIndex = 16;
            this.btnDeletePrice.Text = "Delete";
            this.btnDeletePrice.UseVisualStyleBackColor = true;
            this.btnDeletePrice.Click += new System.EventHandler(this.btnDeletePrice_Click);
            // 
            // btnUpdatePrice
            // 
            this.btnUpdatePrice.Location = new System.Drawing.Point(87, 32);
            this.btnUpdatePrice.Name = "btnUpdatePrice";
            this.btnUpdatePrice.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatePrice.TabIndex = 15;
            this.btnUpdatePrice.Text = "Update";
            this.btnUpdatePrice.UseVisualStyleBackColor = true;
            this.btnUpdatePrice.Click += new System.EventHandler(this.btnUpdatePrice_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(11, 8);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Description";
            // 
            // txtPriceDescription
            // 
            this.txtPriceDescription.Location = new System.Drawing.Point(73, 5);
            this.txtPriceDescription.Name = "txtPriceDescription";
            this.txtPriceDescription.Size = new System.Drawing.Size(141, 20);
            this.txtPriceDescription.TabIndex = 13;
            // 
            // dgvPrices
            // 
            this.dgvPrices.AllowUserToAddRows = false;
            this.dgvPrices.AllowUserToDeleteRows = false;
            this.dgvPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrices.Location = new System.Drawing.Point(6, 61);
            this.dgvPrices.Name = "dgvPrices";
            this.dgvPrices.ReadOnly = true;
            this.dgvPrices.Size = new System.Drawing.Size(343, 135);
            this.dgvPrices.TabIndex = 12;
            this.dgvPrices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrices_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(145, 545);
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
            // lstSeasons
            // 
            this.lstSeasons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescription,
            this.colSeasonId});
            this.lstSeasons.FullRowSelect = true;
            this.lstSeasons.Location = new System.Drawing.Point(7, 205);
            this.lstSeasons.MultiSelect = false;
            this.lstSeasons.Name = "lstSeasons";
            this.lstSeasons.Size = new System.Drawing.Size(341, 205);
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
            // frmCustomize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 577);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcMain);
            this.Name = "frmCustomize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customize Options";
            this.Load += new System.EventHandler(this.frmCustomize_Load);
            this.tcMain.ResumeLayout(false);
            this.tpSeason.ResumeLayout(false);
            this.tpSeason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeason)).EndInit();
            this.tpShowTypes.ResumeLayout(false);
            this.tpShowTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowType)).EndInit();
            this.tpPrices.ResumeLayout(false);
            this.tpPrices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpSeason;
        private System.Windows.Forms.DataGridView dgvSeason;
        private System.Windows.Forms.TabPage tpShowTypes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSeasonDescription;
        private System.Windows.Forms.TextBox txtSeasonDescription;
        private System.Windows.Forms.Button btnAddSeason;
        private System.Windows.Forms.Button btnDeleteSeason;
        private System.Windows.Forms.Button btnUpdateSeason;
        private System.Windows.Forms.Button btnAddShowType;
        private System.Windows.Forms.Button btnDeleteShowType;
        private System.Windows.Forms.Button btnUpdateShowType;
        private System.Windows.Forms.Label lblShowType;
        private System.Windows.Forms.TextBox txtShowType;
        private System.Windows.Forms.DataGridView dgvShowType;
        private System.Windows.Forms.TabPage tpPrices;
        private System.Windows.Forms.Button btnAddPrice;
        private System.Windows.Forms.Button btnDeletePrice;
        private System.Windows.Forms.Button btnUpdatePrice;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtPriceDescription;
        private System.Windows.Forms.DataGridView dgvPrices;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.NumericUpDown udAmount;
        private System.Windows.Forms.ListView lstSeasons;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colSeasonId;
    }
}