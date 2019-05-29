using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            customers = new List<xxCustomers>();
            jobs = new List<xxJobs>();
            tasks = new List<xxTasks>();
            businessValues = new List<xxBusinessValues>();

        }

        public long Id { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerId { get; set; }
        public string Job { get; set; }
        public string TaskName { get; set; }
        public string BusinessValue { get; set; }

        public IList<xxCustomers> customers { get; set; }
        public IList<xxJobs> jobs { get; set; }
        public IList<xxTasks> tasks { get; set; }
        public IList<xxBusinessValues> businessValues { get; set; }
    }

    public class xxCustomers
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
    }

    public class xxJobs
    {
        public long Id { get; set; }
        public string Job { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerId { get; set; }
        public double? JobRate { get; set; }

    }

    public class xxTasks
    {
        public long Id { get; set; }
        public string TaskName { get; set; }
        public long? ProjectId { get; set; }
        public long? BusinessValuesId { get; set; }
    }

    public class xxBusinessValues
    {
        public long Id { get; set; }
        public string BusinessValue { get; set; }
        public double Business { get; set; }
    }
}
