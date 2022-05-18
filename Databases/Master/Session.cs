using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class Session
    {
        public ulong Id { get; set; }
        public string AccountUuid { get; set; } = null!;
        public string Token { get; set; } = null!;
        public byte State { get; set; }
        public byte Platform { get; set; }
        public byte Version { get; set; }
        public byte Operation { get; set; }
        public string? Device { get; set; }
        public DateTime? TimeLastAction { get; set; }
        public DateTime? TimeExpired { get; set; }
        public DateTime? TimeCreated { get; set; }

        public virtual Account AccountUu { get; set; } = null!;
        public virtual Operation OperationNavigation { get; set; } = null!;
        public virtual Platform PlatformNavigation { get; set; } = null!;
        public virtual SessionState StateNavigation { get; set; } = null!;
        public virtual ClientVersion VersionNavigation { get; set; } = null!;
    }
}
