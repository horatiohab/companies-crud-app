using CompaniesApp.Data;
using CompaniesApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = _context.Employees
                .Include(e => e.Company)
                .AsNoTracking();

            return View(await employees.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            EmployeeViewModel employeeVM = new EmployeeViewModel()
            {
                Employee = new Employee(),
                CompanyList = _context.Companies.Select(id => new SelectListItem { 
                    Text = id.Name,
                    Value = id.CompanyId.ToString()
                })
            };

            if(id == null)
            {
                // this is for create
                return View(employeeVM);
            }

            // this is for edit
            employeeVM.Employee = await _context.Employees.FindAsync(id);
            if (employeeVM.Employee == null)
            {
                return NotFound();
            }
            //ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Name", employee.CompanyId);
            return View(employeeVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId, FirstName, LastName, Email, PhoneNumber, CompanyId, Company")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Create new entry
                if (id != employee.EmployeeId)
                {
                    _context.Add(employee);
                }
                // Update exsisting entry
                else
                {
                    _context.Update(employee);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }
    }
}
