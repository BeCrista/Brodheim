using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brodheim;
using Brodheim.Models;

namespace Brodheim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuemSomosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public QuemSomosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/QuemSomos
        public async Task<IActionResult> Index()
        {
              return _context.QuemSomos != null ? 
                          View(await _context.QuemSomos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QuemSomos'  is null.");
        }

        // GET: Admin/QuemSomos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuemSomos == null)
            {
                return NotFound();
            }

            var quemSomos = await _context.QuemSomos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quemSomos == null)
            {
                return NotFound();
            }

            return View(quemSomos);
        }

        // GET: Admin/QuemSomos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuemSomos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QuemSomos quemSomos, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathSlider = Path.Combine(wwwRootPath, @"Images/QuemSomos");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(quemSomos.ImageRepresentative))
                    {
                        var lastImage = Path.Combine(wwwRootPath, quemSomos.ImageRepresentative.TrimStart('\\'));

                        if (System.IO.File.Exists(lastImage))
                        {
                            System.IO.File.Delete(lastImage);
                        }
                    }

                    // Save the image to the server
                    using (var fileStream = new FileStream(Path.Combine(pathSlider, uniqueFileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    // Set the ImageSlider property
                    quemSomos.ImageRepresentative = @"\Images\QuemSomos\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(quemSomos);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(quemSomos);
        }

        // GET: Admin/QuemSomos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuemSomos == null)
            {
                return NotFound();
            }

            var quemSomos = await _context.QuemSomos.FindAsync(id);
            if (quemSomos == null)
            {
                return NotFound();
            }
            return View(quemSomos);
        }

        // POST: Admin/QuemSomos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, QuemSomos quemSomos, IFormFile file)
        {
            if (id != quemSomos.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;

                    // Save image file to the wwwroot/images folder and update the ImageSlider property
                    if (file != null)
                    {
                        string pathSlider = Path.Combine(wwwRootPath, @"Images/QuemSomos");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(quemSomos.ImageRepresentative))
                        {
                            var lastImage = Path.Combine(wwwRootPath, quemSomos.ImageRepresentative.TrimStart('\\'));

                            if (System.IO.File.Exists(lastImage))
                            {
                                System.IO.File.Delete(lastImage);
                            }
                        }

                        // Save the new image to the server
                        using (var fileStream = new FileStream(Path.Combine(pathSlider, uniqueFileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        // Update the ImageSlider property with the new image path
                        quemSomos.ImageRepresentative = @"\Images\QuemSomos\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(quemSomos);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuemSomosExists(quemSomos.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(quemSomos);
        }

        // GET: Admin/QuemSomos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuemSomos == null)
            {
                return NotFound();
            }

            var quemSomos = await _context.QuemSomos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (quemSomos == null)
            {
                return NotFound();
            }

            return View(quemSomos);
        }

        // POST: Admin/QuemSomos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuemSomos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuemSomos'  is null.");
            }
            var quemSomos = await _context.QuemSomos.FindAsync(id);
            if (quemSomos != null)
            {
                _context.QuemSomos.Remove(quemSomos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuemSomosExists(int id)
        {
          return (_context.QuemSomos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
