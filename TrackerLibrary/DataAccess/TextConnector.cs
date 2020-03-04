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
        // TODO: csv 대신 json으로 한 파일에 몰아넣는 방안
        private const string PRIZE_FILE = "PrizeModels.csv";
        private const string PERSON_FILE = "PersonModels.csv";
        private const string TEAM_FILE = "TeamModels.csv";
        private const string TOURNAMENT_FILE = "TournamentModels.csv";
        private const string MATCHUP_FILE = "MatchupModels.csv";
        private const string MATCHUP_ENTRY_FILE = "MatchupEntryModels.csv";

        public PrizeModel CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = PRIZE_FILE.FullFilePath().LoadFile().ConvertToPrizeModels();
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            prizes.Add(model);
            prizes.SaveToPrizeFile(PRIZE_FILE);

            return model;
        }

        public PersonModel CreatePerson(PersonModel model)
        {
            List<PersonModel> persons = PERSON_FILE.FullFilePath().LoadFile().ConvertToPersonModels();
            int currentId = 1;

            if (persons.Count > 0)
            {
                currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            persons.Add(model);
            persons.SaveToPersonFile(PERSON_FILE);

            return model;
        }

        public List<PersonModel> GetPerson_All()
        {
            return PERSON_FILE.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TEAM_FILE.FullFilePath().LoadFile().ConvertToTeamModels(PERSON_FILE);
            int currentId = 1;

            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;

            teams.Add(model);
            teams.SaveToTeamFile(TEAM_FILE);

            return model;
        }

        public List<TeamModel> GetTeam_All()
        {
            return TEAM_FILE.FullFilePath().LoadFile().ConvertToTeamModels(PERSON_FILE);
        }

        public void CreateTournament(TournamentModel model)
        {
            List<TournamentModel> tournaments = TOURNAMENT_FILE.FullFilePath().LoadFile().ConvertToTournamentModels(TEAM_FILE, PERSON_FILE, PRIZE_FILE);

            int currentId = 1;

            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            model.SaveRoundsToFile(MATCHUP_FILE, MATCHUP_ENTRY_FILE);
            tournaments.Add(model);
            tournaments.SaveToTournamentFile(TOURNAMENT_FILE);
        }

        public List<TournamentModel> GetTournament_All()
        {
            return TOURNAMENT_FILE.FullFilePath().LoadFile().ConvertToTournamentModels(TEAM_FILE, PERSON_FILE, PRIZE_FILE);
        }

        public void UpdateMatchup(MatchupModel model)
        {
            model.UpdateMatchuptToFile();
        }
    }
}
