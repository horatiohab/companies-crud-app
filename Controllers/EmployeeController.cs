using CompaniesApp.Data;
using CompaniesApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
            return View(await _context.Employees.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Employee employee = new Employee();

            if (id == null)
            {
                // this is for create
                return View(employee);
            }

            //this is for edit
            employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,Email,Logo,Website")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                // Create new entry
                if (id != employee.EmployeeId)
                {
                    _context.Add(employee);
                }
                // Update exsiting entry
                else
                {
                    _context.Update(employee);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.Employees.FindAsync(id);
            if (entry == null)
            {
                return Json(new { success = false, message = "Error while deleting entry" });
            }

            _context.Employees.Remove(entry);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Succesfully deleted entry" });
        }
    }
}
