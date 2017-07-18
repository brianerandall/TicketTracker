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
    public partial class frmPerformanceDetails : Form
    {
        public event EventHandler SaveButtonClicked;

        private ListViewItem _priceInfo;
        private bool _addingNewPrice;

        public frmPerformanceDetails()
        {
            _priceInfo = null;
            _addingNewPrice = true;

            InitializeComponent();
        }

        public frmPerformanceDetails(ListViewItem priceInfo, bool addingNewPrice)
        {
            _priceInfo = priceInfo;
            _addingNewPrice = addingNewPrice;

            InitializeComponent();
        }

        private void frmShowPrices_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
