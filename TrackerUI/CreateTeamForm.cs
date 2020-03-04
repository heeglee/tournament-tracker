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
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = GlobalConfig.Connection.GetPerson_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
        ITeamRequester callingForm;

        public CreateTeamForm(ITeamRequester caller)
        {
            InitializeComponent();
            WireUpLists();

            callingForm = caller;
        }


        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = null;
            teamMembersListBox.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "PersonTitle";

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "PersonTitle";
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel model = new PersonModel(nameValue.Text, emailValue.Text, phoneValue.Text);

                GlobalConfig.Connection.CreatePerson(model);

                nameValue.Text = "";
                emailValue.Text = "";
                phoneValue.Text = "";

                // TODO: think this is not a safe and confidential way
                availableTeamMembers.Add(model);
                WireUpLists();
            }
            else
            {
                MessageBox.Show("모든 필드를 입력해야 합니다.");
            }
        }

        private bool ValidateForm()
        {
            if (nameValue.Text.Length == 0 || emailValue.Text.Length == 0 || phoneValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel model = (PersonModel)selectTeamMemberDropDown.SelectedItem;

            if (model != null)
            {
                availableTeamMembers.Remove(model);
                selectedTeamMembers.Add(model);
            }

            WireUpLists();
        }

        private void deleteTeamMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel model = (PersonModel)teamMembersListBox.SelectedItem;

            if (model != null)
            {
                selectedTeamMembers.Remove(model);
                availableTeamMembers.Add(model);
            }

            WireUpLists();
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel model = new TeamModel();

            model.TeamName = teamNameValue.Text;
            model.TeamMembers = selectedTeamMembers;

            GlobalConfig.Connection.CreateTeam(model);
            callingForm.TeamComplete(model);

            MessageBox.Show("팀 생성 완료.");
            this.Close();
        }
    }
}
