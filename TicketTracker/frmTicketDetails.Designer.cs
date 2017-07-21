namespace TicketTracker
{
    partial class frmTicketDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTicketDetails));
            this.lblTicketDescription = new System.Windows.Forms.Label();
            this.txtTicketDescription = new System.Windows.Forms.TextBox();
            this.lblAmountPerTicket = new System.Windows.Forms.Label();
            this.txtAmountPerTicket = new System.Windows.Forms.TextBox();
            this.lblAmountSold = new System.Windows.Forms.Label();
            this.txtAmountSold = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTicketDescription
            // 
            this.lblTicketDescription.AutoSize = true;
            this.lblTicketDescription.Location = new System.Drawing.Point(42, 13);
            this.lblTicketDescription.Name = "lblTicketDescription";
            this.lblTicketDescription.Size = new System.Drawing.Size(63, 13);
            this.lblTicketDescription.TabIndex = 0;
            this.lblTicketDescription.Text = "Description:";
            // 
            // txtTicketDescription
            // 
            this.txtTicketDescription.Location = new System.Drawing.Point(107, 10);
            this.txtTicketDescription.Name = "txtTicketDescription";
            this.txtTicketDescription.Size = new System.Drawing.Size(138, 20);
            this.txtTicketDescription.TabIndex = 1;
            // 
            // lblAmountPerTicket
            // 
            this.lblAmountPerTicket.AutoSize = true;
            this.lblAmountPerTicket.Location = new System.Drawing.Point(7, 42);
            this.lblAmountPerTicket.Name = "lblAmountPerTicket";
            this.lblAmountPerTicket.Size = new System.Drawing.Size(98, 13);
            this.lblAmountPerTicket.TabIndex = 2;
            this.lblAmountPerTicket.Text = "Amount Per Ticket:";
            // 
            // txtAmountPerTicket
            // 
            this.txtAmountPerTicket.Location = new System.Drawing.Point(107, 39);
            this.txtAmountPerTicket.Name = "txtAmountPerTicket";
            this.txtAmountPerTicket.Size = new System.Drawing.Size(102, 20);
            this.txtAmountPerTicket.TabIndex = 3;
            // 
            // lblAmountSold
            // 
            this.lblAmountSold.AutoSize = true;
            this.lblAmountSold.Location = new System.Drawing.Point(35, 69);
            this.lblAmountSold.Name = "lblAmountSold";
            this.lblAmountSold.Size = new System.Drawing.Size(70, 13);
            this.lblAmountSold.TabIndex = 4;
            this.lblAmountSold.Text = "Amount Sold:";
            // 
            // txtAmountSold
            // 
            this.txtAmountSold.Location = new System.Drawing.Point(107, 66);
            this.txtAmountSold.Name = "txtAmountSold";
            this.txtAmountSold.Size = new System.Drawing.Size(100, 20);
            this.txtAmountSold.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(37, 98);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(136, 98);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmTicketDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 133);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmountSold);
            this.Controls.Add(this.lblAmountSold);
            this.Controls.Add(this.txtAmountPerTicket);
            this.Controls.Add(this.lblAmountPerTicket);
            this.Controls.Add(this.txtTicketDescription);
            this.Controls.Add(this.lblTicketDescription);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTicketDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket Details";
            this.Load += new System.EventHandler(this.frmTicketDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTicketDescription;
        private System.Windows.Forms.TextBox txtTicketDescription;
        private System.Windows.Forms.Label lblAmountPerTicket;
        private System.Windows.Forms.TextBox txtAmountPerTicket;
        private System.Windows.Forms.Label lblAmountSold;
        private System.Windows.Forms.TextBox txtAmountSold;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}