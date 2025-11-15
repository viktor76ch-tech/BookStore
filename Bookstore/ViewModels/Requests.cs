using Bookstore.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;


namespace Bookstore.ViewModels
{
    internal class Requests
    {
        private SqlConnection conn;
        public void AddBook(Book newBook)
        {
            string comd;
            comd = "insert into Books(Name, LastName, FirstName, Genre, Publisher, " +
                "YearPub, Pages, CostPrice, Price, Number)" +
                "\r\nvalues(N'" + newBook.Name + "', " +
                "N'" + newBook.LastName + "', " +
                "N'" + newBook.FirstName + "', " +
                "N'" + newBook.Genre + "', " +
                "N'" + newBook.Publisher + "', " +
                newBook.YearPub.ToString() + ", " +
                newBook.Pages.ToString() + ", " +
                newBook.CostPrice.ToString() + ", " +
                newBook.Price.ToString() + ", " +
                newBook.CostPrice.ToString() + ");";
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = comd;
            cmd.Connection = conn;
            int str = 0;
            str = cmd.ExecuteNonQuery();
            if (str > 0)
            {
                MessageBox.Show("Книга успешно добавлена", "Уведомление");
            }
            conn.Close();
        }
    }
}
