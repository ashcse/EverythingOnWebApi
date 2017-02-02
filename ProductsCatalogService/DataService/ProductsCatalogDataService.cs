using ProductsCatalogService.Models;
using ProductsCatalogService.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProductsCatalogService.DataService
{
    /// <summary>
    /// Product catalog data base layer logic
    /// </summary>
    public class ProductsCatalogDataService : IProductsCatalogDataService
    {
        /// <summary>
        /// Returns list of all products
        /// </summary>
        /// <returns>List of product info</returns>
        public async Task<IEnumerable<ProductInfo>> GetAllProducts()
        {
            using (var dbContext = new ProductsCatalogDBEntities())
            {
                try
                {
                    var result = (from p in dbContext.Products
                                  select new ProductInfo
                                  {
                                      ProductPrice = p.UnitPrice.HasValue ? p.UnitPrice.Value : 0.0,
                                      ProductCategory = p.ProductType,
                                      ProductDescription = p.ProductDescription,
                                      ProductID = p.ProductID,
                                      ProductName = p.ProductName
                                  });

                    return await result.ToListAsync();
                }
                catch(Exception exc)
                {

                }
            }

            return null;
        }

        /// <summary>
        /// Retruns product for specified id
        /// </summary>        
        /// <returns>product info for passed id</returns>
        public async Task<ProductInfo> GetProductById(int? productId)
        {
            using (var dbContext = new ProductsCatalogDBEntities())
            {
                Product productEntity = await dbContext.Products.FindAsync(productId);
                return new ProductInfo
                {
                    ProductID = productEntity.ProductID,
                    ProductName = productEntity.ProductName,
                    ProductPrice = productEntity.UnitPrice.HasValue? productEntity.UnitPrice.Value : 0.0,
                    ProductCategory = productEntity.ProductType,
                    ProductDescription = productEntity.ProductDescription
                };
            }
        }

        /// <summary>
        /// Retruns list of prducts for specified category
        /// </summary>
        /// <param name="productCatagory">Product Category (search criteria)</param>
        /// <returns>List of products</returns>
        public async Task<IEnumerable<ProductInfo>> GetProducts(string productCatagory)
        {
            using (var dbContext = new ProductsCatalogDBEntities())
           {
               var result = (from p in dbContext.Products
                            where p.ProductType == productCatagory
                            select new ProductInfo
                            {
                                ProductPrice = p.UnitPrice.HasValue?p.UnitPrice.Value: 0.0,
                                ProductCategory = p.ProductType,
                                ProductDescription = p.ProductDescription,
                                ProductID = p.ProductID,
                                ProductName = p.ProductName
                            });

               return await result.ToListAsync();
           }
        }    
        
        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="product">Product to be added</param>
        /// <returns>Number of records added</returns>  
        public async Task<int> AddProduct(ProductInfo product)
        {
            using (var dbContext = new ProductsCatalogDBEntities())
            {

                var prod = new Product 
                {
                     ProductDescription = product.ProductDescription,
                     ProductName = product.ProductName,
                     ProductType = product.ProductCategory,
                     UnitPrice = product.ProductPrice,
                     UnitsInStock = 0
                };

                dbContext.Products.Add(prod);
                return await dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Updates existing product
        /// </summary>
        /// <param name="product">Product to be updated</param>
        /// <returns>Number of records updated</returns>  
        public async Task<int> UpdateProduct(ProductInfo product)
        {
            using (var dbContext = new ProductsCatalogDBEntities())
            {
                Product productEntity = await dbContext.Products.FindAsync(product.ProductID);
                productEntity.ProductDescription = product.ProductDescription;
                productEntity.ProductName = product.ProductName;
                productEntity.ProductType = product.ProductCategory;
                productEntity.UnitPrice = product.ProductPrice;
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
            using (var dbContext = new ProductsCatalogDBEntities())
            {
                Product prodToRemove = dbContext.Products.Find(productID);
                dbContext.Products.Remove(prodToRemove);
                return await dbContext.SaveChangesAsync();
            }
        }
    }
}