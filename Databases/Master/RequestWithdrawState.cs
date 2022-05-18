using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class RequestWithdrawState
    {
        public RequestWithdrawState()
        {
            RequestWithdraw = new HashSet<RequestWithdraw>();
        }

        public byte Id { get; set; }
        public string Name { get; set; } = null!;
        public byte? Translate { get; set; }

        public virtual Translate? TranslateNavigation { get; set; }
        public virtual ICollection<RequestWithdraw> RequestWithdraw { get; set; }
    }
}
