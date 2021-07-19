using CompaniesApp.Data;
using CompaniesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompaniesApp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Company company = new Company();

            if (id == null)
            {
                // this is for create
                return View(company);
            }

            //this is for edit
            company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,Name,Email,Logo,Website")] Company company)
        {
            if (ModelState.IsValid)
            {
                if (id != company.CompanyId)
                {
                    _context.Add(company);
                }
                else
                {
                    _context.Update(company);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

       /* #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = (from c in _context.Companies
                          select c);
            return Json(new { data = allObj });
        }

        #endregion*/
    }
}
