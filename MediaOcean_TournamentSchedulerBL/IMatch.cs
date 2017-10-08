using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaOcean_TournamentSchedulerBL
{
    public interface IMatch
    {
        DateTime matchDate { get; set; }

        ITeam HostTeam { get; set; }

        ITeam GuestTeam { get; set; }
    }
}
