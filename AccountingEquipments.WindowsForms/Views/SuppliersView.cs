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
using static System.Windows.Forms.ComboBox;

namespace AccountingEquipments.WindowsForms.Views
{
    public partial class SuppliersView : UserControl
    {
        private DataManager _manager;
        public SuppliersView(DataManager manager, Supplier[] items)
        {
            _manager = manager;
            InitializeComponent();
            lbItems.Items.AddRange(items);
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            var view = new SupplierView(_manager, lbItems, new Supplier() { Id = 0 });
            view.Anchor = Constants.FullScreenStyles;
            view.Width = this.rightPanel.Width;
            this.rightPanel.Controls.Clear();
            this.rightPanel.Controls.Add(view);
        }

        private void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = (Supplier) lbItems.Items[lbItems.SelectedIndex];
            var view = new SupplierView(_manager, lbItems, selected);
            view.Anchor = Constants.FullScreenStyles;
            view.Width = this.rightPanel.Width;
            this.rightPanel.Controls.Clear();
            this.rightPanel.Controls.Add(view);
        }
    }
}
