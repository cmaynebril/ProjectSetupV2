using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectSetupV2.Models.Context
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public int? JobId { get; set; }
        public int? BusinessValuesId { get; set; }
        public double? TasksRate { get; set; }
        public string Status { get; set; }


        public virtual BusinessValues BusinessValues { get; set; }
        public virtual Jobs Job { get; set; }
    }
}
