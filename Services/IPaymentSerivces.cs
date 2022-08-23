using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Services
{
    public interface IPaymentSerivces
    {
        Task<IEnumerable<PaymentDetail>> Get();
        Task<PaymentDetail> Get(int Id);
        Task<PaymentDetail> Add(PaymentDetail payment);
        Task<PaymentDetail> Update(PaymentDetail payment);
        Task<PaymentDetail> Delete(int Id);
    }
}
