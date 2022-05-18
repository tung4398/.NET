using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class AccountWallet
    {
        public ulong Id { get; set; }
        public string AccountUuid { get; set; } = null!;
        public byte WalletId { get; set; }
        public decimal Amount { get; set; }

        public virtual Account AccountUu { get; set; } = null!;
        public virtual Wallet Wallet { get; set; } = null!;
    }
}
