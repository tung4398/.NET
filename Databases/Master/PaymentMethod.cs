using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            DepositHistory = new HashSet<DepositHistory>();
            RequestWithdraw = new HashSet<RequestWithdraw>();
        }

        public byte Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DepositHistory> DepositHistory { get; set; }
        public virtual ICollection<RequestWithdraw> RequestWithdraw { get; set; }
    }
}
