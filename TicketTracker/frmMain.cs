using System;
using System.Data;
using System.Windows.Forms;
using TicketTrackerRepo.Repo;

namespace TicketTracker
{
    public partial class frmMain : Form
    {       
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                var repo = new SeasonRepository();
                var seasons = repo.GetAll();
                
                cboSeason.DisplayMember = "Description";
                cboSeason.ValueMember = "SeasonId";
                cboSeason.DataSource = seasons;

                if (seasons.Count > 0)
                {
                    cboSeason.SelectedValue = seasons[0].SeasonId;
                    cboSeason_SelectedIndexChanged(cboSeason, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customize = new frmCustomize();
            customize.ShowDialog();
        }

        private void cboSeason_SelectedIndexChanged(object sender, EventArgs e)
        {           
            int seasonId;
            if (cboSeason.SelectedValue.GetType() == typeof(DataRowView))
            {
                seasonId = 0;
            }
            else
            {
                seasonId = Convert.ToInt32(cboSeason.SelectedValue);
            }            
            
            try
            {
                var repo = new ShowRepository();
                var shows = repo.GetList(s => s.SeasonId == seasonId, s => s.ShowType, s => s.Season);

                lstShows.Items.Clear();
                foreach (var show in shows)
                {
                    var item = new ListViewItem(show.Title);
                    item.SubItems.Add(show.ShowType.Name);
                    item.SubItems.Add(show.ShowId.ToString());
                    item.SubItems.Add(show.Season.Description);
                    item.SubItems.Add(repo.GetTicketsSoldForShow(show.ShowId).ToString());
                    item.SubItems.Add(repo.GetAmountCollectedForShow(show.ShowId).ToString());

                    lstShows.Items.Add(item);
                }

                lstShows.View = View.Details;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
        }

        private void lstShows_DoubleClick(object sender, EventArgs e)
        {
            var showDetails = new frmShowDetails(((ListView)sender).FocusedItem, false);
            showDetails.SaveButtonClicked += new EventHandler(evtSaveButtonClicked);
            showDetails.ShowDialog();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var showDetails = new frmShowDetails(null, true);
            showDetails.SaveButtonClicked += new EventHandler(evtSaveButtonClicked);
            showDetails.ShowDialog();
        }

        void evtSaveButtonClicked(object sender, EventArgs e)
        {
            cboSeason_SelectedIndexChanged(cboSeason, new EventArgs());
        }

        private void btnDeleteShow_Click(object sender, EventArgs e)
        {
            if (lstShows.FocusedItem == null)
            {
                MessageBox.Show("You must choose a Show to Delete", "No Show Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("You are about to delete this show.  If you do, all details will be removed." + Environment.NewLine + Environment.NewLine + "Are you sure you still want to continue?", "Really Delete Show?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                var showId = Convert.ToInt32(lstShows.FocusedItem.SubItems[2].Text);

                try
                {
                    var showRepository = new ShowRepository();
                    showRepository.DeleteShow(showId);

                    cboSeason_SelectedIndexChanged(cboSeason, new EventArgs());
                }
                catch (Exception ex)
                {
                    Helper.LogError(ex);
                    throw;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
