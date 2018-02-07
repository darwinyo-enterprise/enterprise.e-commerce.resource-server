using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Inventory
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid VariationId { get; set; }
        public int StockAmount { get; set; }
        public int Location { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Product Product { get; set; }
        public ProductVariation Variation { get; set; }
    }
}
