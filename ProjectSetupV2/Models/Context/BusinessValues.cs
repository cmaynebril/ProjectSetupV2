using System;
using System.Collections.Generic;

namespace ProjectSetupV2.Models.Context
{
    public partial class BusinessValues
    {
        public BusinessValues()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int Id { get; set; }
        public string Business { get; set; }
        public double Rate { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
