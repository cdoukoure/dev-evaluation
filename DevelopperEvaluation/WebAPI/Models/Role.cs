using System;
using System.Collections.Generic;

namespace WebAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            Permission = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateOn { get; set; }

        public User CreatedByNavigation { get; set; }
        public User UpdateByNavigation { get; set; }
        public ICollection<Permission> Permission { get; set; }
    }
}
