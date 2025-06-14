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
            TreeNode root = new TreeNode("����");

            TreeNode drinks = new TreeNode("�������");
            drinks.Nodes.Add("���");
            drinks.Nodes.Add("����");
            drinks.Nodes.Add("���");

            TreeNode addons = new TreeNode("�������");
            addons.Nodes.Add("�����");
            addons.Nodes.Add("�����");
            addons.Nodes.Add("������");

            root.Nodes.Add(drinks);
            root.Nodes.Add(addons);

            treeView1.Nodes.Add(root);
            treeView1.ExpandAll();
        }

        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("��������", 100);
            listView1.Columns.Add("��������", 150);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string drink = comboBox1.SelectedItem?.ToString() ?? "�� �������";
            string size = domainUpDown1.Text;
            int count = (int)numericUpDown1.Value;

            // �������� �������
            StringBuilder addons = new StringBuilder();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                addons.Append(item.ToString() + ", ");
            }
            if (addons.Length > 0)
                addons.Length -= 2; // ������� ��������� ������� � ������

            // ��������� � ListView
            listView1.Items.Add(new ListViewItem(new[] { "�������", drink }));
            listView1.Items.Add(new ListViewItem(new[] { "������", size }));
            listView1.Items.Add(new ListViewItem(new[] { "������", count.ToString() }));
            listView1.Items.Add(new ListViewItem(new[] { "�������", addons.ToString() }));
        }
    }
}
