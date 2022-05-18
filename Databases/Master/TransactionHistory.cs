using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class TransactionHistory
    {
        public ulong Id { get; set; }
        public string AccountUuid { get; set; } = null!;
        public byte Wallet { get; set; }
        public byte Action { get; set; }
        public decimal Changed { get; set; }
        public decimal Balance { get; set; }
        public string? Note { get; set; }
        public DateTime? TimeCreated { get; set; }
    }
}
