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
    public partial class frmShowPrices : Form
    {
        public event EventHandler SaveButtonClicked;

        private ListViewItem _priceInfo;
        private bool _addingNewPrice;

        public frmShowPrices()
        {
            _priceInfo = null;
            _addingNewPrice = true;

            InitializeComponent();
        }

        public frmShowPrices(ListViewItem priceInfo, bool addingNewPrice)
        {
            _priceInfo = priceInfo;
            _addingNewPrice = addingNewPrice;

            InitializeComponent();
        }

        private void frmShowPrices_Load(object sender, EventArgs e)
        {

        }
    }
}
