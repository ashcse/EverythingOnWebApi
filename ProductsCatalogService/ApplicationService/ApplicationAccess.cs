using ProductsCatalogService.DataService;
using ProductsCatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProductsCatalogService.ApplicationService
{
    /// <summary>
    /// Application access layer which implements IApplicationAccess interface
    /// </summary>
    public class ApplicationAccess : IApplicationAccess
    {
        private IProductsCatalogDataService _productsCatalogDataService = null;
        
        public ApplicationAccess(IProductsCatalogDataService productsCatalogDataService)
        {
            _productsCatalogDataService = productsCatalogDataService;
        }

        /// <summary>
        /// Retruns list of all prducts
        /// </summary>        
        /// <returns>List of all products</returns>
        public async Task<IEnumerable<ProductInfo>> GetAllProducts()
        {
            return await _productsCatalogDataService.GetAllProducts();
        }

        /// <summary>
        /// Retruns product for specified id
        /// </summary>        
        /// <returns>product info for passed id</returns>
        public async Task<ProductInfo> GetProductById(int? productId)
        {
            return await _productsCatalogDataService.GetProductById(productId);
        }


        public async Task<IEnumerable<ProductInfo>> GetProducts(string productCatagory)
        {
            return await _productsCatalogDataService.GetProducts(productCatagory);
        }

        public async Task<int> AddProduct(ProductInfo product)
        {
            return await _productsCatalogDataService.AddProduct(product);
        }

        public async Task<int> UpdateProduct(ProductInfo product)
        {
            return await _productsCatalogDataService.UpdateProduct(product);
        }

        public async Task<int> RemoveProduct(int? id)
        {
            return await _productsCatalogDataService.RemoveProduct(id);
        }
    }
}