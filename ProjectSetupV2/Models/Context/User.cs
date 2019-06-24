using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class User : IdentityUser <int>
    {
        public int TeamLeaderId { get; set; }
        public int SupervisorId { get; set; }
        public int ManagerId { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public int Rate { get; set; }
    }
}
