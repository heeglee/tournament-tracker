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
    public partial class TournamentViewerForm : Form
    {
        private TournamentModel tournament;
        BindingList<int> rounds = new BindingList<int>();
        BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();

        public TournamentViewerForm(TournamentModel tournamentModel)
        {
            InitializeComponent();

            tournament = tournamentModel;

            WireUpRoundsLists();
            WireUpMatchupsLists();

            LoadFormData();
            LoadRounds();
        }

        private void LoadFormData()
        {
            tournamentName.Text = tournament.TournamentName;
        }

        private void WireUpRoundsLists()
        {
            roundDropDown.DataSource = rounds;
        }

        private void WireUpMatchupsLists()
        {
            matchupListBox.DataSource = selectedMatchups;
            matchupListBox.DisplayMember = "DisplayName";
        }

        private void LoadRounds()
        {
            rounds = new BindingList<int>();

            rounds.Add(1);
            int currentRound = 1;

            foreach (List<MatchupModel> matchups in tournament.TournamentRounds)
            {
                if (matchups.First().MatchupRound > currentRound)
                {
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }

            //roundsBinding.ResetBindings(false);
            WireUpRoundsLists();
        }

        private void roundDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchups();
        }
        private void LoadMatchups()
        {
            int round = (int)roundDropDown.SelectedItem;

            foreach (List<MatchupModel> matchups in tournament.TournamentRounds)
            {
                if (matchups.First().MatchupRound == round)
                {
                    selectedMatchups = new BindingList<MatchupModel>();

                    foreach (MatchupModel m in matchups)
                    {
                        //CHK: Unplayed Only Checkbox Working
                        if (m.Winner == null || !unplayedOnlyCheckbox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                    }
                }
            }

            WireUpMatchupsLists();

            // CHK
            DisplayMatchupInfo();
        }

        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);

            teamOneName.Visible = isVisible;
            teamOneScoreLabel.Visible = isVisible;
            teamOneScoreValue.Visible = isVisible;
            teamTwoName.Visible = isVisible;
            teamTwoScoreLabel.Visible = isVisible;
            teamTwoScoreValue.Visible = isVisible;
            vsLabel.Visible = isVisible;
            scoreButton.Visible = isVisible;
        }

        // TODO: 이게 최선입니까?
        private void LoadMatchup()
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        teamOneName.Text = m.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = m.Entries[0].Score.ToString();

                        teamTwoName.Text = "<bye>";
                        teamTwoScoreValue.Text = "0";
                    }
                    else
                    {
                        teamOneName.Text = "Not Yet Set";
                        teamOneScoreValue.Text = "";
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        teamTwoName.Text = m.Entries[1].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = m.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoName.Text = "Not Yet Set";
                        teamTwoScoreValue.Text = "";
                    }
                }
            }
        }

        private void matchupListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup();
        }

        private void unplayedOnlyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            LoadMatchups();
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            MatchupModel m = (MatchupModel)matchupListBox.SelectedItem;

            double teamOneScore = 0;
            double teamTwoScore = 0;

            if (!double.TryParse(teamOneScoreValue.Text, out teamOneScore) || !double.TryParse(teamTwoScoreValue.Text, out teamTwoScore))
            {
                MessageBox.Show("Please enter a valid score value.");
                return;
            }

            if (teamOneScore == teamTwoScore)
            {
                MessageBox.Show("Matchup must have a winner team.");
                return;
            }

            for (int i = 0; i < m.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (m.Entries[0].TeamCompeting != null)
                    {
                        m.Entries[0].Score = teamOneScore;
                    }
                }

                if (i == 1)
                {
                    if (m.Entries[1].TeamCompeting != null)
                    {
                        m.Entries[1].Score = teamTwoScore;
                    }
                }
            }

            if (teamOneScore > teamTwoScore)
            {
                // team one wins
                m.Winner = m.Entries[0].TeamCompeting;
            }
            else if (teamTwoScore > teamOneScore)
            {
                // team two wins
                m.Winner = m.Entries[1].TeamCompeting;
            }

            foreach (List<MatchupModel> round in tournament.TournamentRounds)
            {
                foreach (MatchupModel rm in round)
                {
                    foreach (MatchupEntryModel rme in rm.Entries)
                    {
                        if (rme.ParentMatchup != null && rme.ParentMatchup.Id == m.Id)
                        {
                            rme.TeamCompeting = m.Winner;
                            GlobalConfig.Connection.UpdateMatchup(rm);
                        }
                    }
                }
            }

            GlobalConfig.Connection.UpdateMatchup(m);
            LoadMatchups();

            
        }
    }
}
