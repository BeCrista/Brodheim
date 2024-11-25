using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brodheim;
using Brodheim.Models;
using Microsoft.IdentityModel.Tokens;

namespace Brodheim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageSlidersTestemunhasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomePageSlidersTestemunhasController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/HomePageSlidersTestemunhas
        public async Task<IActionResult> Index()
        {
              return _context.SliderTestemunhas != null ? 
                          View(await _context.SliderTestemunhas.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SliderTestemunhas'  is null.");
        }

        // GET: Admin/HomePageSlidersTestemunhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SliderTestemunhas == null)
            {
                return NotFound();
            }

            var homePageSlidersTestemunhas = await _context.SliderTestemunhas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (homePageSlidersTestemunhas == null)
            {
                return NotFound();
            }

            return View(homePageSlidersTestemunhas);
        }

        // GET: Admin/HomePageSlidersTestemunhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/HomePageSlidersTestemunhas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HomePageSlidersTestemunhas homePageSlidersTestemunhas, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathSlider = Path.Combine(wwwRootPath, @"Images/HomePageSliderTestemunha");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(homePageSlidersTestemunhas.PersonImage))
                    {
                        var lastImage = Path.Combine(wwwRootPath, homePageSlidersTestemunhas.PersonImage.TrimStart('\\'));

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
                    homePageSlidersTestemunhas.PersonImage = @"\Images\HomePageSliderTestemunha\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(homePageSlidersTestemunhas);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(homePageSlidersTestemunhas);
        }

        // GET: Admin/HomePageSlidersTestemunhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SliderTestemunhas == null)
            {
                return NotFound();
            }

            var homePageSlidersTestemunhas = await _context.SliderTestemunhas.FindAsync(id);
            if (homePageSlidersTestemunhas == null)
            {
                return NotFound();
            }
            return View(homePageSlidersTestemunhas);
        }

        // POST: Admin/HomePageSlidersTestemunhas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, HomePageSlidersTestemunhas homePageSlidersTestemunhas, IFormFile file)
        {
            if (id != homePageSlidersTestemunhas.ID)
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
                        string pathSlider = Path.Combine(wwwRootPath, @"Images/HomePageSliderTestemunha");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(homePageSlidersTestemunhas.PersonImage))
                        {
                            var lastImage = Path.Combine(wwwRootPath, homePageSlidersTestemunhas.PersonImage.TrimStart('\\'));

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
                        homePageSlidersTestemunhas.PersonImage = @"\Images\HomePageSliderTestemunha\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(homePageSlidersTestemunhas);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomePageSlidersTestemunhasExists(homePageSlidersTestemunhas.ID))
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

            return View(homePageSlidersTestemunhas);
        }

        // GET: Admin/HomePageSlidersTestemunhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SliderTestemunhas == null)
            {
                return NotFound();
            }

            var homePageSlidersTestemunhas = await _context.SliderTestemunhas
                .FirstOrDefaultAsync(m => m.ID == id);
            if (homePageSlidersTestemunhas == null)
            {
                return NotFound();
            }

            return View(homePageSlidersTestemunhas);
        }

        // POST: Admin/HomePageSlidersTestemunhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SliderTestemunhas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SliderTestemunhas'  is null.");
            }
            var homePageSlidersTestemunhas = await _context.SliderTestemunhas.FindAsync(id);
            if (homePageSlidersTestemunhas != null)
            {
                _context.SliderTestemunhas.Remove(homePageSlidersTestemunhas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomePageSlidersTestemunhasExists(int id)
        {
          return (_context.SliderTestemunhas?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
