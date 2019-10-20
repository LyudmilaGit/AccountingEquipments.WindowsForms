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
    public partial class RetailEquipmentView : UserControl
    {
        private string _controllerName = "RetailEquipments";
        private DataManager _manager;
        private Panel _mainPanel;
        private RetailEquipment _model;
        public RetailEquipmentView(DataManager manager, Panel mainPanel, RetailEquipment model)
        {
            _manager = manager;
            _model = model;
            _mainPanel = mainPanel;
            InitializeComponent();
            tbName.Text = model.Name;
            btnSave.Text = model.Id == 0 ? "Добавить" : "Сохранить";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) || cbEquipmentType.SelectedItem == null || cbManufacturer.SelectedItem == null ||
                cbSupplier.SelectedItem == null || cbLocation.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_model.Id == 0)
                {
                    var url = await _manager.Create(_controllerName, new RetailEquipment()
                    {
                        Name = tbName.Text,
                        LocationId = ((IEntityName)cbLocation.SelectedItem).Id,
                        SupplierId = ((IEntityName)cbSupplier.SelectedItem).Id,
                        EquipmentTypeId = ((IEntityName)cbEquipmentType.SelectedItem).Id,
                        ManufacturerId = ((IEntityName)cbManufacturer.SelectedItem).Id,
                    });
                    MessageBox.Show("Успешно создано", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await _manager.Update(_controllerName, _model.Id, new RetailEquipment()
                    {
                        Name = tbName.Text,
                        LocationId = ((IEntityName)cbLocation.SelectedItem).Id,
                        SupplierId = ((IEntityName)cbSupplier.SelectedItem).Id,
                        EquipmentTypeId = ((IEntityName)cbEquipmentType.SelectedItem).Id,
                        ManufacturerId = ((IEntityName)cbManufacturer.SelectedItem).Id,
                    });
                    MessageBox.Show("Успешно обновлено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                var view = new RetailEquipmentsView(_manager, _mainPanel);
                view.Anchor = Constants.FullScreenStyles;
                view.Width = _mainPanel.Width;
                view.Height = _mainPanel.Height;
                _mainPanel.Controls.Clear();
                _mainPanel.Controls.Add(view);
            }
           
        }

        private async void RetailEquipmentView_Load(object sender, EventArgs e)
        {
            var et = await _manager.List<EquipmentType>("EquipmentTypes");
            cbEquipmentType.Items.AddRange(et);
            var selectedIndex = cbEquipmentType.FindStringExact(_model.EquipmentType?.Name);
            cbEquipmentType.SelectedIndex = selectedIndex;

            var l = await _manager.List<Location>("Locations");
            cbLocation.Items.AddRange(l);
            selectedIndex = cbLocation.FindStringExact(_model.Location?.Name);
            cbLocation.SelectedIndex = selectedIndex;

            var m = await _manager.List<Manufacturer>("Manufacturers");
            cbManufacturer.Items.AddRange(m);
            selectedIndex = cbManufacturer.FindStringExact(_model.Manufacturer?.Name);
            cbManufacturer.SelectedIndex = selectedIndex;

            var s = await _manager.List<Supplier>("Suppliers");
            cbSupplier.Items.AddRange(s);
            selectedIndex = cbSupplier.FindStringExact(_model.Supplier?.Name);
            cbSupplier.SelectedIndex = selectedIndex;
        }
    }
}
