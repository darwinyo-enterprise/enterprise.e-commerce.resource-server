using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductVariationSpec
    {
        public Guid Id { get; set; }
        public Guid ProductVariationId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// If true then wont takes effect when base product changed.
        /// Otherwise will take changes as user change base product
        /// </summary>
        public bool Overriden { get; set; }
        
        public DateTime? LastUpdated { get; set; }
        public Guid? UpdatedBy { get; set; }

        public DateTime AddedDateTime { get; set; }
        public Guid AddedBy { get; set; }

        public ProductVariation ProductVariation { get; set; }
    }
}
