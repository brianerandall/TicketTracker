namespace TicketTracker
{
    partial class frmShowDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowDetails));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.lblSeason = new System.Windows.Forms.Label();
            this.cboSeason = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lstPerformances = new System.Windows.Forms.ListView();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPerformances = new System.Windows.Forms.Label();
            this.btnAddPerformances = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(7, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(161, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(214, 8);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type:";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(254, 4);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(152, 21);
            this.cboType.TabIndex = 3;
            // 
            // lblSeason
            // 
            this.lblSeason.AutoSize = true;
            this.lblSeason.Location = new System.Drawing.Point(419, 8);
            this.lblSeason.Name = "lblSeason";
            this.lblSeason.Size = new System.Drawing.Size(46, 13);
            this.lblSeason.TabIndex = 4;
            this.lblSeason.Text = "Season:";
            // 
            // cboSeason
            // 
            this.cboSeason.FormattingEnabled = true;
            this.cboSeason.Location = new System.Drawing.Point(470, 5);
            this.cboSeason.Name = "cboSeason";
            this.cboSeason.Size = new System.Drawing.Size(121, 21);
            this.cboSeason.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(317, 247);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstPerformances
            // 
            this.lstPerformances.FullRowSelect = true;
            this.lstPerformances.Location = new System.Drawing.Point(10, 72);
            this.lstPerformances.Name = "lstPerformances";
            this.lstPerformances.Size = new System.Drawing.Size(581, 118);
            this.lstPerformances.TabIndex = 8;
            this.lstPerformances.UseCompatibleStateImageBehavior = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(217, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPerformances
            // 
            this.lblPerformances.AutoSize = true;
            this.lblPerformances.Location = new System.Drawing.Point(8, 55);
            this.lblPerformances.Name = "lblPerformances";
            this.lblPerformances.Size = new System.Drawing.Size(98, 13);
            this.lblPerformances.TabIndex = 11;
            this.lblPerformances.Text = "Performance Dates";
            // 
            // btnAddPerformances
            // 
            this.btnAddPerformances.Location = new System.Drawing.Point(9, 191);
            this.btnAddPerformances.Name = "btnAddPerformances";
            this.btnAddPerformances.Size = new System.Drawing.Size(97, 23);
            this.btnAddPerformances.TabIndex = 13;
            this.btnAddPerformances.Text = "Add Performance";
            this.btnAddPerformances.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 283);
            this.Controls.Add(this.btnAddPerformances);
            this.Controls.Add(this.lblPerformances);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstPerformances);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cboSeason);
            this.Controls.Add(this.lblSeason);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Details";
            this.Load += new System.EventHandler(this.frmShowDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label lblSeason;
        private System.Windows.Forms.ComboBox cboSeason;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lstPerformances;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPerformances;
        private System.Windows.Forms.Button btnAddPerformances;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}