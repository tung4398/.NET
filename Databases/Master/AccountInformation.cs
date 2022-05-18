using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class AccountInformation
    {
        public ulong Id { get; set; }
        public string AccountUuid { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Trc20WalletAddress { get; set; }

        public virtual Account AccountUu { get; set; } = null!;
    }
}
