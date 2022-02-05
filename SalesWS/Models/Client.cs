using System;
using System.Collections.Generic;

namespace SalesWS.Models
{
    public partial class Client
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
