using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models
{
    public class InvoicingViewModel
    {
        public InvoicingViewModel()
        {
            client = new List<invoiceClients>();
            job = new List<invoiceJobs>();
            task = new List<invoiceTasks>();
            businessValue = new List<invoiceBusinessValues>();
            //assignee = new List<invoiceAssignees>();

        }

        public long Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
        public int TaskId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int TotalTime { get; set; }
        public int JobId { get; set; }
        public int ClientId { get; set; }
        public int BusinessValueId { get; set; }
        public int AssigneeId { get; set; }

        public IList<invoiceClients> client { get; set; }
        public IList<invoiceJobs> job { get; set; }
        public IList<invoiceTasks> task { get; set; }
        public IList<invoiceBusinessValues> businessValue { get; set; }
        //public IList<invoiceAssignees> assignee { get; set; }
    }
    public class invoiceClients
    {
        public long Id { get; set; }
        public string Client { get; set; }
    }

    public class invoiceJobs
    {
        public int Id { get; set; }
        public string Job { get; set; }
        public string ClientName { get; set; }
        public int? ClientId { get; set; }
        public double? JobRate { get; set; }
        public string Status { get; set; }

    }
    public class invoiceTasks
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public int? JobId { get; set; }
        public int? BusinessValuesId { get; set; }
        public double? TasksRate { get; set; }
        public string Status { get; set; }
        public int InvoiceTypeId { get; set; }

    }
    public class invoiceBusinessValues
    {
        public int Id { get; set; }
        public string Business { get; set; }
        public double Rate { get; set; }
    }
    //public class invoiceAssignees
    //{
    //    public int Id { get; set; }
    //    public string Assignee { get; set; }
    //    public long? AssigneeRate { get; set; }

    //}
}
