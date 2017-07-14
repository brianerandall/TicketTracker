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
    public partial class frmShowDetails : Form
    {
        private ListViewItem _showInfo;
        private bool _addingNewShow;
        private frmMain _mainForm;

        public frmShowDetails()
        {
            InitializeComponent();

            _showInfo = null;
            _addingNewShow = true;
            _mainForm = null;
        }

        public frmShowDetails(ListViewItem showInfo, bool addingNewShow, frmMain mainForm)
        {
            InitializeComponent();

            _showInfo = showInfo;
            _addingNewShow = addingNewShow;
            _mainForm = mainForm;
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

                lstPerformances.Enabled = !_addingNewShow;
                lstTicketPrices.Enabled = !_addingNewShow;
                btnAddPerformances.Enabled = !_addingNewShow;
                btnAddPrices.Enabled = !_addingNewShow;
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
            if (_addingNewShow)
            {
                var showRepo = new ShowRepository();

                try
                {
                    var showDto = new ShowDto();
                    showDto.Title = txtName.Text;
                    showDto.ShowTypeId = Convert.ToInt32(cboType.SelectedValue);
                    showDto.SeasonId = Convert.ToInt32(cboSeason.SelectedValue);

                    showRepo.Add(showDto);

                    //_mainForm.
                }
                catch (Exception ex)
                {
                    Helper.LogError(ex);
                    throw ex;
                }
            }
            else
            { }
        }
    }
}
