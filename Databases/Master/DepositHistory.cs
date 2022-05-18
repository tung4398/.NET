using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class DepositHistory
    {
        public ulong Id { get; set; }
        public string AccountUuid { get; set; } = null!;
        public decimal Amount { get; set; }
        public byte Method { get; set; }
        public byte Provider { get; set; }
        public string? Data { get; set; }
        public DateTime TimeCreated { get; set; }

        public virtual Account AccountUu { get; set; } = null!;
        public virtual PaymentMethod MethodNavigation { get; set; } = null!;
        public virtual PaymentProvider ProviderNavigation { get; set; } = null!;
    }
}
