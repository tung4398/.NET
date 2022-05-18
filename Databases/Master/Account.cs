using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class Account
    {
        public Account()
        {
            AccountInformation = new HashSet<AccountInformation>();
            AccountWallet = new HashSet<AccountWallet>();
            DepositHistory = new HashSet<DepositHistory>();
            RequestWithdraw = new HashSet<RequestWithdraw>();
            Session = new HashSet<Session>();
        }

        public ulong Id { get; set; }
        public string Uuid { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte PositionId { get; set; }
        public ulong Lock { get; set; }
        public ulong Activate { get; set; }
        public DateTime? TimeLastLogin { get; set; }
        public DateTime? TimeCreated { get; set; }

        public virtual Position Position { get; set; } = null!;
        public virtual ICollection<AccountInformation> AccountInformation { get; set; }
        public virtual ICollection<AccountWallet> AccountWallet { get; set; }
        public virtual ICollection<DepositHistory> DepositHistory { get; set; }
        public virtual ICollection<RequestWithdraw> RequestWithdraw { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
