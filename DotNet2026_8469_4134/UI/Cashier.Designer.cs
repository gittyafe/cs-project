namespace UI
{
    partial class Cashier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonOKToCustID = new Button();
            labelToInsertCustID = new Label();
            textBoxCustID = new TextBox();
            SuspendLayout();
            // 
            // buttonOKToCustID
            // 
            buttonOKToCustID.Location = new Point(409, 289);
            buttonOKToCustID.Name = "buttonOKToCustID";
            buttonOKToCustID.Size = new Size(94, 29);
            buttonOKToCustID.TabIndex = 0;
            buttonOKToCustID.Text = "אישור";
            buttonOKToCustID.UseVisualStyleBackColor = true;
            buttonOKToCustID.Click += buttonOKToCustID_Click;
            // 
            // labelToInsertCustID
            // 
            labelToInsertCustID.AutoSize = true;
            labelToInsertCustID.Location = new Point(370, 122);
            labelToInsertCustID.Name = "labelToInsertCustID";
            labelToInsertCustID.Size = new Size(193, 20);
            labelToInsertCustID.TabIndex = 1;
            labelToInsertCustID.Text = "הכנס תעודת זהות של הלקוח";
            // 
            // textBoxCustID
            // 
            textBoxCustID.Location = new Point(395, 205);
            textBoxCustID.Name = "textBoxCustID";
            textBoxCustID.Size = new Size(125, 27);
            textBoxCustID.TabIndex = 2;
            // 
            // Cashier
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBoxCustID);
            Controls.Add(labelToInsertCustID);
            Controls.Add(buttonOKToCustID);
            Name = "Cashier";
            Text = "Cashier";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOKToCustID;
        private Label labelToInsertCustID;
        private TextBox textBoxCustID;
    }
}