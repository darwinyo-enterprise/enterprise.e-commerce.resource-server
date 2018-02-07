using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductAbuse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid ProductVariationId { get; set; }
        public Guid ReportedBy { get; set; }
        public DateTime ReportedDateTime { get; set; }
        public string ReportReason { get; set; }
        public bool Approved { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDateTime { get; set; }
        public string ApprovedMessage { get; set; }
        public string PenaltyGiven { get; set; }
        public DateTime? PenaltyGivenDateTime { get; set; }
        public bool? PenaltyCompleted { get; set; }
        public DateTime? PenaltyCompletedDateTime { get; set; }
        public bool Solved { get; set; }

        public Product Product { get; set; }
        public ProductVariation ProductVariation { get; set; }
    }
}
