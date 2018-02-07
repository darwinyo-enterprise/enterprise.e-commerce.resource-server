using System;
using System.Collections.Generic;

namespace Enterprise.E_Commerce.NetStandard.DataLayers.ECommerceDB
{
    public partial class Payments
    {
        public Guid Id { get; set; }
        public Guid PaymentMethodId { get; set; }
        public Guid UserId { get; set; }
        public Guid TransactionId { get; set; }
        public bool PaymentVerified { get; set; }
        public bool Installment { get; set; }
        public bool PaidOff { get; set; }
        public int? InstallmentLength { get; set; }
        public int? InstallmentProgress { get; set; }
        public decimal? InterestRate { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime VerifiedDateTime { get; set; }
        public Guid VerifiedBy { get; set; }
        public DateTime PaidOffDateTime { get; set; }
        public bool Cancelled { get; set; }
        public Guid? CancelledBy { get; set; }
        public string CancelledReason { get; set; }
        public DateTime? CancelledTime { get; set; }

        public Transaction Transaction { get; set; }
    }
}
