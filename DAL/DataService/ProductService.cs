using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.DataService
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Returns list of all products
        /// </summary>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            using (var dbContext = new NORTHWNDEntities())
            {
                try
                {
                    var result = dbContext.Products.Take(5);
                                /*  select new Product
                                  {
                                      UnitPrice = p.UnitPrice.HasValue ? p.UnitPrice.Value : 0,
                                      Category = p.Category,
                                      ProductID = p.ProductID,
                                      ProductName = p.ProductName,
                                      CategoryID = p.CategoryID,
                                      Discontinued = p.Discontinued,
                                      QuantityPerUnit = p.QuantityPerUnit,
                                      Supplier = p.Supplier,
                                      SupplierID = p.SupplierID,
                                      UnitsInStock = p.UnitsInStock,
                                      Order_Details = p.Order_Details,
                                      UnitsOnOrder = p.UnitsOnOrder

                                  });*/

                    return await result.ToListAsync();
                }
                catch (Exception exc)
                {
                    //TBD use logfornet to log the exception details here
                }
            }

            return null;
        }

        /// <summary>
        /// Retruns product for specified id
        /// </summary>        
        /// <returns>product info for passed id</returns>
        public async Task<Product> GetProductById(int? productId)
        {
            using (var dbContext = new NORTHWNDEntities())
            {
               return await dbContext.Products.FindAsync(productId);                
            }
        }

        /// <summary>
        /// Retruns list of prducts for specified category
        /// </summary>
        /// <param name="productCatagory">Product Category (search criteria)</param>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<Product>> GetProducts(int categoryId)
        {
            using (var dbContext = new NORTHWNDEntities())
            {
                var products = from p in dbContext.Products
                             where p.CategoryID == categoryId
                             select p;

                return await products.ToListAsync();
            }
        }

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="product">Product to be added</param>
        /// <returns>Number of records added</returns>  
        public async Task<int> AddProduct(Product product)
        {
            using (var dbContext = new NORTHWNDEntities())
            {
                dbContext.Products.Add(product);
                return await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates existing product
        /// </summary>
        /// <param name="product">Product to be updated</param>
        /// <returns>Number of records updated</returns>  
        public async Task<int> UpdateProduct(Product product)
        {
            using (var dbContext = new NORTHWNDEntities())
            {
                Product productEntity = await dbContext.Products.FindAsync(product.ProductID);
                productEntity.ProductName = product.ProductName;              
                productEntity.CategoryID = product.CategoryID;
                productEntity.UnitPrice = product.UnitPrice;
                dbContext.Entry(productEntity).State = EntityState.Modified;
                return await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Removes specified product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Number of affacted rows</returns>
        public async Task<int> RemoveProduct(int? productID)
        {
            using (var dbContext = new NORTHWNDEntities())
            {
                Product prodToRemove = dbContext.Products.Find(productID);
                dbContext.Products.Remove(prodToRemove);
                return await dbContext.SaveChangesAsync();
            }
        }
    }
}
