namespace UI
{
    partial class CustomerForm
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
            textBoxId = new TextBox();
            textBoxName = new TextBox();
            textBoxPhone = new TextBox();
            textBoxAddress = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonOk = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(100, 12);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(200, 27);
            textBoxId.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(100, 41);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 27);
            textBoxName.TabIndex = 1;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(100, 70);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(200, 27);
            textBoxPhone.TabIndex = 2;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(100, 99);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(200, 27);
            textBoxAddress.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 10;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 11;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 12;
            label3.Text = "Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 102);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 13;
            label4.Text = "Address";
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(144, 140);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 28);
            buttonOk.TabIndex = 4;
            buttonOk.Text = "OK";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(225, 140);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 28);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 180);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxName);
            Controls.Add(textBoxId);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Customer";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
    }
}