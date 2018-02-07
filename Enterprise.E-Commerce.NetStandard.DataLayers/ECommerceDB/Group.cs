using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Group
    {
        public Group()
        {
            ProductGroup = new HashSet<ProductGroup>();
            Sale = new HashSet<Sale>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid CreatedBy { get; set; }

        public ICollection<ProductGroup> ProductGroup { get; set; }
        public ICollection<Sale> Sale { get; set; }
    }
}
