using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLabs
{
    class DatabaseCon
    {
        public static string conString = "Data Source=DESKTOP-4G769OV;Initial Catalog=Colegiu;Integrated Security=True";

        public static void InsertUser(string id, string name)
        {
            try
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (con.State == System.Data.ConnectionState.Open)
                {
                    string querry = $"INSERT INTO Specialitate VALUES ({id}, '{name}')";
                    SqlCommand cmd = new SqlCommand(querry, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static string getAllFields() { 

            string queryString = "Select * from Specialitate";
            string result = "";

            using (SqlConnection connection = new SqlConnection(conString))
            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result += String.Format("{0}, {1}\n", reader[0], reader[1]);
                        }
                    }
                    reader.Close();
                }
            }

            return result;
        }


    }
}
