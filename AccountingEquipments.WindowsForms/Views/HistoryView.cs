using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingEquipments.WindowsForms.Data;

namespace AccountingEquipments.WindowsForms.Views
{
    public partial class HistoryView : UserControl
    {
        public HistoryView(LocationHistory[] data)
        {
            InitializeComponent();
            foreach (var locationHistory in data.OrderByDescending(o => o.Date))
            {
                dataGridView1.Rows.Add(locationHistory.Date.ToString("dd-MM-yyyy HH:mm"),
                    locationHistory.RetailEquipment?.Name,
                    locationHistory.FromLocation?.Name, locationHistory.ToLocation?.Name);
            }
        }

        private void HistoryView_Load(object sender, EventArgs e)
        {

        }
    }
}
