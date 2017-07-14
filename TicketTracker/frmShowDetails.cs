using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketTracker
{
    public partial class frmShowDetails : Form
    {
        private int _showId;

        public frmShowDetails()
        {
            InitializeComponent();
        }

        public frmShowDetails(int showId)
        {
            InitializeComponent();

            _showId = showId;
        }

        private void frmShowDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
