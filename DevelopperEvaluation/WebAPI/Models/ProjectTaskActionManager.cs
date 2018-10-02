using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class ProjectTaskActionManager
    {
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }
        public string Description { get; set; }
        public TimeSpan? Overtime { get; set; }
        public DateTime? NewDeadline { get; set; }
        public string Type { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public User CreatedByNavigation { get; set; }
        public ProjectTask ProjectTask { get; set; }
        public User UpdatedByNavigation { get; set; }
    }
}
