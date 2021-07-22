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
            //var companyToUpdate = await _context.Companies.FindAsync(id);

            
            /*if (System.IO.File.Exists(imagePath))
            {
                
            }*/

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                var file = HttpContext.Request.Form.Files;

                if (file.Count > 0)
                {
                    var imagePath = Path.Combine(_hostEnvironment.WebRootPath + company.Logo);
                    // Create a unique filename for the image
                    string prefix = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(file[0].FileName);
                    var uploads = Path.Combine(wwwRootPath, "images");


                    // Save file to wwwroot/images/
                    using (var fileStream = new FileStream(Path.Combine(uploads, prefix + extension), FileMode.Create))
                    {
                        await file[0].CopyToAsync(fileStream);
                    }
                    
                    
                    company.Logo = "/images/" + prefix + extension;

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                    

                }



                // Create new entry
                if (id != company.CompanyId)
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
