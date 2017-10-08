using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaOcean_TournamentSchedulerBL
{
    public class KabaddiTournament : ITournament
    {
        List<IMatch> tournamentMatches;
        public void AddMatch(IMatch newMatch)
        {
            if(tournamentMatches == null)
                tournamentMatches = new List<IMatch>();

            tournamentMatches.Add(newMatch);
        }

        public List<IMatch> GetAllMatches()
        {
            return tournamentMatches;
        }
    }
}
