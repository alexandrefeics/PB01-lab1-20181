using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppPB01Lab1_AlexandreA.Models;

namespace WebAppPB01Lab1_AlexandreA.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteContext _context;

        public ClienteController(ClienteContext context)
        {
            _context = context;
        }

        // GET: Cliente
        [Route("")]
        [Route("cliente")]
        [Route("cliente/administracao/listar")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cliente.ToListAsync());
        }

        // GET: Cliente/Details/5
        [Route("")]
        [Route("cliente/administracao/detalhes /{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        [Route("cliente/administracao/cadastrar")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,nome,CPF,Email,DataCadastro")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        [Route("cliente/administracao/editar")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente.SingleOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [Route("cliente/administracao/editar")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,nome,CPF,Email,DataCadastro")] Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId))
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
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        [Route("cliente/administracao/remover/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .SingleOrDefaultAsync(m => m.ClienteId == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [Route("cliente/administracao/remover/{id:int}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.SingleOrDefaultAsync(m => m.ClienteId == id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.ClienteId == id);
        }
    }
}
