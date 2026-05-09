using BO;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class ProductForm : Form
    {
        public Product Result { get; private set; }

        public ProductForm()
        {
            InitializeComponent();
            // populate category combobox from enum
            comboBoxCategory.DataSource = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
        }

        public ProductForm(Product product) : this()
        {
            // populate fields for editing
            textBoxId.Text = product.Id.ToString();
            textBoxName.Text = product.Name;
            comboBoxCategory.SelectedItem = product.Category;
            textBoxPrice.Text = product.Price.ToString(CultureInfo.InvariantCulture);
            textBoxQuantity.Text = product.QuantityInStack.ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // basic validation
            if (!int.TryParse(textBoxId.Text, out var id))
            {
                MessageBox.Show("Invalid Id");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Name required");
                return;
            }
            if (!double.TryParse(textBoxPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var price))
            {
                MessageBox.Show("Invalid price");
                return;
            }
            if (!int.TryParse(textBoxQuantity.Text, out var quantity))
            {
                MessageBox.Show("Invalid quantity");
                return;
            }

            Result = new Product
            {
                Id = id,
                Name = textBoxName.Text,
                Category = (Category)comboBoxCategory.SelectedItem,
                Price = price,
                QuantityInStack = quantity
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
