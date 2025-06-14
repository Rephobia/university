using System;
using System.Text;
using System.Windows.Forms;

namespace lab5_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeTreeView();
            InitializeListView();
        }

        private void InitializeTreeView()
        {
            TreeNode root = new TreeNode("Меню");

            TreeNode drinks = new TreeNode("Напитки");
            drinks.Nodes.Add("чай");
            drinks.Nodes.Add("кофе");
            drinks.Nodes.Add("сок");

            TreeNode addons = new TreeNode("Добавки");
            addons.Nodes.Add("сахар");
            addons.Nodes.Add("лимон");
            addons.Nodes.Add("молоко");

            root.Nodes.Add(drinks);
            root.Nodes.Add(addons);

            treeView1.Nodes.Add(root);
            treeView1.ExpandAll();
        }

        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Параметр", 100);
            listView1.Columns.Add("Значение", 150);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string drink = comboBox1.SelectedItem?.ToString() ?? "не выбрано";
            string size = domainUpDown1.Text;
            int count = (int)numericUpDown1.Value;

            // Собираем добавки
            StringBuilder addons = new StringBuilder();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                addons.Append(item.ToString() + ", ");
            }
            if (addons.Length > 0)
                addons.Length -= 2; // удаляем последнюю запятую и пробел

            // Добавляем в ListView
            listView1.Items.Add(new ListViewItem(new[] { "Напиток", drink }));
            listView1.Items.Add(new ListViewItem(new[] { "Размер", size }));
            listView1.Items.Add(new ListViewItem(new[] { "Порций", count.ToString() }));
            listView1.Items.Add(new ListViewItem(new[] { "Добавки", addons.ToString() }));
        }
    }
}
