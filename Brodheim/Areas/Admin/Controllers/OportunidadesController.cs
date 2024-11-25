using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Brodheim.Models;

namespace Brodheim.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OportunidadesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OportunidadesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Oportunidades
        public async Task<IActionResult> Index()
        {
            return _context.Oportunidades != null ?
                        View(await _context.Oportunidades.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Oportunidades'  is null.");
        }

        [HttpGet]
        public IActionResult SearchOportunidades(string nomeTrabalho, string nomeEmpresa, string localizacao, string nomeFuncao)
        {
            // Your code to filter the job opportunities based on the search criteria
            // For example:
            var filteredOpportunities = _context.Oportunidades
                .Where(op => op.NomeTrabalho.Contains(nomeTrabalho ?? "") &&
                             op.NomeEmpresa.Contains(nomeEmpresa ?? "") &&
                             op.Localizacao.Contains(localizacao ?? "") &&
                             op.NomeFuncao.Contains(nomeFuncao ?? ""))
                .ToList();

            // Return the filtered job opportunities as JSON data
            return Json(filteredOpportunities);
        }



        // GET: Admin/Oportunidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Oportunidades == null)
            {
                return NotFound();
            }

            var oportunidades = await _context.Oportunidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oportunidades == null)
            {
                return NotFound();
            }

            return View(oportunidades);
        }

        // GET: Admin/Oportunidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Oportunidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Oportunidades oportunidades, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                // Save image file to the wwwroot/images folder and set the ImageSlider property
                if (file != null)
                {
                    string pathSlider = Path.Combine(wwwRootPath, @"Images/Oportunidades");
                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    if (!string.IsNullOrEmpty(oportunidades.ImageEmpresa))
                    {
                        var lastImage = Path.Combine(wwwRootPath, oportunidades.ImageEmpresa.TrimStart('\\'));

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
                    oportunidades.ImageEmpresa = @"\Images\Oportunidades\" + uniqueFileName;
                }

                // Clear ModelState to avoid validation issues with ImageFile field
                ModelState.Clear();

                // Add the entity to the context after the image has been saved
                _context.Add(oportunidades);

                // Save changes to the database
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(oportunidades);
        }

        // GET: Admin/Oportunidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Oportunidades == null)
            {
                return NotFound();
            }

            var oportunidades = await _context.Oportunidades.FindAsync(id);
            if (oportunidades == null)
            {
                return NotFound();
            }
            return View(oportunidades);
        }

        // POST: Admin/Oportunidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Oportunidades oportunidades, IFormFile file)
        {
            if (id != oportunidades.ID)
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
                        string pathSlider = Path.Combine(wwwRootPath, @"Images/Oportunidades");
                        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        if (!string.IsNullOrEmpty(oportunidades.ImageEmpresa))
                        {
                            var lastImage = Path.Combine(wwwRootPath, oportunidades.ImageEmpresa.TrimStart('\\'));

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
                        oportunidades.ImageEmpresa = @"\Images\Oportunidades\" + uniqueFileName;
                    }

                    // Clear ModelState to avoid validation issues with ImageFile field
                    ModelState.Clear();

                    // Update the entity in the context after the image has been saved or if it is unchanged
                    _context.Update(oportunidades);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OportunidadesExists(oportunidades.ID))
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

            return View(oportunidades);
        }

        // GET: Admin/Oportunidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Oportunidades == null)
            {
                return NotFound();
            }

            var oportunidades = await _context.Oportunidades
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oportunidades == null)
            {
                return NotFound();
            }

            return View(oportunidades);
        }

        // POST: Admin/Oportunidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Oportunidades == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Oportunidades'  is null.");
            }
            var oportunidades = await _context.Oportunidades.FindAsync(id);
            if (oportunidades != null)
            {
                _context.Oportunidades.Remove(oportunidades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OportunidadesExists(int id)
        {
            return (_context.Oportunidades?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
