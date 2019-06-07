using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class InvoiceViewModel
    {
        public string Client { get; set; }
        public string ContactPerson { get; set; }
        public string Job { get; set; }
        public double? JobRate { get; set; }
        public string Task { get; set; }
        public double? TasksRate { get; set; }
        public string Business { get; set; }
        public double Rate { get; set; }
        public string Assignee { get; set; }
        public long? AssigneeRate { get; set; }

    }
}
