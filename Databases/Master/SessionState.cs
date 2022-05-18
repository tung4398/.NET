using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class SessionState
    {
        public SessionState()
        {
            Session = new HashSet<Session>();
        }

        public byte Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Session> Session { get; set; }
    }
}
