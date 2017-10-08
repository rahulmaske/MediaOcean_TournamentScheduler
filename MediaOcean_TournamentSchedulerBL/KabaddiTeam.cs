using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaOcean_TournamentSchedulerBL
{
    public class KabaddiTeam : ITeam
    {
        public KabaddiTeam(string inputTeamName, string inputHomeGround)
        {
            TeamName = inputTeamName;
            HomeGround = inputHomeGround;

        }
        public string TeamName { get; set; }

        public string HomeGround { get; set; }
    }
}
