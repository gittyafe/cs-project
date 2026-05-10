using BlApi;
using BO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class CustomerManager : Form
    {
        static readonly IBl s_bl = BlApi.Factory.Get;
        static readonly ICustomer s_customer = s_bl.Customer;

        private readonly BindingSource _bindingSource = new BindingSource();

        public CustomerManager()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = true;

            // bind the grid to the binding source (same pattern as ProductManager)
            dataGridView1.DataSource = _bindingSource;
        }

        private void CustomerManager_Load(object sender, EventArgs e)
        {
            BindCustomers();
        }

        private void BindCustomers()
        {
            var items = s_customer.ReadAll(x => true).OrderBy(c => c.Id).ToList();
            _bindingSource.DataSource = new BindingList<Customer>(items);
        }

        // add
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
                        BindCustomers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // delete
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Customer selected)
            {
                var result = MessageBox.Show("האם למחוק את הפריט?", "מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    s_customer.Delete(selected.Id);
                    BindCustomers();
                }
            }
            else
            {
                MessageBox.Show("לא נבחר פריט למחיקה");
            }
        }

        // update
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
                            BindCustomers();
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

        // filter (toggle by button text)
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "סינון הלקוחות עם מספר טלפון לא תקין")
            {
                var items = s_customer.ReadAll(x => true)
                    .Where(c => string.IsNullOrWhiteSpace(c.Phone) || c.Phone.Length < 9)
                    .OrderBy(c => c.Id)
                    .ToList();
                _bindingSource.DataSource = new BindingList<Customer>(items);
                button4.Text = "הצג הכל";
            }
            else
            {
                button4.Text = "סינון הלקוחות עם מספר טלפון לא תקין";
                BindCustomers();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                BindCustomers();
                return;
            }
            var item = s_customer.Read(x => x.Id.ToString() == textBox1.Text);
            if (item != null)
            {
                _bindingSource.DataSource = new BindingList<Customer>(new[] { item });
            }
            else
            {
                _bindingSource.DataSource = new BindingList<Customer>();
            }

            //ReadAll - for filtering of 'StartWith...':
            //var items = s_customer.ReadAll(x => true)
            //    .Where(c => c.Id.ToString().StartsWith(textBox1.Text))
            //    .OrderBy(c => c.Id)
            //    .ToList();
            //_bindingSource.DataSource = new BindingList<Customer>(items);
        }

        // designer event handlers referenced from designer file
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // no-op: selection handled via CurrentRow
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // no-op label click
        }
    }
}
