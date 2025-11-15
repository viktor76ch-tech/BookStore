using Bookstore.ViewModels;
using Bookstore.Views;
using Bookstore.Models;
using System;
using System.Security.Policy;
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
            dataGridView1.DataSource = null;
            Models.AppContext _context = new Models.AppContext();
            dataGridView1.DataSource = _context.AcquisitionData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Book b = new Book();
            string name_win = "Добавление книги";
            string name_but = "Добавить книгу";
            Form2 form2 = new Form2(name_win, name_but, b);
            form2.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string idBook = Convert.ToString(selectedRow.Cells["Id"].Value);

            Requests delB = new Requests();
            delB.DeleteBook(idBook);
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
        }
    }
}
