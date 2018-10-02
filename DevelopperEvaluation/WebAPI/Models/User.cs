using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class User
    {
        public User()
        {
            InverseCreatedByNavigation = new HashSet<User>();
            InverseUpdateByNavigation = new HashSet<User>();
            PermissionCreatedByNavigation = new HashSet<Permission>();
            PermissionUpdateByNavigation = new HashSet<Permission>();
            ProjectCreatedByNavigation = new HashSet<Project>();
            ProjectTaskActionCollaboratorCreatedByNavigation = new HashSet<ProjectTaskActionCollaborator>();
            ProjectTaskActionCollaboratorUpdatedByNavigation = new HashSet<ProjectTaskActionCollaborator>();
            ProjectTaskActionManagerCreatedByNavigation = new HashSet<ProjectTaskActionManager>();
            ProjectTaskActionManagerUpdatedByNavigation = new HashSet<ProjectTaskActionManager>();
            ProjectTaskCreatedByNavigation = new HashSet<ProjectTask>();
            ProjectTaskUpdateByNavigation = new HashSet<ProjectTask>();
            ProjectUpdatedByNavigation = new HashSet<Project>();
            RoleCreatedByNavigation = new HashSet<Role>();
            RoleUpdateByNavigation = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int LeftSight { get; set; }
        public int RightSight { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }

        public User CreatedByNavigation { get; set; }
        public User UpdateByNavigation { get; set; }
        public ICollection<User> InverseCreatedByNavigation { get; set; }
        public ICollection<User> InverseUpdateByNavigation { get; set; }
        public ICollection<Permission> PermissionCreatedByNavigation { get; set; }
        public ICollection<Permission> PermissionUpdateByNavigation { get; set; }
        public ICollection<Project> ProjectCreatedByNavigation { get; set; }
        public ICollection<ProjectTaskActionCollaborator> ProjectTaskActionCollaboratorCreatedByNavigation { get; set; }
        public ICollection<ProjectTaskActionCollaborator> ProjectTaskActionCollaboratorUpdatedByNavigation { get; set; }
        public ICollection<ProjectTaskActionManager> ProjectTaskActionManagerCreatedByNavigation { get; set; }
        public ICollection<ProjectTaskActionManager> ProjectTaskActionManagerUpdatedByNavigation { get; set; }
        public ICollection<ProjectTask> ProjectTaskCreatedByNavigation { get; set; }
        public ICollection<ProjectTask> ProjectTaskUpdateByNavigation { get; set; }
        public ICollection<Project> ProjectUpdatedByNavigation { get; set; }
        public ICollection<Role> RoleCreatedByNavigation { get; set; }
        public ICollection<Role> RoleUpdateByNavigation { get; set; }
    }
}
