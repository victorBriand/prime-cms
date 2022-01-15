using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCMS.Data;

namespace WebApplicationCMS.Controllers
{
    public class PlataformaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public PlataformaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //SELECT * FROM Pages WHERE Title = "Plataforma"
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == "Plataforma");
            return View(page);
        }

    }
}
