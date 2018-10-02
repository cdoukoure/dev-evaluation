using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Permission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }

        public User CreatedByNavigation { get; set; }
        public Role Role { get; set; }
        public User UpdateByNavigation { get; set; }
    }
}
