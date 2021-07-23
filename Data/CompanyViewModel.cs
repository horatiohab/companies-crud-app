using CompaniesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesApp.Data
{
    public class CompanyViewModel
    {
        public Company Company { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
