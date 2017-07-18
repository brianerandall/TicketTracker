using System;
using System.Windows.Forms;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Repo;

namespace TicketTracker
{
    public partial class frmCustomize : Form
    {
        int seasonId = 0;
        int showTypeId = 0;

        SeasonRepository seasonRepo = new SeasonRepository();
        ShowTypeRepository showTypeRepo = new ShowTypeRepository();

        public frmCustomize()
        {
            InitializeComponent();
        }

        private void frmCustomize_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            try
            {
                switch (tcMain.SelectedIndex)
                {
                    case 0:
                        var seasons = seasonRepo.GetAll();

                        lstSeasons.Items.Clear();
                        foreach (var season in seasons)
                        {
                            var item = new ListViewItem(season.Description);
                            item.SubItems.Add(season.SeasonId.ToString());

                            lstSeasons.Items.Add(item);
                        }

                        break;
                    case 1:
                        var showTypes = showTypeRepo.GetAll();

                        lstShowTypes.Items.Clear();
                        foreach (var showType in showTypes)
                        {
                            var item = new ListViewItem(showType.Name);
                            item.SubItems.Add(showType.ShowTypeId.ToString());

                            lstShowTypes.Items.Add(item);
                        }

                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
        }

        private void ClearData()
        {
            switch (tcMain.SelectedIndex)
            {
                case 0:
                    txtSeasonDescription.Text = string.Empty;
                    seasonId = 0;
                    errorProvider.SetError(txtSeasonDescription, string.Empty);
                    break;
                case 1:
                    txtShowType.Text = string.Empty;
                    showTypeId = 0;
                    errorProvider.SetError(txtShowType, string.Empty);
                    break;
                default:
                    break;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateSeason_Click(object sender, EventArgs e)
        {
            if (ValidateForm(tcMain.SelectedIndex))
            {
                UpdateRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please correct all errors", "Errors Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteSeason_Click(object sender, EventArgs e)
        {
            if (seasonId != 0)
            {
                DeleteRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("You must choose a record to delete", "Choose A Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSeason_Click(object sender, EventArgs e)
        {
            if (ValidateForm(tcMain.SelectedIndex))
            {
                AddRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please correct all errors", "Errors Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnAddShowType_Click(object sender, EventArgs e)
        {
            if (ValidateForm(tcMain.SelectedIndex))
            {
                AddRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please correct all errors", "Errors Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateShowType_Click(object sender, EventArgs e)
        {
            if (ValidateForm(tcMain.SelectedIndex))
            {
                UpdateRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please correct all errors", "Errors Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteShowType_Click(object sender, EventArgs e)
        {
            if (showTypeId != 0)
            {
                DeleteRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("You must choose a record to delete", "Choose A Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRecord(int pageIndex)
        {
            try
            {
                switch (pageIndex)
                {
                    case 0:
                        var seasonDto = new SeasonDto();
                        seasonDto.Description = txtSeasonDescription.Text;

                        seasonRepo.Add(seasonDto);
                        
                        MessageBox.Show("Record successfully added.", "Add Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        var showTypeDto = new ShowTypeDto();
                        showTypeDto.Name = txtShowType.Text;

                        showTypeRepo.Add(showTypeDto);

                        MessageBox.Show("Record successfully added.", "Add Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
            finally
            {
                DisplayData();
                ClearData();
            }
        }

        private void UpdateRecord(int pageIndex)
        {
            try
            {
                switch (pageIndex)
                {
                    case 0:
                        var seasonDto = new SeasonDto();
                        seasonDto.SeasonId = seasonId;
                        seasonDto.Description = txtSeasonDescription.Text;

                        seasonRepo.Update(seasonDto);

                        MessageBox.Show("Record successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        var showTypeDto = new ShowTypeDto();
                        showTypeDto.ShowTypeId = showTypeId;
                        showTypeDto.Name = txtShowType.Text;

                        showTypeRepo.Update(showTypeDto);

                        MessageBox.Show("Record successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
            finally
            {
                DisplayData();
                ClearData();
            }
        }

        private void DeleteRecord(int pageIndex)
        {
            try
            {
                switch (pageIndex)
                {
                    case 0:
                        var seasonDto = new SeasonDto();
                        seasonDto.SeasonId = seasonId;
                        seasonDto.Description = txtSeasonDescription.Text;

                        seasonRepo.Remove(seasonDto);

                        MessageBox.Show("Record successfully deleted.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        var showTypeDto = new ShowTypeDto();
                        showTypeDto.ShowTypeId = showTypeId;
                        showTypeDto.Name = txtShowType.Name;

                        showTypeRepo.Remove(showTypeDto);

                        MessageBox.Show("Record successfully deleted.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
            finally
            {
                DisplayData();
                ClearData();
            }
        }

        private void btnAddPrice_Click(object sender, EventArgs e)
        {
            if (ValidateForm(tcMain.SelectedIndex))
            {
                AddRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please correct all errors", "Errors Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void btnUpdatePrice_Click(object sender, EventArgs e)
        {
            if (ValidateForm(tcMain.SelectedIndex))
            {
                UpdateRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please correct all errors", "Errors Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm(int tabIndex)
        {
            bool valid = false;
            bool seasonDescriptionValid = false;
            bool showTypeDescriptionValid = false;

            switch (tabIndex)
            {
                case 0:
                    if (string.IsNullOrEmpty(txtSeasonDescription.Text))
                    {
                        errorProvider.SetError(txtSeasonDescription, "You must enter a value");
                    }
                    else
                    {
                        errorProvider.SetError(txtSeasonDescription, string.Empty);
                        seasonDescriptionValid = true;
                    }

                    valid = seasonDescriptionValid;

                    break;
                case 1:
                    if (string.IsNullOrEmpty(txtShowType.Text))
                    {
                        errorProvider.SetError(txtShowType, "You must enter a value");
                    }
                    else
                    {
                        errorProvider.SetError(txtShowType, string.Empty);
                        showTypeDescriptionValid = true;
                    }

                    valid = showTypeDescriptionValid;
                    break;
                default:
                    break;
            }

            return valid;
        }

        private void lstSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSeasons.SelectedItems.Count > 0)
            {
                seasonId = Convert.ToInt32(lstSeasons.SelectedItems[0].SubItems[1].Text);
                txtSeasonDescription.Text = lstSeasons.SelectedItems[0].Text;
            }
        }

        private void lstShowTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstShowTypes.SelectedItems.Count > 0)
            {
                showTypeId = Convert.ToInt32(lstShowTypes.SelectedItems[0].SubItems[1].Text);
                txtShowType.Text = lstShowTypes.SelectedItems[0].Text;
            }
        }
    }
}