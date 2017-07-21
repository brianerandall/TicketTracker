using System;
using System.Windows.Forms;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Repo;

namespace TicketTracker
{
    public partial class frmTicketDetails : Form
    {
        public event EventHandler SaveButtonClicked;

        private ListViewItem _ticketInfo;
        private bool _addingNewTicket;
        private int _performanceId;

        public frmTicketDetails()
        {
            _ticketInfo = null;
            _addingNewTicket = true;
            _performanceId = 0;

            InitializeComponent();
        }

        public frmTicketDetails(ListViewItem ticketInfo, bool addingNewTicket, int performanceId)
        {
            _ticketInfo = ticketInfo;
            _addingNewTicket = addingNewTicket;
            _performanceId = performanceId;

            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTicketDetails_Load(object sender, EventArgs e)
        {
            try
            {
                if (_ticketInfo != null)
                {
                    txtTicketDescription.Text = _ticketInfo.SubItems[0].Text;
                    txtAmountPerTicket.Text = _ticketInfo.SubItems[1].Text;
                    txtAmountSold.Text = _ticketInfo.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                Helper.LogError(ex);
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var ticketRepo = new TicketRepository();

                var ticketDescription = txtTicketDescription.Text;
                var price = Convert.ToDecimal(txtAmountPerTicket.Text);
                var amountSold = Convert.ToInt32(txtAmountSold.Text);

                try
                {
                    if (_addingNewTicket)
                    {
                        var ticketDto = new TicketDto();
                        ticketDto.PerformanceId = _performanceId;
                        ticketDto.Description = ticketDescription;
                        ticketDto.Price = price;
                        ticketDto.AmountSold = amountSold;

                        ticketRepo.Add(ticketDto);
                    }
                    else
                    {
                        var ticketId = Convert.ToInt32(_ticketInfo.SubItems[3].Text);

                        var ticketDto = ticketRepo.GetSingle(t => t.TicketId == ticketId);
                        ticketDto.Description = ticketDescription;
                        ticketDto.Price = price;
                        ticketDto.AmountSold = amountSold;

                        ticketRepo.Update(ticketDto);
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
        }

        private bool ValidateForm()
        {
            bool valid = false;
            bool descriptionValid = false;
            bool priceValid = false;
            bool amountSoldValid = false;

            decimal amountPerTicket;
            int amountSold;

            if (string.IsNullOrEmpty(txtTicketDescription.Text))
            {
                errorProvider.SetError(txtTicketDescription, "You must enter a value");
            }
            else
            {
                errorProvider.SetError(txtTicketDescription, string.Empty);
                descriptionValid = true;
            }

            if (!decimal.TryParse(txtAmountPerTicket.Text, out amountPerTicket))
            {
                errorProvider.SetError(txtAmountPerTicket, "You must enter a valid amount");
            }
            else
            {
                errorProvider.SetError(txtAmountPerTicket, string.Empty);
                priceValid = true;
            }

            if (!int.TryParse(txtAmountSold.Text, out amountSold))
            {
                errorProvider.SetError(txtAmountSold, "You must enter a valid amount");
            }
            else
            {
                errorProvider.SetError(txtAmountSold, string.Empty);
                amountSoldValid = true;
            }

            valid = descriptionValid && priceValid && amountSoldValid;

            return valid;
        }
    }
}
