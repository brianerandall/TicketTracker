using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TicketTracker
{
    public partial class frmMain : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TicketTrackerConnectionString"].ConnectionString);
        SqlDataAdapter seasonAdapter;
        SqlDataAdapter showAdapter;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var dt = new DataTable();
                seasonAdapter = new SqlDataAdapter("select * from dbo.Season", con);
                seasonAdapter.Fill(dt);
                cboSeason.DataSource = dt;
                cboSeason.DisplayMember = "Description";
                cboSeason.ValueMember = "SeasonId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                
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
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                var dt = new DataTable();
                var cmd = new SqlCommand("Select * from dbo.Season Where SeasonId = @SeasonId", con);
                cmd.Parameters.AddWithValue("@SeasonId", seasonId);
                showAdapter = new SqlDataAdapter(cmd);
                showAdapter.Fill(dt);

                foreach (var show in dt.Rows)
                {
                    dgvShows.Rows.Add(show);
                }


                dgvShows.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error Occurred - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Helper.LogError(ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
