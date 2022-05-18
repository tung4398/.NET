using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class GameProvider
    {
        public GameProvider()
        {
            GsUserGameLink = new HashSet<GsUserGameLink>();
        }

        public byte Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<GsUserGameLink> GsUserGameLink { get; set; }
    }
}
