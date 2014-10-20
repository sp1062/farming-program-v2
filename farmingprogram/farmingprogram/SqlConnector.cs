using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace farmingprogram
{
    class SqlConnector
    {
        const string DATABASE_NAME = "farmingdatabase";
        const string DATABASE_USERNAME = "anglia";
        const string DATABASE_PASSWORD = "anglia";

        const string LOGIN_SUBDATABASE = "login";
        const string MAIN_SUBDATABASE = "main";
        const string SERVER_NAME = "p3plcpnl0122.prod.phx3.secureserver.net";
        public void startConnection()
        {
            string connetionString = null;
            SqlConnection connection;
            connetionString = "Data Source="+SERVER_NAME+";Initial Catalog="+DATABASE_NAME+";User ID="+DATABASE_USERNAME+";Password="+DATABASE_PASSWORD+"";
            connection = new SqlConnection(connetionString);
            try
            {
                //connection.Open();
                //MessageBox.Show("Connected.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
