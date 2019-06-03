using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class TimesheetViewModel
    {
        public TimesheetViewModel()
        {
            client = new List<tClients>();
            job = new List<tJobs>();
            task = new List<tTasks>();
            businessValue = new List<tBusinessValues>();
            assignee = new List<tAssignees>();

        }

        public long Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public long TaskId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public double TimeSpent { get; set; }
        public long JobId { get; set; }
        public long ClientId { get; set; }
        public long BusinessValueId { get; set; }
        public long AssigneeId { get; set; }

        public IList<tClients> client { get; set; }
        public IList<tJobs> job { get; set; }
        public IList<tTasks> task { get; set; }
        public IList<tBusinessValues> businessValue { get; set; }
        public IList<tAssignees> assignee { get; set; }
    }
    public class tClients
    {
        public long Id { get; set; }
        public string Client { get; set; }
    }

    public class tJobs
    {
        public long Id { get; set; }
        public string Job { get; set; }
        public string ClientName { get; set; }
        public long? ClientId { get; set; }
        public double? JobRate { get; set; }
    }
    public class tTasks
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public long? JobId { get; set; }
        public long? BusinessValuesId { get; set; }
        public double? TasksRate { get; set; }
    }
    public class tBusinessValues
    {
        public long Id { get; set; }
        public string Business { get; set; }
        public double Rate { get; set; }
    }
    public class tAssignees
    {
        public int Id { get; set; }
        public string Assignee { get; set; }
        public long? AssigneeRate { get; set; }

    }

}
