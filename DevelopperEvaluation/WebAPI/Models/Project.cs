using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Project
    {
        public Project()
        {
            ProjectTask = new HashSet<ProjectTask>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<ProjectTask> ProjectTask { get; set; }
    }
}
