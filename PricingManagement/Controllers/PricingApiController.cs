using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using PricingManagement.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PricingManagement.Controllers
{
    public class PricingApiController : ApiController
    {
        // GET api/<controller>/5
        [Route("GetPriceByProductId")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetPriceByProductId(int productId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58693/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("GetProductByID?productid=" + productId);                
                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                ProductInfo product = new ProductInfo();

                product.ProductID = jsonResponse.ProductID;
                product.ProductName = jsonResponse.ProductName;
                product.ProductDescription = jsonResponse.ProductDescription;
                product.ProductPrice = jsonResponse.ProductPrice;                    
                return Ok(product);
            }
        }

        [Route("GetProductList")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetProductList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58693/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("GetAllProducts");

                dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

                List<ProductInfo> list = new List<ProductInfo>();

                foreach( var jsonData in jsonResponse)
                {
                    ProductInfo product = new ProductInfo();
                    product.ProductID = jsonData.ProductID;
                    product.ProductName = jsonData.ProductName;
                    product.ProductDescription = jsonData.ProductDescription;
                    list.Add(product);
                }
                
                return Ok(list);
            }
        }
    }
}