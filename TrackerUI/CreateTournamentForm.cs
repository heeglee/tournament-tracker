using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            selectTeamDropDown.DataSource = null;
            tournamentTeamsListBox.DataSource = null;
            prizesListBox.DataSource = null;

            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel model = (TeamModel)selectTeamDropDown.SelectedItem;

            if (model != null)
            {
                availableTeams.Remove(model);
                selectedTeams.Add(model);

                WireUpLists();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            // Call the CreatePrizeForm
            CreatePrizeForm form = new CreatePrizeForm(this);
            form.ShowDialog();
        }

        public void PrizeComplete(PrizeModel model)
        {
            selectedPrizes.Add(model);
            WireUpLists();
        }

        public void TeamComplete(TeamModel model)
        {
            availableTeams.Add(model);
            WireUpLists();
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            CreateTeamForm form = new CreateTeamForm(this);
            form.ShowDialog();
        }

        private void removeSelectedPlayerButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)tournamentTeamsListBox.SelectedItem;

            if (team != null)
            {
                selectedTeams.Remove(team);
                availableTeams.Add(team);

                WireUpLists();
            }
        }

        private void removePrizeButton_Click(object sender, EventArgs e)
        {
            PrizeModel prize = (PrizeModel)prizesListBox.SelectedItem;

            if (prize != null)
            {
                // TODO: Wire prizesListBox w/ DB
                selectedPrizes.Remove(prize);
                WireUpLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            decimal entryFee = 0;

            // CHK: entryFee out
            if (!decimal.TryParse(entryFeeValue.Text, out entryFee))
            {
                MessageBox.Show("You need to enter a valid entry fee value.");
                return;
            }

            // Create our tournament model
            TournamentModel tournament = new TournamentModel();

            tournament.TournamentName = tournamentNameValue.Text;
            tournament.EntryFee = entryFee;
            tournament.TournamentPrizes = selectedPrizes;
            tournament.EnteredTeams = selectedTeams;

            // TODO: Wire our matchups
            TournamentLogic.CreateRounds(tournament);
            
            // Create Tournament Entry
            // Create all of the prizes entries
            // Create all of team entries
            GlobalConfig.Connection.CreateTournament(tournament);

            // Create our matchups
        }
    }
}
