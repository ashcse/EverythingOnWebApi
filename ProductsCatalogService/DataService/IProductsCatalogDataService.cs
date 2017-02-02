using ProductsCatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalogService.DataService
{
    /// <summary>
    /// Data service which interacts with the database context to read/udpate products.
    /// </summary>
    public interface IProductsCatalogDataService
    {
        /// <summary>
        /// Retruns list of all prducts
        /// </summary>        
        /// <returns>List of all products</returns>
        Task<IEnumerable<ProductInfo>> GetAllProducts();

        /// <summary>
        /// Retruns product for specified id
        /// </summary>        
        /// <returns>product info for passed id</returns>
        Task<ProductInfo> GetProductById(int? productId);

        /// <summary>
        /// Retruns list of prducts for specified category
        /// </summary>
        /// <param name="productCatagory">Product Category (search criteria)</param>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductInfo>> GetProducts(string productCatagory);

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="product">Product to be added</param>
        /// <returns>Number of records added</returns>  
        Task<int> AddProduct(ProductInfo product);

        /// <summary>
        /// Updates existing product
        /// </summary>
        /// <param name="product">Product to be updated</param>
        /// <returns>Number of records updated</returns>  
        Task<int> UpdateProduct(ProductInfo product);

        /// <summary>
        /// Removes product for specified product id
        /// </summary>
        /// <param name="productID">Product id of product which is to be removed</param>
        /// <returns></returns>
        Task<int> RemoveProduct(int? productID);
    }
}
