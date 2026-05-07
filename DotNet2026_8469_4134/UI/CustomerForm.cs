using BO;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class CustomerForm : Form
    {
        public Customer Result { get; private set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(Customer src) : this()
        {
            // copy values into controls
            if (src != null)
            {
                textBoxId.Text = src.Id.ToString();
                textBoxName.Text = src.Name;
                textBoxPhone.Text = src.Phone;
                textBoxAddress.Text = src.Address;
                Result = new Customer { Id = src.Id, Name = src.Name, Phone = src.Phone, Address = src.Address };
                // when editing an existing customer, do not allow changing the Id
                textBoxId.ReadOnly = true;
                textBoxId.TabStop = false;
                textBoxId.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxId.Text, out var id))
            {
                MessageBox.Show("Invalid id");
                return;
            }

            Result = new Customer
            {
                Id = id,
                Name = textBoxName.Text,
                Phone = textBoxPhone.Text,
                Address = textBoxAddress.Text
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
