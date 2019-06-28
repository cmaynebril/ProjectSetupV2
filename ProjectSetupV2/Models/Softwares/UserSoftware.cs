using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Softwares
{
    public class UserSoftware
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public IEnumerable<RunningSoftwares> RunningSoftwares { get; set; }

    }
}
