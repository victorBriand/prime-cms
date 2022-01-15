using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCMS.Data;

namespace WebApplicationCMS.Controllers
{
    public class MarketingController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public MarketingController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //SELECT * FROM Pages WHERE Title = "Marketing"
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == "Marketing");
            return View(page);
        }

    }
}
