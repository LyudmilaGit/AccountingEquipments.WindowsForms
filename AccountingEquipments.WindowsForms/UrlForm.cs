using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingEquipments.WindowsForms
{
    public partial class UrlForm : Form
    {
        public UrlForm()
        {
            InitializeComponent();
            tbUrl.Text = Properties.Settings.Default["ApiUrl"].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["ApiUrl"] = tbUrl.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
