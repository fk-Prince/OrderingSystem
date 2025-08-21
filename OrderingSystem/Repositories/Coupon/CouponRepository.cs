using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using OrderingSystem.Database;
using OrderingSystem.Model;

namespace OrderingSystem.Repositories.Kiosk
{
    public class CouponRepository : ICouponRepository
    {
        public async Task<Coupon> GetCoupon(string code)
        {
            var db = MyDatabase.getInstance();

            try
            {
                var conn = await db.GetConnection();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Coupon WHERE coupon_code = @coupon_code LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@coupon_code", code);
                MySqlDataReader reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    return new Coupon(
                        reader.GetString("coupon_code"),
                        reader.GetDouble("rate"),
                        reader.GetDateTime("expiry_Date"),
                        reader.GetString("coupon_desc")
                        );
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                await db.CloseConnection();
            }

            return null;
        }
    }
}
