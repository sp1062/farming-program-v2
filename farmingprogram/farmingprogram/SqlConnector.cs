using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace farmingprogram
{
    class SqlConnector
    {
        private static SqlConnection connection = null;

        public static void startConnection()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + path + @"\database\DbFarmProgram.mdf;Integrated Security=True");
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening connection. Closing program.");
                Environment.Exit(0);
            }
        }

        public static SqlConnection getConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                startConnection();
            }
            return connection;
        }

        public static Boolean validPassword(String username, String password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Invalid credentials.");
                return false;
            }
            
            string queryString = "SELECT * FROM Login";
            SqlDataReader command = new SqlCommand(queryString, getConnection()).ExecuteReader();

            try
            {
                while (command.Read())
                {
                    String name = command.GetString(0).ToLower();
                    String pass = command.GetString(1).ToLower();
                    if (name.Equals(username.ToLower()) && pass.Equals(PasswordEncryption.Encrypt(password).ToLower()))
                    {
                        return true;
                    }
                }
                MessageBox.Show("Invalid username or password try again.");
            }
            finally
            {
                command.Close();
            }
            return false;
        }
    }
}
