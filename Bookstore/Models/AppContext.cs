using System.Data;
using System.Data.SqlClient;
using System.Configuration;




namespace Bookstore.Models
{
    public class AppContext
    {
        private SqlDataReader reader;
        private SqlConnection conn;
        private DataTable table;
        string cs = "";
        public DataTable Requests()
        {
            conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Books";
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



