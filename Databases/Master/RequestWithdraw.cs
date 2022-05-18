using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class RequestWithdraw
    {
        public ulong Id { get; set; }
        public string Uuid { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string AccountUuid { get; set; } = null!;
        public decimal Amount { get; set; }
        public decimal Fee { get; set; }
        public byte Method { get; set; }
        public string Data { get; set; } = null!;
        public byte State { get; set; }
        public ulong RefundState { get; set; }
        public string? Note { get; set; }
        public DateTime? TimeDecide { get; set; }
        public DateTime TimeCreated { get; set; }

        public virtual Account AccountUu { get; set; } = null!;
        public virtual PaymentMethod MethodNavigation { get; set; } = null!;
        public virtual RequestWithdrawState StateNavigation { get; set; } = null!;
    }
}
