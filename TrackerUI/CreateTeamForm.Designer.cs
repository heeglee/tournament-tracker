namespace TrackerUI
{
    partial class CreateTeamForm
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
            this.createTeamLabel = new System.Windows.Forms.Label();
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.selectTeamMemberLabel = new System.Windows.Forms.Label();
            this.teamNameValue = new System.Windows.Forms.TextBox();
            this.selectTeamMemberDropDown = new System.Windows.Forms.ComboBox();
            this.addMemberButton = new System.Windows.Forms.Button();
            this.memberNameLabel = new System.Windows.Forms.Label();
            this.memberEmailLabel = new System.Windows.Forms.Label();
            this.memberPhoneLabel = new System.Windows.Forms.Label();
            this.createMemberButton = new System.Windows.Forms.Button();
            this.nameValue = new System.Windows.Forms.TextBox();
            this.emailValue = new System.Windows.Forms.TextBox();
            this.phoneValue = new System.Windows.Forms.TextBox();
            this.teamMembersListBox = new System.Windows.Forms.ListBox();
            this.deleteTeamMemberButton = new System.Windows.Forms.Button();
            this.createTeamButton = new System.Windows.Forms.Button();
            this.addNewMemberGroupBox = new System.Windows.Forms.GroupBox();
            this.addNewMemberGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // createTeamLabel
            // 
            this.createTeamLabel.AutoSize = true;
            this.createTeamLabel.Font = new System.Drawing.Font("나눔고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.createTeamLabel.Location = new System.Drawing.Point(14, 21);
            this.createTeamLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.createTeamLabel.Name = "createTeamLabel";
            this.createTeamLabel.Size = new System.Drawing.Size(114, 36);
            this.createTeamLabel.TabIndex = 0;
            this.createTeamLabel.Text = "팀 생성";
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.teamNameLabel.Location = new System.Drawing.Point(17, 80);
            this.teamNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(50, 24);
            this.teamNameLabel.TabIndex = 1;
            this.teamNameLabel.Text = "팀명";
            // 
            // selectTeamMemberLabel
            // 
            this.selectTeamMemberLabel.AutoSize = true;
            this.selectTeamMemberLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.selectTeamMemberLabel.Location = new System.Drawing.Point(17, 170);
            this.selectTeamMemberLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.selectTeamMemberLabel.Name = "selectTeamMemberLabel";
            this.selectTeamMemberLabel.Size = new System.Drawing.Size(96, 24);
            this.selectTeamMemberLabel.TabIndex = 2;
            this.selectTeamMemberLabel.Text = "팀원 선택";
            // 
            // teamNameValue
            // 
            this.teamNameValue.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.teamNameValue.Location = new System.Drawing.Point(22, 118);
            this.teamNameValue.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.teamNameValue.Name = "teamNameValue";
            this.teamNameValue.Size = new System.Drawing.Size(293, 32);
            this.teamNameValue.TabIndex = 3;
            // 
            // selectTeamMemberDropDown
            // 
            this.selectTeamMemberDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectTeamMemberDropDown.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.selectTeamMemberDropDown.FormattingEnabled = true;
            this.selectTeamMemberDropDown.Location = new System.Drawing.Point(22, 208);
            this.selectTeamMemberDropDown.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.selectTeamMemberDropDown.Name = "selectTeamMemberDropDown";
            this.selectTeamMemberDropDown.Size = new System.Drawing.Size(293, 32);
            this.selectTeamMemberDropDown.TabIndex = 4;
            // 
            // addMemberButton
            // 
            this.addMemberButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addMemberButton.Location = new System.Drawing.Point(92, 262);
            this.addMemberButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.addMemberButton.Name = "addMemberButton";
            this.addMemberButton.Size = new System.Drawing.Size(155, 41);
            this.addMemberButton.TabIndex = 5;
            this.addMemberButton.Text = "팀원 추가";
            this.addMemberButton.UseVisualStyleBackColor = true;
            this.addMemberButton.Click += new System.EventHandler(this.addMemberButton_Click);
            // 
            // memberNameLabel
            // 
            this.memberNameLabel.AutoSize = true;
            this.memberNameLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memberNameLabel.Location = new System.Drawing.Point(10, 50);
            this.memberNameLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.memberNameLabel.Name = "memberNameLabel";
            this.memberNameLabel.Size = new System.Drawing.Size(50, 24);
            this.memberNameLabel.TabIndex = 7;
            this.memberNameLabel.Text = "이름";
            // 
            // memberEmailLabel
            // 
            this.memberEmailLabel.AutoSize = true;
            this.memberEmailLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memberEmailLabel.Location = new System.Drawing.Point(10, 92);
            this.memberEmailLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.memberEmailLabel.Name = "memberEmailLabel";
            this.memberEmailLabel.Size = new System.Drawing.Size(70, 24);
            this.memberEmailLabel.TabIndex = 8;
            this.memberEmailLabel.Text = "E-mail";
            // 
            // memberPhoneLabel
            // 
            this.memberPhoneLabel.AutoSize = true;
            this.memberPhoneLabel.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memberPhoneLabel.Location = new System.Drawing.Point(10, 134);
            this.memberPhoneLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.memberPhoneLabel.Name = "memberPhoneLabel";
            this.memberPhoneLabel.Size = new System.Drawing.Size(50, 24);
            this.memberPhoneLabel.TabIndex = 9;
            this.memberPhoneLabel.Text = "전화";
            // 
            // createMemberButton
            // 
            this.createMemberButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.createMemberButton.Location = new System.Drawing.Point(43, 182);
            this.createMemberButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.createMemberButton.Name = "createMemberButton";
            this.createMemberButton.Size = new System.Drawing.Size(204, 46);
            this.createMemberButton.TabIndex = 10;
            this.createMemberButton.Text = "팀원 생성";
            this.createMemberButton.UseVisualStyleBackColor = true;
            this.createMemberButton.Click += new System.EventHandler(this.createMemberButton_Click);
            // 
            // nameValue
            // 
            this.nameValue.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameValue.Location = new System.Drawing.Point(89, 47);
            this.nameValue.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.nameValue.Name = "nameValue";
            this.nameValue.Size = new System.Drawing.Size(194, 32);
            this.nameValue.TabIndex = 11;
            // 
            // emailValue
            // 
            this.emailValue.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.emailValue.Location = new System.Drawing.Point(89, 89);
            this.emailValue.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.emailValue.Name = "emailValue";
            this.emailValue.Size = new System.Drawing.Size(194, 32);
            this.emailValue.TabIndex = 12;
            // 
            // phoneValue
            // 
            this.phoneValue.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.phoneValue.Location = new System.Drawing.Point(89, 131);
            this.phoneValue.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.phoneValue.Name = "phoneValue";
            this.phoneValue.Size = new System.Drawing.Size(194, 32);
            this.phoneValue.TabIndex = 13;
            // 
            // teamMembersListBox
            // 
            this.teamMembersListBox.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.teamMembersListBox.FormattingEnabled = true;
            this.teamMembersListBox.ItemHeight = 24;
            this.teamMembersListBox.Location = new System.Drawing.Point(401, 118);
            this.teamMembersListBox.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.teamMembersListBox.Name = "teamMembersListBox";
            this.teamMembersListBox.Size = new System.Drawing.Size(293, 388);
            this.teamMembersListBox.TabIndex = 14;
            // 
            // deleteTeamMemberButton
            // 
            this.deleteTeamMemberButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deleteTeamMemberButton.Location = new System.Drawing.Point(544, 524);
            this.deleteTeamMemberButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.deleteTeamMemberButton.Name = "deleteTeamMemberButton";
            this.deleteTeamMemberButton.Size = new System.Drawing.Size(150, 40);
            this.deleteTeamMemberButton.TabIndex = 15;
            this.deleteTeamMemberButton.Text = "목록에서 제거";
            this.deleteTeamMemberButton.UseVisualStyleBackColor = true;
            this.deleteTeamMemberButton.Click += new System.EventHandler(this.deleteTeamMemberButton_Click);
            // 
            // createTeamButton
            // 
            this.createTeamButton.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.createTeamButton.Location = new System.Drawing.Point(247, 604);
            this.createTeamButton.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.createTeamButton.Name = "createTeamButton";
            this.createTeamButton.Size = new System.Drawing.Size(261, 62);
            this.createTeamButton.TabIndex = 16;
            this.createTeamButton.Text = "팀 생성";
            this.createTeamButton.UseVisualStyleBackColor = true;
            this.createTeamButton.Click += new System.EventHandler(this.createTeamButton_Click);
            // 
            // addNewMemberGroupBox
            // 
            this.addNewMemberGroupBox.Controls.Add(this.nameValue);
            this.addNewMemberGroupBox.Controls.Add(this.memberNameLabel);
            this.addNewMemberGroupBox.Controls.Add(this.memberEmailLabel);
            this.addNewMemberGroupBox.Controls.Add(this.memberPhoneLabel);
            this.addNewMemberGroupBox.Controls.Add(this.createMemberButton);
            this.addNewMemberGroupBox.Controls.Add(this.phoneValue);
            this.addNewMemberGroupBox.Controls.Add(this.emailValue);
            this.addNewMemberGroupBox.Font = new System.Drawing.Font("나눔고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addNewMemberGroupBox.Location = new System.Drawing.Point(22, 336);
            this.addNewMemberGroupBox.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.addNewMemberGroupBox.Name = "addNewMemberGroupBox";
            this.addNewMemberGroupBox.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.addNewMemberGroupBox.Size = new System.Drawing.Size(293, 252);
            this.addNewMemberGroupBox.TabIndex = 17;
            this.addNewMemberGroupBox.TabStop = false;
            this.addNewMemberGroupBox.Text = "새 팀원 생성";
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(849, 677);
            this.Controls.Add(this.addNewMemberGroupBox);
            this.Controls.Add(this.createTeamButton);
            this.Controls.Add(this.deleteTeamMemberButton);
            this.Controls.Add(this.teamMembersListBox);
            this.Controls.Add(this.addMemberButton);
            this.Controls.Add(this.selectTeamMemberDropDown);
            this.Controls.Add(this.teamNameValue);
            this.Controls.Add(this.selectTeamMemberLabel);
            this.Controls.Add(this.teamNameLabel);
            this.Controls.Add(this.createTeamLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "CreateTeamForm";
            this.Text = "Create Team";
            this.addNewMemberGroupBox.ResumeLayout(false);
            this.addNewMemberGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createTeamLabel;
        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.Label selectTeamMemberLabel;
        private System.Windows.Forms.TextBox teamNameValue;
        private System.Windows.Forms.ComboBox selectTeamMemberDropDown;
        private System.Windows.Forms.Button addMemberButton;
        private System.Windows.Forms.Label memberNameLabel;
        private System.Windows.Forms.Label memberEmailLabel;
        private System.Windows.Forms.Label memberPhoneLabel;
        private System.Windows.Forms.Button createMemberButton;
        private System.Windows.Forms.TextBox nameValue;
        private System.Windows.Forms.TextBox emailValue;
        private System.Windows.Forms.TextBox phoneValue;
        private System.Windows.Forms.ListBox teamMembersListBox;
        private System.Windows.Forms.Button deleteTeamMemberButton;
        private System.Windows.Forms.Button createTeamButton;
        private System.Windows.Forms.GroupBox addNewMemberGroupBox;
    }
}