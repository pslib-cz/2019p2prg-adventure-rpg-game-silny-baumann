using RPGfaktPRG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGfaktPRG.Services
{
    public interface ILocationProvider
    {
        bool ExistsLocation(int id);
        Location GetLocation(int id);
        List<Connection> GetConnectionsFrom(int id);
        List<Connection> GetConnectionsTo(int id);
        bool IsNavigationLegitimate(int from, int to, GameState state);
    }
}
