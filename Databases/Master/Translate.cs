using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class Translate
    {
        public Translate()
        {
            RequestWithdrawState = new HashSet<RequestWithdrawState>();
            TransactionAction = new HashSet<TransactionAction>();
        }

        public byte Id { get; set; }
        public string? Vi { get; set; }
        public string? En { get; set; }

        public virtual ICollection<RequestWithdrawState> RequestWithdrawState { get; set; }
        public virtual ICollection<TransactionAction> TransactionAction { get; set; }
    }
}
