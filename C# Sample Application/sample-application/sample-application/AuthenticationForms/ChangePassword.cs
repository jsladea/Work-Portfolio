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
using static sampleApp.Presenters.ChangePasswordPresenter;

namespace sampleApp.AuthenticationForms
{
    public partial class ChangePassword : Form, IChangePasswordView
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        public ChangePasswordPresenter Presenter { set; private get; }
        public string FirstQuestion {
            set
            {
                firstSecurityQuestionLbl.Text = value;
            }
        }
        public string SecondQuestion {
            set
            {
                secondSecurityQuestionLbl.Text = value;
            }
        }

        public string Username { get; private set; }

        public string FirstAnswer => firstAnswerBox.Text;

        public string SecondAnswer => secondAnswerBox.Text;

        public string Password => passwordBox.Text;

        private async void submitBtn_Click(object sender, EventArgs e)
        {
            if (InputsAreValid())
            {
                ChangePasswordResult result = await Presenter.ChangePassword();
                if (result == ChangePasswordResult.IncorrectAnswer)
                    MessageBox.Show("Incorrect answer to one or both security questions.", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (result == ChangePasswordResult.Error)
                    MessageBox.Show("An error occurred while attempting to change your password.  Please try again and contact the IT department if the error persists",
                        "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if(result == ChangePasswordResult.Success)
                {
                    this.Close(); //close the form
                }
            }
            else
            {
                MessageBox.Show("Invalid inputs. Please make sure all fields are filled and that the passwords match.", "User Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool InputsAreValid()
        {
            return !string.IsNullOrWhiteSpace(firstAnswerBox.Text) && !string.IsNullOrWhiteSpace(secondAnswerBox.Text) && !string.IsNullOrWhiteSpace(passwordBox.Text) && passwordBox.Text.Equals(confirmPasswordBox.Text);
        }

        private void ChangePassword_Shown(object sender, EventArgs e)
        {
            mainLayoutPanel.Hide();
            GetUsernameControl usernameEntry = new GetUsernameControl();
            usernameEntry.VisibleChanged += new System.EventHandler(async (object eventSender, EventArgs eventArgs) =>
            {
                Username = usernameEntry.Username;
                mainLayoutPanel.Show();
                await Presenter.InitializeQuestions();
            });

            this.Controls.Add(usernameEntry);
            usernameEntry.Show();
        }
    }
}
