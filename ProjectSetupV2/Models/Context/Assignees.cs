using System;
using System.Collections.Generic;

namespace ProjectSetupV2.Models.Context
{
    public partial class Assignees
    {
        public int Id { get; set; }
        public string Assignee { get; set; }
        public long? AssigneeRate { get; set; }
      

    }
}
