using System;
using System.Collections.Generic;

namespace Demo.Databases.Master
{
    public partial class GsApiHistory
    {
        public long Id { get; set; }
        public string? Api { get; set; }
        public string? RequestData { get; set; }
        public string? ResponseData { get; set; }
        public DateTime? TimeCreated { get; set; }
    }
}
