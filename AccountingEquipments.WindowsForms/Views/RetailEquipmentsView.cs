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
using AccountingEquipments.WindowsForms.Settings;

namespace AccountingEquipments.WindowsForms.Views
{
    public partial class RetailEquipmentsView : UserControl
    {
        private DataManager _manager;
        private Panel _mainPanel;
        public RetailEquipmentsView(DataManager manager, Panel mainPanel)
        {
            _mainPanel = mainPanel;
            _manager = manager;
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var view = new RetailEquipmentView(_manager, _mainPanel, new RetailEquipment()
            {
                Id = 0,
            });
            view.Anchor = Constants.FullScreenStyles;
            view.Width = _mainPanel.Width;
            view.Height = _mainPanel.Height;
            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(view);
        }

        private async void RetailEquipmentsView_Load(object sender, EventArgs e)
        {
            var retailEquipments = await _manager.List<RetailEquipment>("RetailEquipments");
            foreach (var retailEquipment in retailEquipments)
            {
                dataGridView1.Rows.Add(retailEquipment.Id, retailEquipment.Name, retailEquipment.Supplier?.Name,
                    retailEquipment.Manufacturer?.Name, retailEquipment.Location?.Name, "Edit"
                );
            }
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_Edit"].Index)
            {
                int id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                var retailEquipment = await _manager.Get<RetailEquipment>("RetailEquipments", id);
                var view = new RetailEquipmentView(_manager, _mainPanel, retailEquipment);
                view.Anchor = Constants.FullScreenStyles;
                view.Width = _mainPanel.Width;
                view.Height = _mainPanel.Height;
                _mainPanel.Controls.Clear();
                _mainPanel.Controls.Add(view);
            }
        }
    }
}
