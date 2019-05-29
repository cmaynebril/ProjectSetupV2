using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class SetupViewModel
    {
        public SetupViewModel()
        {
            customers = new List<xCustomers>();
            jobs = new List<xJobs>();
            tasks = new List<xTasks>();
            businessValues = new List<xBusinessValues>();

        }

        public long Id { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerId { get; set; }
        public string Job { get; set; }
        [NotMapped]
        public string[] TaskName { get; set; }
        public string BusinessValue { get; set; }

        public IList<xCustomers> customers { get; set; }
        public IList<xJobs> jobs { get; set; }
        public IList<xTasks> tasks { get; set; }
        public IList<xBusinessValues> businessValues { get; set; }
    }

    public class xCustomers
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
    }

    public class xJobs
    {
        public long Id { get; set; }
        public string Job { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerId { get; set; }
        public double? JobRate { get; set; }

    }

    public class xTasks
    {
        public long Id { get; set; }
        public string TaskName { get; set; }
        public long? ProjectId { get; set; }
        public long? BusinessValuesId { get; set; }
    }

    public class xBusinessValues
    {
        public long Id { get; set; }
        public string Business { get; set; }
        public double Rate { get; set; }
    }
}
