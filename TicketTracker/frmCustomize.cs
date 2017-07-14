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
        int priceId = 0;

        SeasonRepository seasonRepo = new SeasonRepository();
        ShowTypeRepository showTypeRepo = new ShowTypeRepository();
        PriceRepository priceRepo = new PriceRepository(); 

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
                    case 2:
                        var prices = priceRepo.GetAll();

                        lstPrices.Items.Clear();
                        foreach (var price in prices)
                        {
                            var item = new ListViewItem(price.Description);
                            item.SubItems.Add(price.Amount.Value.ToString());
                            item.SubItems.Add(price.PriceId.ToString());

                            lstPrices.Items.Add(item);
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
                case 2:
                    udAmount.Value = 0M;
                    txtPriceDescription.Text = string.Empty;
                    priceId = 0;
                    errorProvider.SetError(txtPriceDescription, string.Empty);
                    errorProvider.SetError(udAmount, string.Empty);
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
                    case 2:
                        var priceDto = new PriceDto();
                        priceDto.Amount = udAmount.Value;
                        priceDto.Description = txtPriceDescription.Text;

                        priceRepo.Add(priceDto);

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
                    case 2:
                        var priceDto = new PriceDto();
                        priceDto.PriceId = priceId;
                        priceDto.Amount = udAmount.Value;
                        priceDto.Description = txtPriceDescription.Text;

                        priceRepo.Update(priceDto);

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
                    case 2:
                        var priceDto = new PriceDto();
                        priceDto.PriceId = priceId;
                        priceDto.Amount = udAmount.Value;
                        priceDto.Description = txtPriceDescription.Text;

                        priceRepo.Remove(priceDto);

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
            bool priceDescriptionValid = false;
            bool priceValid = false;
            bool seasonDescription = false;
            bool showTypeDescription = false;

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
                        seasonDescription = true;
                    }

                    valid = seasonDescription;

                    break;
                case 1:
                    if (string.IsNullOrEmpty(txtShowType.Text))
                    {
                        errorProvider.SetError(txtShowType, "You must enter a value");
                    }
                    else
                    {
                        errorProvider.SetError(txtShowType, string.Empty);
                        showTypeDescription = true;
                    }

                    valid = showTypeDescription;
                    break;
                case 2:
                    if (string.IsNullOrEmpty(txtPriceDescription.Text))
                    {
                        errorProvider.SetError(txtPriceDescription, "You must enter a value");
                    }
                    else
                    {
                        errorProvider.SetError(txtPriceDescription, string.Empty);
                        priceDescriptionValid = true;
                    }

                    if (udAmount.Value == 0M)
                    {
                        errorProvider.SetError(udAmount, "You must enter a dollar amount");
                    }
                    else
                    {
                        errorProvider.SetError(udAmount, string.Empty);
                        priceValid = true;
                    }

                    valid = priceDescriptionValid && priceValid;
                    
                    break;
                default:
                    break;
            }

            return valid;
        }

        private void btnDeletePrice_Click(object sender, EventArgs e)
        {
            if (priceId != 0)
            {
                DeleteRecord(tcMain.SelectedIndex);
            }
            else
            {
                MessageBox.Show("You must select a record to delete", "Select A Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void lstPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPrices.SelectedItems.Count > 0)
            {
                priceId = Convert.ToInt32(lstPrices.SelectedItems[0].SubItems[2].Text);
                udAmount.Value = Convert.ToDecimal(lstPrices.SelectedItems[0].SubItems[1].Text);
                txtPriceDescription.Text = lstPrices.SelectedItems[0].SubItems[0].Text;
            }
        }
    }
}