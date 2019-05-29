using System;
using System.Collections.Generic;

namespace ProjectSetupV2.Models.Context
{
    public partial class Jobs
    {
        public Jobs()
        {
            Tasks = new HashSet<Tasks>();
        }

        public long Id { get; set; }
        public string Job { get; set; }
        public string ClientName { get; set; }
        public long? ClientId { get; set; }
        public double? JobRate { get; set; }

        public virtual Clients Client { get; set; }
        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
