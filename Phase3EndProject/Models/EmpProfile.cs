using System;
using System.Collections.Generic;

namespace Phase3EndProject.Models
{
    public partial class EmpProfile
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public int? Edept { get; set; }

        public virtual DeptMaster? EdeptNavigation { get; set; }
    }
}
