using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class GsUserGameLink
    {
        public ulong Id { get; set; }
        public string GsuserUuid { get; set; } = null!;
        public byte Provider { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime TimeCreated { get; set; }

        public virtual GsUserLink GsuserUu { get; set; } = null!;
        public virtual GameProvider ProviderNavigation { get; set; } = null!;
    }
}
