using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaOcean_TournamentSchedulerBL
{
    public class Scheduler
    {
        public string GetTournamentSchedule(int noOfTeams)
        {
            int[,] listOfMatches = GetAllMatches(noOfTeams);

            ITournament kbTournament = new KabaddiTournament();

            List<ITeam> teams = new List<ITeam>();
            for (int i = 0; i < noOfTeams; i++)
            {
                teams.Add(new KabaddiTeam("Team-" + (i + 1), "Ground-" + (i + 1)));
            }

            for (int i = 0; i < noOfTeams; i++)
            {
                for (int j = 0; j < noOfTeams - 1; j++)
                {
                    //outputString.Append(i + 1 + " vs " + temp[i, j]);
                    //outputString.Append(Environment.NewLine);
                    IMatch matchObj = new KabaddiMatch();

                    foreach (ITeam singleTeam in teams)
                    {
                        if (singleTeam.TeamName.Equals("Team-" + (i + 1)))
                            matchObj.HostTeam = singleTeam;
                        if (singleTeam.TeamName.Equals("Team-" + listOfMatches[i, j]))
                            matchObj.GuestTeam = singleTeam;
                    }

                    kbTournament.AddMatch(matchObj);
                }
            }

            OptimizeTournamentSchedule(kbTournament);
            StringBuilder outputString = new StringBuilder();

            foreach (IMatch currentMatch in kbTournament.GetAllMatches())
            {
                outputString.Append(currentMatch.HostTeam.TeamName + " -vs- " + currentMatch.GuestTeam.TeamName);
                outputString.Append("\t\tDate: " + currentMatch.matchDate.ToShortDateString() + "\t" + "Ground: " + currentMatch.HostTeam.HomeGround);
                outputString.Append(Environment.NewLine);
                
                outputString.Append(Environment.NewLine);
            }
            

            return outputString.ToString();
        }
        private int[,] GetAllMatches(int noOfTeams)
        {
            int k;
            int[,] calendar = new int[noOfTeams, noOfTeams - 1];

            for (int l = 0; l < noOfTeams - 1; l++)
            {

                k = noOfTeams - l;
                for (int c = 0; c < noOfTeams - 1; c++)
                {

                    if (l + 1 == k)
                    {
                        calendar[l, c] = noOfTeams;
                    }
                    else {
                        calendar[l, c] = k;

                    }
                    k--;
                    if (k == 0)
                    {
                        k = noOfTeams - 1;
                    }
                }

            }

            for (int c = 0; c < noOfTeams - 1; c++)
            {
                for (int l = 0; l < noOfTeams - 1; l++)
                {
                    if (calendar[l, c] == noOfTeams)
                    {
                        calendar[noOfTeams - 1, l] = l + 1;
                    }
                }
            }

            return calendar;
        }

        private void OptimizeTournamentSchedule(ITournament Tournament)
        {
            List<IMatch> tournamentMatches = Tournament.GetAllMatches();
            for (int i = 0; i < tournamentMatches.Count; i++)
            {
                if (i < tournamentMatches.Count - 1)
                {
                    if (tournamentMatches[i].HostTeam.TeamName.Equals(tournamentMatches[i + 1].HostTeam.TeamName)   ||
                        tournamentMatches[i].HostTeam.TeamName.Equals(tournamentMatches[i + 1].GuestTeam.TeamName)  ||
                        tournamentMatches[i].GuestTeam.TeamName.Equals(tournamentMatches[i + 1].HostTeam.TeamName)  ||
                        tournamentMatches[i].GuestTeam.TeamName.Equals(tournamentMatches[i + 1].GuestTeam.TeamName))
                    {
                        for (int j = i + 2; j < tournamentMatches.Count; j++)
                        {
                            if (tournamentMatches[i].HostTeam.TeamName.Equals(tournamentMatches[j].HostTeam.TeamName)   ||
                                tournamentMatches[i].HostTeam.TeamName.Equals(tournamentMatches[j].GuestTeam.TeamName)  ||
                                tournamentMatches[i].GuestTeam.TeamName.Equals(tournamentMatches[j].HostTeam.TeamName)  ||
                                tournamentMatches[i].GuestTeam.TeamName.Equals(tournamentMatches[j].GuestTeam.TeamName))
                            {
                                continue;
                            }
                            else
                            {
                                IMatch tempObj = tournamentMatches[i + 1];
                                tournamentMatches[i + 1] = tournamentMatches[j];
                                tournamentMatches[j] = tempObj;
                                break;
                            }                                              
                        }
                    }
                }
            }
        }
    }
}
