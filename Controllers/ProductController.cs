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
    public class ProductController : Controller
    {
        private readonly StokinDbContext _context;

        public ProductController(StokinDbContext context)
        {
            this._context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View("Index", await _context.Products.OrderBy(p => p.Name).ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View("Create", product);
            }
        }


        [HttpGet]
        public IActionResult Edit(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View("Edit", product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index", "Product");                    
            }

            return View("Edit", product);
        }

        [HttpGet]
        public IActionResult Details(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View("Details", product);
        }

        [HttpGet]
        public IActionResult Delete(Guid Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var product = _context.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            return View("Delete", product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            product = _context.Products.Find(product.Id);
            if (product.Equals(null))
            {
                return NotFound();
            }

            _context.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
