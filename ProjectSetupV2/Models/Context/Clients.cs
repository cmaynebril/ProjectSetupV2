using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class Clients
    {
        public Clients()
        {
            Jobs = new HashSet<Jobs>();
        }

        public long Id { get; set; }
        public string Client { get; set; }
        public string ContactPerson { get; set; }

        public virtual ICollection<Jobs> Jobs { get; set; }
    }
}
