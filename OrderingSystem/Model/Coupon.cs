using System;

namespace OrderingSystem.Model
{
    public class Coupon
    {
        private string coupon_code;
        private double rate;
        private DateTime expiryDate;
        private string coupon_desc;
        public Coupon(string coupon_code, double rate, DateTime expiryDate, string coupon_desc)
        {
            this.coupon_code = coupon_code;
            this.rate = rate;
            this.expiryDate = expiryDate;
            this.coupon_desc = coupon_desc;
        }

        public string Coupon_desc { get => coupon_desc; }
        public string Coupon_code { get => coupon_code; }
        public double Rate { get => rate; }
        public DateTime ExpiryDate { get => expiryDate; }
    }
}
