using BO;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace UI
{
    public partial class SaleForm : Form
    {
        public Sale Result { get; private set; }

        public SaleForm()
        {
            InitializeComponent();
        }

        public SaleForm(Sale sale) : this()
        {
            textBoxId.Text = sale.Id.ToString();
            textBoxProductId.Text = sale.ProductId.ToString();
            textBoxQuantityRequired.Text = sale.QuantityRequired.ToString();
            textBoxTotalPrice.Text = sale.TotalPrice.ToString(CultureInfo.InvariantCulture);
            checkBoxIsOnlyClub.Checked = sale.IsOnlyClub;
            textBoxStartSale.Text = sale.StartSale.ToString("o");
            textBoxEndSale.Text = sale.EndSale.ToString("o");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxId.Text, out var id))
            {
                MessageBox.Show("Invalid Id");
                return;
            }
            if (!int.TryParse(textBoxProductId.Text, out var productId))
            {
                MessageBox.Show("Invalid ProductId");
                return;
            }
            if (!int.TryParse(textBoxQuantityRequired.Text, out var quantityRequired))
            {
                MessageBox.Show("Invalid QuantityRequired");
                return;
            }
            if (!double.TryParse(textBoxTotalPrice.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out var totalPrice))
            {
                MessageBox.Show("Invalid TotalPrice");
                return;
            }
            if (!DateTime.TryParse(textBoxStartSale.Text, null, DateTimeStyles.RoundtripKind, out var startSale))
            {
                MessageBox.Show("Invalid StartSale, use ISO format like 2023-01-01T12:00:00Z");
                return;
            }
            if (!DateTime.TryParse(textBoxEndSale.Text, null, DateTimeStyles.RoundtripKind, out var endSale))
            {
                MessageBox.Show("Invalid EndSale, use ISO format like 2023-01-01T12:00:00Z");
                return;
            }

            Result = new Sale
            {
                Id = id,
                ProductId = productId,
                QuantityRequired = quantityRequired,
                TotalPrice = totalPrice,
                IsOnlyClub = checkBoxIsOnlyClub.Checked,
                StartSale = startSale,
                EndSale = endSale
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
