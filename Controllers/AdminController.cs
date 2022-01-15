using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCMS.Data;
using WebApplicationCMS.Models;

namespace WebApplicationCMS.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EditSection(string title)
        {
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == title);
            ViewData["page"] = title;

            if (title == null)
            {
                return Redirect("Index");
            }


            Page sections = _dbContext.Pages
                .Include(sec => sec.Sections)
                .Single(sec => sec.Title == title);
            //IList<Section> sections = _dbContext.Sections.Include(s => s.Page).Where(s =>s.TitleID == title).ToList();

            ViewBag.title = "Page is " + sections.Title;

            return View(sections.Sections);
        }
        public IActionResult EditPage(int id) 
        {
            // SELECT * FROM Sections WHERE ID = {id}
            var section = _dbContext.Sections.FirstOrDefault(x => x.ID == id);

            if (section == null)
            {
                section = new Section
                {
                    ID = id
                };

                //INSERT INTO Pages VALUE page
                _dbContext.Sections.Add(section);
                _dbContext.SaveChanges();
            }
            return View(section);
        }
        //Données en POST car nombreuses
        [HttpPost]
        public IActionResult SavePage(int title, string content)
        {
            var section = _dbContext.Sections.FirstOrDefault(x => x.ID == title);

            if(section == null)
            {
                return View("Error");
            }


            section.Content = content;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteSection(int id)
        {
            var section = _dbContext.Sections.Find(id);
            _dbContext.Sections.Remove(section);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult AddSection()
        {
            ViewBag.Pages = new SelectList(_dbContext.Pages, "Title");
            return View();
        }
        
        [HttpPost]
        public IActionResult AddSection(Section section)
        {
            _dbContext.Sections.Add(section);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
