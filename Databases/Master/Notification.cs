using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class Notification
    {
        public ulong Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public ulong IsEnable { get; set; }
        public DateTime? TimeStart { get; set; }
        public DateTime? TimeEnd { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
