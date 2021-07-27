using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        /*[NotMapped]
        [Display(Name = "Logo")]
        public IFormFile ImageFile { get; set; }*/
        public string Logo { get; set; }
        public string Website { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
