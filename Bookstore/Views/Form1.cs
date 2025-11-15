using Bookstore.Models;
using Bookstore.ViewModels;
using Bookstore.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            updateTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            string name_win = "Добавление книги";
            string name_but = "Добавить книгу";
            Form2 form2 = new Form2(name_win, name_but, b);
            form2.ShowDialog();
            updateTable();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string idBook = Convert.ToString(selectedRow.Cells["Id"].Value);

            Requests delB = new Requests();
            delB.DeleteBook(idBook);
            updateTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            Book changeBook = new Book();
            changeBook.Id = int.Parse((string)selectedRow.Cells["Id"].Value);
            changeBook.Name = Convert.ToString(selectedRow.Cells["Name"].Value); 
            changeBook.LastName = Convert.ToString(selectedRow.Cells["LastName"].Value);
            changeBook.FirstName = Convert.ToString(selectedRow.Cells["FirstName"].Value);
            changeBook.Genre = Convert.ToString(selectedRow.Cells["Genre"].Value);
            changeBook.Publisher = Convert.ToString(selectedRow.Cells["Publisher"].Value);
            changeBook.YearPub = int.Parse((string)selectedRow.Cells["YearPub"].Value);
            changeBook.Pages = int.Parse((string)selectedRow.Cells["Pages"].Value);
            changeBook.CostPrice = float.Parse((string)selectedRow.Cells["CostPrice"].Value);
            changeBook.Price = float.Parse((string)selectedRow.Cells["Price"].Value);
            changeBook.Number = int.Parse((string)selectedRow.Cells["Number"].Value);

            string name_win = "Изменение данных книги";
            string name_but = "Изменить";
            Form2 form2 = new Form2(name_win, name_but, changeBook);
            form2.ShowDialog();
            updateTable();
        }
        public void updateTable()
        {
            dataGridView1.DataSource = null;
            Models.AppContext _context = new Models.AppContext();
            dataGridView1.DataSource = _context.AcquisitionData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string strS = textBox1.Text;
            if(textBox1.Text!= "") 
            {
                textBox2.Text = "";
                comboBox1.Text = "";
                dataGridView1.DataSource = null;
                Requests sB = new Requests();
                dataGridView1.DataSource = sB.SearchBook("Name", strS);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string strS = textBox2.Text;
            if (textBox2.Text != "")
            {
                textBox1.Text = "";
                comboBox1.Text = "";
                dataGridView1.DataSource = null;
                Requests sB = new Requests();
                dataGridView1.DataSource = sB.SearchBook("LastName", strS);
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string strS = comboBox1.Text;
            if (comboBox1.Text != "")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                dataGridView1.DataSource = null;
                Requests sB = new Requests();
                dataGridView1.DataSource = sB.SearchBook("Genre", strS);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" && textBox4.Text == "") 
            {
                MessageBox.Show("Не введены критерии для поиска", "Уведомление");
                return;
            }
            if (textBox3.Text != "" && textBox4.Text == "") 
            {
                string s1 = "SELECT * FROM Books WHERE Price > (" + textBox3.Text + ")";
                dataGridView1.DataSource = null;
                Requests sBP = new Requests();
                dataGridView1.DataSource = sBP.SearchBookPrice(s1);
            }
            if (textBox3.Text == "" && textBox4.Text != "") 
            {
                string s2 = "SELECT * FROM Books WHERE Price < (" + textBox4.Text + ")";
                dataGridView1.DataSource = null;
                Requests sBP = new Requests();
                dataGridView1.DataSource = sBP.SearchBookPrice(s2);
            }
            if (textBox3.Text != "" && textBox4.Text != "") 
            {
                string s3 = "SELECT * FROM Books WHERE Price BETWEEN(" + textBox3.Text + ") AND (" + textBox4.Text + ")";
                dataGridView1.DataSource = null;
                Requests sBP = new Requests();
                dataGridView1.DataSource = sBP.SearchBookPrice(s3);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }
    }
}
