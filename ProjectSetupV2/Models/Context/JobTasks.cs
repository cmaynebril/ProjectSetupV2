using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSetupV2.Models.Context
{
    public class JobTasks
    {
        public int Id { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? DateCreated { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public double TimeSpent { get; set; }
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        [ForeignKey("BusinessValue")]
        public int BusinessValueId { get; set; }
        [ForeignKey("User")]
        public int AssigneeId { get; set; }

        public Tasks Task { get; set; } //this should be foreign key to table task
        public Jobs Job { get; set; } //this should be foreign key to table job
        public Clients Client { get; set; } //this should be foreign key to table client
        public BusinessValues BusinessValue { get; set; } //this should be foreign key to table businessvalue
        public User User { get; set; } //this should be foreign key to table assignee
    }
}
