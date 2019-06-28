using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Hardwares
{
    public class Display
    {
        [Key]
        public int DisplayId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }
        public string Manufacturer { get; set; }
        [ForeignKey("UserHardware")]
        public int UserHardwareId { get; set; }

        public UserHardware UserHardware { get; set; }


    }
}
