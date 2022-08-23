using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.Models;
using PaymentAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly IPaymentSerivces productService;
        public PaymentDetailController(IPaymentSerivces product)
        {
            productService = product;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<PaymentDetail>> Get()
        {
            return await productService.Get();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<PaymentDetail> Get(int id)
        {
            return await productService.Get(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<PaymentDetail>> Post([FromBody] PaymentDetail product)
        {
            return await productService.Add(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<PaymentDetail> Put(int id, [FromBody] PaymentDetail product)
        {
            return await productService.Update(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDetail>> Delete(int id)
        {
            return await productService.Delete(id);
        }
    }
}
