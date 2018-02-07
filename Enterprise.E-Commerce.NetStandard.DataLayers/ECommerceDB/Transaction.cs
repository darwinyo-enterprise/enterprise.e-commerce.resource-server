using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Transaction
    {
        public Transaction()
        {
            Payments = new HashSet<Payments>();
            ProductOrder = new HashSet<ProductOrder>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public bool Completed { get; set; }
        public Guid? VerifiedByUser { get; set; }
        public Guid? VerifiedByVendor { get; set; }
        public DateTime? VerifiedByVendorDateTime { get; set; }
        public DateTime? VerifiedByUserDateTime { get; set; }
        public DateTime? CompletedDateTime { get; set; }

        public ICollection<Payments> Payments { get; set; }
        public ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
