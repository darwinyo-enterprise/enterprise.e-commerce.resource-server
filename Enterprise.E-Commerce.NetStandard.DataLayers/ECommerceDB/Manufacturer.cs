using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Product = new HashSet<Product>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid AddedBy { get; set; }
        public DateTime AddedDateTime { get; set; }

        public DateTime LastUpdated { get; set; }
        public Guid UpdatedBy { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
