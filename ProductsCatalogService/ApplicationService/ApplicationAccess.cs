using ProductsCatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using DAL.DataService;
using DAL;

namespace ProductsCatalogService.ApplicationService
{
    /// <summary>
    /// Application access layer which implements IApplicationAccess interface
    /// </summary>
    public class ApplicationAccess : IApplicationAccess
    {
        private IProductService _productDataService = null;
        
        public ApplicationAccess(IProductService productsCatalogDataService)
        {
            _productDataService = productsCatalogDataService;
        }

        /// <summary>
        /// Retruns list of all prducts
        /// </summary>        
        /// <returns>List of all products</returns>
        public async Task<IEnumerable<ProductInfo>> GetAllProducts()
        {
            //var list = await _productDataService.GetAllProducts();
            
            return from m in await _productDataService.GetAllProducts()
                       select new ProductInfo()
                       {
                           ProductID = m.ProductID,                            
                           Name = m.ProductName,
                           Price = m.UnitPrice
                       };
        }

        /// <summary>
        /// Retruns product for specified id
        /// </summary>        
        /// <returns>product info for passed id</returns>
        public async Task<ProductInfo> GetProductById(int? productId)
        {
            //return await Task.FromResult<ProductInfo>(null); ;// 
            var p =await _productDataService.GetProductById(productId);
            return new ProductInfo
            {
                Name = p.ProductName,
                Category = p.Category.CategoryName,
                Price = p.UnitPrice,
                ProductID = p.ProductID
            };
        }

        public async Task<IEnumerable<ProductInfo>> GetProducts(int productCatagory)
        {
            return from p in await _productDataService.GetProducts(productCatagory)
                   select new ProductInfo()
                   {
                       Category = p.Category.CategoryName,
                       Name = p.ProductName,
                       ProductID = p.ProductID,
                       Price = p.UnitPrice
                   };
        }

        public async Task<int> AddProduct(ProductInfo product)
        {
            //TBD: Implement it later
            return await Task.FromResult<int>(0);// 

            /* DAL.Product newProduct = new Product {
                 ProductName = product.Name,
                  CategoryID = product.ca
              }

             return await _productDataService.AddProduct(product);

            */
        }

        public async Task<int> UpdateProduct(ProductInfo product)
        {
            return await Task.FromResult<int>(0);// _productDataService.UpdateProduct(product);
        }

        public async Task<int> RemoveProduct(int? id)
        {
            return await Task.FromResult<int>(0);// 0; _productDataService.RemoveProduct(id);
        }
    }
}