namespace TrackerUI
{
    partial class CreateTournamentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.createTournamentLabel = new System.Windows.Forms.Label();
            this.tournamentNameLabel = new System.Windows.Forms.Label();
            this.tournamentNameValue = new System.Windows.Forms.TextBox();
            this.entryFeeLabel = new System.Windows.Forms.Label();
            this.selectTeamLabel = new System.Windows.Forms.Label();
            this.entryFeeValue = new System.Windows.Forms.TextBox();
            this.selectTeamDropDown = new System.Windows.Forms.ComboBox();
            this.addTeamButton = new System.Windows.Forms.Button();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.teamsAndPlayersLabel = new System.Windows.Forms.Label();
            this.prizesLabel = new System.Windows.Forms.Label();
            this.createTournamentButton = new System.Windows.Forms.Button();
            this.tournamentTeamsListBox = new System.Windows.Forms.ListBox();
            this.prizesListBox = new System.Windows.Forms.ListBox();
            this.removeSelectedPlayerButton = new System.Windows.Forms.Button();
            this.removePrizeButton = new System.Windows.Forms.Button();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createTournamentLabel
            // 
            this.createTournamentLabel.AutoSize = true;
            this.createTournamentLabel.Font = new System.Drawing.Font("나눔고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.createTournamentLabel.Location = new System.Drawing.Point(32, 28);
            this.createTournamentLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createTournamentLabel.Name = "createTournamentLabel";
            this.createTournamentLabel.Size = new System.Drawing.Size(204, 36);
            this.createTournamentLabel.TabIndex = 1;
            this.createTournamentLabel.Text = "토너먼트 생성";
            // 
            // tournamentNameLabel
            // 
            this.tournamentNameLabel.AutoSize = true;
            this.tournamentNameLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tournamentNameLabel.Location = new System.Drawing.Point(34, 97);
            this.tournamentNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.tournamentNameLabel.Name = "tournamentNameLabel";
            this.tournamentNameLabel.Size = new System.Drawing.Size(136, 24);
            this.tournamentNameLabel.TabIndex = 2;
            this.tournamentNameLabel.Text = "토너먼트 이름";
            // 
            // tournamentNameValue
            // 
            this.tournamentNameValue.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tournamentNameValue.Location = new System.Drawing.Point(36, 135);
            this.tournamentNameValue.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.tournamentNameValue.Name = "tournamentNameValue";
            this.tournamentNameValue.Size = new System.Drawing.Size(382, 32);
            this.tournamentNameValue.TabIndex = 3;
            // 
            // entryFeeLabel
            // 
            this.entryFeeLabel.AutoSize = true;
            this.entryFeeLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.entryFeeLabel.Location = new System.Drawing.Point(34, 198);
            this.entryFeeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.entryFeeLabel.Name = "entryFeeLabel";
            this.entryFeeLabel.Size = new System.Drawing.Size(70, 24);
            this.entryFeeLabel.TabIndex = 4;
            this.entryFeeLabel.Text = "참가비";
            // 
            // selectTeamLabel
            // 
            this.selectTeamLabel.AutoSize = true;
            this.selectTeamLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.selectTeamLabel.Location = new System.Drawing.Point(34, 263);
            this.selectTeamLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.selectTeamLabel.Name = "selectTeamLabel";
            this.selectTeamLabel.Size = new System.Drawing.Size(76, 24);
            this.selectTeamLabel.TabIndex = 5;
            this.selectTeamLabel.Text = "팀 선택";
            // 
            // entryFeeValue
            // 
            this.entryFeeValue.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.entryFeeValue.Location = new System.Drawing.Point(114, 195);
            this.entryFeeValue.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.entryFeeValue.Name = "entryFeeValue";
            this.entryFeeValue.Size = new System.Drawing.Size(304, 32);
            this.entryFeeValue.TabIndex = 6;
            // 
            // selectTeamDropDown
            // 
            this.selectTeamDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectTeamDropDown.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.selectTeamDropDown.FormattingEnabled = true;
            this.selectTeamDropDown.Location = new System.Drawing.Point(36, 301);
            this.selectTeamDropDown.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.selectTeamDropDown.Name = "selectTeamDropDown";
            this.selectTeamDropDown.Size = new System.Drawing.Size(382, 32);
            this.selectTeamDropDown.TabIndex = 7;
            // 
            // addTeamButton
            // 
            this.addTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTeamButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addTeamButton.Location = new System.Drawing.Point(36, 355);
            this.addTeamButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.addTeamButton.Name = "addTeamButton";
            this.addTeamButton.Size = new System.Drawing.Size(382, 46);
            this.addTeamButton.TabIndex = 8;
            this.addTeamButton.Text = "팀 등록";
            this.addTeamButton.UseVisualStyleBackColor = true;
            this.addTeamButton.Click += new System.EventHandler(this.addTeamButton_Click);
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPrizeButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.createPrizeButton.Location = new System.Drawing.Point(247, 417);
            this.createPrizeButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(171, 46);
            this.createPrizeButton.TabIndex = 9;
            this.createPrizeButton.Text = "상 등록";
            this.createPrizeButton.UseVisualStyleBackColor = true;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // teamsAndPlayersLabel
            // 
            this.teamsAndPlayersLabel.AutoSize = true;
            this.teamsAndPlayersLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.teamsAndPlayersLabel.Location = new System.Drawing.Point(480, 97);
            this.teamsAndPlayersLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.teamsAndPlayersLabel.Name = "teamsAndPlayersLabel";
            this.teamsAndPlayersLabel.Size = new System.Drawing.Size(76, 24);
            this.teamsAndPlayersLabel.TabIndex = 10;
            this.teamsAndPlayersLabel.Text = "참가 팀";
            // 
            // prizesLabel
            // 
            this.prizesLabel.AutoSize = true;
            this.prizesLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.prizesLabel.Location = new System.Drawing.Point(480, 397);
            this.prizesLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.prizesLabel.Name = "prizesLabel";
            this.prizesLabel.Size = new System.Drawing.Size(76, 24);
            this.prizesLabel.TabIndex = 11;
            this.prizesLabel.Text = "상 목록";
            // 
            // createTournamentButton
            // 
            this.createTournamentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTournamentButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.createTournamentButton.Location = new System.Drawing.Point(36, 484);
            this.createTournamentButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.createTournamentButton.Name = "createTournamentButton";
            this.createTournamentButton.Size = new System.Drawing.Size(382, 150);
            this.createTournamentButton.TabIndex = 12;
            this.createTournamentButton.Text = "토너먼트 생성";
            this.createTournamentButton.UseVisualStyleBackColor = true;
            this.createTournamentButton.Click += new System.EventHandler(this.createTournamentButton_Click);
            // 
            // tournamentTeamsListBox
            // 
            this.tournamentTeamsListBox.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tournamentTeamsListBox.FormattingEnabled = true;
            this.tournamentTeamsListBox.ItemHeight = 24;
            this.tournamentTeamsListBox.Location = new System.Drawing.Point(484, 137);
            this.tournamentTeamsListBox.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.tournamentTeamsListBox.Name = "tournamentTeamsListBox";
            this.tournamentTeamsListBox.Size = new System.Drawing.Size(405, 196);
            this.tournamentTeamsListBox.TabIndex = 13;
            // 
            // prizesListBox
            // 
            this.prizesListBox.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.prizesListBox.FormattingEnabled = true;
            this.prizesListBox.ItemHeight = 24;
            this.prizesListBox.Location = new System.Drawing.Point(484, 438);
            this.prizesListBox.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.prizesListBox.Name = "prizesListBox";
            this.prizesListBox.Size = new System.Drawing.Size(405, 196);
            this.prizesListBox.TabIndex = 14;
            // 
            // removeSelectedPlayerButton
            // 
            this.removeSelectedPlayerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removeSelectedPlayerButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.removeSelectedPlayerButton.Location = new System.Drawing.Point(739, 89);
            this.removeSelectedPlayerButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.removeSelectedPlayerButton.Name = "removeSelectedPlayerButton";
            this.removeSelectedPlayerButton.Size = new System.Drawing.Size(150, 40);
            this.removeSelectedPlayerButton.TabIndex = 15;
            this.removeSelectedPlayerButton.Text = "목록에서 제거";
            this.removeSelectedPlayerButton.UseVisualStyleBackColor = true;
            this.removeSelectedPlayerButton.Click += new System.EventHandler(this.removeSelectedPlayerButton_Click);
            // 
            // removePrizeButton
            // 
            this.removePrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.removePrizeButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.removePrizeButton.Location = new System.Drawing.Point(739, 389);
            this.removePrizeButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.removePrizeButton.Name = "removePrizeButton";
            this.removePrizeButton.Size = new System.Drawing.Size(150, 40);
            this.removePrizeButton.TabIndex = 16;
            this.removePrizeButton.Text = "목록에서 제거";
            this.removePrizeButton.UseVisualStyleBackColor = true;
            this.removePrizeButton.Click += new System.EventHandler(this.removePrizeButton_Click);
            // 
            // createTeamButton
            // 
            this.createTeamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createTeamButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.createTeamButton.Location = new System.Drawing.Point(36, 417);
            this.createTeamButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(171, 46);
            this.createTeamButton.TabIndex = 17;
            this.createTeamButton.Text = "팀 생성";
            this.createTeamButton.UseVisualStyleBackColor = true;
            this.createTeamButton.Click += new System.EventHandler(this.createTeamButton_Click);
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(928, 657);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.removePrizeButton);
            this.Controls.Add(this.removeSelectedPlayerButton);
            this.Controls.Add(this.prizesListBox);
            this.Controls.Add(this.tournamentTeamsListBox);
            this.Controls.Add(this.createTournamentButton);
            this.Controls.Add(this.prizesLabel);
            this.Controls.Add(this.teamsAndPlayersLabel);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.addTeamButton);
            this.Controls.Add(this.selectTeamDropDown);
            this.Controls.Add(this.entryFeeValue);
            this.Controls.Add(this.selectTeamLabel);
            this.Controls.Add(this.entryFeeLabel);
            this.Controls.Add(this.tournamentNameValue);
            this.Controls.Add(this.tournamentNameLabel);
            this.Controls.Add(this.createTournamentLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "CreateTournamentForm";
            this.Text = "Create A Tournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createTournamentLabel;
        private System.Windows.Forms.Label tournamentNameLabel;
        private System.Windows.Forms.TextBox tournamentNameValue;
        private System.Windows.Forms.Label entryFeeLabel;
        private System.Windows.Forms.Label selectTeamLabel;
        private System.Windows.Forms.TextBox entryFeeValue;
        private System.Windows.Forms.ComboBox selectTeamDropDown;
        private System.Windows.Forms.Button addTeamButton;
        private System.Windows.Forms.Button createPrizeButton;
        private System.Windows.Forms.Label teamsAndPlayersLabel;
        private System.Windows.Forms.Label prizesLabel;
        private System.Windows.Forms.Button createTournamentButton;
        private System.Windows.Forms.ListBox tournamentTeamsListBox;
        private System.Windows.Forms.ListBox prizesListBox;
        private System.Windows.Forms.Button removeSelectedPlayerButton;
        private System.Windows.Forms.Button removePrizeButton;
        private System.Windows.Forms.Button createTeamButton;
    }
}