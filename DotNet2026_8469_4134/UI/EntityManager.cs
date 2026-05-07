using BlApi;
using BO;
using DalApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class EntityManager : Form
    {
        // DataGridView is declared in the designer partial class. Configure it after InitializeComponent.
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get;
        static readonly BlApi.ICustomer s_customer = s_bl.Customer;

        // use a BindingSource so UI updates and binding contracts are handled correctly
        private readonly BindingSource _bindingSource = new BindingSource();

        public EntityManager()
        {
            InitializeComponent();
            // configure the designer DataGridView
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = true;

            // bind the grid to the binding source once and reuse it
            dataGridView1.DataSource = _bindingSource;
        }

        private void EntityManager_Load(object sender, EventArgs e)
        {
            BindCustomers();
        }

        //delete
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Customer selected)
            {
                // שאלה למשתמש
                var result = MessageBox.Show(
                    "האם למחוק את הפריט?",
                    "מחיקה",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    s_customer.Delete(selected.Id);
                    RefreshList();
                }
            }
            else
            {
                MessageBox.Show("לא נבחר פריט למחיקה");
            }
        }

        //add
        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new CustomerForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var created = form.Result;
                        s_customer.Create(created);
                        RefreshList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // kept for designer compatibility; selection handled via DataGridView
        }

        //update
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Customer selected)
            {
                using (var form = new CustomerForm(selected))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        try
                        {
                            var updated = form.Result;
                            s_customer.Update(updated);
                            RefreshList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("לא נבחר פריט לעדכון");
            }
        }

        private void RefreshList()
        {
            BindCustomers();
        }

        private void BindCustomers()
        {
            // get items already ordered by Id, then expose them via a BindingList so the grid is bound to an IBindingList
            var list = s_customer.ReadAll(x => true).OrderBy(c => c.Id).ToList();
            _bindingSource.DataSource = new BindingList<Customer>(list);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var list = s_customer.ReadAll(x => x.Phone.Length < 5).OrderBy(c => c.Id).ToList();
            _bindingSource.DataSource = new BindingList<Customer>(list);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
