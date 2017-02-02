using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsCatalogService.Models;
using ProductsCatalogService.ApplicationService;
using ProductsCatalogService.Controllers;
using Moq;
using System.Web.Http.Results;

namespace ProductsCatalogServiceTester
{
    [TestClass]
    public class ProductsCatalogServiceTester
    {
        private List<ProductInfo> GetAllProducts()
        {
            var testProducts = new List<ProductInfo>();
            testProducts.Add(new ProductInfo
            {

                ProductCategory = "Note",
                ProductDescription = "Samsung Note 5 with Exynos",
                ProductID = 2,
                ProductName = "Samsung Note 5",
                ProductPrice = 55000

            });

            testProducts.Add(new ProductInfo
            {

                ProductCategory = "IPhone 6",
                ProductDescription = "IPhone 6",
                ProductID = 3,
                ProductName = "IPhone 6",
                ProductPrice = 70000
            });

            return testProducts;
        }

        
        [TestMethod]
        public async Task GetAllProducts_ReturnAllProducts()
        {
            List<ProductInfo> testProducts = GetAllProducts();            
            var applicationLayerMock = new Mock<IApplicationAccess>();
            applicationLayerMock.Setup(x => x.GetAllProducts()).Returns(Task.FromResult<IEnumerable<ProductInfo>>(testProducts));

            var controller = new ProductCatalogApiController(applicationLayerMock.Object);
            var result = await controller.GetAllProducts() as OkNegotiatedContentResult<List<ProductInfo>>;
            List<ProductInfo> content = result.Content.ToList();
            Assert.AreEqual(testProducts.Count, content.Count);
        }
    }   
}
