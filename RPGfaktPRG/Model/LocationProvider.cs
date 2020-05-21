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

            _locations.Add(Room.Start, new Location
            { // Game starts 
                ID = 0,
                Title = "Start",
                Description = "Vítáme tě u naší hry, která bude o útěku z vězení. Už to nebudeme zdržovat, běž na to!"
                

            }) ;
            _locations.Add(Room.Prison, new Location
            {
                ID = 1,
                Title = "Prison",
                Description = "Probouzíš se v jakémsi vězení a nic si nepamatuješ. Po chvilce slyšíš rozhovor mezi dvěma strážemi z něhož vyplývá, že jsi byl unešen hitmany, kteří se tě chystají kvůli tvým neuvěřitelným programátorským schopnostem prodat do otroctví. Musíš se za každou cenu dostat ven."
            });
            _locations.Add(Room.Fence, new Location
            {
                ID = 2,
                Title = "Fence",
                Description = "Přibližuješ se k plotu a zjištuješ, že přelézt ho asi není ta nejbezpečnější věc."
            });
            _locations.Add(Room.BehindFenceSuccess, new Location
            {
                ID = 3,
                Title = "BehindFenceSuccess",
                Description = "Úspěšně jsi přelezl plot, ale těžce jsi se zranil. Jsi sotva schopen udržet se na nohou. Ocitáš se před dlouhou silnicí. V dálce přes silnici vidíš uprostřed pustiny stát auto."
            });
            _locations.Add(Room.BehindFenceFailure, new Location
            {
                ID = 4,
                Title = "BehindFenceFailure",
                Description = "Při přelézání plotu jsi se několikrát bodl o drát. Rychle začínáš ztrácet krev a padáš do bezvědomí..."
            });
            _locations.Add(Room.Hall, new Location
            {
                ID = 5,
                Title = "Hall",
                Description = "Vstupuješ do haly, která je k tvému překvapení naprosto vylidněná. Stráže musí být někde poblíž."
            });
            _locations.Add(Room.Toilets, new Location
            {
                ID = 6,
                Title = "Toilets",
                Description = "Vstupuješ na záchody strážných. Už se připravuješ vykonat svojí potřebu, když najednou si všimneš krabičky v rohu místnosti."
            });
            _locations.Add(Room.ToiletsBox, new Location
            {
                ID = 7,
                Title = "ZachodyKrabicka",
                Description = "Přibližuješ se ke krabičce a rychle ti dochází, že jsou to pojistky. Vyhozením by sis mohl získat nějaký čas."
            });
            _locations.Add(Room.ToiletsBoxBlow, new Location
            {
                ID = 8,
                Title = "ZachodyKrabickaVyhozeni",
                Description = "Vyhodil jsi pojistky, čehož si stráže samozřejmě hned všimly. Snažil ses se nespatřeně vrátit do cely, ale jedna ze stráží tě chytila. Byl jsi poslán do lépe zabezpečené cely a nikdy už jsi neměl šanci k úniku."
            });
            _locations.Add(Room.CameraRoom, new Location
            {
                ID = 9,
                Title = "CameraRoom",
                Description = "Vstupuješ do místnosti s kamerami. Na stole vidíš jakousi kartu a mobil. Když se podíváš na hodiny na počítači, vidíš, že je čas oběda."
            });
            _locations.Add(Room.Gate, new Location
            {
                ID = 10,
                Title = "Gate",
                Description = "Opatrně jsi se proplížil a nikdo tě nespatřil. Vedle brány vidíš terminál. Na otevření brány budeš potřebovat kartu."
            });
            _locations.Add(Room.Tower, new Location
            {
                ID = 11,
                Title = "Tower",
                Description = "Pomalu se plížíš po schodech věže. V polovině cesty špatně šlápneš a uděláš tak hlasitý zvuk. Zezhora slyšíš, jak se zvedá strážný a jde ti naproti v domnění, že jsi jiný strážný, co ho jde vystřídat. Co uděláš?"
            });
            _locations.Add(Room.Yard, new Location
            {
                ID = 12,
                Title = "Yard",
                Description = "Dostal jsi se na nádvoří. Vidíš, že okolo celého areálu je ostnatý plot."
            });
            
            _locations.Add(Room.GameOver, new Location
            {
                ID = 13,
                Title = "Game Over",
                Description = "O uprchlých vězních z Alcatrazu se neví nic. Ani to, jestli jejich útěk byl úspěšný, nebo ne. U tebe je to však nadmíru jasné. ",
                Health = -10
            }); // Game Over


            _map.Add(new Connection(Room.Start, Room.Prison, "Začít"));
            _map.Add(new Connection(Room.Prison, Room.Hall, "Jít do haly"));
            _map.Add(new Connection(Room.Hall, Room.Prison, "Vrátit se do cely"));
            _map.Add(new Connection(Room.Prison, Room.Yard, "Utéct oknem na nádvoří"));
            _map.Add(new Connection(Room.Yard, Room.Prison, "Vrátit se do cely"));
            _map.Add(new Connection(Room.Yard, Room.Fence, "Jít k plotu"));
            _map.Add(new Connection(Room.Fence, Room.BehindFence, "Přelézt plot"));
            _map.Add(new Connection(Room.Yard, Room.Tower, "Proplížit se ke strážní věži"));
            _map.Add(new Connection(Room.Yard, Room.Gate, "Proplížit se k bráně"));
            _map.Add(new Connection(Room.Hall, Room.Toilets, "Vyzkoušet zbrusu nový záchody"));
            _map.Add(new Connection(Room.Hall, Room.CameraRoom, "Jít do kamerové místnosti"));
            _map.Add(new Connection(Room.Toilets, Room.Hall, "Jít zpět do haly"));
            _map.Add(new Connection(Room.CameraRoom, Room.Hall, "Jít zpět do haly"));
            _map.Add(new Connection(Room.Gate, Room.Hall, "Jít do vězeňské budovy"));
            _map.Add(new Connection(Room.Gate, Room.Prison, "Vrátit se do svojí cely"));
            _map.Add(new Connection(Room.Toilets, Room.ToiletsBox, "Jít ke krabičce"));
            _map.Add(new Connection(Room.ToiletsBox, Room.ToiletsBoxBlow, "Vyhodit pojistky"));
            _map.Add(new Connection(Room.ToiletsBox, Room.Hall, "Jít zpět do haly"));
            _map.Add(new Connection(Room.ToiletsBoxBlow, Room.Prison, "Hrát znovu"));
            _map.Add(new Connection(Room.Hall, Room.GameOver, "awdawd"));

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