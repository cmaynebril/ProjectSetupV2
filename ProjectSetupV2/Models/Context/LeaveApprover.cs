using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class LeaveApprover
    {
        [Key]
        public int ApproverId { get; set; }
        public string Approver { get; set; }
        public int LeaveId { get; set; }
        public string Status { get; set; }

        public Leave Leave { get; set; }
    }
}
