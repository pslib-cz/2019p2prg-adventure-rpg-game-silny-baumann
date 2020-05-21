using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public int clickPercentage = 70;
        public GameState State { get; set; }
        public List<Connection> Targets { get; set; }
        public Random RandomGen = new Random();
        public string wdawd = "dwad";
        public int randomValueBetween0And99;
        public void OnGet(Room id)
        {
            _gs.FetchData();
            
            _gs.State.Location = id;

            _gs.Store();
            Location = _gs.Location;
            Targets = _gs.Targets;
            _gs.Action(id);
            State = _gs.State;
            randomValueBetween0And99 = RandomGen.Next(100);
        }
        
    }
}