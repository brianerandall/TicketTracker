namespace TicketTracker
{
    partial class frmPerformanceDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerformanceDetails));
            this.lblPerformanceDate = new System.Windows.Forms.Label();
            this.dtpPerformanceDate = new System.Windows.Forms.DateTimePicker();
            this.lblTicketPrices = new System.Windows.Forms.Label();
            this.lstTicketPrices = new System.Windows.Forms.ListView();
            this.colTicketDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPricePerTicket = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmountSold = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTicketId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddTicket = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPerformanceDate
            // 
            this.lblPerformanceDate.AutoSize = true;
            this.lblPerformanceDate.Location = new System.Drawing.Point(4, 8);
            this.lblPerformanceDate.Name = "lblPerformanceDate";
            this.lblPerformanceDate.Size = new System.Drawing.Size(96, 13);
            this.lblPerformanceDate.TabIndex = 0;
            this.lblPerformanceDate.Text = "Performance Date:";
            // 
            // dtpPerformanceDate
            // 
            this.dtpPerformanceDate.CustomFormat = "MM/dd/yyyy hh:mm tt";
            this.dtpPerformanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPerformanceDate.Location = new System.Drawing.Point(101, 5);
            this.dtpPerformanceDate.Name = "dtpPerformanceDate";
            this.dtpPerformanceDate.Size = new System.Drawing.Size(149, 20);
            this.dtpPerformanceDate.TabIndex = 1;
            // 
            // lblTicketPrices
            // 
            this.lblTicketPrices.AutoSize = true;
            this.lblTicketPrices.Location = new System.Drawing.Point(4, 30);
            this.lblTicketPrices.Name = "lblTicketPrices";
            this.lblTicketPrices.Size = new System.Drawing.Size(69, 13);
            this.lblTicketPrices.TabIndex = 3;
            this.lblTicketPrices.Text = "Ticket Prices";
            // 
            // lstTicketPrices
            // 
            this.lstTicketPrices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTicketDescription,
            this.colPricePerTicket,
            this.colAmountSold,
            this.colTicketId});
            this.lstTicketPrices.FullRowSelect = true;
            this.lstTicketPrices.Location = new System.Drawing.Point(7, 46);
            this.lstTicketPrices.Name = "lstTicketPrices";
            this.lstTicketPrices.Size = new System.Drawing.Size(354, 97);
            this.lstTicketPrices.TabIndex = 4;
            this.lstTicketPrices.UseCompatibleStateImageBehavior = false;
            this.lstTicketPrices.View = System.Windows.Forms.View.Details;
            // 
            // colTicketDescription
            // 
            this.colTicketDescription.Text = "Description";
            this.colTicketDescription.Width = 150;
            // 
            // colPricePerTicket
            // 
            this.colPricePerTicket.Text = "Price Per Ticket";
            this.colPricePerTicket.Width = 100;
            // 
            // colAmountSold
            // 
            this.colAmountSold.Text = "Amount Sold";
            this.colAmountSold.Width = 100;
            // 
            // colTicketId
            // 
            this.colTicketId.Text = "Ticket Id";
            this.colTicketId.Width = 0;
            // 
            // btnAddTicket
            // 
            this.btnAddTicket.Location = new System.Drawing.Point(6, 144);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.Size = new System.Drawing.Size(75, 23);
            this.btnAddTicket.TabIndex = 5;
            this.btnAddTicket.Text = "Add Ticket";
            this.btnAddTicket.UseVisualStyleBackColor = true;
            this.btnAddTicket.Click += new System.EventHandler(this.btnAddTicket_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(128, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(231, 227);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPerformanceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 262);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddTicket);
            this.Controls.Add(this.lstTicketPrices);
            this.Controls.Add(this.lblTicketPrices);
            this.Controls.Add(this.dtpPerformanceDate);
            this.Controls.Add(this.lblPerformanceDate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPerformanceDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Performance Details";
            this.Load += new System.EventHandler(this.frmShowPrices_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPerformanceDate;
        private System.Windows.Forms.DateTimePicker dtpPerformanceDate;
        private System.Windows.Forms.Label lblTicketPrices;
        private System.Windows.Forms.ListView lstTicketPrices;
        private System.Windows.Forms.ColumnHeader colTicketDescription;
        private System.Windows.Forms.ColumnHeader colAmountSold;
        private System.Windows.Forms.ColumnHeader colTicketId;
        private System.Windows.Forms.Button btnAddTicket;
        private System.Windows.Forms.ColumnHeader colPricePerTicket;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}