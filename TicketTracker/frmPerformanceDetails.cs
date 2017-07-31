using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Repo;

namespace TicketTracker
{
    public partial class frmPerformanceDetails : Form
    {
        public event EventHandler SaveButtonClicked;

        private ListViewItem _performanceInfo;
        private bool _addingNewPerformance;
        private int _showId;
        private PerformanceRepository _performanceRepo = new PerformanceRepository();
        private TicketRepository _ticketRepo = new TicketRepository();

        public frmPerformanceDetails()
        {
            _performanceInfo = null;
            _addingNewPerformance = true;
            _showId = 0;

            InitializeComponent();
        }

        public frmPerformanceDetails(ListViewItem performanceInfo, bool addingNewPerformance, int showId)
        {
            _performanceInfo = performanceInfo;
            _addingNewPerformance = addingNewPerformance;
            _showId = showId;

            InitializeComponent();
        }

        void evtTicketButtonClicked(object sender, EventArgs e)
        {
            LoadTicketInfo();
            RecalculateAmounts();
        }

        private void AddHandlers()
        {
            foreach (var control in Controls)
            {
                if (control.GetType().Name == "TextBox")
                {
                    ((TextBox)control).Validating += new CancelEventHandler(OnTextboxValidating);
                }
                else
                {
                    if (control.GetType().Name == "GroupBox")
                    {
                        foreach (TextBox innerControl in ((GroupBox)control).Controls.OfType<TextBox>())
                        {
                            innerControl.Validating += new CancelEventHandler(OnTextboxValidating);
                        }
                    }
                }               
            }
        }

        protected void OnTextboxValidating(object sender, CancelEventArgs e)
        {
            string tag;

            if (((TextBox)sender).Tag == null)
            {
                tag = string.Empty;
            }
            else
            {
                tag = ((TextBox)sender).Tag.ToString();
            }            

            if (tag.Contains("Integer"))
            {
                ValidateIntegerAmount(sender, e);
            }
            else
            {
                ValidateDecimalAmount(sender, e);
            }

            RecalculateAmounts();
        }

        private void RecalculateAmounts()
        {
            decimal seedMoney;
            decimal changeCollected;
            decimal onesCollected;
            decimal fivesCollected;
            decimal tensCollected;
            decimal twentiesCollected;
            decimal fiftiesCollected;
            decimal hundredsCollected;
            decimal checksCollected;
            decimal creditCardsCollected;
            decimal ticketSales;           
            decimal totalCashCollected;
            decimal totalAmountCollected;

            if (_performanceInfo != null)
            {
                var performanceId = Convert.ToInt32(_performanceInfo.SubItems[4].Text);
                ticketSales = _performanceRepo.GetSingle(p => p.PerformanceId == performanceId, p => p.Tickets).Tickets.Sum(t => t.Price.GetValueOrDefault() * t.AmountSold.GetValueOrDefault());
            }
            else
            {
                ticketSales = 0M;
            }

            decimal.TryParse(txtSeedMoney.Text, out seedMoney);
            decimal.TryParse(txtChangeCollected.Text, out changeCollected);
            decimal.TryParse(txtOnesCollected.Text, out onesCollected);
            decimal.TryParse(txtFivesCollected.Text, out fivesCollected);
            decimal.TryParse(txtTensCollected.Text, out tensCollected);
            decimal.TryParse(txtTwentiesCollected.Text, out twentiesCollected);
            decimal.TryParse(txtFiftiesCollected.Text, out fiftiesCollected);
            decimal.TryParse(txtHundredsCollected.Text, out hundredsCollected);
            decimal.TryParse(txtTotalChecks.Text, out checksCollected);
            decimal.TryParse(txtTotalCreditCards.Text, out creditCardsCollected);

            totalCashCollected = changeCollected + onesCollected + fivesCollected + tensCollected + twentiesCollected + fiftiesCollected + hundredsCollected;
            totalAmountCollected = totalCashCollected + checksCollected + creditCardsCollected;
            
            txtTicketSales.Text = ticketSales.ToString("0.00");
            txtTotalCollected.Text = totalAmountCollected.ToString("0.00");
            txtCashTotal.Text = totalCashCollected.ToString("0.00");
            txtTotalChecks.Text = checksCollected.ToString("0.00");
            txtGrandTotal.Text = totalAmountCollected.ToString("0.00");
            txtDifference.Text = (totalAmountCollected - ticketSales).ToString("0.00");
        }

