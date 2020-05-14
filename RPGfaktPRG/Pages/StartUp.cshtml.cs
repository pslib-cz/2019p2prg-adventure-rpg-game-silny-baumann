using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGfaktPRG.Model;
using RPGfaktPRG.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPGfaktPRG.Pages
{
    public class StartUpModel : PageModel
    {
        private GameService _gs;
        public Location Location { get; set; }
        public List<Connection> Targets { get; set; }

        public StartUpModel(GameService gs)
        {
            _gs = gs;
        }

        public void OnGet()
        {
            _gs.Start();
            Location = _gs.Location;
            Targets = _gs.Targets;
        }
    }
}