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
            this.components = new System.ComponentModel.Container();
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnDeleteTicket = new System.Windows.Forms.Button();
            this.lblSeedMoney = new System.Windows.Forms.Label();
            this.txtSeedMoney = new System.Windows.Forms.TextBox();
            this.gbAmounts = new System.Windows.Forms.GroupBox();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.lblGrandTotal = new System.Windows.Forms.Label();
            this.txtTotalCreditCards = new System.Windows.Forms.TextBox();
            this.lblTotalCreditCards = new System.Windows.Forms.Label();
            this.txtTotalChecks = new System.Windows.Forms.TextBox();
            this.lblTotalChecks = new System.Windows.Forms.Label();
            this.txtCashTotal = new System.Windows.Forms.TextBox();
            this.lblCashTotal = new System.Windows.Forms.Label();
            this.txtHundredsCollected = new System.Windows.Forms.TextBox();
            this.lblHundredsCollected = new System.Windows.Forms.Label();
            this.txtFiftiesCollected = new System.Windows.Forms.TextBox();
            this.lblFiftiesCollected = new System.Windows.Forms.Label();
            this.txtTwentiesCollected = new System.Windows.Forms.TextBox();
            this.lblTwentiesCollected = new System.Windows.Forms.Label();
            this.txtTensCollected = new System.Windows.Forms.TextBox();
            this.lblTensCollected = new System.Windows.Forms.Label();
            this.txtFivesCollected = new System.Windows.Forms.TextBox();
            this.lblFivesCollected = new System.Windows.Forms.Label();
            this.txtOnesCollected = new System.Windows.Forms.TextBox();
            this.lblOnesCollected = new System.Windows.Forms.Label();
            this.txtChangeCollected = new System.Windows.Forms.TextBox();
            this.lblChangeCollected = new System.Windows.Forms.Label();
            this.gbMisc = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSquareFees = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblDonations = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblConcessionVouchers = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblStarVouchers = new System.Windows.Forms.Label();
            this.txtClassPasses = new System.Windows.Forms.TextBox();
            this.lblClassPasses = new System.Windows.Forms.Label();
            this.txtTicketSales = new System.Windows.Forms.TextBox();
            this.lblTicketSales = new System.Windows.Forms.Label();
            this.txtTotalCollected = new System.Windows.Forms.TextBox();
            this.lblTotalCollected = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.gbAmounts.SuspendLayout();
            this.gbMisc.SuspendLayout();
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
            this.lblTicketPrices.Location = new System.Drawing.Point(4, 259);
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
            this.lstTicketPrices.Location = new System.Drawing.Point(7, 275);
            this.lstTicketPrices.Name = "lstTicketPrices";
            this.lstTicketPrices.Size = new System.Drawing.Size(354, 97);
            this.lstTicketPrices.TabIndex = 4;
            this.lstTicketPrices.UseCompatibleStateImageBehavior = false;
            this.lstTicketPrices.View = System.Windows.Forms.View.Details;
            this.lstTicketPrices.DoubleClick += new System.EventHandler(this.lstTicketPrices_DoubleClick);
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
            this.btnAddTicket.Location = new System.Drawing.Point(6, 373);
            this.btnAddTicket.Name = "btnAddTicket";
            this.btnAddTicket.Size = new System.Drawing.Size(75, 23);
            this.btnAddTicket.TabIndex = 5;
            this.btnAddTicket.Text = "Add Ticket";
            this.btnAddTicket.UseVisualStyleBackColor = true;
            this.btnAddTicket.Click += new System.EventHandler(this.btnAddTicket_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(128, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(231, 491);
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
            // btnDeleteTicket
            // 
            this.btnDeleteTicket.Location = new System.Drawing.Point(87, 373);
            this.btnDeleteTicket.Name = "btnDeleteTicket";
            this.btnDeleteTicket.Size = new System.Drawing.Size(81, 23);
            this.btnDeleteTicket.TabIndex = 8;
            this.btnDeleteTicket.Text = "Delete Ticket";
            this.btnDeleteTicket.UseVisualStyleBackColor = true;
            this.btnDeleteTicket.Click += new System.EventHandler(this.btnDeleteTicket_Click);
            // 
            // lblSeedMoney
            // 
            this.lblSeedMoney.AutoSize = true;
            this.lblSeedMoney.Location = new System.Drawing.Point(7, 40);
            this.lblSeedMoney.Name = "lblSeedMoney";
            this.lblSeedMoney.Size = new System.Drawing.Size(70, 13);
            this.lblSeedMoney.TabIndex = 9;
            this.lblSeedMoney.Text = "Seed Money:";
            // 
            // txtSeedMoney
            // 
            this.txtSeedMoney.Location = new System.Drawing.Point(78, 37);
            this.txtSeedMoney.Name = "txtSeedMoney";
            this.txtSeedMoney.Size = new System.Drawing.Size(100, 20);
            this.txtSeedMoney.TabIndex = 10;
            this.txtSeedMoney.Validating += new System.ComponentModel.CancelEventHandler(this.txtSeedMoney_Validating);
            // 
            // gbAmounts
            // 
            this.gbAmounts.Controls.Add(this.txtGrandTotal);
            this.gbAmounts.Controls.Add(this.lblGrandTotal);
            this.gbAmounts.Controls.Add(this.txtTotalCreditCards);
            this.gbAmounts.Controls.Add(this.lblTotalCreditCards);
            this.gbAmounts.Controls.Add(this.txtTotalChecks);
            this.gbAmounts.Controls.Add(this.lblTotalChecks);
            this.gbAmounts.Controls.Add(this.txtCashTotal);
            this.gbAmounts.Controls.Add(this.lblCashTotal);
            this.gbAmounts.Controls.Add(this.txtHundredsCollected);
            this.gbAmounts.Controls.Add(this.lblHundredsCollected);
            this.gbAmounts.Controls.Add(this.txtFiftiesCollected);
            this.gbAmounts.Controls.Add(this.lblFiftiesCollected);
            this.gbAmounts.Controls.Add(this.txtTwentiesCollected);
            this.gbAmounts.Controls.Add(this.lblTwentiesCollected);
            this.gbAmounts.Controls.Add(this.txtTensCollected);
            this.gbAmounts.Controls.Add(this.lblTensCollected);
            this.gbAmounts.Controls.Add(this.txtFivesCollected);
            this.gbAmounts.Controls.Add(this.lblFivesCollected);
            this.gbAmounts.Controls.Add(this.txtOnesCollected);
            this.gbAmounts.Controls.Add(this.lblOnesCollected);
            this.gbAmounts.Controls.Add(this.txtChangeCollected);
            this.gbAmounts.Controls.Add(this.lblChangeCollected);
            this.gbAmounts.Location = new System.Drawing.Point(5, 67);
            this.gbAmounts.Name = "gbAmounts";
            this.gbAmounts.Size = new System.Drawing.Size(332, 170);
            this.gbAmounts.TabIndex = 11;
            this.gbAmounts.TabStop = false;
            this.gbAmounts.Text = "Cash/Check/Credit Cards";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Location = new System.Drawing.Point(245, 80);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(75, 20);
            this.txtGrandTotal.TabIndex = 21;
            // 
            // lblGrandTotal
            // 
            this.lblGrandTotal.AutoSize = true;
            this.lblGrandTotal.Location = new System.Drawing.Point(153, 83);
            this.lblGrandTotal.Name = "lblGrandTotal";
            this.lblGrandTotal.Size = new System.Drawing.Size(66, 13);
            this.lblGrandTotal.TabIndex = 20;
            this.lblGrandTotal.Text = "Grand Total:";
            // 
            // txtTotalCreditCards
            // 
            this.txtTotalCreditCards.Location = new System.Drawing.Point(245, 59);
            this.txtTotalCreditCards.Name = "txtTotalCreditCards";
            this.txtTotalCreditCards.Size = new System.Drawing.Size(75, 20);
            this.txtTotalCreditCards.TabIndex = 19;
            // 
            // lblTotalCreditCards
            // 
            this.lblTotalCreditCards.AutoSize = true;
            this.lblTotalCreditCards.Location = new System.Drawing.Point(152, 62);
            this.lblTotalCreditCards.Name = "lblTotalCreditCards";
            this.lblTotalCreditCards.Size = new System.Drawing.Size(94, 13);
            this.lblTotalCreditCards.TabIndex = 18;
            this.lblTotalCreditCards.Text = "Total Credit Cards:";
            // 
            // txtTotalChecks
            // 
            this.txtTotalChecks.Location = new System.Drawing.Point(245, 38);
            this.txtTotalChecks.Name = "txtTotalChecks";
            this.txtTotalChecks.Size = new System.Drawing.Size(75, 20);
            this.txtTotalChecks.TabIndex = 17;
            // 
            // lblTotalChecks
            // 
            this.lblTotalChecks.AutoSize = true;
            this.lblTotalChecks.Location = new System.Drawing.Point(152, 41);
            this.lblTotalChecks.Name = "lblTotalChecks";
            this.lblTotalChecks.Size = new System.Drawing.Size(73, 13);
            this.lblTotalChecks.TabIndex = 16;
            this.lblTotalChecks.Text = "Total Checks:";
            // 
            // txtCashTotal
            // 
            this.txtCashTotal.Location = new System.Drawing.Point(245, 17);
            this.txtCashTotal.Name = "txtCashTotal";
            this.txtCashTotal.ReadOnly = true;
            this.txtCashTotal.Size = new System.Drawing.Size(75, 20);
            this.txtCashTotal.TabIndex = 15;
            // 
            // lblCashTotal
            // 
            this.lblCashTotal.AutoSize = true;
            this.lblCashTotal.Location = new System.Drawing.Point(152, 20);
            this.lblCashTotal.Name = "lblCashTotal";
            this.lblCashTotal.Size = new System.Drawing.Size(61, 13);
            this.lblCashTotal.TabIndex = 14;
            this.lblCashTotal.Text = "Total Cash:";
            // 
            // txtHundredsCollected
            // 
            this.txtHundredsCollected.Location = new System.Drawing.Point(58, 143);
            this.txtHundredsCollected.Name = "txtHundredsCollected";
            this.txtHundredsCollected.Size = new System.Drawing.Size(75, 20);
            this.txtHundredsCollected.TabIndex = 13;
            // 
            // lblHundredsCollected
            // 
            this.lblHundredsCollected.AutoSize = true;
            this.lblHundredsCollected.Location = new System.Drawing.Point(-1, 147);
            this.lblHundredsCollected.Name = "lblHundredsCollected";
            this.lblHundredsCollected.Size = new System.Drawing.Size(56, 13);
            this.lblHundredsCollected.TabIndex = 12;
            this.lblHundredsCollected.Text = "Hundreds:";
            // 
            // txtFiftiesCollected
            // 
            this.txtFiftiesCollected.Location = new System.Drawing.Point(58, 122);
            this.txtFiftiesCollected.Name = "txtFiftiesCollected";
            this.txtFiftiesCollected.Size = new System.Drawing.Size(75, 20);
            this.txtFiftiesCollected.TabIndex = 11;
            // 
            // lblFiftiesCollected
            // 
            this.lblFiftiesCollected.AutoSize = true;
            this.lblFiftiesCollected.Location = new System.Drawing.Point(18, 126);
            this.lblFiftiesCollected.Name = "lblFiftiesCollected";
            this.lblFiftiesCollected.Size = new System.Drawing.Size(37, 13);
            this.lblFiftiesCollected.TabIndex = 10;
            this.lblFiftiesCollected.Text = "Fifties:";
            // 
            // txtTwentiesCollected
            // 
            this.txtTwentiesCollected.Location = new System.Drawing.Point(58, 101);
            this.txtTwentiesCollected.Name = "txtTwentiesCollected";
            this.txtTwentiesCollected.Size = new System.Drawing.Size(75, 20);
            this.txtTwentiesCollected.TabIndex = 9;
            // 
            // lblTwentiesCollected
            // 
            this.lblTwentiesCollected.AutoSize = true;
            this.lblTwentiesCollected.Location = new System.Drawing.Point(2, 105);
            this.lblTwentiesCollected.Name = "lblTwentiesCollected";
            this.lblTwentiesCollected.Size = new System.Drawing.Size(53, 13);
            this.lblTwentiesCollected.TabIndex = 8;
            this.lblTwentiesCollected.Text = "Twenties:";
            // 
            // txtTensCollected
            // 
            this.txtTensCollected.Location = new System.Drawing.Point(58, 80);
            this.txtTensCollected.Name = "txtTensCollected";
            this.txtTensCollected.Size = new System.Drawing.Size(75, 20);
            this.txtTensCollected.TabIndex = 7;
            // 
            // lblTensCollected
            // 
            this.lblTensCollected.AutoSize = true;
            this.lblTensCollected.Location = new System.Drawing.Point(21, 83);
            this.lblTensCollected.Name = "lblTensCollected";
            this.lblTensCollected.Size = new System.Drawing.Size(34, 13);
            this.lblTensCollected.TabIndex = 6;
            this.lblTensCollected.Text = "Tens:";
            // 
            // txtFivesCollected
            // 
            this.txtFivesCollected.Location = new System.Drawing.Point(58, 59);
            this.txtFivesCollected.Name = "txtFivesCollected";
            this.txtFivesCollected.Size = new System.Drawing.Size(75, 20);
            this.txtFivesCollected.TabIndex = 5;
            // 
            // lblFivesCollected
            // 
            this.lblFivesCollected.AutoSize = true;
            this.lblFivesCollected.Location = new System.Drawing.Point(20, 62);
            this.lblFivesCollected.Name = "lblFivesCollected";
            this.lblFivesCollected.Size = new System.Drawing.Size(35, 13);
            this.lblFivesCollected.TabIndex = 4;
            this.lblFivesCollected.Text = "Fives:";
            // 
            // txtOnesCollected
            // 
            this.txtOnesCollected.Location = new System.Drawing.Point(58, 38);
            this.txtOnesCollected.Name = "txtOnesCollected";
            this.txtOnesCollected.Size = new System.Drawing.Size(75, 20);
            this.txtOnesCollected.TabIndex = 3;
            // 
            // lblOnesCollected
            // 
            this.lblOnesCollected.AutoSize = true;
            this.lblOnesCollected.Location = new System.Drawing.Point(20, 41);
            this.lblOnesCollected.Name = "lblOnesCollected";
            this.lblOnesCollected.Size = new System.Drawing.Size(35, 13);
            this.lblOnesCollected.TabIndex = 2;
            this.lblOnesCollected.Text = "Ones:";
            // 
            // txtChangeCollected
            // 
            this.txtChangeCollected.Location = new System.Drawing.Point(58, 17);
            this.txtChangeCollected.Name = "txtChangeCollected";
            this.txtChangeCollected.Size = new System.Drawing.Size(75, 20);
            this.txtChangeCollected.TabIndex = 1;
            // 
            // lblChangeCollected
            // 
            this.lblChangeCollected.AutoSize = true;
            this.lblChangeCollected.Location = new System.Drawing.Point(8, 20);
            this.lblChangeCollected.Name = "lblChangeCollected";
            this.lblChangeCollected.Size = new System.Drawing.Size(47, 13);
            this.lblChangeCollected.TabIndex = 0;
            this.lblChangeCollected.Text = "Change:";
            // 
            // gbMisc
            // 
            this.gbMisc.Controls.Add(this.textBox1);
            this.gbMisc.Controls.Add(this.lblSquareFees);
            this.gbMisc.Controls.Add(this.textBox2);
            this.gbMisc.Controls.Add(this.lblDonations);
            this.gbMisc.Controls.Add(this.textBox3);
            this.gbMisc.Controls.Add(this.lblConcessionVouchers);
            this.gbMisc.Controls.Add(this.textBox4);
            this.gbMisc.Controls.Add(this.lblStarVouchers);
            this.gbMisc.Controls.Add(this.txtClassPasses);
            this.gbMisc.Controls.Add(this.lblClassPasses);
            this.gbMisc.Location = new System.Drawing.Point(343, 67);
            this.gbMisc.Name = "gbMisc";
            this.gbMisc.Size = new System.Drawing.Size(208, 170);
            this.gbMisc.TabIndex = 12;
            this.gbMisc.TabStop = false;
            this.gbMisc.Text = "Miscellaneous";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(125, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 20);
            this.textBox1.TabIndex = 19;
            // 
            // lblSquareFees
            // 
            this.lblSquareFees.AutoSize = true;
            this.lblSquareFees.Location = new System.Drawing.Point(51, 105);
            this.lblSquareFees.Name = "lblSquareFees";
            this.lblSquareFees.Size = new System.Drawing.Size(70, 13);
            this.lblSquareFees.TabIndex = 18;
            this.lblSquareFees.Text = "Square Fees:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(125, 80);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(75, 20);
            this.textBox2.TabIndex = 17;
            // 
            // lblDonations
            // 
            this.lblDonations.AutoSize = true;
            this.lblDonations.Location = new System.Drawing.Point(63, 83);
            this.lblDonations.Name = "lblDonations";
            this.lblDonations.Size = new System.Drawing.Size(58, 13);
            this.lblDonations.TabIndex = 16;
            this.lblDonations.Text = "Donations:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(125, 59);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(75, 20);
            this.textBox3.TabIndex = 15;
            // 
            // lblConcessionVouchers
            // 
            this.lblConcessionVouchers.AutoSize = true;
            this.lblConcessionVouchers.Location = new System.Drawing.Point(8, 62);
            this.lblConcessionVouchers.Name = "lblConcessionVouchers";
            this.lblConcessionVouchers.Size = new System.Drawing.Size(113, 13);
            this.lblConcessionVouchers.TabIndex = 14;
            this.lblConcessionVouchers.Text = "Concession Vouchers:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(125, 38);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(75, 20);
            this.textBox4.TabIndex = 13;
            // 
            // lblStarVouchers
            // 
            this.lblStarVouchers.AutoSize = true;
            this.lblStarVouchers.Location = new System.Drawing.Point(44, 41);
            this.lblStarVouchers.Name = "lblStarVouchers";
            this.lblStarVouchers.Size = new System.Drawing.Size(77, 13);
            this.lblStarVouchers.TabIndex = 12;
            this.lblStarVouchers.Text = "Star Vouchers:";
            // 
            // txtClassPasses
            // 
            this.txtClassPasses.Location = new System.Drawing.Point(125, 17);
            this.txtClassPasses.Name = "txtClassPasses";
            this.txtClassPasses.Size = new System.Drawing.Size(75, 20);
            this.txtClassPasses.TabIndex = 11;
            // 
            // lblClassPasses
            // 
            this.lblClassPasses.AutoSize = true;
            this.lblClassPasses.Location = new System.Drawing.Point(49, 20);
            this.lblClassPasses.Name = "lblClassPasses";
            this.lblClassPasses.Size = new System.Drawing.Size(72, 13);
            this.lblClassPasses.TabIndex = 10;
            this.lblClassPasses.Text = "Class Passes:";
            // 
            // txtTicketSales
            // 
            this.txtTicketSales.Location = new System.Drawing.Point(253, 37);
            this.txtTicketSales.Name = "txtTicketSales";
            this.txtTicketSales.ReadOnly = true;
            this.txtTicketSales.Size = new System.Drawing.Size(100, 20);
            this.txtTicketSales.TabIndex = 14;
            // 
            // lblTicketSales
            // 
            this.lblTicketSales.AutoSize = true;
            this.lblTicketSales.Location = new System.Drawing.Point(182, 40);
            this.lblTicketSales.Name = "lblTicketSales";
            this.lblTicketSales.Size = new System.Drawing.Size(69, 13);
            this.lblTicketSales.TabIndex = 13;
            this.lblTicketSales.Text = "Ticket Sales:";
            // 
            // txtTotalCollected
            // 
            this.txtTotalCollected.Location = new System.Drawing.Point(449, 37);
            this.txtTotalCollected.Name = "txtTotalCollected";
            this.txtTotalCollected.ReadOnly = true;
            this.txtTotalCollected.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCollected.TabIndex = 16;
            // 
            // lblTotalCollected
            // 
            this.lblTotalCollected.AutoSize = true;
            this.lblTotalCollected.Location = new System.Drawing.Point(356, 40);
            this.lblTotalCollected.Name = "lblTotalCollected";
            this.lblTotalCollected.Size = new System.Drawing.Size(93, 13);
            this.lblTotalCollected.TabIndex = 15;
            this.lblTotalCollected.Text = "Amount Collected:";
            // 
            // frmPerformanceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 524);
            this.Controls.Add(this.txtTotalCollected);
            this.Controls.Add(this.lblTotalCollected);
            this.Controls.Add(this.txtTicketSales);
            this.Controls.Add(this.lblTicketSales);
            this.Controls.Add(this.gbMisc);
            this.Controls.Add(this.gbAmounts);
            this.Controls.Add(this.txtSeedMoney);
            this.Controls.Add(this.lblSeedMoney);
            this.Controls.Add(this.btnDeleteTicket);
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
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.gbAmounts.ResumeLayout(false);
            this.gbAmounts.PerformLayout();
            this.gbMisc.ResumeLayout(false);
            this.gbMisc.PerformLayout();
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
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnDeleteTicket;
        private System.Windows.Forms.GroupBox gbAmounts;
        private System.Windows.Forms.TextBox txtHundredsCollected;
        private System.Windows.Forms.Label lblHundredsCollected;
        private System.Windows.Forms.TextBox txtFiftiesCollected;
        private System.Windows.Forms.Label lblFiftiesCollected;
        private System.Windows.Forms.TextBox txtTwentiesCollected;
        private System.Windows.Forms.Label lblTwentiesCollected;
        private System.Windows.Forms.TextBox txtTensCollected;
        private System.Windows.Forms.Label lblTensCollected;
        private System.Windows.Forms.TextBox txtFivesCollected;
        private System.Windows.Forms.Label lblFivesCollected;
        private System.Windows.Forms.TextBox txtOnesCollected;
        private System.Windows.Forms.Label lblOnesCollected;
        private System.Windows.Forms.TextBox txtChangeCollected;
        private System.Windows.Forms.Label lblChangeCollected;
        private System.Windows.Forms.TextBox txtSeedMoney;
        private System.Windows.Forms.Label lblSeedMoney;
        private System.Windows.Forms.TextBox txtTotalCollected;
        private System.Windows.Forms.Label lblTotalCollected;
        private System.Windows.Forms.TextBox txtTicketSales;
        private System.Windows.Forms.Label lblTicketSales;
        private System.Windows.Forms.GroupBox gbMisc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblSquareFees;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblDonations;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblConcessionVouchers;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblStarVouchers;
        private System.Windows.Forms.TextBox txtClassPasses;
        private System.Windows.Forms.Label lblClassPasses;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label lblGrandTotal;
        private System.Windows.Forms.TextBox txtTotalCreditCards;
        private System.Windows.Forms.Label lblTotalCreditCards;
        private System.Windows.Forms.TextBox txtTotalChecks;
        private System.Windows.Forms.Label lblTotalChecks;
        private System.Windows.Forms.TextBox txtCashTotal;
        private System.Windows.Forms.Label lblCashTotal;
    }
}