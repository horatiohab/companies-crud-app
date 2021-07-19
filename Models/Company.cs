using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesApp.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
