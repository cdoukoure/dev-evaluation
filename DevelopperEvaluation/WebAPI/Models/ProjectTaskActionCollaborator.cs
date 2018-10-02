using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class ProjectTaskActionCollaborator
    {
        public int Id { get; set; }
        public int ProjectTaskId { get; set; }
        public string Description { get; set; }
        public DateTime DatetimeStart { get; set; }
        public DateTime? DatetimeEnd { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public User CreatedByNavigation { get; set; }
        public ProjectTask ProjectTask { get; set; }
        public User UpdatedByNavigation { get; set; }
    }
}
