using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Hardwares
{
    public class UsbDevice
    {
        [Key]
        public int UsbDeviceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("UserHardware")]
        public int UserHardwareId { get; set; }

        public UserHardware UserHardware { get; set; }

    }
}
