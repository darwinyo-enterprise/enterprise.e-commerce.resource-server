using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Category
    {
        public Category()
        {
            Sale = new HashSet<Sale>();
            SubCategory = new HashSet<SubCategory>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Images { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastUpdated { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }

        public ICollection<Sale> Sale { get; set; }
        public ICollection<SubCategory> SubCategory { get; set; }
    }
}
