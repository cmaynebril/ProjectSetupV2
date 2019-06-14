using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class JobTasks
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public double TotalTime { get; set; }

        public Tasks Task { get; set; } //this should be foreign key to table task
        public Jobs Job { get; set; } //this should be foreign key to table job
        public Clients Client { get; set; } //this should be foreign key to table client
        public BusinessValues BusinessValue { get; set; } //this should be foreign key to table businessvalue
        public Assignees Assignee { get; set; } //this should be foreign key to table assignee
    }
}
