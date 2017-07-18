using System;
using System.Windows.Forms;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Repo;

namespace TicketTracker
{
    public partial class frmShowDetails : Form
    {
        public event EventHandler SaveButtonClicked;

        private ListViewItem _showInfo;
        private bool _addingNewShow;

        public frmShowDetails()
        {
            InitializeComponent();

            _showInfo = null;
            _addingNewShow = true;
        }

        public frmShowDetails(ListViewItem showInfo, bool addingNewShow)
        {
            InitializeComponent();

            _showInfo = showInfo;
            _addingNewShow = addingNewShow;
        }

        private void frmShowDetails_Load(object sender, EventArgs e)
        {
            try
            {
                var showTypeRepo = new ShowTypeRepository();
                var showTypes = showTypeRepo.GetAll();

                var seasonRepo = new SeasonRepository();
                var seasons = seasonRepo.GetAll();

                cboSeason.DisplayMember = "Description";
                cboSeason.ValueMember = "SeasonId";
                cboSeason.DataSource = seasons;

                cboType.DisplayMember = "Name";
                cboType.ValueMember = "ShowTypeId";
                cboType.DataSource = showTypes;

                if (_showInfo != null)
                {
                    cboType.SelectedIndex = cboType.FindStringExact(_showInfo.SubItems[1].Text);
                    cboSeason.SelectedIndex = cboSeason.FindStringExact(_showInfo.SubItems[3].Text);

                    txtName.Text = _showInfo.SubItems[0].Text;
                }

                LoadPerformanceInfo();

                lstPerformances.Enabled = !_addingNewShow;
                btnAddPerformances.Enabled = !_addingNewShow;
            }
            catch (Exception ex)
            {
                Helper.LogError(ex);
                throw ex;
            }
        }

        private void LoadPerformanceInfo()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Helper.LogError(ex);
                throw ex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var showRepo = new ShowRepository();

                var showTitle = txtName.Text;
                var showTypeId = Convert.ToInt32(cboType.SelectedValue);
                var seasonId = Convert.ToInt32(cboSeason.SelectedValue);

                try
                {
                    if (_addingNewShow)
                    {
                        var showDto = new ShowDto();
                        showDto.Title = showTitle;
                        showDto.ShowTypeId = showTypeId;
                        showDto.SeasonId = seasonId;

                        showRepo.Add(showDto);
                    }
                    else
                    {
                        var showId = Convert.ToInt32(_showInfo.SubItems[2].Text);

                        var showDto = showRepo.GetSingle(s => s.ShowId == showId);
                        showDto.Title = showTitle;
                        showDto.ShowTypeId = showTypeId;
                        showDto.SeasonId = seasonId;

                        showRepo.Update(showDto);
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
            bool showNameValid = false;
            bool showTypeValid = false;
            bool showSeasonValid = false;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider.SetError(txtName, "You must enter a value");
            }
            else
            {
                errorProvider.SetError(txtName, string.Empty);
                showNameValid = true;
            }

            if (cboSeason.SelectedItem == null)
            {
                errorProvider.SetError(cboSeason, "You must select a value");
            }
            else
            {
                errorProvider.SetError(cboSeason, string.Empty);
                showSeasonValid = true;
            }

            if (cboType.SelectedItem == null)
            {
                errorProvider.SetError(cboType, "You must select a value");
            }
            else
            {
                errorProvider.SetError(cboType, string.Empty);
                showTypeValid = true;
            }

            valid = showNameValid && showTypeValid && showSeasonValid;

            return valid;
        }

        void evtPerformanceButtonClicked(object sender, EventArgs e)
        {

        }

        private void btnAddPerformances_Click(object sender, EventArgs e)
        {
            var showDetails = new frmPerformanceDetails(null, true);
            showDetails.SaveButtonClicked += new EventHandler(evtPerformanceButtonClicked);
            showDetails.ShowDialog();
        }
    }
}
