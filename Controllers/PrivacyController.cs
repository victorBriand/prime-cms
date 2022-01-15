using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCMS.Data;

namespace WebApplicationCMS.Controllers
{
    public class PrivacyController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public PrivacyController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //SELECT * FROM Pages WHERE Title = "Agencia"
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == "Privacy");
            return View(page);
        }

    }
}
