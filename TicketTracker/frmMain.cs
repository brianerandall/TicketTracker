using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TicketTrackerRepo.Repo;
using TicketTrackerRepo.DTOs;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

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
                var seasons = repo.GetAllSeasons();
                
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
                var shows = repo.GetShowsBySeasonId(seasonId);

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
    }
}
