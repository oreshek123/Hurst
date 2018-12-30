using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hurst.DAL;

namespace Hurst.Models
{
    public class ModelShop
    {
        public IEnumerable<Product> Products { get; set; }
        public string Search { get; set; }
    }
}