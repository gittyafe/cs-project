using BlApi;
using BO;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class SaleManager : Form
    {
        static readonly IBl s_bl = BlApi.Factory.Get;
        static readonly ISale s_sale = s_bl.Sale;

        private BindingSource _bindingSource = new BindingSource();

        public SaleManager()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.DataSource = _bindingSource;
        }

        private void SaleManager_Load(object sender, EventArgs e)
        {
            BindSales();
        }

        private void BindSales()
        {
            var items = s_sale.ReadAll(x => true).OrderBy(s => s.Id).ToList();
            _bindingSource.DataSource = new BindingList<Sale>(items);
            // set Hebrew headers and RTL layout (same as CustomerManager)
            dataGridView1.RightToLeft = RightToLeft.Yes;
            if (dataGridView1.Columns["Id"] != null) dataGridView1.Columns["Id"].HeaderText = "מ.ז.";
            if (dataGridView1.Columns["ProductId"] != null) dataGridView1.Columns["ProductId"].HeaderText = "מ.ז. מוצר";
            if (dataGridView1.Columns["QuantityRequired"] != null) dataGridView1.Columns["QuantityRequired"].HeaderText = "כמות נדרשת";
            if (dataGridView1.Columns["TotalPrice"] != null) dataGridView1.Columns["TotalPrice"].HeaderText = "סה\"כ מחיר";
            if (dataGridView1.Columns["IsOnlyClub"] != null) dataGridView1.Columns["IsOnlyClub"].HeaderText = "חברי מועדון";
            if (dataGridView1.Columns["StartSale"] != null) dataGridView1.Columns["StartSale"].HeaderText = "תחילת מבצע";
            if (dataGridView1.Columns["EndSale"] != null) dataGridView1.Columns["EndSale"].HeaderText = "סיום מבצע";
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new SaleForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var created = form.Result;
                        s_sale.Create(created);
                        BindSales();
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
            if (dataGridView1.CurrentRow?.DataBoundItem is Sale selected)
            {
                var result = MessageBox.Show("האם למחוק את הפריט?", "מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    s_sale.Delete(selected.Id);
                    BindSales();
                }
            }
            else
            {
                MessageBox.Show("לא נבחר פריט למחיקה");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.DataBoundItem is Sale selected)
            {
                using (var form = new SaleForm(selected))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        try
                        {
                            var updated = form.Result;
                            s_sale.Update(updated);
                            BindSales();
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
                BindSales();
                return;
            }
            var item = s_sale.Read(x => x.Id.ToString() == textBox1.Text);
            if (item != null)
            {
                _bindingSource.DataSource = new BindingList<Sale>(new[] { item });
            }
            else
            {
                _bindingSource.DataSource = new BindingList<Sale>();
            }

            //ReadAll - for filtering of 'StartWith...'
            //var items = s_sale.ReadAll(x => true)
            //    .Where(c => c.Id.ToString().StartsWith(textBox1.Text))
            //    .OrderBy(c => c.Id)
            //    .ToList();
            //_bindingSource.DataSource = new BindingList<Sale>(items);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "הצג הכל")
            {
                BindSales();
                button4.Text = "סינון מבצעים שנגמרו";
            }
            else
            {
                var items = s_sale.ReadAll(x => true)
                    .Where(c => c.EndSale < DateTime.Now)
                    .OrderBy(c => c.Id)
                    .ToList();
                _bindingSource.DataSource = new BindingList<Sale>(items);
                button4.Text = "הצג הכל";
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
