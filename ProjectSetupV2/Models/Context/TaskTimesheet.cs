using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class TaskTimesheet
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Job { get; set; }
        public string Task { get; set; }
        public DateTime? Date { get; set; }
        public string TotalTimeSpent { get; set; }
        public int AssigneeId { get; set; }
    }
}
