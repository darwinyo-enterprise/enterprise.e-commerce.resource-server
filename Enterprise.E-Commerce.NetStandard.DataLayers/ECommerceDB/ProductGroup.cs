using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductGroup
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid? ProductId { get; set; }
        public Guid? ProductVariationId { get; set; }
        public DateTime AddedDateTime { get; set; }
        public Guid AddedBy { get; set; }

        public Group Group { get; set; }
        public Product Product { get; set; }
        public ProductVariation ProductVariation { get; set; }
    }
}
