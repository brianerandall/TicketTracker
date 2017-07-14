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
                var shows = repo.GetList(s => s.SeasonId == seasonId, s => s.ShowType);

                lstShows.Items.Clear();
                foreach (var show in shows)
                {
                    var item = new ListViewItem(show.Title);
                    item.SubItems.Add(show.ShowType.Name);
                    item.SubItems.Add(show.ShowId.ToString());

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
            var showDetails = new frmShowDetails(Convert.ToInt32(((ListView)sender).FocusedItem.SubItems[2].Text));
            showDetails.ShowDialog();
        }
    }
}
