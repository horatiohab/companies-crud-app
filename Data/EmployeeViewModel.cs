using CompaniesApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesApp.Data
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}
