namespace UI
{
    partial class SaleForm
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
            labelProductId = new System.Windows.Forms.Label();
            textBoxProductId = new System.Windows.Forms.TextBox();
            labelQuantityRequired = new System.Windows.Forms.Label();
            textBoxQuantityRequired = new System.Windows.Forms.TextBox();
            labelTotalPrice = new System.Windows.Forms.Label();
            textBoxTotalPrice = new System.Windows.Forms.TextBox();
            labelIsOnlyClub = new System.Windows.Forms.Label();
            checkBoxIsOnlyClub = new System.Windows.Forms.CheckBox();
            labelStartSale = new System.Windows.Forms.Label();
            textBoxStartSale = new System.Windows.Forms.TextBox();
            labelEndSale = new System.Windows.Forms.Label();
            textBoxEndSale = new System.Windows.Forms.TextBox();
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
            textBoxId.Location = new System.Drawing.Point(200, 12);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new System.Drawing.Size(200, 27);
            textBoxId.TabIndex = 1;
            // 
            // labelProductId
            // 
            labelProductId.AutoSize = true;
            labelProductId.Location = new System.Drawing.Point(12, 55);
            labelProductId.Name = "labelProductId";
            labelProductId.Size = new System.Drawing.Size(78, 20);
            labelProductId.TabIndex = 2;
            labelProductId.Text = "Product Id";
            // 
            // textBoxProductId
            // 
            textBoxProductId.Location = new System.Drawing.Point(200, 52);
            textBoxProductId.Name = "textBoxProductId";
            textBoxProductId.Size = new System.Drawing.Size(200, 27);
            textBoxProductId.TabIndex = 3;
            // 
            // labelQuantityRequired
            // 
            labelQuantityRequired.AutoSize = true;
            labelQuantityRequired.Location = new System.Drawing.Point(12, 95);
            labelQuantityRequired.Name = "labelQuantityRequired";
            labelQuantityRequired.Size = new System.Drawing.Size(122, 20);
            labelQuantityRequired.TabIndex = 4;
            labelQuantityRequired.Text = "Quantity Required";
            // 
            // textBoxQuantityRequired
            // 
            textBoxQuantityRequired.Location = new System.Drawing.Point(200, 92);
            textBoxQuantityRequired.Name = "textBoxQuantityRequired";
            textBoxQuantityRequired.Size = new System.Drawing.Size(200, 27);
            textBoxQuantityRequired.TabIndex = 5;
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Location = new System.Drawing.Point(12, 135);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new System.Drawing.Size(74, 20);
            labelTotalPrice.TabIndex = 6;
            labelTotalPrice.Text = "TotalPrice";
            // 
            // textBoxTotalPrice
            // 
            textBoxTotalPrice.Location = new System.Drawing.Point(200, 132);
            textBoxTotalPrice.Name = "textBoxTotalPrice";
            textBoxTotalPrice.Size = new System.Drawing.Size(200, 27);
            textBoxTotalPrice.TabIndex = 7;
            // 
            // labelIsOnlyClub
            // 
            labelIsOnlyClub.AutoSize = true;
            labelIsOnlyClub.Location = new System.Drawing.Point(12, 175);
            labelIsOnlyClub.Name = "labelIsOnlyClub";
            labelIsOnlyClub.Size = new System.Drawing.Size(77, 20);
            labelIsOnlyClub.TabIndex = 8;
            labelIsOnlyClub.Text = "IsOnlyClub";
            // 
            // checkBoxIsOnlyClub
            // 
            checkBoxIsOnlyClub.Location = new System.Drawing.Point(200, 172);
            checkBoxIsOnlyClub.Name = "checkBoxIsOnlyClub";
            checkBoxIsOnlyClub.Size = new System.Drawing.Size(24, 24);
            checkBoxIsOnlyClub.TabIndex = 9;
            // 
            // labelStartSale
            // 
            labelStartSale.AutoSize = true;
            labelStartSale.Location = new System.Drawing.Point(12, 205);
            labelStartSale.Name = "labelStartSale";
            labelStartSale.Size = new System.Drawing.Size(72, 20);
            labelStartSale.TabIndex = 10;
            labelStartSale.Text = "StartSale";
            // 
            // textBoxStartSale
            // 
            textBoxStartSale.Location = new System.Drawing.Point(200, 202);
            textBoxStartSale.Name = "textBoxStartSale";
            textBoxStartSale.Size = new System.Drawing.Size(200, 27);
            textBoxStartSale.TabIndex = 11;
            // 
            // labelEndSale
            // 
            labelEndSale.AutoSize = true;
            labelEndSale.Location = new System.Drawing.Point(12, 245);
            labelEndSale.Name = "labelEndSale";
            labelEndSale.Size = new System.Drawing.Size(60, 20);
            labelEndSale.TabIndex = 12;
            labelEndSale.Text = "EndSale";
            // 
            // textBoxEndSale
            // 
            textBoxEndSale.Location = new System.Drawing.Point(200, 242);
            textBoxEndSale.Name = "textBoxEndSale";
            textBoxEndSale.Size = new System.Drawing.Size(200, 27);
            textBoxEndSale.TabIndex = 13;
            // 
            // buttonOk
            // 
            buttonOk.Location = new System.Drawing.Point(200, 285);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new System.Drawing.Size(94, 29);
            buttonOk.TabIndex = 14;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(306, 285);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(94, 29);
            buttonCancel.TabIndex = 15;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // SaleForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(460, 380);

