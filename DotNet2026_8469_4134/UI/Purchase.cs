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
        private Label labelTitle;
        private BindingSource bsProducts;
        private System.ComponentModel.IContainer components;
        private DataGridView itemList;
        private Label total;
        private Button toDoOrder;
        private Label helloToCust;
        private List<Product> _allProducts = new List<Product>();
        private BindingList<ProductInOrder> _cart = new BindingList<ProductInOrder>();
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewTextBoxColumn colUnit;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewButtonColumn colRemove;
        private BindingSource bsCart;

        public Purchase(string custID)
        {
            _custID = custID;
            InitializeComponent();
        }



        private void InitializeComponent()
        {
            components = new Container();
            textBoxSearch = new TextBox();
            dgvProducts = new DataGridView();
            labelTitle = new Label();
            bsProducts = new BindingSource(components);
            itemList = new DataGridView();
            colRemove = new DataGridViewButtonColumn();
            total = new Label();
            toDoOrder = new Button();
            helloToCust = new Label();
            textBoxSearchID = new TextBox();
            ((ISupportInitialize)dgvProducts).BeginInit();
            ((ISupportInitialize)bsProducts).BeginInit();
            ((ISupportInitialize)itemList).BeginInit();
            SuspendLayout();
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(1038, 78);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.PlaceholderText = "חיפוש לפי שם מוצר";
            textBoxSearch.Size = new Size(202, 27);
            textBoxSearch.TabIndex = 2;
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProducts.ColumnHeadersHeight = 29;
            dgvProducts.Location = new Point(889, 125);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            dgvProducts.RowHeadersWidth = 51;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.Size = new Size(351, 520);
            dgvProducts.TabIndex = 2;
            dgvProducts.CellDoubleClick += DgvProducts_CellDoubleClick;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(20, 15);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(0, 20);
            labelTitle.TabIndex = 0;
            // 
            // itemList
            // create and configure columns: Name, Unit price, Total price, Quantity, Remove
            itemList.AllowUserToAddRows = false;
            itemList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            itemList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // instantiate columns
            colName = new DataGridViewTextBoxColumn();
            colUnit = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colRemove = new DataGridViewButtonColumn();

            // configure columns
            colName.DataPropertyName = "ProductName";
            colName.Name = "colName";
            colName.HeaderText = "שם מוצר";
            colName.ReadOnly = true;
            colName.Width = 220;

            colUnit.DataPropertyName = "BasePrice";
            colUnit.Name = "colUnit";
            colUnit.HeaderText = "מחיר יחידה";
            colUnit.ReadOnly = true;
            colUnit.DefaultCellStyle.Format = "0.00";
            colUnit.Width = 90;

            colTotal.DataPropertyName = "TotalPrice";
            colTotal.Name = "colTotal";
            colTotal.HeaderText = "מחיר כולל";
            colTotal.ReadOnly = true;
            colTotal.DefaultCellStyle.Format = "0.00";
            colTotal.Width = 100;

            colAmount.DataPropertyName = "AmountInOrder";
            colAmount.Name = "colAmount";
            colAmount.HeaderText = "כמות";
            colAmount.ReadOnly = false;
            colAmount.Width = 70;

            colRemove.Name = "colRemove";
            colRemove.HeaderText = "";
            colRemove.Text = "הסר";
            colRemove.UseColumnTextForButtonValue = true;
            colRemove.Width = 60;

            itemList.AutoGenerateColumns = false;
            // add columns in desired order
            itemList.Columns.AddRange(new DataGridViewColumn[] { colName, colUnit, colTotal, colAmount, colRemove });
            itemList.EditMode = DataGridViewEditMode.EditOnEnter;
            itemList.Location = new Point(101, 94);
            itemList.Name = "itemList";
            itemList.RowHeadersWidth = 51;
            itemList.Size = new Size(410, 460);
            itemList.TabIndex = 3;
            itemList.CellEndEdit += ItemList_CellEndEdit;
            itemList.CellContentClick += itemList_CellContentClick;
            // 
            // colRemove
            // 
            colRemove.HeaderText = "";
            colRemove.MinimumWidth = 6;
            colRemove.Name = "colRemove";
            colRemove.Text = "הסר";
            colRemove.UseColumnTextForButtonValue = true;
            colRemove.Width = 60;
            // 
            // total
            // 
            total.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            total.AutoSize = true;
            total.Location = new Point(217, 574);
            total.Name = "total";
            total.Size = new Size(132, 20);
            total.TabIndex = 4;
            total.Text = "סכום לתשלום: 0.00";
            // 
            // toDoOrder
            // 
            toDoOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            toDoOrder.Location = new Point(171, 616);
            toDoOrder.Name = "toDoOrder";
            toDoOrder.Size = new Size(145, 29);
            toDoOrder.TabIndex = 5;
            toDoOrder.Text = "לביצוע ההזמנה";
            toDoOrder.UseVisualStyleBackColor = true;
            toDoOrder.Click += toDoOrder_Click;
            // 
            // helloToCust
            // 
            helloToCust.AutoSize = true;
            helloToCust.Location = new Point(217, 42);
            helloToCust.Name = "helloToCust";
            helloToCust.Size = new Size(50, 20);
            helloToCust.TabIndex = 6;
            helloToCust.Text = "label2";
            // 
            // textBoxSearchID
            // 
            textBoxSearchID.Location = new Point(889, 78);
            textBoxSearchID.Name = "textBoxSearchID";
            textBoxSearchID.PlaceholderText = "חיפוש לפי מזהה";
            textBoxSearchID.Size = new Size(130, 27);
            textBoxSearchID.TabIndex = 1;
            textBoxSearchID.TextChanged += TextBoxSearchID_TextChanged;
            // 
            // Purchase
            // 
            ClientSize = new Size(1295, 700);
            Controls.Add(helloToCust);
            Controls.Add(toDoOrder);
            Controls.Add(total);
            Controls.Add(itemList);
            Controls.Add(labelTitle);
            Controls.Add(textBoxSearchID);
            Controls.Add(textBoxSearch);
            Controls.Add(dgvProducts);
            MinimumSize = new Size(900, 600);
            Name = "Purchase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Purchase";
            Load += Purchase_Load;
            ((ISupportInitialize)dgvProducts).EndInit();
            ((ISupportInitialize)bsProducts).EndInit();
            ((ISupportInitialize)itemList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            // Make the window large but not full-screen (around 85-90% of working area)
            try
            {
                var wa = Screen.PrimaryScreen.WorkingArea;
                this.Size = new System.Drawing.Size((int)(wa.Width * 0.9), (int)(wa.Height * 0.85));
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            catch { }
            // Load products from BL
            try
            {
                var bl = BlApi.Factory.Get;
                _allProducts = bl.Product.ReadAll(p => true);
                bsProducts.DataSource = _allProducts;
                dgvProducts.DataSource = bsProducts;
                // hide properties not needed or reorder columns if desired
                if (dgvProducts.Columns.Contains("ListSaleInProduct"))
                    dgvProducts.Columns["ListSaleInProduct"].Visible = false;

                // Initialize cart bindings
                bsCart = new BindingSource();
                bsCart.DataSource = _cart;
                itemList.DataSource = bsCart;
                helloToCust.Text = $"ת.ז.: {_custID}";
                UpdateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בטעינת מוצרים: {ex.Message}");
            }
        }

        private void TextBoxSearch_TextChanged(object? sender, EventArgs e)
        {
            DoSearch();
            dgvProducts.Refresh();
        }

        private void TextBoxSearchID_TextChanged(object? sender, EventArgs e)
        {
            DoSearch();
            dgvProducts.Refresh();
        }

        private void DoSearch()
        {
            string nameQuery = textBoxSearch.Text?.Trim() ?? string.Empty;
            string idQuery = textBoxSearchID.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(nameQuery) && string.IsNullOrEmpty(idQuery))
            {
                bsProducts.DataSource = _allProducts;
                return;
            }

            List<Product> filtered = _allProducts;
            if (!string.IsNullOrEmpty(nameQuery))
                filtered = filtered.Where(p => p.Name != null && p.Name.Contains(nameQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!string.IsNullOrEmpty(idQuery) && int.TryParse(idQuery, out int id))
                filtered = filtered.Where(p => p.Id == id).ToList();

            bsProducts.DataSource = filtered;
        }

        private void DgvProducts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var prod = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
            if (prod == null) return;

            var existing = _cart.FirstOrDefault(x => x.ProductId == prod.Id);
            if (existing != null)
            {
                existing.AmountInOrder += 1;
                existing.TotalPrice = existing.AmountInOrder * existing.BasePrice;
                bsCart.ResetBindings(false);
            }
            else
            {
                var pio = new ProductInOrder(prod.Id, prod.Name, prod.Price, 1, prod.ListSaleInProduct?.Select(s => new BO.SaleInProduct(s.SaleId, s.AmountForSale, s.Price, s.IsOnlyClub)).ToList() ?? new List<BO.SaleInProduct>(), prod.Price);
                _cart.Add(pio);
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            double sum = _cart.Sum(i => i.TotalPrice);
            total.Text = $"סכום לתשלום: {sum:0.00}";
        }

        private void toDoOrder_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("לא נבחרו מוצרים להזמנה.");
                return;
            }
            // perform stock update in DAL via BL
            try
            {
                var bl = BlApi.Factory.Get;
                // validate stock
                foreach (var item in _cart)
                {
                    var prod = _allProducts.FirstOrDefault(p => p.Id == item.ProductId);
                    if (prod == null)
                        throw new Exception($"המוצר {item.ProductName} לא נמצא במאגר.");
                    if (prod.QuantityInStack < item.AmountInOrder)
                        throw new Exception($"לא נשאר מלאי מספיק עבור {item.ProductName}. זמינות: {prod.QuantityInStack}");
                }

                // reduce stock
                foreach (var item in _cart)
                {
                    var prod = _allProducts.First(p => p.Id == item.ProductId);
                    prod.QuantityInStack -= item.AmountInOrder;
                    bl.Product.Update(prod);
                }

                MessageBox.Show($"ההזמנה בוצעה בהצלחה. { _cart.Count } פריטים הוסרו מהמלאי.");
                _cart.Clear();
                bsCart.ResetBindings(false);
                UpdateTotal();
                // refresh products list from BL
                _allProducts = bl.Product.ReadAll(p => true);
                bsProducts.DataSource = _allProducts;
                dgvProducts.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בביצוע ההזמנה: {ex.Message}");
            }
        }

        private void ItemList_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var row = itemList.Rows[e.RowIndex];
            var item = row.DataBoundItem as ProductInOrder;
            if (item == null) return;
            // ensure amount is integer >=1 (column named colAmount)
            var cell = row.Cells["colAmount"];
            if (!int.TryParse(cell.Value?.ToString() ?? "", out int amount) || amount < 1)
            {
                // restore previous
                cell.Value = item.AmountInOrder;
                return;
            }
            item.AmountInOrder = amount;
            item.TotalPrice = item.AmountInOrder * item.BasePrice;
            bsCart.ResetBindings(false);
            UpdateTotal();
        }

        // removal handled via remove-button column

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void itemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // if remove button clicked
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var col = itemList.Columns[e.ColumnIndex];
            if (col != null && col.Name == "colRemove")
            {
                var item = itemList.Rows[e.RowIndex].DataBoundItem as ProductInOrder;
                if (item == null) return;
                var res = MessageBox.Show($"להסיר {item.ProductName} מהסל?", "אישור הסרה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    _cart.Remove(item);
                    bsCart.ResetBindings(false);
                    UpdateTotal();
                }
            }
        }

        private void total_Click(object sender, EventArgs e)
        {

        }

        private void helloToCust_Click(object sender, EventArgs e)
        {

        }
    }
}
