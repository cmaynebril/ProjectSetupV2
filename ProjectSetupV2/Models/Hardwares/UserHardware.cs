using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Hardwares
{
    public class UserHardware
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        //public int DiskId { get; set; }
        //public int DisplayId { get; set; }
        //public int UsbDeviceId { get; set; }

        //public Disk Disk { get; set; }
        //public Display Display { get; set; }
        //public UsbDevice UsbDevice { get; set; }

        public IEnumerable<Disk> Disk { get; set; }
        public IEnumerable<Display> Display { get; set; }

        public IEnumerable<UsbDevice> UsbDevice { get; set; }

    }
}
