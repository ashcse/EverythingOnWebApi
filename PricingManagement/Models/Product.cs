using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PricingManagement.Models
{
    /// <summary>
    /// This class represent product at application level
    /// </summary>
    public class ProductInfo
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 7)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string ProductDescription { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string ProductCategory { get; set; }

        [Required]
        public double ProductPrice { get; set; }
    }
}