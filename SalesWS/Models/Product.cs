using System;
using System.Collections.Generic;

namespace SalesWS.Models
{
    public partial class Product
    {
        public Product()
        {
            Concepts = new HashSet<Concept>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public decimal Cost { get; set; }

        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
