using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class CommentAbuse
    {
        public Guid Id { get; set; }
        public Guid CommentId { get; set; }
        public Guid ReportedBy { get; set; }
        public DateTime ReportedDateTime { get; set; }
        public string ReportReason { get; set; }
        public bool Approved { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDateTime { get; set; }
        public string ApprovedMessage { get; set; }
        public Guid Actor { get; set; }
        public string PenaltyGiven { get; set; }
        public DateTime? PenaltyGivenDateTime { get; set; }
        public bool? PenaltyCompleted { get; set; }
        public DateTime? PenaltyCompletedDateTime { get; set; }
        public bool Solved { get; set; }
        public DateTime? SolvedDateTime { get; set; }
        public string SolvedMessage { get; set; }
        public Guid? SolvedBy { get; set; }

        public ProductComment Comment { get; set; }
    }
}
