using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class Position
    {
        public Position()
        {
            Account = new HashSet<Account>();
        }

        public byte Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Account> Account { get; set; }
    }
}
