using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zametki
{
    public partial class Form1 : Form
    {

        DataTable table;


        public Form1()
        {
            InitializeComponent();

            button5.Click += button5_Click;
            button6.Click += button6_Click;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

        }



        void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;

            try
            {
                // пытаемся сохранить текст в файл
                System.IO.File.WriteAllText(filename, txtTextzametki.Text);
                MessageBox.Show("Файл сохранен");
            }
            catch (Exception ex) when (ex is UnauthorizedAccessException || ex is IOException || ex is ArgumentException || ex is DirectoryNotFoundException || ex is PathTooLongException || ex is NotSupportedException)
            {
                MessageBox.Show("Невозможно сохранить файл. Пожалуйста, проверьте правильность выбранного файла и доступ к папке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // открытие файла
        void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            try
            {
                // пытаемся прочитать файл в строку
                string fileText = System.IO.File.ReadAllText(filename);
                txtTextzametki.Text = fileText;
                MessageBox.Show("Файл открыт");
            }
            catch (Exception ex) when (ex is UnauthorizedAccessException || ex is IOException || ex is NotSupportedException)
            {
                MessageBox.Show("Невозможно открыть выбранный файл. Убедитесь, что выбранный файл является текстовым файлом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Заглавие", typeof(string));
            table.Columns.Add("Текст заметки", typeof(string));
            dataGridView1.DataSource = table;
            dataGridView1.Columns["Текст заметки"].Visible = false;
            dataGridView1.Columns["Заглавие"].Width = 172;



        }

        private void txtTextzametki_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtZaglavie.Clear();
            txtTextzametki.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtZaglavie.Text, txtTextzametki.Text);
            txtZaglavie.Clear();
            txtTextzametki.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            if (index > -1)
            {
                txtZaglavie.Text = table.Rows[index].ItemArray[0].ToString();
                txtTextzametki.Text = table.Rows[index].ItemArray[1].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }

     

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
          
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

  
    }
}
