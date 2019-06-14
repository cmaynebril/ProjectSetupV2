using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class InvoiceViewModel
    {
        public InvoiceViewModel()
        {
            customers = new List<iCustomers>();
            jobs = new List<iJobs>();
            tasks = new List<iTasks>();
            businessValues = new List<iBusinessValues>();
        }

        public long Id { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerId { get; set; }
        public string Job { get; set; }
        public string TaskName { get; set; }
        public string BusinessValue { get; set; }

        public IList<iCustomers> customers { get; set; }
        public IList<iJobs> jobs { get; set; }
        public IList<iTasks> tasks { get; set; }
        public IList<iBusinessValues> businessValues { get; set; }
    }

    public class iCustomers
    {
        public long Id { get; set; }
        public string CustomerName { get; set; }
    }

    public class iJobs
    {
        public long Id { get; set; }
        public string Job { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerId { get; set; }
        public double? JobRate { get; set; }

    }

    public class iTasks
    {
        public long Id { get; set; }
        public string Task { get; set; }
        public long? JobId { get; set; }
        public long? BusinessValuesId { get; set; }
        public double? TasksRate { get; set; }
        public string Status { get; set; }
    }

        public class iBusinessValues
    {
        public long Id { get; set; }
        public string Business { get; set; }
        public double Rate { get; set; }
    }

}
