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
    public partial class TournamentDashboardForm : Form, ITournamentRequester
    {
        List<TournamentModel> tournaments;

        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void WireUpLists()
        {
            tournaments = GlobalConfig.Connection.GetTournament_All();
            loadExistingTournamentDropDown.DataSource = tournaments;
            loadExistingTournamentDropDown.DisplayMember = "TournamentName";
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm frm = new CreateTournamentForm(this);
            frm.ShowDialog();
        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)loadExistingTournamentDropDown.SelectedItem;
            TournamentViewerForm frm = new TournamentViewerForm(tm);

            frm.ShowDialog();
        }

        public void TournamentComplete(TournamentModel model)
        {
            WireUpLists();
        }
    }
}
