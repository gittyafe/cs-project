using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Cashier : Form
    {
        public Cashier()
        {
            InitializeComponent();
        }

        private void buttonOKToCustID_Click(object sender, EventArgs e)
        {
            string custID = textBoxCustID.Text;
            if (string.IsNullOrEmpty(custID))
            {
                
                    MessageBox.Show("נא להכניס ת.ז. של הלקוח.");
                    textBoxCustID.Focus();
                

            }
            else
            {
                // Open the purchase window for the given customer ID
                this.Hide();
                using (var purchase = new Purchase(custID))
                {
                    purchase.ShowDialog();
                }
                this.Show();
            }
        }
    }
}
