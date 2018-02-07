using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductVariationImage
    {
        public Guid Id { get; set; }
        public Guid ProductVariationId { get; set; }
        public string Image { get; set; }
        public DateTime AddedDateTime { get; set; }
        public Guid AddedBy { get; set; }

        public ProductVariation ProductVariation { get; set; }
    }
}
