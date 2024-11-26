using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DCProyectoPersMVC.Data;
using DCProyectoPersMVC.Models;

namespace DCProyectoPersMVC.Controllers
{
    public class DCBebidasController : Controller
    {
        private readonly DCProyectoPersMVCContext _context;

        public DCBebidasController(DCProyectoPersMVCContext context)
        {
            _context = context;
        }

        // Método privado para obtener la lista de tipos de bebida
        private SelectList GetDCTipos()
        {
            return new SelectList(Enum.GetValues(typeof(DC_Tipo)).Cast<DC_Tipo>());
        }

        // GET: DCBebidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DCBebida.ToListAsync());
        }

        // GET: DCBebidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCBebida = await _context.DCBebida
                .FirstOrDefaultAsync(m => m.DC_BebidaID == id);
            if (dCBebida == null)
            {
                return NotFound();
            }

            return View(dCBebida);
        }

        // GET: DCBebidas/Create
        public IActionResult Create()
        {
            ViewData["DCTipos"] = GetDCTipos();
            return View();
        }

        // POST: DCBebidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DC_BebidaID,DC_Nombre,DC_Precio,DC_Tipo")] DCBebida dCBebida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dCBebida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DCTipos"] = GetDCTipos();
            return View(dCBebida);
        }

        // GET: DCBebidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCBebida = await _context.DCBebida.FindAsync(id);
            if (dCBebida == null)
            {
                return NotFound();
            }

            ViewData["DCTipos"] = GetDCTipos();
            return View(dCBebida);
        }

        // POST: DCBebidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DC_BebidaID,DC_Nombre,DC_Precio,DC_Tipo")] DCBebida dCBebida)
        {
            if (id != dCBebida.DC_BebidaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dCBebida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DCBebidaExists(dCBebida.DC_BebidaID))
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

            ViewData["DCTipos"] = GetDCTipos();
            return View(dCBebida);
        }

        // GET: DCBebidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dCBebida = await _context.DCBebida
                .FirstOrDefaultAsync(m => m.DC_BebidaID == id);
            if (dCBebida == null)
            {
                return NotFound();
            }

            return View(dCBebida);
        }

        // POST: DCBebidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dCBebida = await _context.DCBebida.FindAsync(id);
            if (dCBebida != null)
            {
                _context.DCBebida.Remove(dCBebida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DCBebidaExists(int id)
        {
            return _context.DCBebida.Any(e => e.DC_BebidaID == id);
        }
    }
}

