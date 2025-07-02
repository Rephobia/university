using System;

namespace lab3
{
    public partial class Form1 : Form
    {
        private DbHelper dbHelper;
        private int selectedLessonId = -1;

        public Form1()
        {
            InitializeComponent();
            string connectionString = "Data Source=./app.db;";
            dbHelper = new DbHelper(connectionString);

            LoadComboBoxes();
            LoadDataGrid();


        }
        private void LoadComboBoxes()
        {
            comboBox1.DataSource = dbHelper.GetTeachers();
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "id";

            comboBox2.DataSource = dbHelper.GetTable("groups");
            comboBox2.DisplayMember = "specialty";
            comboBox2.ValueMember = "id";

            comboBox3.DataSource = dbHelper.GetTable("subjects");
            comboBox3.DisplayMember = "name";
            comboBox3.ValueMember = "id";

            comboBox4.DataSource = dbHelper.GetTable("lesson_types");
            comboBox4.DisplayMember = "name";
            comboBox4.ValueMember = "id";
        }
        private void LoadDataGrid(string filter = "")
        {
            dataGridView1.DataSource = dbHelper.GetLessons(filter);
            dataGridView1.Columns["id"].HeaderText = "ID занятия";
            dataGridView1.Columns["Teacher"].HeaderText = "Преподаватель";
            dataGridView1.Columns["GroupName"].HeaderText = "Группа";
            dataGridView1.Columns["Subject"].HeaderText = "Предмет";
            dataGridView1.Columns["LessonType"].HeaderText = "Тип занятия";
            dataGridView1.Columns["hours"].HeaderText = "Часы";
            selectedLessonId = -1;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int teacherId = Convert.ToInt32(comboBox1.SelectedValue);
            int groupId = Convert.ToInt32(comboBox2.SelectedValue);
            int subjectId = Convert.ToInt32(comboBox3.SelectedValue);
            int lessonTypeId = Convert.ToInt32(comboBox4.SelectedValue);
            int hours = (int)numericUpDown1.Value;

            dbHelper.AddLesson(teacherId, groupId, subjectId, lessonTypeId, hours);
            LoadDataGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedLessonId == -1)
            {
                MessageBox.Show("Выберите запись для редактирования");
                return;
            }

            int teacherId = Convert.ToInt32(comboBox1.SelectedValue);
            int groupId = Convert.ToInt32(comboBox2.SelectedValue);
            int subjectId = Convert.ToInt32(comboBox3.SelectedValue);
            int lessonTypeId = Convert.ToInt32(comboBox4.SelectedValue);
            int hours = (int)numericUpDown1.Value;

            dbHelper.UpdateLesson(selectedLessonId, teacherId, groupId, subjectId, lessonTypeId, hours);
            LoadDataGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedLessonId == -1)
            {
                MessageBox.Show("Выберите запись для удаления");
                return;
            }

            dbHelper.DeleteLesson(selectedLessonId);
            LoadDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filter = textBox1.Text.Trim();
            LoadDataGrid(filter);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            LoadDataGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedLessonId = Convert.ToInt32(row.Cells["id"].Value);
                Console.WriteLine("Selected ID: " + selectedLessonId);
            }
        }
    }
}
