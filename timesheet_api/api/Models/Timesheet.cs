using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Timesheet
    {
        public Timesheet()
        {
            TaskLines = new HashSet<TaskLine>();
        }

        public string TimesheetId { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool? Checked { get; set; }
        public bool? IsValid { get; set; }
        public int StudentId { get; set; }
        public string Email { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<TaskLine> TaskLines { get; set; }
    }
}
