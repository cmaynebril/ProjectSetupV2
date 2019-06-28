using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Hardwares
{
    public class UserHardwareViewModel
    {
        public int id { get; set; }
        public DateTime timeStamp { get; set; }
        public List<Disk> disks { get; set; }
        public List<Display> displays { get; set; }
        public List<UsbDevice> usbDevices { get; set; }

        public class Disk
        {
            public int diskId { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string serialNumber { get; set; }
            public string title { get; set; }
            public string spec { get; set; }
        }

        public class Display
        {
            public int displayId { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string serialNumber { get; set; }
            public string manufacturer { get; set; }
        }

        public class UsbDevice
        {
            public int usbDeviceId { get; set; }
            public string name { get; set; }
            public string description { get; set; }
        }


    }
   

}