            // עיצוב כללי
            this.BackColor = Color.FromArgb(245, 238, 230);
            this.Font = new Font("Segoe UI", 10F);

            // תרגום תוויות
            labelId.Text = "מזהה";
            labelProductId.Text = "מזהה מוצר";
            labelQuantityRequired.Text = "כמות למבצע";
            labelTotalPrice.Text = "מחיר ";
            labelIsOnlyClub.Text = "מבצע לחברי מועדון בלבד";
            labelStartSale.Text = "תחילת מבצע";
            labelEndSale.Text = "סיום מבצע";

            // שדרוג שדות וכפתורים
            textBoxId.BorderStyle = BorderStyle.FixedSingle;
            textBoxProductId.BorderStyle = BorderStyle.FixedSingle;
            textBoxQuantityRequired.BorderStyle = BorderStyle.FixedSingle;
            textBoxTotalPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxStartSale.BorderStyle = BorderStyle.FixedSingle;
            textBoxEndSale.BorderStyle = BorderStyle.FixedSingle;

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
            Controls.Add(textBoxEndSale);
            Controls.Add(labelEndSale);
            Controls.Add(textBoxStartSale);
            Controls.Add(labelStartSale);
            Controls.Add(checkBoxIsOnlyClub);
            Controls.Add(labelIsOnlyClub);
            Controls.Add(textBoxTotalPrice);
            Controls.Add(labelTotalPrice);
            Controls.Add(textBoxQuantityRequired);
            Controls.Add(labelQuantityRequired);
            Controls.Add(textBoxProductId);
            Controls.Add(labelProductId);
            Controls.Add(textBoxId);
            Controls.Add(labelId);

            Name = "SaleForm";
            Text = "מבצע";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelProductId;
        private System.Windows.Forms.TextBox textBoxProductId;
        private System.Windows.Forms.Label labelQuantityRequired;
        private System.Windows.Forms.TextBox textBoxQuantityRequired;
        private System.Windows.Forms.Label labelTotalPrice;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Label labelIsOnlyClub;
        private System.Windows.Forms.CheckBox checkBoxIsOnlyClub;
        private System.Windows.Forms.Label labelStartSale;
        private System.Windows.Forms.TextBox textBoxStartSale;
        private System.Windows.Forms.Label labelEndSale;
        private System.Windows.Forms.TextBox textBoxEndSale;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}
