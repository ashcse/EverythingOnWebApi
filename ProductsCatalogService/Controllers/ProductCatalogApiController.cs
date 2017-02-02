using ProductsCatalogService.ApplicationService;
using ProductsCatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ProductsCatalogService.Controllers
{
    /// <summary>
    /// Product controller
    /// </summary>    
    public class ProductCatalogApiController : ApiController
    {
        #region Private fields

        private IApplicationAccess _applicationAccess = null;

        #endregion 

        #region Constructors

        public ProductCatalogApiController(IApplicationAccess applicationAccess)
        {
            _applicationAccess = applicationAccess;
        }

        #endregion 

        #region APIs

        [Route("GetAllProducts")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            dynamic list = await _applicationAccess.GetAllProducts();
            return Ok(list);
        }

        [Route("GetProductByID")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetProductById(int? productID)
        {
            dynamic product = await _applicationAccess.GetProductById(productID);
            return Ok(product);
        }

        /// <summary>
        /// Returns all the products for specified  category
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("GetProductsListByCatagory")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetProductsListByCatagory([FromUri] GetProductsListParam param)
        {
            if (param == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest);
                resp.Content = new StringContent("Error: PrductType is required");
                throw new HttpResponseException(resp);
            }
            else
            {
                dynamic list = await _applicationAccess.GetProducts(param.ProductType);
                return Ok(list);
            }
        }

        [Route("EditProduct")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> EditProduct([FromBody] ProductInfo param)
        {
            if (param == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest);
                resp.Content = new StringContent("Error: Provide product information");
                throw new HttpResponseException(resp);
            }
            else
            {
                dynamic list = await _applicationAccess.UpdateProduct(param);
                return Ok(list);
            }
        }

        [Route("AddProduct")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> AddProduct([FromBody] ProductInfo param)
        {
            if (param == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest);
                resp.Content = new StringContent("Error: Provide product information");
                throw new HttpResponseException(resp);
            }
            else
            {
                dynamic list = await _applicationAccess.AddProduct(param);
                return Ok(list);
            }
        }

        [Route("RemoveProduct")]
        [HttpDelete]
        [AllowAnonymous]
        public async Task<IHttpActionResult> RemoveProduct(int? id)
        {
            if (id == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest);
                resp.Content = new StringContent("Error: Provide product information");
                throw new HttpResponseException(resp);
            }
            else
            {
                dynamic list = await _applicationAccess.RemoveProduct(id);
                return Ok(list);
            }
        }

        #endregion 
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            var modelState = actionContext.ModelState;

            if (actionContext.ActionArguments.Values.Contains(null) || !modelState.IsValid)
            {
                actionContext.Response = actionContext.Request
                     .CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
        }
    } 
}
