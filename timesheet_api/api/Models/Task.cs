using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Task
    {
        public Task()
        {
            TaskLines = new HashSet<TaskLine>();
        }

        public int TaskId { get; set; }
        public string TaskName { get; set; } = null!;
        public string? TaskDescription { get; set; }

        public virtual ICollection<TaskLine> TaskLines { get; set; }
    }
}
