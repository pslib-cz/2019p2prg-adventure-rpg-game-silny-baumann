using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RPGfaktPRG.Model;
using RPGfaktPRG.Services;

namespace RPGfaktPRG.Pages
{
    public class PlaceModel : PageModel
    {
        private GameService _gs;

        public PlaceModel(GameService gs)
        {
            _gs = gs;
        }

        public Location Location { get; set; }
        public List<Connection> Targets { get; set; }
        public void OnGet(Room id)
        {
            _gs.FetchData();
            
            _gs.State.Location = id;

            _gs.Store();
            Location = _gs.Location;
            Targets = _gs.Targets;
        }
    }
}