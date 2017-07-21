﻿using System;
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
        }

        private void frmShowPrices_Load(object sender, EventArgs e)
        {
            if (_performanceInfo != null)
            {
                dtpPerformanceDate.Value = Convert.ToDateTime(_performanceInfo.SubItems[0].Text);
            }

            LoadTicketInfo();
        }

        private void LoadTicketInfo()
        {
            try
            {
                var performanceId = Convert.ToInt32(_performanceInfo.SubItems[4].Text);

                var repo = new TicketRepository();
                var tickets = repo.GetList(t => t.PerformanceId == performanceId);

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
                var performanceRepo = new PerformanceRepository();

                var performanceDate = dtpPerformanceDate.Value;

                try
                {
                    if (_addingNewPerformance)
                    {
                        var performanceDto = new PerformanceDto();
                        performanceDto.ShowId = _showId;
                        performanceDto.Date = performanceDate;
                        performanceDto.ChangeCollected = 0;
                        performanceDto.OnesCollected = 0;
                        performanceDto.FivesCollected = 0;
                        performanceDto.TensCollected = 0;
                        performanceDto.TwentiesCollected = 0;
                        performanceDto.FiftiesCollected = 0;
                        performanceDto.HundredsCollected = 0;
                        performanceDto.CheckAmount = 0;
                        performanceDto.CreditCardAmount = 0;
                        performanceDto.StartingCash = 0;
                        performanceDto.ClassPasses = 0;
                        performanceDto.StarVoucherAmount = 0;
                        performanceDto.ConcessionVoucherAmount = 0;
                        performanceDto.Donations = 0;
                        performanceDto.Miscellaneous = 0;
                        performanceDto.CreditCardFees = 0;
                        performanceDto.SeasonPasses = 0;

                        performanceRepo.Add(performanceDto);
                    }
                    else
                    {
                        var performanceId = Convert.ToInt32(_performanceInfo.SubItems[4].ToString());

                        var performanceDto = performanceRepo.GetSingle(p => p.PerformanceId == performanceId);
                        performanceDto.ShowId = _showId;
                        performanceDto.Date = performanceDate;
                        performanceDto.ChangeCollected = 0;
                        performanceDto.OnesCollected = 0;
                        performanceDto.FivesCollected = 0;
                        performanceDto.TensCollected = 0;
                        performanceDto.TwentiesCollected = 0;
                        performanceDto.FiftiesCollected = 0;
                        performanceDto.HundredsCollected = 0;
                        performanceDto.CheckAmount = 0;
                        performanceDto.CreditCardAmount = 0;
                        performanceDto.StartingCash = 0;
                        performanceDto.ClassPasses = 0;
                        performanceDto.StarVoucherAmount = 0;
                        performanceDto.ConcessionVoucherAmount = 0;
                        performanceDto.Donations = 0;
                        performanceDto.Miscellaneous = 0;
                        performanceDto.CreditCardFees = 0;
                        performanceDto.SeasonPasses = 0;

                        performanceRepo.Update(performanceDto);
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
                    var ticketRepository = new TicketRepository();
                    var ticket = ticketRepository.GetSingle(t => t.TicketId == ticketId);

                    ticketRepository.Remove(ticket);

                    LoadTicketInfo();
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
