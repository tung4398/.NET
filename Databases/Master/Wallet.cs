using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class Wallet
    {
        public Wallet()
        {
            AccountWallet = new HashSet<AccountWallet>();
        }

        public byte Id { get; set; }
        public string Name { get; set; } = null!;
        public string Unit { get; set; } = null!;

        public virtual ICollection<AccountWallet> AccountWallet { get; set; }
    }
}
