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
    public class PassosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PassosController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Passos
        public async Task<IActionResult> Index()
        {
              return _context.Passos != null ? 
                          View(await _context.Passos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Passos'  is null.");
        }

        // GET: Admin/Passos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passos == null)
            {
                return NotFound();
            }

            var passos = await _context.Passos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (passos == null)
            {
                return NotFound();
            }

            return View(passos);
        }

        // GET: Admin/Passos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Passos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Passos passos, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathSlider = Path.Combine(wwwRootPath, @"Images/Passos");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(passos.ImagePasso))
                    {
                        var lastImage = Path.Combine(wwwRootPath, passos.ImagePasso.TrimStart('\\'));

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
                    passos.ImagePasso = @"\Images\Passos\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(passos);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(passos);
        }

        // GET: Admin/Passos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passos == null)
            {
                return NotFound();
            }

            var passos = await _context.Passos.FindAsync(id);
            if (passos == null)
            {
                return NotFound();
            }
            return View(passos);
        }

        // POST: Admin/Passos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Passos passos, IFormFile file)
        {
            if (id != passos.ID)
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
                        string pathSlider = Path.Combine(wwwRootPath, @"Images/Passos");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(passos.ImagePasso))
                        {
                            var lastImage = Path.Combine(wwwRootPath, passos.ImagePasso.TrimStart('\\'));

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
                        passos.ImagePasso = @"\Images\Passos\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(passos);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassosExists(passos.ID))
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

            return View(passos);
        }

        // GET: Admin/Passos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passos == null)
            {
                return NotFound();
            }

            var passos = await _context.Passos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (passos == null)
            {
                return NotFound();
            }

            return View(passos);
        }

        // POST: Admin/Passos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Passos'  is null.");
            }
            var passos = await _context.Passos.FindAsync(id);
            if (passos != null)
            {
                _context.Passos.Remove(passos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassosExists(int id)
        {
          return (_context.Passos?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
