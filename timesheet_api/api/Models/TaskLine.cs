using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class TaskLine
    {
        public int TimeDone { get; set; }
        public int TaskId { get; set; }
        public string TimeSheetId { get; set; } = null!;

        public virtual Task Task { get; set; } = null!;
        public virtual Timesheet TimeSheet { get; set; } = null!;
    }
}
