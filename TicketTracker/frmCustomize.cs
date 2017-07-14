using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TicketTrackerRepo.DTOs;
using TicketTrackerRepo.Repo;

namespace TicketTracker
{
    public partial class frmCustomize : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketTrackerConnectionString"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter showTypeAdapter;
        SqlDataAdapter priceAdapter;
        int seasonId = 0;
        int showTypeId = 0;
        int priceId = 0;

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
                con.Open();
                var dt = new DataTable();

                switch (tcMain.SelectedIndex)
                {
                    case 0:
                        var repo = new SeasonRepository();
                        var seasons = repo.GetAllSeasons();

                        lstSeasons.Items.Clear();
                        foreach (var season in seasons)
                        {
                            var item = new ListViewItem(season.Description);
                            item.SubItems.Add(season.SeasonId.ToString());

                            lstSeasons.Items.Add(item);
                        }

                        break;
                    case 1:
                        showTypeAdapter = new SqlDataAdapter("Select * from dbo.ShowType", con);
                        showTypeAdapter.Fill(dt);
                        dgvShowType.DataSource = dt;
                        break;
                    case 2:
                        priceAdapter = new SqlDataAdapter("Select * from dbo.Price", con);
                        priceAdapter.Fill(dt);
                        dgvPrices.DataSource = dt;
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
                con.Close();
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



        private void dgvSeason_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seasonId = Convert.ToInt32(dgvSeason.Rows[e.RowIndex].Cells[0].Value.ToString());
            //txtSeasonDescription.Text = dgvSeason.Rows[e.RowIndex].Cells[1].Value.ToString();
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

        private void dgvShowType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            showTypeId = Convert.ToInt32(dgvShowType.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtShowType.Text = dgvShowType.Rows[e.RowIndex].Cells[1].Value.ToString();
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

                        var repo = new SeasonRepository();
                        repo.AddSeason(seasonDto);
                        
                        MessageBox.Show("Record successfully added.", "Add Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        cmd = new SqlCommand("Insert Into dbo.ShowType ([Name]) Values (@Name)", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@Name", txtShowType.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record successfully added.", "Add Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        cmd = new SqlCommand("Insert Into dbo.Price (Amount, [Description]) Values (@Amount, @Description)", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@Amount", udAmount.Value);
                        cmd.Parameters.AddWithValue("@Description", txtPriceDescription);
                        cmd.ExecuteNonQuery();
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
                con.Close();
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
                        var season = new SeasonDto();
                        season.SeasonId = seasonId;
                        season.Description = txtSeasonDescription.Text;

                        var repo = new SeasonRepository();
                        repo.UpdateSeason(season);

                        MessageBox.Show("Record successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        cmd = new SqlCommand("Update dbo.ShowType Set [Name] = @Name where ShowTypeId = @Id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@Id", showTypeId);
                        cmd.Parameters.AddWithValue("@Name", txtShowType.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record successfully updated.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        cmd = new SqlCommand("Update dbo.Price Set [Description] = @Description, Price = @Price where PriceId = @Id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@Id", priceId);
                        cmd.Parameters.AddWithValue("@Description", txtPriceDescription.Text);
                        cmd.Parameters.AddWithValue("@Price", udAmount.Value);
                        cmd.ExecuteNonQuery();
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
                con.Close();
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
                        var season = new SeasonDto();
                        season.SeasonId = seasonId;
                        season.Description = txtSeasonDescription.Text;

                        var repo = new SeasonRepository();
                        repo.DeleteSeason(season);

                        MessageBox.Show("Record successfully deleted.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1:
                        cmd = new SqlCommand("Delete from dbo.ShowType Where ShowTypeId = @Id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@Id", showTypeId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record successfully deleted.", "Delete Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        cmd = new SqlCommand("Delete from dbo.Price Where PriceId = @Id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@Id", priceId);
                        cmd.ExecuteNonQuery();
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
                con.Close();
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

        private void dgvPrices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            priceId = Convert.ToInt32(dgvPrices.Rows[e.RowIndex].Cells[0].Value.ToString());
            udAmount.Value = Convert.ToDecimal(dgvPrices.Rows[e.RowIndex].Cells[1].Value);
            txtPriceDescription.Text = dgvPrices.Rows[e.RowIndex].Cells[2].Value.ToString();
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
    }
}