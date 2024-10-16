using System;
using System.Collections.Generic;

namespace EcommerceAPI.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public decimal? Price { get; set; }
    }
}
