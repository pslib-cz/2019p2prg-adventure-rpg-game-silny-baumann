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
            
            _locations.Add(Room.Start, new Location { // Game starts 
                Title = "Start", 
                Description = "Vítáme tě u naší hry, která bude o útěku z vězení. Už to nebudeme zdržovat, běž na to!" });
            _locations.Add(Room.Prison, new Location { 
                Title = "Prison", 
                Description = "Probouzíš se v jakémsi vězení a nic si nepamatuješ. Po chvilce slyšíš rozhovor mezi dvěma strážemi z něhož vyplývá, že jsi byl unešen hitmany, kteří se tě chystají kvůli tvým neuvěřitelným programátorským schopnostem prodat do otroctví. Musíš se za každou cenu dostat ven." });
            _locations.Add(Room.Fence, new Location { 
                Title = "Fence", 
                Description = "Přibližuješ se k plotu a zjištuješ, že přelézt ho nebude uplně bezpečné." }); 
            _locations.Add(Room.Hall, new Location {
                Title = "Hall", 
                Description = "Vstupuješ do haly, která je k tvému překvapení naprosto vylidněná. Stráže musí být někde poblíž." });
            _locations.Add(Room.Zachody, new Location {
                Title = "Zachody", 
                Description = "Vstupuješ na záchody strážných. Už se připravuješ vykonat svojí potřebu, když najednou si všimneš krabičky v rohu místnosti." });
            _locations.Add(Room.CameraRoom, new Location { 
                Title = "CameraRoom", 
                Description = "Vstupuješ do místnosti s kamerami. Na stole vidíš jakousi kartu a mobil. Když se podíváš na hodiny na počítači, vidíš, že je čas oběda." });
            _locations.Add(Room.Gate, new Location { 
                Title = "Gate", 
                Description = "Opatrně jsi se proplížil a nikdo tě nespatřil. Vedle brány vidíš terminál. Na otevření brány budeš potřebovat kartu." });
            _locations.Add(Room.Tower, new Location { 
                Title = "Tower", 
                Description = "Pomalu se plížíš po schodech věže. V polovině cesty špatně šlápneš a uděláš tak hlasitý zvuk. Zezhora slyšíš, jak se zvedá strážný a jde ti naproti v domnění, že jsi jiný strážný, co ho jde vystřídat. Co uděláš?" });
            _locations.Add(Room.Yard, new Location { 
                Title = "Yard", 
                Description = "Dostal jsi se na nádvoří. Vidíš, že okolo celého areálu je ostnatý plot." });
            _locations.Add(Room.GameOver, new Location { 
                Title = "Game Over", 
                Description = "O uprchlých vězních z Alcatrazu se neví nic. Ani to, jestli jejich útěk byl úspěšný, nebo ne. U tebe je to však nadmíru jasné. "
            }); // Game Over


            _map.Add(new Connection(Room.Start, Room.Prison, "Začít"));
            _map.Add(new Connection(Room.Prison, Room.Hall, "Jít do haly"));
            _map.Add(new Connection(Room.Hall, Room.Prison, "Vrátit se do cely"));
            _map.Add(new Connection(Room.Prison, Room.Yard, "Utéct oknem na nádvoří"));
            _map.Add(new Connection(Room.Yard, Room.Prison, "Vrátit se do cely"));
            _map.Add(new Connection(Room.Yard, Room.Tower, "Proplížit se ke strážní věži"));
            _map.Add(new Connection(Room.Yard, Room.Gate, "Proplížit se k bráně"));
            _map.Add(new Connection(Room.Hall, Room.Zachody, "Vyzkoušet zbrusu nový záchody"));
            _map.Add(new Connection(Room.Hall, Room.CameraRoom, "Jít do kamerové místnosti"));
            _map.Add(new Connection(Room.Zachody, Room.Hall, "Jít zpět do haly"));
            _map.Add(new Connection(Room.CameraRoom, Room.Hall, "Jít zpět do haly"));
            _map.Add(new Connection(Room.Gate, Room.Hall, "Jít do vězeňské budovy"));
            _map.Add(new Connection(Room.Gate, Room.Prison, "Vrátit se do svojí cely"));
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

