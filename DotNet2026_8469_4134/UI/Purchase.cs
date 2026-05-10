using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI
{
    public partial class Purchase : Form
    {
        private string _custID;

        private TextBox textBoxSearch;
        private TextBox textBoxSearchID;

        private DataGridView dgvProducts;
        private DataGridView itemList;

        private Label total;
        private Label helloToCust;

        private Button toDoOrder;

        private BindingSource bsProducts;
        private BindingSource bsCart;

        private List<Product> _allProducts = new();
        private BindingList<ProductInOrder> _cart = new();

        private IBl bl = Factory.Get;

        public Purchase(string custID)
        {
            _custID = custID;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            textBoxSearch = new TextBox();
            textBoxSearchID = new TextBox();

            dgvProducts = new DataGridView();
            itemList = new DataGridView();

            total = new Label();
            helloToCust = new Label();
            toDoOrder = new Button();

            bsProducts = new BindingSource();
            bsCart = new BindingSource();

            SuspendLayout();

            // ================= FORM =================
            this.Text = "Purchase";
            this.Size = new Size(1300, 800);
            this.RightToLeft = RightToLeft.No;

            // ================= SEARCH =================
            textBoxSearch.Location = new Point(1030, 50);
            textBoxSearch.PlaceholderText = "חיפוש לפי שם";
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            textBoxSearchID.Location = new Point(870, 50);
            textBoxSearchID.PlaceholderText = "חיפוש לפי קוד";
            textBoxSearchID.TextChanged += TextBoxSearch_TextChanged;

            // ================= PRODUCTS =================
            dgvProducts.Location = new Point(750, 100);
            dgvProducts.Size = new Size(500, 500);
            dgvProducts.ReadOnly = true;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.CellDoubleClick += DgvProducts_CellDoubleClick;

            dgvProducts.AutoGenerateColumns = false;

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "קוד" });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "שם מוצר" });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "מחיר" });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QuantityInStack", HeaderText = "מלאי" });

            // ================= CART =================
            itemList.Location = new Point(50, 100);
            itemList.Size = new Size(650, 500);
            itemList.AutoGenerateColumns = false;
            itemList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            itemList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "שם מוצר",
                DataPropertyName = "ProductName",
                ReadOnly = true
            });

            itemList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "מחיר",
                DataPropertyName = "BasePrice"
            });

            itemList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAmount",
                HeaderText = "כמות",
                DataPropertyName = "AmountInOrder"
            });

            itemList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTotal",
                HeaderText = "סה״כ",
                DataPropertyName = "TotalPrice",
                ReadOnly = true
            });

            itemList.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colRemove",
                HeaderText = "",
                Text = "הסר",
                UseColumnTextForButtonValue = true
            });

            itemList.CellEndEdit += ItemList_CellEndEdit;
            itemList.CellContentClick += ItemList_CellContentClick;

            // ================= TOTAL =================
            total.Location = new Point(250, 620);
            total.AutoSize = true;
            total.Font = new Font("Arial", 16, FontStyle.Bold);
            total.ForeColor = Color.DarkGreen;
            total.AutoSize = true;

            // ================= CUSTOMER =================
            helloToCust.Location = new Point(20, 20);
            helloToCust.AutoSize = true;

            // ================= ORDER =================
            toDoOrder.Location = new Point(200, 650);
            toDoOrder.Text = "בצע הזמנה";
            toDoOrder.Click += toDoOrder_Click;
            toDoOrder.Size = new Size(220, 60);
            toDoOrder.Font = new Font("Arial", 14, FontStyle.Bold);

            Controls.Add(textBoxSearch);
            Controls.Add(textBoxSearchID);
            Controls.Add(dgvProducts);
            Controls.Add(itemList);
            Controls.Add(total);
            Controls.Add(helloToCust);
            Controls.Add(toDoOrder);

            Load += Purchase_Load;

            ResumeLayout(false);
        }

        // ================= LOAD =================
        private void Purchase_Load(object sender, EventArgs e)
        {
            _allProducts = bl.Product.ReadAll(p => true);

            bsProducts.DataSource = _allProducts;
            dgvProducts.DataSource = bsProducts;

            bsCart.DataSource = _cart;
            itemList.DataSource = bsCart;

            helloToCust.Text = $"לקוח: {_custID}";

            UpdateTotal();
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            DoSearch();
        }

        // ================= ADD PRODUCT =================
        private void DgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var prod = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
                if (prod == null) return;

                bl.Order.AddProductToOrder(
                    new Order { ProductsInOrder = _cart.ToList() },
                    prod.Id,
                    1);

                var existing = _cart.FirstOrDefault(x => x.ProductId == prod.Id);

                if (existing == null)
                {
                    _cart.Add(new ProductInOrder(
                        prod.Id,
                        prod.Name,
                        prod.Price,
                        1,
                        new List<SaleInProduct>()
                    ));
                }

                bsCart.ResetBindings(false);
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "אין מלאי", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ================= EDIT QUANTITY =================
        private void ItemList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var item = itemList.Rows[e.RowIndex].DataBoundItem as ProductInOrder;
            if (item == null) return;

            if (int.TryParse(item.AmountInOrder.ToString(), out int amount))
            {
                item.AmountInOrder = amount;

                // חישוב מגיע מה-BL בלבד!
                bl.Order.AddProductToOrder(new Order { ProductsInOrder = _cart.ToList() }, item.ProductId, 0);
            }

            bsCart.ResetBindings(false);
            UpdateTotal();
        }

        // ================= REMOVE =================
        private void ItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (itemList.Columns[e.ColumnIndex].Name == "colRemove")
            {
                var item = itemList.Rows[e.RowIndex].DataBoundItem as ProductInOrder;
                if (item == null) return;

                _cart.Remove(item);

                bsCart.ResetBindings(false);
                UpdateTotal();
            }
        }

        // ================= SEARCH =================
        private void DoSearch()
        {
            string name = textBoxSearch.Text.Trim();
            string idText = textBoxSearchID.Text.Trim();

            IEnumerable<Product> result = _allProducts;

            if (!string.IsNullOrWhiteSpace(name))
                result = result.Where(p => p.Name.Contains(name));

            if (int.TryParse(idText, out int id))
                result = result.Where(p => p.Id == id);

            bsProducts.DataSource = result.ToList();
        }

        // ================= TOTAL =================
        private void UpdateTotal()
        {
            total.Text = $"סה״כ: {_cart.Sum(x => x.TotalPrice):0.00}";
        }

        // ================= ORDER =================
        private void toDoOrder_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                ProductsInOrder = _cart.ToList()
            };

            bl.Order.DoOrder(order);

            MessageBox.Show("הזמנה בוצעה");

            _cart.Clear();
            bsCart.ResetBindings(false);

            UpdateTotal();

            _allProducts = bl.Product.ReadAll(p => true);
            bsProducts.DataSource = null;
            bsProducts.DataSource = _allProducts;

            dgvProducts.Refresh();
        }
    }
}