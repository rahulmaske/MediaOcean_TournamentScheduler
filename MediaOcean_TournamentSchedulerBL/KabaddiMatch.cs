using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaOcean_TournamentSchedulerBL
{
    public class KabaddiMatch : IMatch
    {
        public DateTime matchDate { get; set; }

        public ITeam HostTeam { get; set; }

        public ITeam GuestTeam { get; set; }
    }
}
