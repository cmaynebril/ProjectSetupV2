using System;
using System.Collections.Generic;

namespace ProjectSetupV2.Models.Context
{
    public partial class Timesheet
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public long TaskId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public double TimeSpent { get; set; }
        public long JobId { get; set; }
        public long ClientId { get; set; }
        public long BusinessValueId { get; set; }
        public long AssigneeId { get; set; }


    }
}
