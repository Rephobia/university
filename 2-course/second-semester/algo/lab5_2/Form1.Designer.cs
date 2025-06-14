namespace lab5_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBox1 = new ComboBox();
            checkedListBox1 = new CheckedListBox();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            domainUpDown1 = new DomainUpDown();
            listView1 = new ListView();
            treeView1 = new TreeView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "чай", "кофе", "сок" });
            comboBox1.Location = new Point(193, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "сахар", "лимон", "молоко" });
            checkedListBox1.Location = new Point(194, 44);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(120, 58);
            checkedListBox1.TabIndex = 1;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(197, 137);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(197, 119);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 3;
            label1.Text = "Количество порций";
            // 
            // domainUpDown1
            // 
            domainUpDown1.Items.Add("маленький");
            domainUpDown1.Items.Add("средний");
            domainUpDown1.Items.Add("большой");
            domainUpDown1.Location = new Point(197, 166);
            domainUpDown1.Name = "domainUpDown1";
            domainUpDown1.Size = new Size(120, 23);
            domainUpDown1.TabIndex = 4;
            domainUpDown1.Text = "размер стакана";
            // 
            // listView1
            // 
            listView1.Location = new Point(320, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(373, 192);
            listView1.TabIndex = 5;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(12, 12);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(176, 192);
            treeView1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(215, 195);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Заказать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(treeView1);
            Controls.Add(listView1);
            Controls.Add(domainUpDown1);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(checkedListBox1);
            Controls.Add(comboBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private CheckedListBox checkedListBox1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private DomainUpDown domainUpDown1;
        private ListView listView1;
        private TreeView treeView1;
        private Button button1;
    }
}
