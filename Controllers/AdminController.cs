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
using WebApplicationCMS.ViewModel;

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
            var sectionsList = _dbContext.Sections
                .Include(x => x.Page)
                .ToList();
            return View(sectionsList);
        }
        [HttpPost]
        public IActionResult EditSection([Bind("Id,Title,Content,Page")] Section model)
        {


            var section = _dbContext.Sections.Where(x => x.ID == model.ID).FirstOrDefault();

            section = model;

            _dbContext.Update(section);
            _dbContext.SaveChanges();

            return View(section);

            //var page = _dbContext.Pages.FirstOrDefault(x => x.Title == title);
            //ViewData["page"] = title;

            //if (title == null)
            //{
            //    return Redirect("Index");
            //}


            //Page sections = _dbContext.Pages
            //    .Include(sec => sec.Sections)
            //    .Single(sec => sec.Title == title);
            ////IList<Section> sections = _dbContext.Sections.Include(s => s.Page).Where(s =>s.TitleID == title).ToList();

            //ViewBag.title = "Page is " + sections.Title;

            //return View(sections.Sections);
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
                return RedirectToAction(nameof(Index));
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


        [HttpGet]
        public IActionResult AddSection()
        {
            //ViewBag.Pages = new SelectList(_dbContext.Pages, "Title");
            var pagesList = _dbContext.Pages.ToList();
            var model = new AdminAddSectionViewModel
            {
                PageList = pagesList,
            };

            return View(model);
        }
        
        [HttpPost]
        public IActionResult AddSection([Bind("Content,Page")] AdminAddSectionViewModel model)
        {
            var page = _dbContext.Pages.Where(x => x.Id == model.Page.Id).FirstOrDefault();
            var section = new Section
            {
                Content = model.Content,
                Page = page
            };
            _dbContext.Add(section);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
