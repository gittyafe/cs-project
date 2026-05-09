namespace UI
{
    partial class SaleManager
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
            label1 = new Label();
            textBox1 = new TextBox();
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
            dataGridView1.Size = new Size(799, 342);
            dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(833, 414);
            button1.Name = "button1";
            button1.Size = new Size(75, 55);
            button1.TabIndex = 1;
            button1.Text = "הוספה";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(833, 277);
            button2.Name = "button2";
            button2.Size = new Size(75, 55);
            button2.TabIndex = 2;
            button2.Text = "מחיקה";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(833, 347);
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
            label2.Location = new Point(422, 28);
            label2.Name = "label2";
            label2.Size = new Size(149, 31);
            label2.TabIndex = 7;
            label2.Text = "ניהול מבצעים";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(533, 431);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 8;
            label1.Text = "חיפוש לפי מספר מזהה";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(545, 454);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 9;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button4
            // 
            button4.Location = new Point(14, 449);
            button4.Name = "button4";
            button4.Size = new Size(226, 40);
            button4.TabIndex = 10;
            button4.Text = "סינון מבצעים שנגמרו";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // SaleManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 501);
            Controls.Add(button4);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "SaleManager";
            Text = "Sale Manager";
            Load += SaleManager_Load;
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
        private Label label1;
        private TextBox textBox1;
        private Button button4;
    }
}
