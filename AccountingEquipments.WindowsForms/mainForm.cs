using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingEquipments.WindowsForms.Data;
using AccountingEquipments.WindowsForms.Settings;
using AccountingEquipments.WindowsForms.Views;

namespace AccountingEquipments.WindowsForms
{
    public partial class mainForm : Form
    {
        private DataManager manager;
        public mainForm()
        {
            InitializeComponent();
            
            manager = new DataManager(Properties.Settings.Default["ApiUrl"].ToString());

            var view = new RetailEquipmentsView(manager, mainPanel);
            view.Anchor = Constants.FullScreenStyles;
            view.Width = mainPanel.Width;
            view.Height = mainPanel.Height;
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(view);
        }

        private async void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var view = new SuppliersView(manager, await manager.List<Supplier>("Suppliers"));
            view.Anchor = Constants.FullScreenStyles;
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(view);
        }

        private async void manufacturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var view = new ManufacturersView(manager, await manager.List<Manufacturer>("Manufacturers"));
            view.Anchor = Constants.FullScreenStyles;
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(view);
        }

        private async void equipmentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var view = new EquipmentTypesView(manager, await manager.List<EquipmentType>("EquipmentTypes"));
            view.Anchor = Constants.FullScreenStyles;
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(view);
        }

        private async void locationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var view = new LocationsView(manager, await manager.List<Location>("Locations"));
            view.Anchor = Constants.FullScreenStyles;
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(view);
        }

        private async void retailEquipmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var view = new RetailEquipmentsView(manager, mainPanel);
            view.Anchor = Constants.FullScreenStyles;
            view.Width = mainPanel.Width;
            view.Height = mainPanel.Height;
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(view);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void urlAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrlForm form = new UrlForm();
            form.ShowDialog();
        }

        private async void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = await manager.List<LocationHistory>("LocationHistory");
            var view = new HistoryView(data);
            view.Anchor = Constants.FullScreenStyles;
            view.Width = mainPanel.Width;
            view.Height = mainPanel.Height;
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.Add(view);
        }
    }
}
