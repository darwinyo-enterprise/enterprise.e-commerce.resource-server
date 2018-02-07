using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class ProductComment
    {
        public ProductComment()
        {
            CommentAbuse = new HashSet<CommentAbuse>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Comments { get; set; }
        public DateTime CommentDateTime { get; set; }
        public bool Abuse { get; set; }
        public DateTime? ReportedDateTime { get; set; }
        public Guid? ReportedBy { get; set; }

        public Product Product { get; set; }
        public ICollection<CommentAbuse> CommentAbuse { get; set; }
    }
}
