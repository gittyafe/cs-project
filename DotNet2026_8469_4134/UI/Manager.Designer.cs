namespace UI
{
    partial class Manager
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(510, 110);
            button1.Name = "button1";
            button1.Size = new Size(131, 190);
            button1.TabIndex = 0;
            button1.Text = "לקוחות";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(333, 110);
            button2.Name = "button2";
            button2.Size = new Size(129, 190);
            button2.TabIndex = 1;
            button2.Text = "מוצרים";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(158, 110);
            button3.Name = "button3";
            button3.Size = new Size(129, 190);
            button3.TabIndex = 2;
            button3.Text = "מבצעים";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Manager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);

            // עיצוב כללי תואם לשאר היישום
            this.BackColor = Color.FromArgb(245, 238, 230);
            this.Font = new Font("Segoe UI", 10F);

            // כותרת ראשית
            var title = new Label();
            title.Text = "מנהל";
            title.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(90, 70, 60);
            title.Size = new Size(760, 50);
            title.Location = new Point(20, 10);
            title.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(title);

            // כפתורים גדולים וסגנון מודרני
            button1.Size = new Size(170, 220);
            button2.Size = new Size(170, 220);
            button3.Size = new Size(170, 220);

            button1.BackColor = Color.FromArgb(181, 136, 99);
            button1.ForeColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            button2.BackColor = Color.FromArgb(181, 136, 99);
            button2.ForeColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            button3.BackColor = Color.FromArgb(181, 136, 99);
            button3.ForeColor = Color.White;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.Font = new Font("Segoe UI", 14, FontStyle.Bold);

            // מיקומים
            button3.Location = new Point(80, 110);
            button2.Location = new Point(305, 110);
            button1.Location = new Point(530, 110);

            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);

            Name = "Manager";
            Text = "מנהל";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
    }
}