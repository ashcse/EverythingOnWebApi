using PricingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace PricingManagement.Controllers
{
    public class PricingController : Controller
    {

        #region Private Fields

        private PricingApiController _pricingApiController = null;

        public PricingController()
        {
            _pricingApiController = new PricingApiController();
        }

        #endregion

        // GET: Returns list of products which are shown in Index view with product names and description
        // Where users can select any product to get price
        public async Task<ActionResult> Index()
        {
            var products = await _pricingApiController.GetProductList();
            return View(((OkNegotiatedContentResult<List<ProductInfo>>)(products)).Content.AsEnumerable<ProductInfo>());
        }

        // GET: Pricing/Details/5 
        // Fetches the price for specified product (for which primary key id is passed)
        // Then returned adn shown in Details view
        // Internally PricingController API is using Restful API which ProductCatalogSerivce, which returns JSON data
        public async Task<ActionResult> Details(int id)
        {
            var product = await _pricingApiController.GetPriceByProductId(id);
            return View(((OkNegotiatedContentResult<ProductInfo>)(product)).Content);
        }
    }
}
