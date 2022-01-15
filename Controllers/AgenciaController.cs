using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationCMS.Data;

namespace WebApplicationCMS.Controllers
{
    public class AgenciaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public AgenciaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            //SELECT * FROM Pages WHERE Title = "Agencia"
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == "Agencia");
            return View(page);
        }

    }
}
