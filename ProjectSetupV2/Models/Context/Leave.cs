using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class Leave
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? EndDate { get; set; }
        public string  Reason { get; set; }
        public string Status { get; set; }
        public string TypeOfRequest { get; set; }

        public User User { get; set; }
        public IEnumerable<LeaveApprover> LeaveApprover { get; set; }
    }
}
