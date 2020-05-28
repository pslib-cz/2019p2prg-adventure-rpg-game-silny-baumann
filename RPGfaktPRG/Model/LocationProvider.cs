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


            });
            _locations.Add(Room.Prison, new Location
            {
                ID = 1,
                Title = "Prison",
                Description = "Probouzíš se v jakémsi vězení a nic si nepamatuješ. Po chvilce slyšíš rozhovor mezi dvěma strážemi z něhož vyplývá, že jsi byl unešen hitmany, kteří se tě chystají kvůli tvým neuvěřitelným programátorským schopnostem prodat do otroctví. Musíš se za každou cenu dostat ven. Ze stolu čouhá drát, který by mohl posloužit jako šperhák."
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
                Title = "Podařilo se přelézt",
                Description = "Úspěšně jsi přelezl plot, ale těžce jsi se zranil. Jsi sotva schopen udržet se na nohou. Ocitáš se před dlouhou silnicí. V dálce přes silnici vidíš uprostřed pustiny stát auto. Udržel jsi malé škrábnutí.."
            });
            _locations.Add(Room.BehindFenceFailure, new Location
            {
                ID = 4,
                Title = "Nepovedlo se",
                Description = "Při přelézání plotu jsi se několikrát bodl o drát. Rychle začínáš ztrácet krev a padáš do bezvědomí... přišel jsi o svá HP"

            });
            _locations.Add(Room.Hall, new Location
            {
                ID = 5,
                Title = "Hall",
                Description = "Vstupuješ do haly, která je k tvému překvapení naprosto vylidněná. Stráže musí být někde poblíž. Máš na výběr vrátit se zpátky, jít do první místnosti na záchody nebo dostat se do jídelny a nebo do místnosti s kamerami."
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
            _locations.Add(Room.DiningRoom, new Location
            {
                ID = 14,
                Title = "DiningRoom",
                Description = "Pomalu otevíráš dveře jídelny. Po vykouknutí zpoza dveří vidíš, kde byly celou dobu všechny stráže. Než se naděješ, všichni se po tobě sbíhají..."
            });
            _locations.Add(Room.Car, new Location
            {
                ID = 15,
                Title = "Car",
                Description = "Pomalu jsi se dobelhal k autu. Všímáš si otevřených dveří ale když se podíváš dovnitř, klíče nevidíš."
            });
            _locations.Add(Room.Road, new Location
            {
                ID = 16,
                Title = "Road",
                Description = "Chvíli jdeš po cestě, když najednou okolo projíždí vězeňské auto. Nejspíš si všimli, že jim chybíš. Auto se zastavuje. Co uděláš?"
            });
            _locations.Add(Room.DoNothing, new Location
            {
                ID = 17,
                Title = "DoNothing",
                Description = "Poklidně jdeš dál po silnici s vírou, že tě nerozpoznají. Ovšem se mýlíš a poslední co vidíš je to, jak strážník vytahuje svoje USPčko."
            });
            _locations.Add(Room.Run, new Location
            {
                ID = 18,
                Title = "Run",
                Description = "Rozhodneš se utíkat, ale je to k ničemu. Během několika sekund tě strážní dobíhají a sráží tě na zem..."
            });
            _locations.Add(Room.Surrender, new Location
            {
                ID = 19,
                Title = "Surrender",
                Description = "Rozhodneš se neriskovat svůj život a vzdát se. Stráže tě berou do zadní části auta. Stráže už se chystají tě odvézt, když najednou řidiči začne zvonit telefon. Nechává klíčky v zapalování a jde s telefonem ven. Druhý strážný si jde zatím zakouřit. Tohle by mohla být tvoje poslední šance na útěk. Co uděláš?"
            });
            _locations.Add(Room.DoNothingCar, new Location
            {
                ID = 20,
                Title = "DoNothingCar",
                Description = "Rozhodneš se nic neudělat. Po chvilce se oba strážní vracejí a odváží tě do věznice. Vážně jsi TAKHLE propásl svojí šanci?"
            });
            _locations.Add(Room.CarSteal, new Location
            {
                ID = 21,
                Title = "CarSteal",
                Description = "Přelézáš zezadu na místo řidiče a rychle startuješ auto. Strážníci si tě rychle všímají a běží k autu. Ty ale šlapeš na pedál a rychle odjíždíš. Zvládl jsi to!"
            });


            _map.Add(new Connection(1, Room.Start, Room.Prison, "Začít"));
            _map.Add(new Connection(2, Room.Prison, Room.Hall, "Pokusit se vypáčit zámek"));
            _map.Add(new Connection(3, Room.Prison, Room.Yard, "Utéct oknem na nádvoří"));
            _map.Add(new Connection(4, Room.Yard, Room.Prison, "Vrátit se do cely"));
            _map.Add(new Connection(5, Room.Yard, Room.Fence, "Jít k plotu"));
            _map.Add(new Connection(6, Room.Yard, Room.Tower, "Proplížit se ke strážní věži"));
            _map.Add(new Connection(7, Room.Yard, Room.Gate, "Proplížit se k bráně"));
            _map.Add(new Connection(8, Room.Hall, Room.Toilets, "Vyzkoušet zbrusu nový záchody"));
            _map.Add(new Connection(9, Room.Hall, Room.CameraRoom, "Jít do kamerové místnosti"));
            _map.Add(new Connection(10, Room.Hall, Room.Prison, "Vrátit se do cely"));
            _map.Add(new Connection(11, Room.Toilets, Room.Hall, "Jít zpět do haly"));
            _map.Add(new Connection(12, Room.CameraRoom, Room.Hall, "Jít zpět do haly"));
            _map.Add(new Connection(13, Room.Gate, Room.Hall, "Jít do vězeňské budovy"));
            _map.Add(new Connection(14, Room.Gate, Room.Prison, "Vrátit se do svojí cely"));
            _map.Add(new Connection(15, Room.Toilets, Room.ToiletsBox, "Jít ke krabičce"));
            _map.Add(new Connection(16, Room.ToiletsBox, Room.ToiletsBoxBlow, "Vyhodit pojistky"));
            _map.Add(new Connection(17, Room.ToiletsBox, Room.Hall, "Jít zpět do haly"));
            _map.Add(new Connection(18, Room.ToiletsBoxBlow, Room.Prison, "Hrát znovu"));
            _map.Add(new Connection(20, Room.BehindFenceSuccess, Room.Car, "Jít k autu"));
            _map.Add(new Connection(21, Room.BehindFenceSuccess, Room.Road, "Jít po silnici"));
            _map.Add(new Connection(22, Room.Car, Room.BehindFenceSuccess, "Vrátit se k plotu"));
            _map.Add(new Connection(23, Room.Road, Room.DoNothing, "Jít dál"));
            _map.Add(new Connection(24, Room.Road, Room.Run, "Zkusit utéct"));
            _map.Add(new Connection(25, Room.Run, Room.Prison, "Hrát znovu"));
            _map.Add(new Connection(26, Room.DoNothing, Room.Prison, "Hrát znovu"));
            _map.Add(new Connection(27, Room.Road, Room.Surrender, "Vzdát se"));
            _map.Add(new Connection(28, Room.Surrender, Room.DoNothingCar, "Nic nedělat"));
            _map.Add(new Connection(29, Room.Surrender, Room.CarSteal, "Pokusit se ukrást auto"));
            _map.Add(new Connection(30, Room.CarSteal, Room.Prison, "Hrát znovu"));
            _map.Add(new Connection(31, Room.Fence, Room.BehindFenceSuccess, "Jít k plotu"));
            _map.Add(new Connection(32, Room.Fence, Room.BehindFenceFailure, "Jít k plotu"));
            _map.Add(new Connection(33, Room.Fence, Room.Yard, "Vrátit se na nádvoří"));
            _map.Add(new Connection(34, Room.BehindFenceFailure, Room.Prison, "Hrát znovu"));
            _map.Add(new Connection(35, Room.Hall, Room.DiningRoom, "Jít do jídelny"));
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