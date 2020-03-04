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
        ITournamentRequester callingForm;

        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm(ITournamentRequester caller)
        {
            InitializeComponent();
            WireUpLists();

            callingForm = caller;
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
                selectedPrizes.Remove(prize);
                WireUpLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            decimal entryFee = 0;

            if (!decimal.TryParse(entryFeeValue.Text, out entryFee))
            {
                MessageBox.Show("참가비에 올바른 값을 입력해야 합니다.");
                return;
            }

            TournamentModel tournament = new TournamentModel();

            tournament.TournamentName = tournamentNameValue.Text;
            tournament.EntryFee = entryFee;
            tournament.TournamentPrizes = selectedPrizes;
            tournament.EnteredTeams = selectedTeams;

            TournamentLogic.CreateRounds(tournament);
            GlobalConfig.Connection.CreateTournament(tournament);

            callingForm.TournamentComplete(tournament);
            MessageBox.Show("토너먼트 생성 완료.");
            this.Close();
        }
    }
}
