using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INMETRO.REGOIAS.WEB.DADOS;
using INMETRO.REGOIAS.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INMETRO.REGOIAS.WEB.Controllers
{
    public class OrganismoController : Controller
    {
        private readonly OrgContexto _contexto;

        public OrganismoController(OrgContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Organismos.Where(s => s.EhAtivo).OrderBy(c => c.CodigoOIA).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome, CodigoOIA, EhAtivo")] Organismo organismo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contexto.Add(organismo);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
                throw;
            }
            return View(organismo);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departamento = await _contexto.Organismos.SingleOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Organismo departamento)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(departamento);
                    await _contexto.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!DepartamentoExists(departamento.DepartamentoID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }

    }
}