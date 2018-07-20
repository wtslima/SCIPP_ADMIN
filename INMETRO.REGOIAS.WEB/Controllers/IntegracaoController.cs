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
            var integracao = new IntegracaoOrganismo();
            //integracao.DiretorioInspecao = "INSPECOES";

            var organismos = _contexto.Organismos.OrderBy(o => o.Id).ToList(); 

            organismos.Insert(0, new Organismo()
            {
                Id = 0,
                CodigoOIA  = "Selecione	o CÓDIGO-OIA"
            });
            ViewBag.Organismos = organismos;
            return View(integracao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IntegracaoOrganismo integracaoInfo)
        {
            try
            {
               
                    if (integracaoInfo.OrganismoId> 0)
                    {
                        var codigo_oia =  _contexto.Organismos.FirstOrDefault(s => s.Id == integracaoInfo.OrganismoId).CodigoOIA;
                        integracaoInfo.DiretorioInspecaoLocal = codigo_oia;

                    }

                    integracaoInfo.DiretorioInspecao = "INSPECOES";
                    integracaoInfo.Porta = integracaoInfo.TipoIntegracao == 1 ? "21" : "22";
                    _contexto.Add(integracaoInfo);
                    await _contexto.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
                throw;
            }
            return View(integracaoInfo);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var integracao = await _contexto.Integracao.SingleOrDefaultAsync(m => m.Id == id);
            if (integracao == null)
            {
                return NotFound();
            }
            return View(integracao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IntegracaoOrganismo integracao)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(integracao);
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
            return View(integracao);
        }
    }
}