using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaOcean_TournamentSchedulerBL
{
    public interface ITeam
    {
        string TeamName { get; set; }

        string HomeGround { get; set; }
    }
}
