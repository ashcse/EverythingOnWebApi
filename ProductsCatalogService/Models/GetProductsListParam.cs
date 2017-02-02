using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductsCatalogService.Models
{
    public class GetProductsListParam
    {
        [Required(ErrorMessage = "Product Type is required")]
        public int ProductType { get; set; }
    }
}