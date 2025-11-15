using Bookstore.Models;
using Bookstore.ViewModels;
using System;
using System.Windows.Forms;

namespace Bookstore.Views
{
    public partial class Form2 : Form
    {
        public Form2(string nw, string nb)
        {
            InitializeComponent();
            label11.Text = nw;
            button1.Text = nb;
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            Book newBook = new Book();
            newBook.Name = textBox1.Text;
            newBook.LastName = textBox2.Text;
            newBook.FirstName = textBox3.Text;
            newBook.Genre = comboBox1.Text;
            newBook.Publisher = textBox5.Text;
            newBook.YearPub = int.Parse(textBox4.Text);
            newBook.Pages = int.Parse(textBox6.Text);
            newBook.CostPrice = float.Parse(textBox9.Text);
            newBook.Price = float.Parse(textBox8.Text);
            newBook.Number = int.Parse(textBox7.Text);
            ViewModels.Requests ab = new ViewModels.Requests();
            ab.AddBook(newBook);
        }
    }
}
