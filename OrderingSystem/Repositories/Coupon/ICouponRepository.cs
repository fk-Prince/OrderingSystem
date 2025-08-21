using System.Threading.Tasks;
using OrderingSystem.Model;

namespace OrderingSystem.Repositories.Kiosk
{
    public interface ICouponRepository
    {
        Task<Coupon> GetCoupon(string code);
    }
}
