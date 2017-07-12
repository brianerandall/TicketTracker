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

                if (dt.Rows.Count > 0)
                {
                    cboSeason.SelectedValue = dt.Rows[0].Field<int>(0);
                    cboSeason_SelectedIndexChanged(cboSeason, new EventArgs());                    
                }
                
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
                var cmd = new SqlCommand("Select s.ShowId, st.Name, s.Title from dbo.Show s (NOLOCK) Inner Join dbo.ShowType st (NOLOCK) on s.ShowTypeId = st.ShowTypeId Where s.SeasonId = @SeasonId", con);
                cmd.Parameters.AddWithValue("@SeasonId", seasonId);
                showAdapter = new SqlDataAdapter(cmd);
                showAdapter.Fill(dt);

                foreach (DataRow show in dt.Rows)
                {
                    var item = new ListViewItem(show[2].ToString());
                    item.SubItems.Add(show[1].ToString());
                    item.SubItems.Add(show[0].ToString());

                    lstShows.Items.Add(item);
                }

                lstShows.View = View.Details;
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
