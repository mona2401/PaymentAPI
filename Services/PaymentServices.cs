using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using PaymentAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Services
{
    public class PaymentServices : IPaymentSerivces
    {
        private readonly PaymentDetailContext dbContext;
        public PaymentServices(PaymentDetailContext _db)
        {
            dbContext = _db;
        }
        public async Task<PaymentDetail> Add(PaymentDetail payment)
        {
            await dbContext.PaymentDetails.AddAsync(payment);
            await dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<PaymentDetail> Delete(int id)
        {
            var result = await dbContext.PaymentDetails.FirstOrDefaultAsync(x => x.PaymentDetailId == id);
            if (result != null)
            {
                dbContext.Entry(result).State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<PaymentDetail>> Get()
        {
            var result = await dbContext.PaymentDetails.ToListAsync();
            return result;
        }

        public async Task<PaymentDetail> Get(int id)
        {
            var result = await dbContext.PaymentDetails.FirstOrDefaultAsync(x => x.PaymentDetailId == id);
            return result;
        }

        public async Task<PaymentDetail> Update(PaymentDetail product)
        {
            var result = await dbContext.PaymentDetails.FirstOrDefaultAsync(a => a.PaymentDetailId == product.PaymentDetailId);
            if (result != null)
            {
                result.CardOwnerName = product.CardOwnerName;
                result.CardNumber = product.CardNumber;
                result.ExpirationDate = product.ExpirationDate;
                result.SecurityCode = product.SecurityCode;
                await dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
