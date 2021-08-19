using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDOLISTt.infrastructure;
using ToDOLISTt.Models;

namespace ToDOLISTt.Controllers
{
    public class TodoController : Controller
    {
        private readonly ToDoContext context;

        public TodoController(ToDoContext context)
        {
            this.context = context;
        }
        //Get/
        public async Task<ActionResult> Index()
        {
            IQueryable<Todolisst> items = from i in context.todolissts orderby i.Id select i;

            List<Todolisst> todolissts = await items.ToListAsync();

            return View(todolissts);
        }

        // Get /todo/create
        public IActionResult Create() => View();

        //Post /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Todolisst item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item hass been added";

                return RedirectToAction("Index");
            }

            return View(item);

        }
        // Get /todo/edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Todolisst item = await context.todolissts.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //Post /todo/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Todolisst item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item hass been updated";

                return RedirectToAction("Index");
            }

            return View(item);

        }
        // Get /todo/delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Todolisst item = await context.todolissts.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                context.todolissts.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item hass been deleted";
            }

            return RedirectToAction("Index");
        }
    }
}