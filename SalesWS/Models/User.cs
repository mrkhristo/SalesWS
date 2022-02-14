using System;
using System.Collections.Generic;

namespace SalesWS.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
