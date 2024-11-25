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
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BrandsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Brands
        public async Task<IActionResult> Index()
        {
              return _context.Brands != null ? 
                          View(await _context.Brands.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Brands'  is null.");
        }

        // GET: Admin/Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brands == null)
            {
                return NotFound();
            }

            return View(brands);
        }

        // GET: Admin/Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Brands brands, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathSlider = Path.Combine(wwwRootPath, @"Images/Brands");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(brands.ImageBrand))
                    {
                        var lastImage = Path.Combine(wwwRootPath, brands.ImageBrand.TrimStart('\\'));

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
                    brands.ImageBrand = @"\Images\Brands\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(brands);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(brands);
        }

        // GET: Admin/Brands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands.FindAsync(id);
            if (brands == null)
            {
                return NotFound();
            }
            return View(brands);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Brands brands, IFormFile file)
        {
            if (id != brands.ID)
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
                        string pathSlider = Path.Combine(wwwRootPath, @"Images/Brands");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(brands.ImageBrand))
                        {
                            var lastImage = Path.Combine(wwwRootPath, brands.ImageBrand.TrimStart('\\'));

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
                        brands.ImageBrand = @"\Images\Brands\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(brands);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandsExists(brands.ID))
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

            return View(brands);
        }

        // GET: Admin/Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Brands == null)
            {
                return NotFound();
            }

            var brands = await _context.Brands
                .FirstOrDefaultAsync(m => m.ID == id);
            if (brands == null)
            {
                return NotFound();
            }

            return View(brands);
        }

        // POST: Admin/Brands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Brands == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Brands'  is null.");
            }
            var brands = await _context.Brands.FindAsync(id);
            if (brands != null)
            {
                _context.Brands.Remove(brands);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandsExists(int id)
        {
          return (_context.Brands?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
