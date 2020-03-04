using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        #region ############# CONSTS
        public const string PRIZE_FILE = "PrizeModels.csv";
        public const string PERSON_FILE = "PersonModels.csv";
        public const string TEAM_FILE = "TeamModels.csv";
        public const string TOURNAMENT_FILE = "TournamentModels.csv";
        public const string MATCHUP_FILE = "MatchupModels.csv";
        public const string MATCHUP_ENTRY_FILE = "MatchupEntryModels.csv";
        #endregion

        #region ######### PROPERTIES
        public static IDataConnection Connection { get; private set; }
        #endregion

        #region ############ METHODS
        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                TextConnector text = new TextConnector();
                Connection = text;
            }
        }

        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        #endregion
    }
}
