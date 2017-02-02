using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.DataService
{
    public interface IProductService
    {
        /// <summary>
        /// Retruns list of all prducts
        /// </summary>        
        /// <returns>List of all products</returns>
        Task<IEnumerable<Product>> GetAllProducts();

        /// <summary>
        /// Retruns product for specified id
        /// </summary>        
        /// <returns>product info for passed id</returns>
        Task<Models.ProductInfoDB> GetProductById(int? productId);

        /// <summary>
        /// Retruns list of prducts for specified category
        /// </summary>
        /// <param name="productCatagory">Product Category (search criteria)</param>
        /// <returns>List of products</returns>
        Task<IEnumerable<Product>> GetProducts(int categoryId);

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="product">Product to be added</param>
        /// <returns>Number of records added</returns>  
        Task<int> AddProduct(Product product);

        /// <summary>
        /// Updates existing product
        /// </summary>
        /// <param name="product">Product to be updated</param>
        /// <returns>Number of records updated</returns>  
        Task<int> UpdateProduct(Product product);

        /// <summary>
        /// Removes product for specified product id
        /// </summary>
        /// <param name="productID">Product id of product which is to be removed</param>
        /// <returns></returns>
        Task<int> RemoveProduct(int? productID);
    }
}
