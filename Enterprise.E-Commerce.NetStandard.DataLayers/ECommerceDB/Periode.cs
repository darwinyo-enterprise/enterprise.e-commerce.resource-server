using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Periode
    {
        public Periode()
        {
            Sale = new HashSet<Sale>();
        }

        public Guid Id { get; set; }
        public string Alias { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }

        public ICollection<Sale> Sale { get; set; }
    }
}
