using System;
using System.Collections.Generic;

namespace ProjectSetupV2.Models.Context
{
    public partial class Staffs
    {
        public int Id { get; set; }
        public string StaffName { get; set; }
        public long? StaffRate { get; set; }
        public long? TaskId { get; set; }

        public virtual Tasks Task { get; set; }
    }
}
