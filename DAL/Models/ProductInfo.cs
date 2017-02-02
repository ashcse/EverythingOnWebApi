using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    /// <summary>
    /// Model class to pass required informatioin to application layer
    /// </summary>
    public class ProductInfoDB
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Category { get; set; }
    }
}

