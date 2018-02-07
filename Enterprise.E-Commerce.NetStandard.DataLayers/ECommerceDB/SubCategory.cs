using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Product = new HashSet<Product>();
            Sale = new HashSet<Sale>();
        }

        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Enabled { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public DateTime LastUpdated { get; set; }
        public Guid UpdatedBy { get; set; }

        public Category Category { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<Sale> Sale { get; set; }
    }
}
