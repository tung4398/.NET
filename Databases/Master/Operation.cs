using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class Operation
    {
        public Operation()
        {
            Session = new HashSet<Session>();
        }

        public byte Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Session> Session { get; set; }
    }
}
