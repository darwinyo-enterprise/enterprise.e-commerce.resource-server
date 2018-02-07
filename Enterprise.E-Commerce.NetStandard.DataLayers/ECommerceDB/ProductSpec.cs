using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductSpec
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

        public DateTime? LastUpdated { get; set; }
        public Guid? UpdatedBy { get; set; }

        public DateTime AddedDateTime { get; set; }
        public Guid AddedBy { get; set; }

        public Product Product { get; set; }
    }
}
