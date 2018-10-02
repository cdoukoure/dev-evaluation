using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class ProjectTask
    {
        public ProjectTask()
        {
            ProjectTaskActionCollaborator = new HashSet<ProjectTaskActionCollaborator>();
            ProjectTaskActionManager = new HashSet<ProjectTaskActionManager>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Sequence { get; set; }
        public string Label { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public TimeSpan TimePlanned { get; set; }
        public TimeSpan TimeElapsed { get; set; }
        public TimeSpan TimeRemaining { get; set; }
        public DateTime? Deadline { get; set; }
        public string Note { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }

        public User CreatedByNavigation { get; set; }
        public Project Project { get; set; }
        public User UpdateByNavigation { get; set; }
        public ICollection<ProjectTaskActionCollaborator> ProjectTaskActionCollaborator { get; set; }
        public ICollection<ProjectTaskActionManager> ProjectTaskActionManager { get; set; }
    }
}
