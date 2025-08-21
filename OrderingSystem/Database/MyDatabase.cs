using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace OrderingSystem.Database
{
    public class MyDatabase
    {
        private static MyDatabase instance;
        private static readonly string driver = "server=localhost;user=root;pwd=root;database=yawa;AllowUserVariables=true";
        private MySqlConnection conn;
        private MyDatabase()
        {
        }

        public static MyDatabase getInstance()
        {
            if (instance == null)
            {
                instance = new MyDatabase();
            }
            return instance;
        }

        public async Task<MySqlConnection> GetConnection()
        {


            try
            {
                if (conn == null)
                {
                    conn = new MySqlConnection(driver);
                }


                while (conn.State == ConnectionState.Connecting)
                {

                }


                if (conn.State != ConnectionState.Open)
                {
                    await conn.OpenAsync();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            return conn;

        }
        public async Task CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                await conn.CloseAsync();
            }
        }

    }
}
