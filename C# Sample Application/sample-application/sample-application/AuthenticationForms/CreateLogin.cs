using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sampleApp.Presenters;
using sampleApp.Views;

namespace sampleApp.AuthenticationForms
{
    public partial class CreateLogin : Form, ICreateLoginView
    {
        public CreateLogin(bool updateExistingLogin)
        {
            InitializeComponent();
            UpdateExistingLogin = updateExistingLogin;
            if (UpdateExistingLogin)
            {
                LoadUpdateLayout();
            }
        }

        public CreateLogin()
        {
            InitializeComponent();
            UpdateExistingLogin = false;
        }

        public CreateLoginPresenter Presenter { set; private get; }

        public bool UpdateExistingLogin { private set; get; }

        public string Username => usernameBox.Text;

        public string TempPassword => tempPasswordBox.Text;

        public string Password => passwordBox.Text;

        public string ConfirmPassword => confirmPasswordBox.Text;

        public string FirstQuestion => questionBoxOne.GetItemText(questionBoxOne.SelectedItem);

        public string SecondQuestion => questionBoxTwo.GetItemText(questionBoxTwo.SelectedItem);

        public string FirstAnswer => answerBoxOne.Text;

        public string SecondAnswer => answerBoxTwo.Text;

        public void LoadSecurityQuestions(string[] securityQuestions)
        {
            questionBoxOne.Items.AddRange(securityQuestions);
            questionBoxTwo.Items.AddRange(securityQuestions);
        }

        private void LoadUpdateLayout()
        {
            usernameLbl.Text = "Enter Username:";
            updateFlowPanel.Show();
            headerLbl.Text = "Update Login";
            passwordLbl.Text = "Enter New Password";
            createBtn.Text = "Update Login";
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            string inputValidationMessage = await Presenter.InputsAreValid();
            if (inputValidationMessage.Equals("true"))
            {
                await Presenter.CreateLogin();
                ClearInputs();
            }
            else
                MessageBox.Show(inputValidationMessage, "Invalid Input");
        }

        private async void CreateLogin_Shown(object sender, EventArgs e)
        {
            string[] questions = await Presenter.GetSecurityQuestions();
            questionBoxOne.Items.AddRange(questions);
            questionBoxTwo.Items.AddRange(questions);
        }

        private void ClearInputs()
        {
            usernameBox.Text = "";
            tempPasswordBox.Text = "";
            passwordBox.Text = "";
            confirmPasswordBox.Text = "";
            questionBoxOne.SelectedIndex = -1;
            questionBoxTwo.SelectedIndex = -1;
            answerBoxOne.Text = "";
            answerBoxTwo.Text = "";
        }

    }
}
