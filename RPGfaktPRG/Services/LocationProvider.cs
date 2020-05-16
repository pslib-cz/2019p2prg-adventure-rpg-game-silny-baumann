using RPGfaktPRG.Model;
using RPGfaktPRG.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGfaktPRG.Services
{
    public class LocationProvider : ILocationProvider
    {
        private Dictionary<int, ILocation> _locations;
        private List<Connection> _map;

        public LocationProvider()
        {
            _locations = new Dictionary<int, ILocation>();
            _map = new List<Connection>();
            
            _locations.Add(0, new Location {Title = "Start", Description = "This is where our story starts."}); // Game starts
            _locations.Add(1, new Location { Title = "Prison", Description = "Probouzíš se v jakémsi vězení a nic si nepamatuješ. Po chvilce slyšíš rozhovor mezi dvěma strážemi z něhož vyplývá, že jsi byl unešen hitmany, kteří se tě chystají kvůli tvým neuvěřitelným programátorským schopnostem prodat do otroctví. Musíš se za každou cenu dostat ven." });
            _locations.Add(2, new Location { Title = "Yard", Description = "Dostal jsi se na nádvoří a vidíš že okolo celého areálu je ostnatý plot. Pokusit se ho přelézt by tě mohlo stát život." });
            _locations.Add(4, new Location { Title = "Fence", Description = "" }); //In prison
            _locations.Add(5, new Location { Title = "Gate", Description = "Opatrně jsi se proplížil a nikdo tě nespatřil. Vedle brány vidíš terminál. Na otevření brány budeš potřebovat kartu." });
            _locations.Add(6, new Location { Title = "Tower", Description = "Pomalu se plížíš po schodech věže, když najednou jeden ze schodů vydá zvláštní zvuk po tom, co na něj šlápneš. Zezhora slyšíš jak se zvedá strážný a jde ti naproti v domění, že jsi jiný strážný, co ho jde vystřídat. Co uděláš?" });
            _locations.Add(7, new Location {Title = "Hall", Description = "" });
            _locations.Add(8, new Location {Title = "Zachody", Description = "" });
            _locations.Add(9, new Location { Title = "CameraRoom", Description = "" });
            _locations.Add(10, new Location { Title = "Game Over", Description = "All worldly things will one day perish. You just did." }); // Game Over
            _map.Add(new Connection(1, 2, "Prison"));
            _map.Add(new Connection(2, 7, "JDI DO HALY"));
            _map.Add(new Connection(7, 2, "Můžeš se vrátit do cely"));
            _map.Add(new Connection(2, 3, "Utéct na YARD"));
            _map.Add(new Connection(3, 2, "Vrátit se zpět"));
            _map.Add(new Connection(3, 6, "Jdi ke věži"));
            _map.Add(new Connection(3, 5, "Jdi k bráně"));
            _map.Add(new Connection(7, 8, "Vyzkoušej nový záchody"));
            _map.Add(new Connection(7, 9, "Jdi do cameraRoom"));
            _map.Add(new Connection(8, 7, "Zpět do Haly"));
            _map.Add(new Connection(9, 7, "Zpět do Haly"));
            _map.Add(new Connection(9, 7, "Zpět do Haly"));

        }

        public bool ExistsLocation(int id)
        {
            return _locations.ContainsKey(id);
        }

        public List<Connection> GetConnectionsFrom(int id)
        {
            if (ExistsLocation(id))
            {
                return _map.Where(m => m.From == id).ToList();
            }
            throw new InvalidLocation();
        }

        public List<Connection> GetConnectionsTo(int id)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(int id)
        {
            if (ExistsLocation(id))
            {
                return (Location)_locations[id];
            }
            throw new InvalidLocation();
        }

        public bool IsNavigationLegitimate(int from, int to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}

