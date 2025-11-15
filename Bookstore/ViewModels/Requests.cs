using Bookstore.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;
using System.Windows.Forms;


namespace Bookstore.ViewModels
{
    internal class Requests
    {
        private SqlDataReader reader;
        private SqlConnection conn;
        private DataTable table;
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
                newBook.Number.ToString() + ");";
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

        public void DeleteBook(string idBook)
        {
            string comd;
            comd = "DELETE FROM Books\r\nWHERE Id = " + idBook + ";";
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = comd;
            cmd.Connection = conn;
            int str = 0;

            DialogResult result = MessageBox.Show("Вы точно хотите удалить книгу", "Подтверждение удаления", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                str = cmd.ExecuteNonQuery();
            }
            else
            {
                conn.Close();
                return;
            }

            if (str > 0)
            {
                MessageBox.Show("Книга успешно удалена", "Уведомление");
            }
            conn.Close();
        }

        public void СhangeBook(Book oldBook, Book nBook)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            int str = 0;
            if (oldBook.Name != nBook.Name) 
            {
                cmd.CommandText = "UPDATE Books\r\nSET Name = N'" + nBook.Name + "'" +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.LastName != nBook.LastName)
            {
                cmd.CommandText = "UPDATE Books\r\nSET LastName = N'" + nBook.LastName + "'" +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.FirstName != nBook.FirstName)
            {
                cmd.CommandText = "UPDATE Books\r\nSET FirstName = N'" + nBook.FirstName + "'" +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.Genre != nBook.Genre)
            {
                cmd.CommandText = "UPDATE Books\r\nSET Genre = N'" + nBook.Genre + "'" +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.Publisher != nBook.Publisher)
            {
                cmd.CommandText = "UPDATE Books\r\nSET Publisher = N'" + nBook.Publisher + "'" +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.YearPub != nBook.YearPub)
            {
                cmd.CommandText = "UPDATE Books\r\nSET YearPub = " + nBook.YearPub.ToString() +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.Pages != nBook.Pages)
            {
                cmd.CommandText = "UPDATE Books\r\nSET Pages = " + nBook.Pages.ToString() +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.CostPrice != nBook.CostPrice)
            {
                cmd.CommandText = "UPDATE Books\r\nSET CostPrice = " + nBook.CostPrice.ToString() +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.Price != nBook.Price)
            {
                cmd.CommandText = "UPDATE Books\r\nSET Price = " + nBook.Price.ToString() +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (oldBook.Number != nBook.Number)
            {
                cmd.CommandText = "UPDATE Books\r\nSET Number = " + nBook.Number.ToString() +
                    "\r\nWHERE Id = " + nBook.Id.ToString() + ";";
                str = cmd.ExecuteNonQuery();
            }
            if (str > 0)
            {
                MessageBox.Show("Книга успешно Изменена", "Уведомление");
            }
            conn.Close();
        }

        public DataTable SearchBook(string stolb, string partWord)
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Books WHERE " + stolb + " LIKE N'" + partWord + "%';";
            cmd.Connection = conn;
            table = new DataTable();
            reader = cmd.ExecuteReader();
            int line = 0;
            do
            {
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            table.Columns.Add(reader.GetName(i));
                        }
                        line++;
                    }
                    DataRow row = table.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];

                    }
                    table.Rows.Add(row);
                }
            } while (reader.NextResult());

            reader.Close();
            conn.Close();
            return table;
        }
    }
}
