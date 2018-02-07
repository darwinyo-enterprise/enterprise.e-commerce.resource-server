using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class UserWishlist
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductVariationId { get; set; }
        public DateTime AddedDateTime { get; set; }
        public bool Valid { get; set; }

        public ProductVariation ProductVariation { get; set; }
    }
}
