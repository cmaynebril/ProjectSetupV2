using System;
using System.Collections.Generic;

namespace ProjectSetupV2.Models.Context
{
    public partial class Tasks
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public long? JobId { get; set; }
        public long? BusinessValuesId { get; set; }
        public double? TasksRate { get; set; }
        public string Status { get; set; }

        public virtual BusinessValues BusinessValues { get; set; }
        public virtual Jobs Job { get; set; }
    }
}
