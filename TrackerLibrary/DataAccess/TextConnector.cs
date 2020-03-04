using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        public void CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = GlobalConfig.PRIZE_FILE.FullFilePath().LoadFile().ConvertToPrizeModels();
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            prizes.Add(model);
            prizes.SaveToPrizeFile();
        }

        public void CreatePerson(PersonModel model)
        {
            List<PersonModel> persons = GlobalConfig.PERSON_FILE.FullFilePath().LoadFile().ConvertToPersonModels();
            int currentId = 1;

            if (persons.Count > 0)
            {
                currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            persons.Add(model);
            persons.SaveToPersonFile();
        }

        public List<PersonModel> GetPerson_All()
        {
            return GlobalConfig.PERSON_FILE.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public void CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = GlobalConfig.TEAM_FILE.FullFilePath().LoadFile().ConvertToTeamModels();
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            teams.Add(model);
            teams.SaveToTeamFile();
        }

        public List<TeamModel> GetTeam_All()
        {
            return GlobalConfig.TEAM_FILE.FullFilePath().LoadFile().ConvertToTeamModels();
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = GlobalConfig.TOURNAMENT_FILE.FullFilePath().LoadFile().ConvertToTournamentModels();

            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            model.SaveRoundsToFile();
            tournaments.Add(model);
            tournaments.SaveToTournamentFile();
            TournamentLogic.UpdateTournamentResults(model);
        }

        public List<TournamentModel> GetTournament_All()
        {
            return GlobalConfig.TOURNAMENT_FILE.FullFilePath().LoadFile().ConvertToTournamentModels();
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchuptToFile();
        }
    }
}
