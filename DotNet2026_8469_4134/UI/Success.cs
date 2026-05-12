using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BO;

namespace UI
{
    public class Success : Form
    {
        // פקדים שמוגדרים ברמת המחלקה כדי שנוכל לגשת אליהם מכל מקום
        private Panel panelMain;
        private ListView itemsListView;
        private Label title;
        private Button btnOk;
        private Label summary;

        public Success(Order order)
        {
            // 1. קריאה לפונקציית העיצוב הסטנדרטית
            InitializeComponent();

            // 2. קריאה לפונקציה שתמלא את הנתונים מהאובייקט order
            PopulateOrderData(order);
        }

        // מתודה זו תהיה "נקייה" וניתן יהיה לערוך אותה במעצב
        private void InitializeComponent()
        {
            title = new Label();
            panelMain = new Panel();
            itemsListView = new ListView();
            summary = new Label();
            btnOk = new Button();
            SuspendLayout();

            // Form
            this.ClientSize = new Size(620, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "הצלחה";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(245, 238, 230); // צבע אחיד כפי שביקשת

            // title
            title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            title.Location = new Point(20, 14);
            title.Name = "title";
            title.Size = new Size(580, 40);
            title.TabIndex = 0;
            title.Text = "הזמנה בוצעה בהצלחה";
            title.TextAlign = ContentAlignment.MiddleCenter;

            // panelMain
            panelMain.Location = new Point(20, 64);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(580, 360);
            panelMain.BackColor = Color.White;
            panelMain.Padding = new Padding(12);

            // itemsListView
            itemsListView.Location = new Point(12, 12);
            itemsListView.Name = "itemsListView";
            itemsListView.Size = new Size(556, 220);
            itemsListView.View = View.Details;
            itemsListView.FullRowSelect = true;
            itemsListView.GridLines = false;
            itemsListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            itemsListView.Columns.Add("מוצר", 160, HorizontalAlignment.Left);
            itemsListView.Columns.Add("כמות", 80, HorizontalAlignment.Center);
            itemsListView.Columns.Add("מחיר", 120, HorizontalAlignment.Right);
            itemsListView.Columns.Add("במבצע", 80, HorizontalAlignment.Center);

            // summary
            summary.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            summary.Location = new Point(12, 240);
            summary.Name = "summary";
            summary.Size = new Size(556, 90);
            summary.TabIndex = 2;
            summary.ForeColor = Color.DarkGreen;
            summary.TextAlign = ContentAlignment.MiddleLeft;

            // btnOk
            btnOk.Anchor = AnchorStyles.Bottom;
            btnOk.Location = new Point((this.ClientSize.Width - 140) / 2, 440);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(140, 44);
            btnOk.TabIndex = 3;
            btnOk.Text = "אישור";
            btnOk.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnOk.BackColor = Color.FromArgb(181, 136, 99);
            btnOk.ForeColor = Color.White;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Click += btnOk_Click;

            // compose
            panelMain.Controls.Add(itemsListView);
            panelMain.Controls.Add(summary);
            Controls.Add(title);
            Controls.Add(panelMain);
            Controls.Add(btnOk);

            ResumeLayout(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close(); // סגירת הטופס
        }

        private void PopulateOrderData(Order order)
        {
            if (order == null || order.ProductsInOrder == null) return;

            // ודא שה-BL מחשב שוב את המחירים ואת רשימת המבצעים לכל פריט
            var bl = BlApi.Factory.Get;
            foreach (var p in order.ProductsInOrder.ToList())
            {
                try { bl.Order.AddProductToOrder(order, p.ProductId, 0); }
                catch { }
            }

            // מלא את ה-ListView
            itemsListView.Items.Clear();
            foreach (var p in order.ProductsInOrder)
            {
                var lvi = new ListViewItem(p.ProductName);
                lvi.SubItems.Add(p.AmountInOrder.ToString());
                lvi.SubItems.Add(p.TotalPrice.ToString("0.00"));
                lvi.SubItems.Add(p.UsesSale ? "כן" : "לא");
                itemsListView.Items.Add(lvi);
            }

            int totalItems = order.ProductsInOrder.Sum(p => p.AmountInOrder);
            double totalPrice = order.FinalPrice;
            double fullPrice = order.ProductsInOrder.Sum(p => p.BasePrice * p.AmountInOrder);
            double saved = fullPrice - totalPrice;

            summary.Text = $"מספר פריטים: {totalItems}\nעלות לפני מבצעים: {fullPrice:0.00}  |  עלות לאחר מבצעים: {totalPrice:0.00}\nחסכת: {saved:0.00}";
        }
    }
}