        private void ValidateDecimalAmount(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                TextBox tx = sender as TextBox;
                decimal test;
                if (!decimal.TryParse(tx.Text, out test))
                {
                    MessageBox.Show("Please enter a valid amount", "Amount Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else //this is the formatting line
                    tx.Text = test.ToString("0.00");
            }
        }

        private void ValidateIntegerAmount(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                TextBox tx = sender as TextBox;
                int test;
                if (!int.TryParse(tx.Text, out test))
                {
                    MessageBox.Show("Please enter a valid amount", "Amount Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
                else //this is the formatting line
                    tx.Text = test.ToString();
            }
        }

        private void frmShowPrices_Load(object sender, EventArgs e)
        {
            AddHandlers();

            if (_performanceInfo != null)
            {
                dtpPerformanceDate.Value = Convert.ToDateTime(_performanceInfo.SubItems[0].Text);

                var performanceId = Convert.ToInt32(_performanceInfo.SubItems[4].Text);
                var performance = _performanceRepo.GetSingle(p => p.PerformanceId == performanceId);

                txtSeedMoney.Text = performance.StartingCash.GetValueOrDefault().ToString("0.00");
                txtChangeCollected.Text = performance.ChangeCollected.GetValueOrDefault().ToString("0.00");
                txtOnesCollected.Text = performance.OnesCollected.GetValueOrDefault().ToString("0.00");
                txtFivesCollected.Text = performance.FivesCollected.GetValueOrDefault().ToString("0.00");
                txtTensCollected.Text = performance.TensCollected.GetValueOrDefault().ToString("0.00");
                txtTwentiesCollected.Text = performance.TwentiesCollected.GetValueOrDefault().ToString("0.00");
                txtFiftiesCollected.Text = performance.FiftiesCollected.GetValueOrDefault().ToString("0.00");
                txtHundredsCollected.Text = performance.HundredsCollected.GetValueOrDefault().ToString("0.00");
                txtTotalChecks.Text = performance.CheckAmount.GetValueOrDefault().ToString("0.00");
                txtTotalCreditCards.Text = performance.CreditCardAmount.GetValueOrDefault().ToString("0.00");
                txtSeasonPasses.Text = performance.SeasonPasses.GetValueOrDefault().ToString("0");
                txtClassPasses.Text = performance.ClassPasses.GetValueOrDefault().ToString("0");
                txtConcessionVouchers.Text = performance.ConcessionVoucherAmount.GetValueOrDefault().ToString("0.00");
                txtStarVouchers.Text = performance.StarVoucherAmount.GetValueOrDefault().ToString("0.00");
                txtDonations.Text = performance.Donations.GetValueOrDefault().ToString("0.00");
                txtSquareFees.Text = performance.CreditCardFees.GetValueOrDefault().ToString("0.00");
                txtMiscellaneous.Text = performance.Miscellaneous.GetValueOrDefault().ToString("0.00");

                LoadTicketInfo();
            }
            else
            {
                txtSeedMoney.Text = "0.00";
                txtChangeCollected.Text = "0.00";
                txtOnesCollected.Text = "0.00";
                txtFivesCollected.Text = "0.00";
                txtTensCollected.Text = "0.00";
                txtTwentiesCollected.Text = "0.00";
                txtFiftiesCollected.Text = "0.00";
                txtHundredsCollected.Text = "0.00";
                txtTotalChecks.Text = "0.00";
                txtTotalCreditCards.Text = "0.00";
                txtSeasonPasses.Text = "0";
                txtClassPasses.Text = "0";
                txtConcessionVouchers.Text = "0.00";
                txtStarVouchers.Text = "0.00";
                txtDonations.Text = "0.00";
                txtSquareFees.Text = "0.00";
                txtMiscellaneous.Text = "0.00";
            }

            RecalculateAmounts();

            lstTicketPrices.Enabled = !_addingNewPerformance;
            btnAddTicket.Enabled = !_addingNewPerformance;
            btnDeleteTicket.Enabled = !_addingNewPerformance;
        }

        private void LoadTicketInfo()
        {
            try
            {
                var performanceId = Convert.ToInt32(_performanceInfo.SubItems[4].Text);

                var tickets = _ticketRepo.GetList(t => t.PerformanceId == performanceId);

                lstTicketPrices.Items.Clear();
                foreach (var ticket in tickets)
                {
                    var item = new ListViewItem(ticket.Description);
                    item.SubItems.Add(ticket.Price.ToString());
                    item.SubItems.Add(ticket.AmountSold.ToString());
                    item.SubItems.Add(ticket.TicketId.ToString());

                    lstTicketPrices.Items.Add(item);
                }

                lstTicketPrices.View = View.Details;

            }
            catch (Exception ex)
            {
                Helper.LogError(ex);
                throw ex;
            }         
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {
            var ticketDetails = new frmTicketDetails(null, true, Convert.ToInt32(_performanceInfo.SubItems[4].Text));
            ticketDetails.SaveButtonClicked += new EventHandler(evtTicketButtonClicked);
            ticketDetails.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(this, e);
            }

            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var performanceDate = dtpPerformanceDate.Value;
                var changeCollected = Convert.ToDecimal(txtChangeCollected.Text);
                var onesCollected = Convert.ToDecimal(txtOnesCollected.Text);
                var fivesCollected = Convert.ToDecimal(txtFivesCollected.Text);
                var tensCollected = Convert.ToDecimal(txtTensCollected.Text);
                var twentiesCollected = Convert.ToDecimal(txtTwentiesCollected.Text);
                var fiftiesCollected = Convert.ToDecimal(txtFiftiesCollected.Text);
                var hundredsCollected = Convert.ToDecimal(txtHundredsCollected.Text);
                var checkAmount = Convert.ToDecimal(txtTotalChecks.Text);
                var creditCardAmount = Convert.ToDecimal(txtTotalCreditCards.Text);
                var startingCash = Convert.ToDecimal(txtSeedMoney.Text);
                var seasonPasses = Convert.ToInt32(txtSeasonPasses.Text);
                var classPasses = Convert.ToInt32(txtClassPasses.Text);
                var starVoucherAmount = Convert.ToDecimal(txtStarVouchers.Text);
                var concesstionVoucherAmount = Convert.ToDecimal(txtConcessionVouchers.Text);
                var donations = Convert.ToDecimal(txtDonations.Text);
                var miscellaneous = Convert.ToDecimal(txtMiscellaneous.Text);
                var creditCardFees = Convert.ToDecimal(txtSquareFees.Text);


                try
                {
                    if (_addingNewPerformance)
                    {
                        var performanceDto = new PerformanceDto();
                        performanceDto.ShowId = _showId;
                        performanceDto.Date = performanceDate;
                        performanceDto.ChangeCollected = changeCollected;
                        performanceDto.OnesCollected = onesCollected;
                        performanceDto.FivesCollected = fivesCollected;
                        performanceDto.TensCollected = tensCollected;
                        performanceDto.TwentiesCollected = twentiesCollected;
                        performanceDto.FiftiesCollected = fiftiesCollected;
                        performanceDto.HundredsCollected = hundredsCollected;
                        performanceDto.CheckAmount = checkAmount;
                        performanceDto.CreditCardAmount = creditCardAmount;
                        performanceDto.StartingCash = startingCash;
                        performanceDto.SeasonPasses = seasonPasses;
                        performanceDto.ClassPasses = classPasses;
                        performanceDto.StarVoucherAmount = starVoucherAmount;
                        performanceDto.ConcessionVoucherAmount = concesstionVoucherAmount;
                        performanceDto.Donations = donations;
                        performanceDto.Miscellaneous = miscellaneous;
                        performanceDto.CreditCardFees = creditCardFees;

                        _performanceRepo.Add(performanceDto);
                    }
                    else
                    {
                        var performanceId = Convert.ToInt32(_performanceInfo.SubItems[4].Text.ToString());

                        var performanceDto = _performanceRepo.GetSingle(p => p.PerformanceId == performanceId);
                        performanceDto.Date = performanceDate;
                        performanceDto.ChangeCollected = changeCollected;
                        performanceDto.OnesCollected = onesCollected;
                        performanceDto.FivesCollected = fivesCollected;
                        performanceDto.TensCollected = tensCollected;
                        performanceDto.TwentiesCollected = twentiesCollected;
                        performanceDto.FiftiesCollected = fiftiesCollected;
                        performanceDto.HundredsCollected = hundredsCollected;
                        performanceDto.CheckAmount = checkAmount;
                        performanceDto.CreditCardAmount = creditCardAmount;
                        performanceDto.StartingCash = startingCash;
                        performanceDto.SeasonPasses = seasonPasses;
                        performanceDto.ClassPasses = classPasses;
                        performanceDto.StarVoucherAmount = starVoucherAmount;
                        performanceDto.ConcessionVoucherAmount = concesstionVoucherAmount;
                        performanceDto.Donations = donations;
                        performanceDto.Miscellaneous = miscellaneous;
                        performanceDto.CreditCardFees = creditCardFees;

                        _performanceRepo.Update(performanceDto);
                    }

                    if (SaveButtonClicked != null)
                    {
                        SaveButtonClicked(this, e);
                    }

                    this.Close();
                }
                catch (Exception ex)
                {
                    Helper.LogError(ex);
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("Please correct all errors", "Errors Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            bool valid = false;
            bool performanceDateValid = false;

            if (string.IsNullOrEmpty(dtpPerformanceDate.Text) || dtpPerformanceDate.Value == null)
            {
                errorProvider.SetError(dtpPerformanceDate, "You must enter a value");
            }
            else
            {
                errorProvider.SetError(dtpPerformanceDate, string.Empty);
                performanceDateValid = true;
            }

            valid = performanceDateValid;

            return valid;
        }

        private void lstTicketPrices_DoubleClick(object sender, EventArgs e)
        {
            var ticketDetails = new frmTicketDetails(((ListView)sender).FocusedItem, false, Convert.ToInt32(_performanceInfo.SubItems[4].Text));
            ticketDetails.SaveButtonClicked += new EventHandler(evtTicketButtonClicked);
            ticketDetails.ShowDialog();
        }

        private void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            if (lstTicketPrices.FocusedItem == null)
            {
                MessageBox.Show("You must choose a Ticket to Delete", "No Ticket Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("You are about to delete this ticket.  If you do, all details will be removed." + Environment.NewLine + Environment.NewLine + "Are you sure you still want to continue?", "Really Delete Ticket?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                var ticketId = Convert.ToInt32(lstTicketPrices.FocusedItem.SubItems[3].Text);

                try
                {
                    var ticket = _ticketRepo.GetSingle(t => t.TicketId == ticketId);

                    _ticketRepo.Remove(ticket);

                    LoadTicketInfo();
                    RecalculateAmounts();
                }
                catch (Exception ex)
                {
                    Helper.LogError(ex);
                    throw;
                }
            }
        }
    }
}
