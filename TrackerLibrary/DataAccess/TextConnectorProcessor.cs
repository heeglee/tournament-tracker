using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextHelpers
{
    public static class TextConnectorProcessor
    {
        // * Load the text file
        // * Convert the text to List<PrizeModel>
        // Find the max ID
        // Add the new record with the new ID (max + 1)
        // Convert the prizes to list<string>
        // Save the list<string> to the text file

        public static string FullFilePath(this string fileName) // PrizeModels.csv
        {
            // D:\workspace\TournamentTracker\PrizeModels.csv
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeModel> ConvertToPrizeModels(this List<string> lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeModel model = new PrizeModel();
                model.Id = int.Parse(cols[0]);
                model.PlaceNumber = int.Parse(cols[1]);
                model.PlaceName = cols[2];
                model.PrizeAmount = decimal.Parse(cols[3]);
                model.PrizePercentage = float.Parse(cols[4]);

                output.Add(model);
            }

            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeModel model in models)
            {
                lines.Add($"{ model.Id },{ model.PlaceNumber },{ model.PlaceName },{ model.PrizeAmount },{ model.PrizePercentage }");
            }

            // TODO: make path if not exists
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static List<PersonModel> ConvertToPersonModels(this List<string> lines)
        {
            List<PersonModel> output = new List<PersonModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PersonModel model = new PersonModel();
                model.Id = int.Parse(cols[0]);
                model.Name = cols[1];
                model.EmailAddress = cols[2];
                model.PhoneNumber = cols[3];

                output.Add(model);
            }

            return output;
        }

        public static void SaveToPersonFile(this List<PersonModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonModel model in models)
            {
                lines.Add($"{ model.Id },{ model.Name },{ model.EmailAddress },{ model.PhoneNumber }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
        // TODO: 제너릭으로 해결할 수 있지 않을까? 제너릭을 쓰려면 모든 프로퍼티를 나열할 방법을 고안해야 함.

        public static List<TeamModel> ConvertToTeamModels(this List<string> lines, string personFileName)
        {
            // id, team name, list of ids separated by the pipe
            // ex) 1, SKT, 1|2|3
            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> person = personFileName.FullFilePath().LoadFile().ConvertToPersonModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamModel model = new TeamModel();
                model.Id = int.Parse(cols[0]);
                model.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');
                
                foreach (string id in personIds)
                {
                    int idNum = 0;
                    
                    if (int.TryParse(id, out idNum))
                    {
                        model.TeamMembers.Add(person.Where(x => x.Id == idNum).First());
                    }
                }

                output.Add(model);
            }

            return output;
        }

        public static void SaveToTeamFile(this List<TeamModel> models, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamModel model in models)
            {
                lines.Add($"{ model.Id },{ model.TeamName },{ model.TeamMembers.ConvertPeopleListToString() }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        private static string ConvertPeopleListToString(this List<PersonModel> person)
        {
            string output = "";
            if (person.Count == 0) return output;

            foreach (PersonModel p in person)
            {
                output += $"{ p.Id }|";
            }

            return output.Substring(0, output.Length - 1);
        }

        public static List<TournamentModel> ConvertToTournamentModels(this List<string> lines, string teamFileName, string personFileName, string prizeFileName)
        {
            // BRACKETS: A list of entered teams, A list of prizes, lists of matchup models
            // 0  1              2        3          4          5
            // id,TournamentName,EntryFee,(id|id|id),(id|id|id),(id^id^id|id^id^id|id^id^id)

            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeamModels(personFileName);
            List<PrizeModel> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrizeModels();
            List<MatchupModel> matchups = GlobalConfig.MATCHUP_FILE.FullFilePath().LoadFile().ConvertToMatchupModels();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                string[] teamIds, prizeIds;
                
                TournamentModel tournament = new TournamentModel();
                tournament.Id = int.Parse(cols[0]);
                tournament.TournamentName = cols[1];
                tournament.EntryFee = decimal.Parse(cols[2]);

                teamIds = cols[3].Split('|');

                foreach (string id in teamIds)
                {
                    tournament.EnteredTeams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                }

                if (cols[4].Length > 0)
                {
                    prizeIds = cols[4].Split('|');

                    foreach (string id in prizeIds)
                    {
                        tournament.TournamentPrizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                    } 
                }

                // Capture Rounds Information
                string[] rounds = cols[5].Split('|');

                foreach (string round in rounds)
                {
                    string[] msText = round.Split('^');
                    List<MatchupModel> ms = new List<MatchupModel>();

                    foreach (string matchupModelTextId in msText)
                    {
                        ms.Add(matchups.Where(x => x.Id == int.Parse(matchupModelTextId)).First());
                    }

                    tournament.TournamentRounds.Add(ms);
                }

                output.Add(tournament);
            }

            return output;
        }

        public static void SaveToTournamentFile(this List<TournamentModel> models, string fileName)
        {
            // Rounds: id^id^id|id^id^id|id^id^id
            List<string> lines = new List<string>();

            foreach (TournamentModel tournament in models)
            {
                lines.Add($"{ tournament.Id },{ tournament.TournamentName },{ tournament.EntryFee },{ tournament.EnteredTeams.ConvertTeamListToString() },{ tournament.TournamentPrizes.ConvertPrizeListToString() },{ tournament.TournamentRounds.ConvertRoundListToString() }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        private static string ConvertTeamListToString(this List<TeamModel> teams)
        {
            string output = "";
            if (teams.Count == 0) return output;

            foreach (TeamModel team in teams)
            {
                output += $"{ team.Id }|";
            }

            return output.Substring(0, output.Length - 1);
        }

        private static string ConvertPrizeListToString(this List<PrizeModel> prizes)
        {
            string output = "";
            if (prizes.Count == 0) return output;

            foreach (PrizeModel prize in prizes)
            {
                output += $"{ prize.Id }|";
            }

            return output.Substring(0, output.Length - 1);
        }

        private static string ConvertRoundListToString(this List<List<MatchupModel>> rounds)
        {
            string output = "";
            if (rounds.Count == 0) return output;

            foreach (List<MatchupModel> matchups in rounds)
            {
                output += $"{ matchups.ConvertMatchupListToString() }|";
            }

            return output.Substring(0, output.Length - 1);
        }

        private static string ConvertMatchupListToString(this List<MatchupModel> matchups)
        {
            string output = "";
            if (matchups.Count == 0) return output;

            foreach (MatchupModel matchup in matchups)
            {
                output += $"{ matchup.Id }^";
            }

            return output.Substring(0, output.Length - 1);
        }

        private static string ConvertMatchupEntryListToString(this List<MatchupEntryModel> entries)
        {
            string output = "";
            if (entries.Count == 0) return output;

            foreach (MatchupEntryModel entry in entries)
            {
                output += $"{ entry.Id }|";
            }

            return output.Substring(0, output.Length - 1);
        }

        public static void SaveRoundsToFile(this TournamentModel model, string matchupFile, string matchupEntryFile)
        {
            // Loop through each Round
            // Loop through each Matchup
            // Get the id for the new matchup and save the record
            // Loop through each Entry, get the id, and save it

            foreach (List<MatchupModel> round in model.TournamentRounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    // Load all of the matchups from file
                    // Get the top id and add one
                    // Store the id
                    // Save the matchup record

                    matchup.SaveMatchupToFile(matchupFile, matchupEntryFile);
                }
            }
        }

        // TODO: naming var: matchup and matchups
        public static void SaveMatchupToFile(this MatchupModel matchup, string matchupFile, string matchupEntryFile)
        {
            List<MatchupModel> matchups = GlobalConfig.MATCHUP_FILE.FullFilePath().LoadFile().ConvertToMatchupModels();
            List<string> lines = new List<string>();

            int currentId = 1;

            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }

            matchup.Id = currentId;
            matchups.Add(matchup);

            foreach (MatchupEntryModel entry in matchup.Entries)
            {
                entry.SaveEntryToFile(matchupEntryFile);
            }

            foreach (MatchupModel m in matchups)
            {
                string winner = m.Winner != null ? m.Winner.Id.ToString() : "";

                lines.Add($"{ m.Id },{ ConvertMatchupEntryListToString(m.Entries) },{ winner },{ m.MatchupRound }");
            }

            File.WriteAllLines(GlobalConfig.MATCHUP_FILE.FullFilePath(), lines);
        }

        public static void UpdateMatchuptToFile(this MatchupModel matchup)
        {
            List<MatchupModel> matchups = GlobalConfig.MATCHUP_FILE.FullFilePath().LoadFile().ConvertToMatchupModels();
            List<string> lines = new List<string>();
            MatchupModel oldMatchup = new MatchupModel();

            // TODO: if this picks just one matchup, can I replace it with a Where() method?
            foreach (MatchupModel m in matchups)
            {
                if (m.Id == matchup.Id)
                {
                    oldMatchup = m;
                }
            }

            matchups.Remove(oldMatchup);
            matchups.Add(matchup);

            foreach (MatchupEntryModel entry in matchup.Entries)
            {
                entry.UpdateEntryToFile();
            }

            foreach (MatchupModel m in matchups)
            {
                string winner = m.Winner != null ? m.Winner.Id.ToString() : "";

                lines.Add($"{ m.Id },{ ConvertMatchupEntryListToString(m.Entries) },{ winner },{ m.MatchupRound }");
            }

            File.WriteAllLines(GlobalConfig.MATCHUP_FILE.FullFilePath(), lines);
        }

        public static void SaveEntryToFile(this MatchupEntryModel entry, string matchupEntryFile)
        {
            List<MatchupEntryModel> entries = GlobalConfig.MATCHUP_ENTRY_FILE.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
            List<string> lines = new List<string>();

            int currentId = 1;

            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }

            entry.Id = currentId;
            entries.Add(entry);

            foreach (MatchupEntryModel e in entries)
            {
                string parent = e.ParentMatchup != null ? e.ParentMatchup.Id.ToString() : "";
                string teamCompeting = e.TeamCompeting != null ? e.TeamCompeting.Id.ToString() : "";

                lines.Add($"{ e.Id },{ teamCompeting },{ e.Score },{ parent }");
            }

            File.WriteAllLines(GlobalConfig.MATCHUP_ENTRY_FILE.FullFilePath(), lines);
        }

        public static void UpdateEntryToFile(this MatchupEntryModel entry)
        {
            List<MatchupEntryModel> entries = GlobalConfig.MATCHUP_ENTRY_FILE.FullFilePath().LoadFile().ConvertToMatchupEntryModels();
            List<string> lines = new List<string>();
            MatchupEntryModel oldEntry = new MatchupEntryModel();

            foreach (MatchupEntryModel e in entries)
            {
                if (e.Id == entry.Id) oldEntry = e;
            }

            entries.Remove(oldEntry);
            entries.Add(entry);

            foreach (MatchupEntryModel e in entries)
            {
                string parent = e.ParentMatchup != null ? e.ParentMatchup.Id.ToString() : "";
                string teamCompeting = e.TeamCompeting != null ? e.TeamCompeting.Id.ToString() : "";

                lines.Add($"{ e.Id },{ teamCompeting },{ e.Score },{ parent }");
            }

            File.WriteAllLines(GlobalConfig.MATCHUP_ENTRY_FILE.FullFilePath(), lines);
        }

        public static List<MatchupEntryModel> ConvertToMatchupEntryModels(this List<string> input)
        {
            // id = 0, TeamCompeting = 1, Score = 2, ParentMatchup = 3
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();

            foreach (string line in input)
            {
                string[] cols = line.Split(',');

                MatchupEntryModel matchupEntry = new MatchupEntryModel();
                matchupEntry.Id = int.Parse(cols[0]);
                matchupEntry.TeamCompeting = cols[1].Length == 0 ? null : LookupTeamById(int.Parse(cols[1]));
                matchupEntry.Score = double.Parse(cols[2]);
                //matchupEntry.ParentMatchup = LookupMatchupById(int.Parse(cols[3])); // CHK
                int parentId = 0;
                matchupEntry.ParentMatchup = int.TryParse(cols[3], out parentId) ? LookupMatchupById(parentId) : null;

                output.Add(matchupEntry);
            }

            return output;
        }

        private static List<MatchupEntryModel> ConvertStringToMatchupEntryModels(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntryModel> output;
            List<string> entries = GlobalConfig.MATCHUP_ENTRY_FILE.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();

            foreach (string id in ids)
            {
                foreach (string entry in entries)
                {
                    string[] cols = entry.Split(',');

                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }

            output = matchingEntries.ConvertToMatchupEntryModels();

            return output;
        }

        private static TeamModel LookupTeamById(int id)
        {
            List<string> teams = GlobalConfig.TEAM_FILE.FullFilePath().LoadFile();

            foreach (string team in teams)
            {
                string[] cols = team.Split(',');

                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeamModels(GlobalConfig.PERSON_FILE).First();
                }
            }

            return null;
        }

        private static MatchupModel LookupMatchupById(int id)
        {
            List<string> matchups = GlobalConfig.MATCHUP_FILE.FullFilePath().LoadFile();

            foreach (string matchup in matchups)
            {
                string[] cols = matchup.Split(',');

                if (cols[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(matchup);

                    return matchingMatchups.ConvertToMatchupModels().First();
                }
            }

            return null;
        }

        public static List<MatchupModel> ConvertToMatchupModels(this List<string> lines)
        {
            // id = 0, entries = 1(pipe delimited by id), winner = 2, matchupRound = 3
            List<MatchupModel> output = new List<MatchupModel>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                MatchupModel model = new MatchupModel();
                model.Id = int.Parse(cols[0]);
                model.Entries = ConvertStringToMatchupEntryModels(cols[1]);
                if (cols[2].Length == 0)
                {
                    model.Winner = null;
                }
                else
                {
                    model.Winner = cols[2].Length != 0 ? LookupTeamById(int.Parse(cols[2])) : null;
                }

                model.MatchupRound = int.Parse(cols[3]);

                output.Add(model);
            }

            return output;
        }

    }
}
