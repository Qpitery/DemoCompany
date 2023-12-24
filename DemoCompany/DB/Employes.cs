using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DemoCompany
{
    public partial class Employes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public string Position { get; set; }
        public int? DepartmentId { get; set; }
        public double Salary { get; set; }
        public DateTime? HiringDate { get; set; }

        public virtual Departments Department { get; set; }
    }
}
