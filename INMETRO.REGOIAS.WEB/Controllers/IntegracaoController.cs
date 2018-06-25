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
    public class IntegracaoController : Controller
    {
        private readonly OrgContexto _contexto;

        public IntegracaoController(OrgContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Integracao.OrderBy(s => s.DiretorioInspecaoLocal).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IntegracaoOrganismo integracaoInfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contexto.Add(integracaoInfo);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
                throw;
            }
            return View(integracaoInfo);
        }
    }
}