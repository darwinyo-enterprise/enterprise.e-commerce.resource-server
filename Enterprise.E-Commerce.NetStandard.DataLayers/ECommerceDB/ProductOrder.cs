using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductOrder
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductVariationId { get; set; }
        public Guid TransactionId { get; set; }
        public int Amount { get; set; }
        public decimal OrderTimePrice { get; set; }
        public DateTime OrderTime { get; set; }
        public decimal? TotalPrice { get; set; }
        public string Message { get; set; }
        public bool VendorVerified { get; set; }
        public DateTime VendorVerifiedDateTime { get; set; }
        public bool Valid { get; set; }
        public bool Completed { get; set; }
        public Guid UserAddressId { get; set; }
        public Guid CourierId { get; set; }

        public Courier Courier { get; set; }
        public ProductVariation ProductVariation { get; set; }
        public Transaction Transaction { get; set; }
    }
}
