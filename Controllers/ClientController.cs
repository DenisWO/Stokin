using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stokin.Data;
using Stokin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stokin.Controllers
{
    public class ClientController : Controller
    {
        private readonly StokinDbContext _context;

        public ClientController(StokinDbContext context)
        {
            this._context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.OrderBy(c => c.Name).ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("Index", "Client");
            }
            else
            {
                return View(client);
            }
        }

        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var client = _context.Clients.Find(Id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Update(client);
                _context.SaveChanges();
                return RedirectToAction("Index", "Client");
            }
            else
            {
                return View(client);
            }
        }

        [HttpGet]
        public IActionResult Details(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var client = _context.Clients.Find(Id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var client = _context.Clients.Find(Id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
            return RedirectToAction("Index", "Client");
        }
        
    }
}
