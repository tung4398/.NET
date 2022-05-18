using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class TransactionAction
    {
        public byte Id { get; set; }
        public string Default { get; set; } = null!;
        public byte? Translate { get; set; }

        public virtual Translate? TranslateNavigation { get; set; }
    }
}
