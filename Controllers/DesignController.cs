using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCMS.Data;

namespace WebApplicationCMS.Controllers
{
    public class DesignController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public DesignController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //SELECT * FROM Pages WHERE Title = "Design"
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == "Design");
            return View(page);
        }

    }
}
