using System;
using System.Collections.Generic;

namespace SalesWS.Models
{
    public partial class Sale
    {
        public Sale()
        {
            Concepts = new HashSet<Concept>();
        }

        public long Id { get; set; }
        public long ClientId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public virtual ICollection<Concept> Concepts { get; set; }
    }
}
