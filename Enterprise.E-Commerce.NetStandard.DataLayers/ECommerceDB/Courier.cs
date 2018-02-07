using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Courier
    {
        public Courier()
        {
            ProductOrder = new HashSet<ProductOrder>();
        }

        public Guid Id { get; set; }
        public string VendorName { get; set; }
        public DateTime OrderTime { get; set; }
        public string CourierName { get; set; }
        public string PickUpAddress { get; set; }
        public string DropOffAddress { get; set; }
        public string ReceivedBy { get; set; }
        public bool Completed { get; set; }
        public DateTime? DeliveredDateTime { get; set; }

        public ICollection<ProductOrder> ProductOrder { get; set; }
    }
}
