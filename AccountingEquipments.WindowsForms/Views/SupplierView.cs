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
    public partial class SupplierView : UserControl
    {
        private string _controllerName = "Suppliers";
        private DataManager _manager;
        private ListBox _lbItems;
        private Supplier _model;
        public SupplierView(DataManager manager, ListBox lbItems, Supplier model)
        {
            _manager = manager;
            _model = model;
            _lbItems = lbItems;
            InitializeComponent();
            tbName.Text = model.Name;
            tbEmail.Text = model.Email;
            tbPhone.Text = model.Phone;
            btnSave.Text = model.Id == 0 ? "Добавить" : "Сохранить";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Наименование обязательное для заполнения", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                if (_model.Id == 0)
                {
                    var url = await _manager.Create(_controllerName, new Supplier()
                    {
                        Name = tbName.Text,
                        Email = tbEmail.Text,
                        Phone = tbPhone.Text
                    });
                    MessageBox.Show("Успешно создано", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    await _manager.Update(_controllerName, _model.Id, new Supplier()
                    {
                        Name = tbName.Text,
                        Email = tbEmail.Text,
                        Phone = tbPhone.Text
                    });
                    MessageBox.Show("Успешно обновлено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            _lbItems.Items.Clear();
            _lbItems.Items.AddRange(await _manager.List<Supplier>("Suppliers"));
        }
    }
}
