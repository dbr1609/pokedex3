using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pokedex3.Models;

namespace Pokedex3.Controllers
{
    public class PokedexController : Controller
    {
        private IPokedex pokedex;
        private IConfiguration configuration;
        private ILogger<PokedexController> logger;
        public PokedexController(IConfiguration configuration, ILogger<PokedexController> logger, IPokedex pokedex)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.pokedex = pokedex;
        }
        
        public IActionResult Index()
        {
            logger.LogInformation("A user has used the pokedex");
            ViewBag.TimeStampGenerated = pokedex.GeneratedAt.ToString();
            return View(pokedex.GetAll());
        }

        public IActionResult Details(int id)
        {
            Pokemon pokemon = pokedex.Get(id);
            if (pokemon != null)
            {
                return View(pokemon);
            }
            return NotFound();
        }
    }
}
