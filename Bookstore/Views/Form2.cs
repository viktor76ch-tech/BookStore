using Bookstore.Models;
using Bookstore.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Bookstore.Views
{
    public partial class Form2 : Form
    {
        Book book = new Book();
        public Form2(string nw, string nb, Book b)
        {
            InitializeComponent();
            label11.Text = nw;
            button1.Text = nb;
            book = b;
            textBox1.Text = book.Name;
            textBox2.Text = book.LastName;
            textBox3.Text = book.FirstName;
            comboBox1.Text = book.Genre;
            textBox5.Text = book.Publisher;
            textBox4.Text = book.YearPub.ToString();
            textBox6.Text = book.Pages.ToString();
            textBox9.Text = book.CostPrice.ToString();
            textBox8.Text = book.Price.ToString();
            textBox7.Text = book.Number.ToString();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var pb in this.Controls.OfType<TextBox>())
            {
                if (pb.Text == "")
                {
                    MessageBox.Show("Не все данные введены", "Уведомление");
                    return;
                }
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Не все данные введены", "Уведомление");
                return;
            }

            if (button1.Text == "Добавить книгу")
            {
                Book newBook = new Book();
                newBook = FillBook();
                Requests aB = new Requests();
                aB.AddBook(newBook);
                ClearForm();
            }

            if (button1.Text == "Изменить")
            {
                Book chBook = new Book();
                chBook = FillBook();
                chBook.Id = book.Id;
                Requests chB = new Requests();
                chB.СhangeBook(book,chBook);
            }
        }
        public Book FillBook()
        { 
            Book nBook = new Book();
            nBook.Name = textBox1.Text;
            nBook.LastName = textBox2.Text;
            nBook.FirstName = textBox3.Text;
            nBook.Genre = comboBox1.Text;
            nBook.Publisher = textBox5.Text;
            nBook.YearPub = int.Parse(textBox4.Text);
            nBook.Pages = int.Parse(textBox6.Text);
            nBook.CostPrice = float.Parse(textBox9.Text);
            nBook.Price = float.Parse(textBox8.Text);
            nBook.Number = int.Parse(textBox7.Text);
            return nBook;
        }

        public void ClearForm()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
        }
    }
}
