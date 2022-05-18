using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class PaymentProvider
    {
        public PaymentProvider()
        {
            DepositHistory = new HashSet<DepositHistory>();
        }

        public byte Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<DepositHistory> DepositHistory { get; set; }
    }
}
