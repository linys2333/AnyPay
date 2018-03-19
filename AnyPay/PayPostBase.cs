using AnyPay.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnyPay
{
    public abstract class PayPostBase<T> where T : PayResponse
    {
        protected readonly Merchant m_Merchant;
        
        protected readonly PayRequest m_PayRequest;

        public List<PayParam> PayParams { get; set; }

        public abstract string PostUrl { get; }

        protected PayPostBase(Merchant merchant, PayRequest request)
        {
            m_Merchant = merchant;
            m_PayRequest = request;
            PayParams = new List<PayParam>();
        }

        public abstract Task<T> PostAsync();
    }
}
