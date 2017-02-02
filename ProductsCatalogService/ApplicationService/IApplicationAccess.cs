using ProductsCatalogService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCatalogService.ApplicationService
{
    /// <summary>
    /// Following interface provides methods to interact with application layer   
    /// </summary>
    public interface IApplicationAccess
    {
        /// <summary>
        /// Retruns list of prducts for specified category
        /// </summary>
        /// <param name="productCatagory">Product Category (search criteria)</param>
        /// <returns>List of products</returns>
        Task<IEnumerable<ProductInfo>> GetProducts(string productCatagory);

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
        /// Adds a new product
        /// </summary>
        /// <param name="product">Product to be added</param>
        /// <returns>Returns 1 if added successfully otherwise 0</returns>  
        Task<int> AddProduct(ProductInfo product);

        /// <summary>
        /// Updates a new product
        /// </summary>
        /// <param name="product">Product to be updated</param>
        /// <returns>1 if updated successfully otherwise 0</returns>  
        Task<int> UpdateProduct(ProductInfo product);        

        /// <summary>
        /// Removes specified product
        /// </summary>
        /// <param name="Id">Product id</param>
        /// <returns>1 if removed successfully otherwise 0</returns>
        Task<int> RemoveProduct(int? id);
    }
}
