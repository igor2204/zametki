using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zametki
{
    public partial class Form1 : Form
    {

        DataTable table;


        public Form1()
        {
            InitializeComponent();
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
    }
}
