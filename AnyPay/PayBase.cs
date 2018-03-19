using AnyPay.Models;

namespace AnyPay
{
    public abstract class PayBase
    {
        protected readonly PayPlatform m_PayPlatform;

        protected PayBase(PayPlatform payPlatform)
        {
            m_PayPlatform = payPlatform;
        }
        
        public PayPlatform GetPayPlatform() => m_PayPlatform;
    }
}
