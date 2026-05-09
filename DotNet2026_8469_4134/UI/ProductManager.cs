using BlApi;
using BO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class ProductManager : Form
    {
        static readonly IBl s_bl = BlApi.Factory.Get;
        static readonly IProduct s_product = s_bl.Product;

        private BindingSource _bindingSource = new BindingSource();

        public ProductManager()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = _bindingSource;
        }

        private void ProductManager_Load(object sender, EventArgs e)
        {
            BindProducts();
        }

        private void BindProducts()
        {
            var items = s_product.ReadAll(x => true).OrderBy(p => p.Id);
            _bindingSource.DataSource = new BindingList<Product>(items.ToList());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new ProductForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var created = form.Result;
                        s_product.Create(created);
                        BindProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Product selected)
            {
                var result = MessageBox.Show("האם למחוק את הפריט?", "מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    s_product.Delete(selected.Id);
                    BindProducts();
                }
            }
            else
            {
                MessageBox.Show("לא נבחר פריט למחיקה");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Product selected)
            {
                using (var form = new ProductForm(selected))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        try
                        {
                            var updated = form.Result;
                            s_product.Update(updated);
                            BindProducts();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                BindProducts();
                return;
            }

            var items = s_product.ReadAll(x => true)
                .Where(c => c.Id.ToString().StartsWith(textBox1.Text))
                .OrderBy(c => c.Id)
                .ToList();
            _bindingSource.DataSource = new BindingList<Product>(items);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "הצג הכל")
            {
                BindProducts();
                button4.Text = "סינון מוצרים לפי קטגורית 'שוקולד'";
            }
            else
            {
                var items = s_product.ReadAll(x => true)
                    .Where(c => c.Category == Category.CHOCOLATE)
                    .OrderBy(c => c.Id)
                    .ToList();
                _bindingSource.DataSource = new BindingList<Product>(items);
                button4.Text = "הצג הכל";
            }
            
        }
    }
}
