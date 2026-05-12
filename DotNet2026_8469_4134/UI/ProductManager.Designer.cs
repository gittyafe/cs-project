namespace UI
{
    partial class ProductManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 84);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(702, 342);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.Location = new Point(722, 422);
            button1.Name = "button1";
            button1.Size = new Size(75, 55);
            button1.TabIndex = 1;
            button1.Text = "הוספה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(722, 300);
            button2.Name = "button2";
            button2.Size = new Size(75, 55);
            button2.TabIndex = 2;
            button2.Text = "מחיקה";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(722, 361);
            button3.Name = "button3";
            button3.Size = new Size(75, 55);
            button3.TabIndex = 3;
            button3.Text = "עדכון";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(338, 34);
            label2.Name = "label2";
            label2.Size = new Size(140, 31);
            label2.TabIndex = 7;
            label2.Text = "ניהול מוצרים";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(492, 462);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(138, 27);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(492, 439);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 9;
            label1.Text = "חיפוש לפי מספר מזהה";
            // 
            // button4
            // 
            button4.Location = new Point(14, 451);
            button4.Name = "button4";
            button4.Size = new Size(251, 38);
            button4.TabIndex = 10;
            button4.Text = "סינון מוצרים מקטגורית 'שוקולד'";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // ProductManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 520);

            // עיצוב כללי תואם לאפליקציה
            this.BackColor = Color.FromArgb(245, 238, 230);
            this.Font = new Font("Segoe UI", 10F);

            // כותרת ראשית
            var title = new Label();
            title.Text = "ניהול מוצרים";
            title.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(90, 70, 60);
            title.AutoSize = false;
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Size = new Size(780, 50);
            title.Location = new Point(30, 10);
            Controls.Add(title);

            // כפתורים מינימליים לצד הטבלה
            button1.Size = new Size(90, 48);
            button2.Size = new Size(90, 48);
            button3.Size = new Size(90, 48);

            button1.BackColor = Color.FromArgb(181, 136, 99);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            button2.BackColor = Color.FromArgb(120, 170, 200);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            button3.BackColor = Color.FromArgb(181, 170, 130);
            button3.ForeColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold);
            label2.Location = new Point(320, 64);
            label2.Text = "רשימת מוצרים";

            label1.Text = "חפש לפי מזהה:";
            label1.Location = new Point(500, 440);
            textBox1.Location = new Point(500, 465);
            textBox1.Size = new Size(220, 30);

            button4.Text = "סינון מוצרים מקטגורית 'שוקולד'";
            button4.Size = new Size(260, 38);
            button4.BackColor = Color.FromArgb(181, 136, 99);
            button4.ForeColor = Color.White;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // שדרוג DataGridView
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(181, 136, 99);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);

            Name = "ProductManager";
            Text = "ניהול מוצרים";
            Load += ProductManager_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button button4;
    }
}
