using System;
using System.Collections.Generic;

namespace EcommerceAPI.Models
{
    public partial class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ContactNumber { get; set; } = null!;
    }
}
