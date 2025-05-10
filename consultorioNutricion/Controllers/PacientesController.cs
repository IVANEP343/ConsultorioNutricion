using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using consultorioNutricion.Data;
using consultorioNutricion.Models;

namespace consultorioNutricion.Controllers
{
    public class PacientesController : Controller
    {
        private readonly ConsultorioDbContext _context;

        public PacientesController(ConsultorioDbContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var consultorioDbContext = _context.Pacientes.Include(p => p.Ciudad).Include(p => p.ObraSocial);
            return View(await consultorioDbContext.ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.Ciudad)
                .Include(p => p.ObraSocial)
                .FirstOrDefaultAsync(m => m.PacienteId == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            ViewData["CiudadId"] = new SelectList(_context.Ciudads, "CiudadId", "CiudadId");
            ViewData["ObraSocialId"] = new SelectList(_context.ObraSocials, "ObraSocialId", "ObraSocialId");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacienteId,Nombre,Apellido,Dni,Calle,Altura,Piso,Depto,CiudadId,Telefono,Email,ObraSocialId,NumeroAfiliado,FechaNacimiento,Antecedentes,Alergias,Observaciones,FechaAlta")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudads, "CiudadId", "CiudadId", paciente.CiudadId);
            ViewData["ObraSocialId"] = new SelectList(_context.ObraSocials, "ObraSocialId", "ObraSocialId", paciente.ObraSocialId);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudads, "CiudadId", "CiudadId", paciente.CiudadId);
            ViewData["ObraSocialId"] = new SelectList(_context.ObraSocials, "ObraSocialId", "ObraSocialId", paciente.ObraSocialId);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacienteId,Nombre,Apellido,Dni,Calle,Altura,Piso,Depto,CiudadId,Telefono,Email,ObraSocialId,NumeroAfiliado,FechaNacimiento,Antecedentes,Alergias,Observaciones,FechaAlta")] Paciente paciente)
        {
            if (id != paciente.PacienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.PacienteId))
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
            ViewData["CiudadId"] = new SelectList(_context.Ciudads, "CiudadId", "CiudadId", paciente.CiudadId);
            ViewData["ObraSocialId"] = new SelectList(_context.ObraSocials, "ObraSocialId", "ObraSocialId", paciente.ObraSocialId);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.Ciudad)
                .Include(p => p.ObraSocial)
                .FirstOrDefaultAsync(m => m.PacienteId == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.PacienteId == id);
        }
    }
}
