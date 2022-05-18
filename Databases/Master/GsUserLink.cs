using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class GsUserLink
    {
        public GsUserLink()
        {
            GsUserGameLink = new HashSet<GsUserGameLink>();
        }

        public ulong Id { get; set; }
        public string Uuid { get; set; } = null!;
        public string AccountUuid { get; set; } = null!;
        public string Username { get; set; } = null!;
        public DateTime TimeCreated { get; set; }

        public virtual ICollection<GsUserGameLink> GsUserGameLink { get; set; }
    }
}
