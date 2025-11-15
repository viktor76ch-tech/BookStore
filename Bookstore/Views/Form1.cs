using Bookstore.Views;
using System;
using System.Windows.Forms;

namespace Bookstore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            Models.AppContext _context = new Models.AppContext();
            dataGridView1.DataSource = _context.AcquisitionData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name_win = "Добавление книги";
            string name_but = "Добавить книгу";
            Form2 form2 = new Form2(name_win, name_but);
            form2.ShowDialog();
        }
    }
}
