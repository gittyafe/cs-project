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
        private bool _isClubCustomer = false;

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
            ApplyDesign();
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

            // ================= 1. FORM SETUP =================
            this.Text = "Purchase";
            this.Size = new Size(1550, 900);
            this.StartPosition = FormStartPosition.CenterScreen;

            int centerPoint = this.ClientSize.Width / 2;
            int spacing = 60;

            // ================= 2. PRODUCTS GRID (קודם כל נגדיר מיקום לטבלה!) =================
            dgvProducts.Size = new Size(500, 550);
            dgvProducts.Location = new Point(centerPoint + (spacing / 2), 110);
            dgvProducts.ReadOnly = true;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducts.CellDoubleClick += DgvProducts_CellDoubleClick;

            AddProductColumns();

            // ================= 3. SEARCH CONTROLS (עכשיו אפשר להשתמש במיקום הטבלה) =================
            int searchSpacing = 10;
            int searchWidth = (dgvProducts.Width - searchSpacing) / 2;

            // עכשיו dgvProducts.Left ו-dgvProducts.Right הם לא 0!
            textBoxSearch.Size = new Size(searchWidth, 38);
            textBoxSearch.Location = new Point(dgvProducts.Left, 40);
            textBoxSearch.PlaceholderText = "חיפוש לפי שם";
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged; // אל תשכח להוסיף את האירוע

            textBoxSearchID.Size = new Size(searchWidth, 38);
            textBoxSearchID.Location = new Point(dgvProducts.Left + searchWidth + searchSpacing, 40);
            textBoxSearchID.PlaceholderText = "חיפוש לפי קוד";
            textBoxSearchID.TextChanged += TextBoxSearch_TextChanged; // אל תשכח להוסיף את האירוע

            // ================= 4. CART GRID (ללא שינוי) =================
            itemList.Size = new Size(550, 550);
            itemList.Location = new Point(centerPoint - itemList.Width - (spacing / 2), 110);
            itemList.ReadOnly = false;
            itemList.AutoGenerateColumns = false;
            itemList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            itemList.CellEndEdit += ItemList_CellEndEdit;
            itemList.CellContentClick += ItemList_CellContentClick;

            AddCartColumns();

            // ================= LABELS & TOTAL =================
            helloToCust.Location = new Point(50, 20);
            helloToCust.AutoSize = true;
            total.AutoSize = true;

            // ================= ORDER BUTTON =================
            toDoOrder.Size = new Size(220, 60);
            // כפתור ממורכז מתחת לטבלת העגלה
            toDoOrder.Location = new Point(itemList.Left + (itemList.Width - toDoOrder.Width) / 2, 720);
            toDoOrder.Text = "בצע הזמנה";
            toDoOrder.Click += toDoOrder_Click;
            // העבר מיקום ה-total מעל לכפתור
            total.Location = new Point(toDoOrder.Left + (toDoOrder.Width / 2) - 100, toDoOrder.Top - 60);

            // ================= ADD CONTROLS =================
            this.Controls.AddRange(new Control[] {
            textBoxSearch, textBoxSearchID, dgvProducts,
            itemList, total, helloToCust, toDoOrder
        });

            this.Load += Purchase_Load;
        }

        private void AddProductColumns()
        {
            dgvProducts.Columns.Clear();
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "קוד", Width = 60 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "שם מוצר", Width = 150 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Price", HeaderText = "מחיר", Width = 70 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "QuantityInStack", HeaderText = "מלאי", Width = 70 });
        }

        private void AddCartColumns()
        {
            itemList.Columns.Clear();
            itemList.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "שם מוצר", DataPropertyName = "ProductName", ReadOnly = true, Width = 160 });
            itemList.Columns.Add(new DataGridViewTextBoxColumn { Name = "colPrice", HeaderText = "מחיר", DataPropertyName = "BasePrice", ReadOnly = true, Width = 60 });
            itemList.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAmount", HeaderText = "כמות", DataPropertyName = "AmountInOrder", Width = 60 });
            itemList.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTotal", HeaderText = "סה״כ", DataPropertyName = "TotalPrice", ReadOnly = true, Width = 70 });
            itemList.Columns.Add(new DataGridViewCheckBoxColumn { Name = "colUsesSale", HeaderText = "מבצע", DataPropertyName = "UsesSale", ReadOnly = true, Width = 50 });
            itemList.Columns.Add(new DataGridViewButtonColumn { Name = "colRemove", HeaderText = "", Text = "הסר", UseColumnTextForButtonValue = true, Width = 60 });
        }

        private void ApplyDesign()
        {
            this.BackColor = Color.FromArgb(245, 238, 230);
            this.Font = new Font("Segoe UI", 10F);

            // רקע
            try
            {
                string bgPath = System.IO.Path.Combine(Application.StartupPath, "bg.png");
                if (System.IO.File.Exists(bgPath))
                {
                    this.BackgroundImage = Image.FromFile(bgPath);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            catch { }

            // עיצוב טקסטים
            helloToCust.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            helloToCust.ForeColor = Color.FromArgb(90, 70, 60);

            total.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            total.ForeColor = Color.FromArgb(120, 90, 70);

            // עיצוב כפתור
            toDoOrder.BackColor = Color.FromArgb(181, 136, 99);
            toDoOrder.ForeColor = Color.White;
            toDoOrder.FlatStyle = FlatStyle.Flat;
            toDoOrder.FlatAppearance.BorderSize = 0;
            toDoOrder.Font = new Font("Segoe UI", 16, FontStyle.Bold);

            StyleGrid(dgvProducts);
            StyleGrid(itemList);
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 35;

            // כותרות
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(181, 136, 99);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // תאים
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 210, 190);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Padding = new Padding(5, 0, 5, 0);
        }


        // ================= EVENTS =================

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
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

        private void DgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var prod = dgvProducts.Rows[e.RowIndex].DataBoundItem as Product;
                if (prod == null) return;

                Order order = new Order
                {
                    IsClub = _isClubCustomer,
                    ProductsInOrder = _cart.ToList()
                };

                bl.Order.AddProductToOrder(order, prod.Id, 1);

                _cart.Clear();

                foreach (var item in order.ProductsInOrder)
                    _cart.Add(item);

                bsCart.ResetBindings(false);

                total.Text = $"סה״כ: {order.FinalPrice:0.00}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ItemList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var item = itemList.Rows[e.RowIndex].DataBoundItem as ProductInOrder;
            if (item == null) return;

            Order order = new Order
            {
                IsClub = _isClubCustomer,
                ProductsInOrder = _cart.ToList()
            };

            bl.Order.AddProductToOrder(order, item.ProductId, 0);

            _cart.Clear();

            foreach (var p in order.ProductsInOrder)
                _cart.Add(p);

            bsCart.ResetBindings(false);

            total.Text = $"סה״כ: {order.FinalPrice:0.00}";
        }

        private void ItemList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (itemList.Columns[e.ColumnIndex].Name == "colRemove")
            {
                var item = itemList.Rows[e.RowIndex].DataBoundItem as ProductInOrder;
                if (item == null) return;

                _cart.Remove(item);
                bsCart.ResetBindings(false);
                UpdateTotal();
            }
        }

        private void UpdateTotal()
        {
            total.Text = $"סה״כ: {_cart.Sum(x => x.TotalPrice):0.00}";
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            _allProducts = bl.Product.ReadAll(p => true);

            bsProducts.DataSource = _allProducts;
            dgvProducts.DataSource = bsProducts;

            bsCart.DataSource = _cart;
            itemList.DataSource = bsCart;

            // הצגת ברכת שלום ללקוח ויצירת מצב מועדון במידת הצורך
            try
            {
                int id = int.Parse(_custID);
                var cust = bl.Customer.Read(c => c.Id == id);
                if (cust != null)
                {
                    _isClubCustomer = cust.IsClub;
                    if (_isClubCustomer)
                        helloToCust.Text = $"שלום {cust.Name} ⭐ חבר מועדון";
                    else
                        helloToCust.Text = $"שלום {cust.Name}";
                }
            }
            catch
            {
                helloToCust.Text = "לקוח מזדמן";
            }

            UpdateTotal();
        }

        private void toDoOrder_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                IsClub = _isClubCustomer,
                ProductsInOrder = _cart.ToList()
            };

            bl.Order.CalcTotalPrice(order);

            // ודא שכל הפריטים מעודכנים (מבצעים ומחיר יחידה) לפני חישוב וסגירת הזמנה
            foreach (var p in order.ProductsInOrder.ToList())
            {
                try { bl.Order.AddProductToOrder(order, p.ProductId, 0); }
                catch { /* המשך גם אם חישוב לפריט נכשל */ }
            }

            // מחשב את המחיר הסופי
            bl.Order.CalcTotalPrice(order);

            try
            {
                bl.Order.DoOrder(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "שגיאה בביצוע ההזמנה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // הצגת חלון הצלחה עם פרטי ההזמנה - לעטוף בנסיונות על מנת לתפוס שגיאות ביצירת הטופס
            try
            {
                using (var successForm = new Success(order))
                {
                    successForm.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                // הצג שגיאה מפורטת כדי שתוכלי לראות למה החלון לא נפתח
                MessageBox.Show($"שגיאה בעת פתיחת חלון ההצלחה:\n{ex}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _cart.Clear();
            bsCart.ResetBindings(false);

            UpdateTotal();

            _allProducts = bl.Product.ReadAll(p => true);
            bsProducts.DataSource = _allProducts;
        }
    }
}