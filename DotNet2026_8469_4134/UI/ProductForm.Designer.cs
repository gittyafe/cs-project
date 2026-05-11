namespace UI
{
    partial class ProductForm
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

        private void InitializeComponent()
        {
            labelId = new System.Windows.Forms.Label();
            textBoxId = new System.Windows.Forms.TextBox();
            labelName = new System.Windows.Forms.Label();
            textBoxName = new System.Windows.Forms.TextBox();
            labelCategory = new System.Windows.Forms.Label();
            comboBoxCategory = new System.Windows.Forms.ComboBox();
            labelPrice = new System.Windows.Forms.Label();
            textBoxPrice = new System.Windows.Forms.TextBox();
            labelQuantity = new System.Windows.Forms.Label();
            textBoxQuantity = new System.Windows.Forms.TextBox();
            buttonOk = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new System.Drawing.Point(12, 15);
            labelId.Name = "labelId";
            labelId.Size = new System.Drawing.Size(24, 20);
            labelId.TabIndex = 0;
            labelId.Text = "Id";
            // 
            // textBoxId
            // 
            textBoxId.Location = new System.Drawing.Point(140, 12);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new System.Drawing.Size(200, 27);
            textBoxId.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new System.Drawing.Point(12, 55);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(47, 20);
            labelName.TabIndex = 2;
            labelName.Text = "Name";
            // 
            // textBoxName
            // 
            textBoxName.Location = new System.Drawing.Point(140, 52);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(200, 27);
            textBoxName.TabIndex = 3;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new System.Drawing.Point(12, 95);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new System.Drawing.Size(65, 20);
            labelCategory.TabIndex = 4;
            labelCategory.Text = "Category";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new System.Drawing.Point(140, 92);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new System.Drawing.Size(200, 28);
            comboBoxCategory.TabIndex = 5;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new System.Drawing.Point(12, 135);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new System.Drawing.Size(42, 20);
            labelPrice.TabIndex = 6;
            labelPrice.Text = "Price";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new System.Drawing.Point(140, 132);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new System.Drawing.Size(200, 27);
            textBoxPrice.TabIndex = 7;
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new System.Drawing.Point(12, 175);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new System.Drawing.Size(60, 20);
            labelQuantity.TabIndex = 8;
            labelQuantity.Text = "Quantity";
            // 
            // textBoxQuantity
            // 
            textBoxQuantity.Location = new System.Drawing.Point(140, 172);
            textBoxQuantity.Name = "textBoxQuantity";
            textBoxQuantity.Size = new System.Drawing.Size(200, 27);
            textBoxQuantity.TabIndex = 9;
            // 
            // buttonOk
            // 
            buttonOk.Location = new System.Drawing.Point(140, 220);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(94, 29);
            buttonOk.TabIndex = 10;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(246, 220);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(94, 29);
            buttonCancel.TabIndex = 11;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(380, 320);

            // עיצוב כללי תואם לאפליקציה
            this.BackColor = Color.FromArgb(245, 238, 230);
            this.Font = new Font("Segoe UI", 10F);

            // שדרוג פקדים
            labelId.Text = "מזהה";
            labelName.Text = "שם";
            labelCategory.Text = "קטגוריה";
            labelPrice.Text = "מחיר";
            labelQuantity.Text = "מלאי";

            textBoxId.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxQuantity.BorderStyle = BorderStyle.FixedSingle;
            comboBoxCategory.FlatStyle = FlatStyle.Flat;

            // כפתורים עיצוב
            buttonOk.Text = "אישור";
            buttonOk.BackColor = Color.FromArgb(181, 136, 99);
            buttonOk.ForeColor = Color.White;
            buttonOk.FlatStyle = FlatStyle.Flat;
            buttonOk.FlatAppearance.BorderSize = 0;
            buttonOk.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            buttonCancel.Text = "ביטול";
            buttonCancel.BackColor = Color.FromArgb(180, 180, 180);
            buttonCancel.ForeColor = Color.White;
            buttonCancel.FlatStyle = FlatStyle.Flat;
            buttonCancel.FlatAppearance.BorderSize = 0;
            buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(textBoxQuantity);
            Controls.Add(labelQuantity);
            Controls.Add(textBoxPrice);
            Controls.Add(labelPrice);
            Controls.Add(comboBoxCategory);
            Controls.Add(labelCategory);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(textBoxId);
            Controls.Add(labelId);

            Name = "ProductForm";
            Text = "מוצר";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
