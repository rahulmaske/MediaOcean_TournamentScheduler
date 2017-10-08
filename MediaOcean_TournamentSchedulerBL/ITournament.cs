using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaOcean_TournamentSchedulerBL
{
    public interface ITournament
    {        
        void AddMatch(IMatch newMatch);

        List<IMatch> GetAllMatches();
    }
}
