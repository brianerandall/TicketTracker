using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void frmShowPrices_Load(object sender, EventArgs e)
        {
            if (_performanceInfo != null)
            {
                dtpPerformanceDate.Value = Convert.ToDateTime(_performanceInfo.SubItems[0].Text);
            }
        }

        private void btnAddTicket_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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
            return true;
        }
    }
}
