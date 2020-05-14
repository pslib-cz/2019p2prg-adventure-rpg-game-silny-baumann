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
        private Dictionary<Room, ILocation> _locations;
        private List<Connection> _map;

        public LocationProvider()
        {
            _locations = new Dictionary<Room, ILocation>();
            _map = new List<Connection>();
            
            _locations.Add(Room.Start, new Location {Title = "Start", Description = "This is where our story starts."}); // Game starts
            _locations.Add(Room.Fence, new Location { Title = "Fence", Description = "" }); //In prison
            _locations.Add(Room.Hall, new Location {Title = "Hall", Description = "" });
            _locations.Add(Room.Zachody, new Location {Title = "Zachody", Description = "" });
            _locations.Add(Room.CameraRoom, new Location { Title = "CameraRoom", Description = "" });
            _locations.Add(Room.Gate, new Location { Title = "Gate", Description = "Opatrně jsi se proplížil a nikdo tě nespatřil. Vedle brány vidíš terminál. Na otevření brány budeš potřebovat kartu." });
            _locations.Add(Room.Tower, new Location { Title = "Tower", Description = "Pomalu se plížíš po schodech věže, když najednou jeden ze schodů vydá zvláštní zvuk po tom, co na něj šlápneš. Zezhora slyšíš jak se zvedá strážný a jde ti naproti v domění, že jsi jiný strážný, co ho jde vystřídat. Co uděláš?" });
            _locations.Add(Room.Yard, new Location { Title = "Yard", Description = "Dostal jsi se na nádvoří a vidíš že okolo celého areálu je ostnatý plot. Pokusit se ho přelézt by tě mohlo stát život." });
            _locations.Add(Room.Prison, new Location { Title = "Prison", Description = "Probouzíš se v jakémsi vězení a nic si nepamatuješ. Po chvilce slyšíš rozhovor mezi dvěma strážemi z něhož vyplývá, že jsi byl unešen hitmany, kteří se tě chystají kvůli tvým neuvěřitelným programátorským schopnostem prodat do otroctví. Musíš se za každou cenu dostat ven." });
            _locations.Add(Room.GameOver, new Location { Title = "Game Over", Description = "All worldly things will one day perish. You just did." }); // Game Over
            _map.Add(new Connection(Room.Start, Room.Prison, "Prison"));
            _map.Add(new Connection(Room.Prison, Room.Hall, "JDI DO HALY"));
            _map.Add(new Connection(Room.Hall, Room.Prison, "Můžeš se vrátit do cely"));
            _map.Add(new Connection(Room.Prison, Room.Yard, "Utéct na YARD"));
            _map.Add(new Connection(Room.Yard, Room.Prison, "Vrátit se zpět"));
            _map.Add(new Connection(Room.Yard, Room.Tower, "Jdi ke věži"));
            _map.Add(new Connection(Room.Yard, Room.Gate, "Jdi k bráně"));
            _map.Add(new Connection(Room.Hall, Room.Zachody, "Vyzkoušej nový záchody"));
            _map.Add(new Connection(Room.Hall, Room.CameraRoom, "Jdi do cameraRoom"));
            _map.Add(new Connection(Room.Zachody, Room.Hall, "Zpět do Haly"));
            _map.Add(new Connection(Room.CameraRoom, Room.Hall, "Zpět do Haly"));
            _map.Add(new Connection(Room.CameraRoom, Room.Hall, "Zpět do Haly"));

        }

        public bool ExistsLocation(Room id)
        {
            return _locations.ContainsKey(id);
        }

        public List<Connection> GetConnectionsFrom(Room id)
        {
            if (ExistsLocation(id))
            {
                return _map.Where(m => m.From == id).ToList();
            }
            throw new InvalidLocation();
        }

        public List<Connection> GetConnectionsTo(Room id)
        {
            throw new NotImplementedException();
        }

        public Location GetLocation(Room id)
        {
            if (ExistsLocation(id))
            {
                return (Location)_locations[id];
            }
            throw new InvalidLocation();
        }

        public bool IsNavigationLegitimate(Room from, Room to, GameState state)
        {
            throw new NotImplementedException();
        }
    }
}

