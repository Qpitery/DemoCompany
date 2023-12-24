using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DemoCompany
{
    public partial class Departments
    {
        public Departments()
        {
            Employes = new HashSet<Employes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Supervisor { get; set; }

        public virtual ICollection<Employes> Employes { get; set; }
    }
}
