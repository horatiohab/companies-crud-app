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
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CompanyController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company company = await _context.Companies.SingleOrDefaultAsync(c => c.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            CompanyViewModel viewModel = new CompanyViewModel();

            viewModel.Company = company;

            List<Employee> employees = await _context.Employees
                .Where(e => e.Company == company).ToListAsync();

            return View(viewModel);
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
                string wwwRootPath = _hostEnvironment.WebRootPath;
                var file = HttpContext.Request.Form.Files;

                if (file.Count == 1)
                {
                    /*// Delete old file if there is one
                    if (company.Logo != null)
                    {
                        var imagePath = Path.Combine(wwwRootPath + company.Logo);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }*/

                    // Create a filename for the image
                    //string prefix = Guid.NewGuid().ToString();
                    string prefix = company.Name + "_" + "logo";
                    string extension = Path.GetExtension(file[0].FileName);
                    var uploads = Path.Combine(wwwRootPath, "images");
                    string fileName = company.Logo = prefix + extension;

                    // Save file to wwwroot/images/
                    using (var fileStream = new FileStream(Path.Combine(uploads, prefix + extension), FileMode.Create))
                    {
                        await file[0].CopyToAsync(fileStream);
                    }

                    company.Logo = Path.Combine("\\images", prefix + extension);
                }
                else if (company.CompanyId != 0)
                {
                    // Update when the image isn't changed
                    var objFromDb = await _context.Companies
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.CompanyId == id);

                    company.Logo = objFromDb.Logo;
                }

                // Create new entry
                if (company.CompanyId == 0)
                {
                    _context.Add(company);
                }
                // Update exsiting entry
                else
                {
                    _context.Update(company);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.Companies.FindAsync(id);
            if (entry == null)
            {
                return Json(new { success = false, message = "Error while deleting entry" });
            }

            // Delete image from folder
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath + entry.Logo);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _context.Companies.Remove(entry);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Succesfully deleted entry" });
        }
    }
}
