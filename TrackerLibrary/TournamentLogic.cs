using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            model.TournamentRounds.Add(CreateFirstRound(byes, randomizedTeams));

            CreateOtherRounds(model, rounds);
            UpdateTournamentResults(model);
        }

        public static void UpdateTournamentResults(TournamentModel model)
        {
            List<MatchupModel> toScore = new List<MatchupModel>();
            //int startingRound = model.CheckCurrentRound();

            foreach (List<MatchupModel> round in model.TournamentRounds)
            {
                foreach (MatchupModel rm in round)
                {
                    if (rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

            MarkWinnerInMatchups(toScore);
            AdvanceWinners(toScore, model);

            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));
            //int endingRound = model.CheckCurrentRound();

            //if (endingRound > startingRound)
            //{
                // Round end events
            //}
        }

        private static void MarkWinnerInMatchups(List<MatchupModel> models)
        {
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            foreach (MatchupModel m in models)
            {
                // Checks for bye week entry
                if (m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }

                if (m.Entries[0].Score > m.Entries[1].Score)
                {
                    m.Winner = greaterWins == "1" ? m.Entries[0].TeamCompeting : m.Entries[1].TeamCompeting;
                }
                else if (m.Entries[0].Score < m.Entries[1].Score)
                {
                    m.Winner = greaterWins == "1" ? m.Entries[1].TeamCompeting : m.Entries[0].TeamCompeting;
                }
                else
                {
                    throw new Exception("Matchup must have a winner team.");
                }
            }
        }

        //private static int CheckCurrentRound(this TournamentModel model)
        //{
        //    int output = 1;

        //    foreach (List<MatchupModel> round in model.TournamentRounds)
        //    {
        //        if (round.All(x => x.Winner != null))
        //        {
        //            output++;
        //        }
        //    }

        //    return output;
        //}

        private static void AdvanceWinners(List<MatchupModel> models, TournamentModel tournament)
        {
            foreach (MatchupModel m in models)
            {
                foreach (List<MatchupModel> round in tournament.TournamentRounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntryModel rme in rm.Entries)
                        {
                            if (rme.ParentMatchup?.Id == m.Id)
                            {
                                rme.TeamCompeting = m.Winner;
                                GlobalConfig.Connection.UpdateMatchup(rm);
                            }
                        }
                    }
                }
            }
        }

        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRound = model.TournamentRounds[0];
            List<MatchupModel> currentRound = new List<MatchupModel>();
            MatchupModel currentMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach (MatchupModel matchup in previousRound)
                {
                    currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = matchup });

                    if (currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.MatchupRound = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new MatchupModel();
                    }
                }

                model.TournamentRounds.Add(currentRound);
                previousRound = currentRound;

                currentRound = new List<MatchupModel>();
                round++;
            }
        }

        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel currentMatchup = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                currentMatchup.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                if (byes > 0 || currentMatchup.Entries.Count > 1)
                {
                    currentMatchup.MatchupRound = 1;
                    output.Add(currentMatchup);
                    currentMatchup = new MatchupModel();

                    if (byes > 0)
                    {
                        byes--;
                    }
                }
            }

            return output;
        }

        private static int NumberOfByes(int rounds, int numberOfTeams)
        {
            int totalTeams = 1;

            for (int i = 0; i < rounds; i++)
            {
                totalTeams *= 2;
            }

            return totalTeams - numberOfTeams;
        }

        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;

            while (val < teamCount)
            {
                output++;
                val *= 2;
            }

            return output;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}
