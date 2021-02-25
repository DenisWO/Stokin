using Microsoft.AspNetCore.Mvc;
using Stokin.Data;
using Stokin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stokin.Controllers
{
    public class ItemSaleController : Controller
    {
        private readonly StokinDbContext _context;
        private ItemSale itemsale;

        public ItemSaleController(StokinDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(Sale sale)
        {
            ViewBag.Sale = sale;
            ViewBag.Products = _context.Products.ToList();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(string product, ItemSale item)
        {
            Sale sale = ViewBag.Sale;
            item.Product = _context.Products.Find(Guid.Parse(product));
            if (sale.Items == null)
            {
                sale.Items = new List<ItemSale>();
            }
            sale.Items.Add(item);
            if (ModelState.IsValid)
            {
                ViewBag.Sale = sale;
                ViewBag.Items = sale.Items;
            }
            return View("Create");
        }
    }
}
