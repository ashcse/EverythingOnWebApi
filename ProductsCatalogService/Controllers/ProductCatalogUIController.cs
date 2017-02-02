using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using ProductsCatalogService.Models;
using System.Net;
using System.Web.Http.Results;

namespace ProductsCatalogService.Controllers
{
    public class ProductCatalogUIController : Controller
    {
        #region Private Fields

        private ProductCatalogApiController _productApiController = null;

        #endregion

        #region Constructors        

        public ProductCatalogUIController(ProductCatalogApiController apiController)
        {
            _productApiController = apiController;
        }

        #endregion

        // GET: ProductCatalogUI
        public async Task<ActionResult> Index()
        {
            var products = await _productApiController.GetAllProducts();
            return View(((OkNegotiatedContentResult<List<ProductInfo>>)(products)).Content.AsEnumerable<ProductInfo>());
        }

        // GET: ProductCatalogUI/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var response = await _productApiController.GetProductById(id);
            return View(((OkNegotiatedContentResult<ProductInfo>)(response)).Content);
        }

        // GET: ProductCatalogUI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductID,ProductName,ProductDescription,ProductCategory,ProductPrice")] ProductInfo product)
        {
            if (ModelState.IsValid)
            {
                await _productApiController.AddProduct(product);                
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: ProductCatalogUI/Edit/5        
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var response = await _productApiController.GetProductById(id);
            return View(((OkNegotiatedContentResult<ProductInfo>)(response)).Content);
        }

        // POST: ProductCatalogUI/Edit/5
        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductID,ProductName,ProductDescription,ProductCategory,ProductPrice")] ProductInfo product)
        {
            if (ModelState.IsValid)
            {
                await _productApiController.EditProduct(product);                
                return View(product);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET: ProductCatalogUI/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var response = await _productApiController.GetProductById(id);
            return View(((OkNegotiatedContentResult<ProductInfo>)(response)).Content);
        }

        // POST: ProductCatalogUI/Delete/5        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _productApiController.RemoveProduct(id);
            return RedirectToAction("Index");
        }
    }
}
