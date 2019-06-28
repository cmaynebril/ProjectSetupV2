using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Softwares
{
    public class RunningSoftwares
    {
        [Key]
        public int SoftwareId { get; set; }
        public string Name { get; set; }
        public DateTime DateInstalled { get; set; }
        public string Version { get; set; }
        [ForeignKey("UserSoftware")]
        public int MainSoftwareId { get; set; }

        public UserSoftware UserSoftware { get; set; }

    }
}
