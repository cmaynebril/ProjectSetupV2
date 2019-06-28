using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Softwares
{
    public class UserSoftwareViewModel
    {
        public int id { get; set; }
        public string timeStamp { get; set; }
        public List<RunningSoftware> runningSoftwares { get; set; }

        public class RunningSoftware
        {
            public int softwareId { get; set; }
            public string name { get; set; }
            public DateTime dateInstalled { get; set; }
            public string version { get; set; }
        }
    }
}
