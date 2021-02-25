using Microsoft.AspNetCore.Mvc;
using Stokin.Data;
using Stokin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stokin.Controllers
{
    public class SaleController : Controller
    {
        private readonly StokinDbContext _context;

        public SaleController(StokinDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", _context.Sales.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public void Create(Sale sale)
        {
        }

        [HttpGet]
        public void FindClient()
        {
            Console.WriteLine("");
        }
    }
}
