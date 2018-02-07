using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductFavorite
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductVariationId { get; set; }
        public Guid UserId { get; set; }
        public DateTime FavoritedDateTime { get; set; }

        public Product Product { get; set; }
        public ProductVariation ProductVariation { get; set; }
    }
}
